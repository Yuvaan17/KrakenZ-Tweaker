using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace KrakenZ_Tweaker.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl4.xaml
    /// </summary>
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
        }


        private void Optimize_Registry_Click(object sender, RoutedEventArgs e)
        {
            if (Optimize_Registry.IsChecked == true)
            {
                try
                {
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", true))
                    {
                        key.CreateSubKey("NetworkThrottlingIndex");
                        key.SetValue("NetworkThrottlingIndex", "0ffffffff", RegistryValueKind.DWord);
                        key.CreateSubKey("SystemResponsiveness");
                        key.SetValue("SystemResponsiveness", "dword:00000000");
                        key.CreateSubKey("NoLazyMode");
                        key.SetValue("NoLazyMode", "1");
                    }
                }
                catch (Exception) { MessageBox.Show("Failed"); }

                try
                {
                    using (RegistryKey key1 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop"))
                    {
                        key1.CreateSubKey("MenuShowDelay");
                        key1.SetValue("MenuShowDelay", "0");
                        key1.CreateSubKey("WaitToKillAppTimeout");
                        key1.SetValue("WaitToKillAppTimeout", "5000");
                        key1.CreateSubKey("HungAppTimeout");
                        key1.SetValue("HungAppTimeout", "4000");
                        key1.CreateSubKey("AutoEndTasks");
                        key1.SetValue("AutoEndTasks", "1");
                        key1.CreateSubKey("LowLevelHooksTimeout");
                        key1.SetValue("LowLevelHooksTimeout", "dword:00001000");
                        key1.CreateSubKey("WaitToKillServiceTimeout");
                        key1.SetValue("WaitToKillServiceTimeout", "00002000");
                    }
                }
                catch (Exception) { MessageBox.Show("Failed"); }
              
                try
                {
                    using (RegistryKey key2 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management"))
                    {
                        key2.CreateSubKey("LargeSystemCache");
                        key2.SetValue("LargeSystemCache", "0");
                    }
                }
                catch (Exception) { }
                try
                {
                    using (RegistryKey key3 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Power"))
                    {
                        key3.CreateSubKey("HyperBootEnabled");
                        key3.SetValue("HyperBootEnabled", "0");
                    }
                }
                catch (Exception) { MessageBox.Show("Failed"); }
            }
            else
            {

            }

        }
    }
}
