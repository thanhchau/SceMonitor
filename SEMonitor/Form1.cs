using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using static System.Windows.Forms.LinkLabel;
using System.Drawing.Imaging;
using System.Xml.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace SEMonitor
{

    public partial class Form1 : Form
    {
        private static HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String ip = (String)textBox1.Text;
            if (ip.Trim() != "")
            {
                lstip.Items.Add(ip);
            }
            textBox1.Text = "";
            String mcname = (String)txtmachinename.Text;
            if (mcname.Trim() != "")
            {
                listBoxName.Items.Add(mcname);
            }
            txtmachinename.Text = "";
        }
        List<Machine> listipw2 = new List<Machine>();
        private void button4_Click(object sender, EventArgs e)
        {
            txtmachinename.Enabled = false;
            textBox1.Enabled = false;
            txtDb.Enabled = false;
            button4.Enabled = false;
            int i = 1;
            foreach (string x in lstmapped.Items)
            {
                Machine m = new Machine();
                m.name = i;
                m.ip = x;
                listipw2.Add(m);
                i++;
            }
            triggerEventOls.Start();
        }

        private async void triggerEventOls_Tick(object sender, EventArgs e)
        {
            string pathtToRead = "";
            foreach (Machine line in listipw2)
            {
                pathtToRead = @"\\" + line.ip + @"\Pictures\OnlineRecording" + @"\" + DateTime.Now.Year.ToString() + @"\" + DateTime.Now.Month.ToString().PadLeft(2, '0') + @"\" + DateTime.Today.Day.ToString().PadLeft(2, '0');
                try
                {
                    //await exporttoSe(pathtToRead, line.name);
                    //await Task.Run(exporttoSe(pathtToRead, line.name));
                    await Task.Run(() => exporttoSe(pathtToRead, line.name));
                }
                catch (Exception ex)
                {
                    var str = ex.Message.Substring(5, 7);
                    var str2 = ex.Message.Substring(0, 6);

                    if (str.CompareTo("process") != 0 && str2.CompareTo("Could") != 0)
                    {
                        //WriteLog(ex.Message.ToString());
                        char c;
                    }
                    else
                    {
                        //WriteLog(ex.Message.ToString());
                    }

                }
            }


        }
        async Task exporttoSe(string pathtToRead, int i)
        {
            var directory = new DirectoryInfo(pathtToRead);
            string MyBatchFile = @"execute.bat";
            string lastwrite = "no";
            string machineName = "";
            //machineName += "may" + i.ToString();
            machineName = "may"+listBoxName.Items[i - 1].ToString();
            string copyto = @"E:\alldata\" + machineName + @"\" + DateTime.Now.Year.ToString() + @"\" + DateTime.Now.Month.ToString().PadLeft(2, '0') + @"\" + DateTime.Today.Day.ToString().PadLeft(2, '0');
            if (!Directory.Exists(copyto))
            {
                Directory.CreateDirectory(copyto);
            }
            if (!Directory.Exists(copyto + @"\export"))
            {
                Directory.CreateDirectory(copyto + @"\export");
            }
            lastwrite = await getLastWrite(machineName);
            if (directory.GetFileSystemInfos().Length != 0)
            {
                var myFile = directory.GetFiles()
               .OrderByDescending(f => f.LastWriteTime)
               .First();
                if (myFile != null)
                {
                    if (lastwrite != myFile.Name)
                    {
                        //Console.WriteLine(myFile.FullName);
                        System.IO.File.Copy(myFile.FullName, copyto + @"\" + myFile.Name, true);
                        var process = new Process
                        {
                            StartInfo = {
                         Arguments = String.Format("\"{0}\" \"{1}\"", copyto+@"\"+myFile.Name, copyto+@"\export\"+myFile.Name+".tif")
                                        }
                        };
                        process.StartInfo.FileName = MyBatchFile;
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        if (!IsFileLocked(new FileInfo(copyto + @"\" + myFile.Name)))
                        {
                            process.Start();
                            //convert
                            if (myFile.Name != "log.txt")
                            {
                                string fileTiff = copyto + @"\export\" + myFile.Name + ".tif";
                                string name1 = myFile.Name.Substring(0, myFile.Name.Length - 4);
                                string fileTiff1 = copyto + @"\export\" + name1 + "_1.hif.tif";
                                string[] pathnameNewjpg = ConvertTiffToJpeg(fileTiff);
                                string[] pathnameNewjpg1 = ConvertTiffToJpeg(fileTiff1);
                                //-------------------Add New Record To DB
                                //var url = "https://661e254198427bbbef038972.mockapi.io/baggage";
                                try
                                {
                                    var url = txtDb.Text;
                                    var data = new Baggage() { fileName = myFile.Name + "0.jpg", machineName = machineName };
                                    var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                                    var requestContent = new StringContent(jsonData, Encoding.Unicode, "application/json");
                                    var response = await client.PostAsync(url, requestContent);
                                    var data1 = new Baggage() { fileName = name1 + "_1.hif0.jpg", machineName = machineName };
                                    var jsonData1 = Newtonsoft.Json.JsonConvert.SerializeObject(data1);
                                    var requestContent1 = new StringContent(jsonData1, Encoding.Unicode, "application/json");
                                    var response1 = await client.PostAsync(url, requestContent1);
                                }
                                catch (Exception ex)
                                {
                                    WriteLog("Warning: Database Error plese Check!!!!!");
                                }

                                //------------------End Add New Record To Database
                            }

                            //end convert
                            WriteLog(DateTime.Now.ToString() + " ---- Copy " + myFile.Name + " to >> " + copyto);
                        }

                        //WriteLog(" copy " + myFile.Name+" to "+copyto);
                       
                        try
                        {
                            StreamWriter sw = new StreamWriter(machineName + ".txt");
                            sw.WriteLine(myFile.Name);
                            sw.Close();
                            lastwrite = myFile.Name;
                        }
                        catch (Exception ex)
                        {
                            //WriteLog(ex.ToString());
                            char cs;
                        }
                    }
                    else
                    {
                        //Console.WriteLine("Wait For Change!!!!");
                    }
                }
            }
            else
            {
                StreamWriter sw = new StreamWriter(pathtToRead + "\\log.txt");
                sw.WriteLine("Log Begin----------------");
                sw.Close();
            }
            //await Task.Yield();
        }
        async Task<string> getLastWrite(string lastwriteFile)
        {
            string lastwrite = "no";
            string filename = lastwriteFile + ".txt";
            try
            {
                if (File.Exists(filename))
                {
                    lastwrite = File.ReadAllText(filename);
                    lastwrite = lastwrite.Replace("\r\n", " ");
                    lastwrite = lastwrite.Trim();
                }
                else
                {

                    using (FileStream fs = File.Create(filename))
                    {
                        // Add some text to file
                        Byte[] title = new UTF8Encoding(true).GetBytes("");
                        fs.Write(title, 0, title.Length);

                    }
                }

            }
            catch(Exception ex)
            {
                return "no";
            }
         
            return lastwrite;
        }
        void WriteLog(string text)
        {
            if (txtlog.Lines.Length == 200)
            {
                txtlog.Text = "";
            }
            txtlog.Invoke((Action)delegate
            {
                txtlog.AppendText(text);
                txtlog.AppendText(Environment.NewLine); ;
            });

        }
        void WriteLog2(string text)
        {
            if (txtlog2.Lines.Length == 200)
            {
                txtlog2.Text = "";
            }
            txtlog2.Invoke((Action)delegate
            {
                txtlog2.AppendText(text);
                txtlog2.AppendText(Environment.NewLine); ;
            });

        }

        private void txtlog_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lstip.Items.Clear();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            await Task.Run(() => LoadLstMap());

            progressBar1.Visible = false;

        }
        private void LoadLstMap()
        {
            foreach (string x in lstip.Items)
            {
                if (isValidConnection(x))
                {

                    //lstmapped.Items.Add(x);
                    lstmapped.Invoke((Action)delegate
                    {
                        lstmapped.Items.Add(x);
                    });
                }
                else
                {
                    MessageBox.Show(x + " connect Fail");
                }
            }
        }

        private bool isValidConnection(string url)
        {
            try
            {
                string p = @"\\" + url + @"\Pictures";
                if (Directory.Exists(p))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            lstmapped.Items.Clear();
        }
        public static string[] ConvertTiffToJpeg(string fileName)
        {
            using (Image imageFile = Image.FromFile(fileName))
            {
                FrameDimension frameDimensions = new FrameDimension(
                    imageFile.FrameDimensionsList[0]);

                // Gets the number of pages from the tiff image (if multipage) 
                int frameNum = imageFile.GetFrameCount(frameDimensions);
                string[] jpegPaths = new string[frameNum];

                for (int frame = 0; frame < frameNum; frame++)
                {
                    // Selects one frame at a time and save as jpeg. 
                    imageFile.SelectActiveFrame(frameDimensions, frame);
                    using (Bitmap bmp = new Bitmap(imageFile))
                    {
                        jpegPaths[frame] = String.Format("{0}\\{1}{2}.jpg",
                            Path.GetDirectoryName(fileName),
                            Path.GetFileNameWithoutExtension(fileName),
                            frame);
                        bmp.Save(jpegPaths[frame], ImageFormat.Jpeg);
                    }
                }

                return jpegPaths;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            ClbtriggerEventOls.Start();
        }

        private async void ClbtriggerEventOls_Tick(object sender, EventArgs e)
        {
            string pathtToRead = "";
            foreach (Machine line in listipw2)
            {
                pathtToRead = @"\\" + line.ip + @"\Pictures\Clipboard" + @"\" + DateTime.Now.Year.ToString() + @"\" + DateTime.Now.Month.ToString().PadLeft(2, '0') + @"\" + DateTime.Today.Day.ToString().PadLeft(2, '0');
                try
                {
                    //await exporttoSe(pathtToRead, line.name);
                    //await Task.Run(exporttoSe(pathtToRead, line.name));
                    await Task.Run(() => exporttoSe2(pathtToRead, line.name));
                }
                catch (Exception ex)
                {
                    var str = ex.Message.Substring(10, 4);
                    if (str.CompareTo("find") != 0)
                    {
                        //WriteLog2(ex.Message.ToString());
                    }
                    //break;


                }
            }
        }
        async Task exporttoSe2(string pathtToRead, int i)
        {
            var directory = new DirectoryInfo(pathtToRead);
            string MyBatchFile = @"execute.bat";
            string lastwrite = "no";
            string machineName = "";
            string machineName1 = "";
            machineName = "machine"+ listBoxName.Items[i-1].ToString();
            machineName1 = "may" + listBoxName.Items[i - 1].ToString();
            string copyto = @"E:\alldata\Clipboard\" + machineName + @"\" + DateTime.Now.Year.ToString() + @"\" + DateTime.Now.Month.ToString().PadLeft(2, '0') + @"\" + DateTime.Today.Day.ToString().PadLeft(2, '0');
            if (!Directory.Exists(copyto))
            {
                Directory.CreateDirectory(copyto);
            }
            if (!Directory.Exists(copyto + @"\export"))
            {
                Directory.CreateDirectory(copyto + @"\export");
            }
            lastwrite = await getLastWrite(machineName);
            if (directory.GetFileSystemInfos().Length != 0)
            {
                var myFile = directory.GetFiles()
               .OrderByDescending(f => f.LastWriteTime)
               .First();
                if (myFile != null)
                {
                    if (lastwrite != myFile.Name)
                    {
                        //Console.WriteLine(myFile.FullName);
                        System.IO.File.Copy(myFile.FullName, copyto + @"\" + myFile.Name, true);
                        var process = new Process
                        {
                            StartInfo = {
                         Arguments = String.Format("\"{0}\" \"{1}\"", copyto+@"\"+myFile.Name, copyto+@"\export\"+myFile.Name+".tif")
                                        }
                        };
                        process.StartInfo.FileName = MyBatchFile;
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        if (!IsFileLocked(new FileInfo(copyto + @"\" + myFile.Name)))
                        {
                            process.Start();
                            //convert
                            if (myFile.Name != "log.txt")
                            {
                                string fileTiff = copyto + @"\export\" + myFile.Name + ".tif";
                                string name1 = myFile.Name.Substring(0, myFile.Name.Length - 4);
                                string fileTiff1 = copyto + @"\export\" + name1 + "_1.hif.tif";
                                string[] pathnameNewjpg = ConvertTiffToJpeg(fileTiff);
                                string[] pathnameNewjpg1 = ConvertTiffToJpeg(fileTiff1);
                                /*//-------------------Add New Record To DB
                                *//*var url = "https://661e254198427bbbef038972.mockapi.io/baggage";*/
                                try
                                {
                                    var url = txtDb.Text;
                                    var data = new Baggage() { fileName = myFile.Name + "0.jpg", machineName = machineName1, Clipboard = true };
                                    var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                                    var requestContent = new StringContent(jsonData, Encoding.Unicode, "application/json");
                                    var response = await client.PostAsync(url, requestContent);
                                    var data1 = new Baggage() { fileName = name1 + "_1.hif0.jpg", machineName = machineName1, Clipboard = true };
                                    var jsonData1 = Newtonsoft.Json.JsonConvert.SerializeObject(data1);
                                    var requestContent1 = new StringContent(jsonData1, Encoding.Unicode, "application/json");
                                    var response1 = await client.PostAsync(url, requestContent1);
                                }
                                catch (Exception ex)
                                {
                                    WriteLog2("Warning: Database Error plese Check!!!!!");
                                }

                                //------------------End Add New Record To Database
                            }
                            WriteLog2(DateTime.Now.ToString() + " ---- Copy " + myFile.Name + " to >> " + copyto);
                            //end convert
                        }


                        //WriteLog(" copy " + myFile.Name+" to "+copyto);
                        
                        try
                        {
                            StreamWriter sw = new StreamWriter(machineName + ".txt");
                            sw.WriteLine(myFile.Name);
                            sw.Close();
                            lastwrite = myFile.Name;
                        }
                        catch (Exception ex)
                        {
                            //WriteLog2(ex.ToString());
                            char cs2;
                        }
                    }
                    else
                    {
                        //Console.WriteLine("Wait For Change!!!!");
                    }
                }
            }
            else
            {
                StreamWriter sw = new StreamWriter(pathtToRead + "\\log.txt");
                sw.WriteLine("Log Begin----------------");
                sw.Close();
            }
            //await Task.Yield();
        }
        protected virtual bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
