using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;


namespace KrakenZ_Tweaker.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
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

        private void Restore_Point_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Creating a restore Point! Please be patient wait for the confirmation message and don't close the app before it. This process will take a few minutes to complete.");
            ExecuteCommand(@"wmic.exe /Namespace:\\root\default Path SystemRestore Call CreateRestorePoint ""KrakenZ Tweaker Restore Point"", 100, 7");
            MessageBox.Show("Restore Point was created Succesfully!");

        }

        private void Revert_Restore_Point_Click(object sender, RoutedEventArgs e)
        {
            Wow64Interop.EnableWow64FSRedirection(false);
            ExecuteCommand("rstrui.exe");
        }




    }
    public class Wow64Interop
    {
        [DllImport("Kernel32.Dll", EntryPoint = "Wow64EnableWow64FsRedirection")]
        public static extern bool EnableWow64FSRedirection(bool enable);
    }
}

