using System;
using System.Diagnostics;
using System.Windows;
using System.Reflection;
using System.Security.Principal;
using KrakenZ_Tweaker.UserControls;

namespace KrakenZ_Tweaker
{

    public partial class MainWindow : Window
    {
        private void AdminRelauncher()
        {


            if (!IsRunAsAdmin())
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = Assembly.GetEntryAssembly().Location.Replace(".dll", ".exe");

                proc.Verb = "runas";

                try
                {
                    Process.Start(proc);
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("This program must be run as an administrator! \n\n" + ex.ToString());
                }
            }

        }

        private bool IsRunAsAdmin()
        {
            try
            {
                WindowsIdentity id = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(id);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (Exception)
            {
                return false;
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            AdminRelauncher();




            Restore_Point.IsChecked = true;
            User_Control.Children.Add(defaultUC);



        }

        private readonly UserControl1 defaultUC = new UserControl1();
        private readonly UserControl2 UC2 = new UserControl2();
        private readonly UserControl3 UC3 = new UserControl3();
        private readonly UserControl4 UC4 = new UserControl4();
        private readonly UserControl5 UC5 = new UserControl5();



        private void Restore_Point_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User_Control.Children.Remove(UC2);
                User_Control.Children.Remove(UC3);
                User_Control.Children.Remove(UC4);
                User_Control.Children.Remove(UC5);
                User_Control.Children.Add(defaultUC);
            }
            catch(Exception)
            {

            }
        }

        private void Disable_Unnecessary_Services_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User_Control.Children.Remove(defaultUC);
                User_Control.Children.Remove(UC3);
                User_Control.Children.Remove(UC4);
                User_Control.Children.Remove(UC5);
                User_Control.Children.Add(UC2);
            }
            catch(Exception) { }
        }

        private void Clear_Junk_Files_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User_Control.Children.Remove(defaultUC);
                User_Control.Children.Remove(UC2);
                User_Control.Children.Remove(UC4);
                User_Control.Children.Remove(UC5);
                User_Control.Children.Add(UC3);
            }catch(Exception){ }
        }

        private void Useful_Optimization_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                User_Control.Children.Remove(defaultUC);
                User_Control.Children.Remove(UC2);
                User_Control.Children.Remove(UC3);
                User_Control.Children.Remove(UC5);
                User_Control.Children.Add(UC4);
            }
            catch (Exception) { }

        }

        private void Startup_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                User_Control.Children.Remove(defaultUC);
                User_Control.Children.Remove(UC2);
                User_Control.Children.Remove(UC3);
                User_Control.Children.Remove(UC4);
                User_Control.Children.Add(UC5);
            }
            catch (Exception) { }

        }

        private void YouTube_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://www.youtube.com/c/KrakenZYT";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });

        }

        private void Discord_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://discord.gg/Sea87E4e3X";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });

        }

        private void Website_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://www.krakenz.xyz";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });

        }

        private void Tutorial_Click(object sender, RoutedEventArgs e)
        {
            string url = "Youtube Video Url";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });

        }

        private void Support_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://www.krakenz.xyz/p/support-me.html";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });

        }
    }
}