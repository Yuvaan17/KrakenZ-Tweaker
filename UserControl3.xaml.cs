using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using System.Diagnostics;

namespace KrakenZ_Tweaker.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl3.xaml
    /// </summary>
    /// 
    public partial class UserControl3 : UserControl
    {
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }
        public UserControl3()
        {
            InitializeComponent();
        }

        private void Scan_Click(object sender, RoutedEventArgs e)

        {
            try
            {
                DirectoryInfo di2 = new DirectoryInfo(Environment.GetEnvironmentVariable("SystemRoot"));
                string path = Convert.ToString(di2);
                string path2 = path.Remove(3);
                DirectoryInfo di = new DirectoryInfo(path + @"\temp");
                DirectoryInfo di3 = new DirectoryInfo(path + @"\Prefetch");
                String myUserName = Environment.UserName;
                DirectoryInfo di4 = new DirectoryInfo(path2 + @"Users\" + myUserName + @"\AppData\Local\Temp");
                string x = Convert.ToString(di4);
                Junk_Files.Items.Clear();
                FileInfo[] files = di.GetFiles();
                DirectoryInfo[] dir = di.GetDirectories();
                FileInfo[] files2 = di3.GetFiles();
                DirectoryInfo[] dir2 = di3.GetDirectories();
                FileInfo[] files3 = di4.GetFiles();
                DirectoryInfo[] dir3 = di4.GetDirectories();


                foreach (FileInfo file in files)
                {
                    Junk_Files.Items.Add(file);
                }
                foreach (DirectoryInfo directory in dir)
                {
                    Junk_Files.Items.Add(directory);
                }

                foreach (FileInfo file in files2)
                {
                    Junk_Files.Items.Add(file);
                }
                foreach (DirectoryInfo directory in dir2)
                {
                    Junk_Files.Items.Add(directory);
                }
                foreach (FileInfo file in files3)
                {
                    Junk_Files.Items.Add(file);
                }
                foreach (DirectoryInfo directory in dir3)
                {
                    Junk_Files.Items.Add(directory);
                }
                string Size = Convert.ToString(di);
                string Size3 = Convert.ToString(di3);
                string Size4 = Convert.ToString(di4);
                float f2 = DirSize(new DirectoryInfo(Size3));
                float f3 = DirSize(new DirectoryInfo(Size4));

                float f = DirSize(new DirectoryInfo(Size));
                float Size2 = f / 1048576 + f2 / 1048576 + f3 / 1048576;
                String FinalSize = Convert.ToString(Math.Round(Size2, 1));
                Final.Text = "File size to be cleared: " + FinalSize + " MB";
                Final.Foreground = (Brush)(new BrushConverter().ConvertFrom("#ffffff"));

            }
            catch (Exception)
            {
                MessageBox.Show("The path is invalid. You can leave this step");
            }


        }



        private void Clear_Files_Click(object sender, RoutedEventArgs e)
        {
            if (Junk_Files.Items.Count > 0)
            {
                DirectoryInfo di2 = new DirectoryInfo(Environment.GetEnvironmentVariable("SystemRoot"));
                string path = Convert.ToString(di2);

                DirectoryInfo di = new DirectoryInfo(path + @"\temp");
                FileInfo[] files = di.GetFiles();
                DirectoryInfo[] dir = di.GetDirectories();
                DirectoryInfo di3 = new DirectoryInfo(path + @"\Prefetch");
                FileInfo[] files2 = di3.GetFiles();
                DirectoryInfo[] dir2 = di3.GetDirectories();
                String myUserName = Environment.UserName;
                string path2 = path.Remove(3);
                DirectoryInfo di4 = new DirectoryInfo(path2 + @"Users\" + myUserName + @"\AppData\Local\Temp");
                FileInfo[] files3 = di4.GetFiles();
                DirectoryInfo[] dir3 = di4.GetDirectories();
                foreach (FileInfo file in files)
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (Exception) { }
                }
                foreach (DirectoryInfo directory in dir)
                {
                    try
                    {
                        directory.Delete();
                    }

                    catch (Exception) { }
                }
                foreach (FileInfo file in files2)
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (Exception) { }
                }
                foreach (DirectoryInfo directory in dir2)
                {
                    try
                    {
                        directory.Delete();
                    }

                    catch (Exception) { }
                }
                foreach (FileInfo file in files3)
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (Exception) { }
                }
                foreach (DirectoryInfo directory in dir3)
                {
                    try
                    {
                        directory.Delete();
                    }

                    catch (Exception) { }
                }
                MessageBox.Show("All the junk files were deleted successfully");
                Junk_Files.Items.Clear();
                Final.Text = "File size to be cleared:";



            }
            else
            {
                MessageBox.Show("Kindly scan for the junk files first before clearing them.");
            }

        }
        public static string ExecuteCommand(string command)
        {

            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command)
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process proc = new Process())
            {
                proc.StartInfo = procStartInfo;
                proc.Start();

                string output = proc.StandardOutput.ReadToEnd();

                if (string.IsNullOrEmpty(output))
                    output = proc.StandardError.ReadToEnd();

                return output;
            }

        }

        private void CleanMGR_Click(object sender, RoutedEventArgs e)
        {
            Wow64Interop.EnableWow64FSRedirection(false);
            ExecuteCommand("cleanmgr.exe");

        }
    }
}
