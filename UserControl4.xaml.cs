using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (var rkey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", false))

            {
                uint a, b, c;


                if (rkey == null)
                {
                    a = 0; b = 0; c = 0;
                }
                else
                {
                    try
                    {
                        a = Convert.ToUInt32(rkey.GetValue("NetworkThrottlingIndex", RegistryValueKind.DWord));
                        b = Convert.ToUInt32(rkey.GetValue("SystemResponsiveness", RegistryValueKind.DWord));
                        c = Convert.ToUInt32(rkey.GetValue("NoLazyMode", RegistryValueKind.String));
                        if (a + b + c == 11)
                        {
                            Optimize_Registry.IsChecked = true;
                        }
                    }
                    catch (Exception)
                    {


                    }
                }

            }
            using (RegistryKey Key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"))
            {
                try
                {
                    uint a = Convert.ToUInt32(Key.GetValue("EnableLUA", RegistryValueKind.DWord));
                    if (a == 0)
                    {
                        Disable_UAC.IsChecked=true;
                    }
                }
                catch (Exception) { }
            }
            using (RegistryKey Key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\Au"))
            {
                uint a = Convert.ToUInt32(Key.GetValue("NoAutoUpdate", RegistryValueKind.DWord));
                if(a == 1)
                {
                    Disable_Updates.IsChecked = true;
                }

            }
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (var rkey = hklm.OpenSubKey(@"SYSTEM\ControlSet001\Control", false))

            {
                uint a;


                if (rkey == null)
                {
                    a = 0; 
                }
                else
                {
                    try
                    {
                        a = Convert.ToUInt32(rkey.GetValue("SvcHostSplitThresholdInKB", RegistryValueKind.DWord));
                        ulong x = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
                        ulong y = x / 1024;

                        if (a == y)
                        {
                            Optimize_Ram.IsChecked = true;
                        }
                    }
                    catch (Exception)
                    {


                    }
                }

            }

            string d = ExecuteCommand("Fsutil behavior query memoryusage");
                if (d == "MemoryUsage = 2")
                { Latency_Optimizations.IsChecked = true; }
          
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                using (RegistryKey key = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced"))
                {
                    uint x = Convert.ToUInt32(key.GetValue("ShowSyncProviderNotifications", RegistryValueKind.DWord));
                    
                        using (RegistryKey key2 = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"))
                        {
                            uint a = Convert.ToUInt32(key2.GetValue("FeatureManagementEnabled", RegistryValueKind.DWord));
                            uint b  = Convert.ToUInt32(key2.GetValue("OemPreInstalledAppsEnabled",  RegistryValueKind.DWord));
                            uint c = Convert.ToUInt32(key2.GetValue("PreInstalledAppsEnabled",  RegistryValueKind.DWord));
                            uint l = Convert.ToUInt32(key2.GetValue("PreInstalledAppsEverEnabled",  RegistryValueKind.DWord));
                            uint e = Convert.ToUInt32(key2.GetValue("RotatingLockScreenEnabled",  RegistryValueKind.DWord));
                            uint f = Convert.ToUInt32(key2.GetValue("RotatingLockScreenOverlayEnabled",  RegistryValueKind.DWord));
                            uint g = Convert.ToUInt32(key2.GetValue("SilentInstalledAppsEnabled",  RegistryValueKind.DWord));
                            uint h = Convert.ToUInt32(key2.GetValue("SoftLandingEnabled",  RegistryValueKind.DWord));
                            uint i = Convert.ToUInt32(key2.GetValue("SubscribedContent-310093Enabled", RegistryValueKind.DWord));
                            uint k = Convert.ToUInt32(key2.GetValue("SubscribedContent-338387Enabled", RegistryValueKind.DWord));
                            uint z = Convert.ToUInt32(key2.GetValue("SubscribedContent-338388Enabled",  RegistryValueKind.DWord));
                            uint s = Convert.ToUInt32(key2.GetValue("SubscribedContent-338389Enabled", RegistryValueKind.DWord));
                            uint v = Convert.ToUInt32(key2.GetValue("SubscribedContent-338393Enabled",  RegistryValueKind.DWord));
                            uint j = Convert.ToUInt32(key2.GetValue("SubscribedContent-353694Enabled",  RegistryValueKind.DWord));
                            uint q = Convert.ToUInt32(key2.GetValue("SubscribedContent-353696Enabled",  RegistryValueKind.DWord));
                            uint w = Convert.ToUInt32(key2.GetValue("SystemPaneSuggestionsEnabled",  RegistryValueKind.DWord));
                            if (a + b + c+l+e+f+g+h+i+k+z+s+v+j+q+w+x == 0)
                            {

                                Disable_Ads.IsChecked = true;

                            }
                        }
                  
                }
                
         
       

        }


        private void Optimize_Registry_Click(object sender, RoutedEventArgs e)
        {
            if (Optimize_Registry.IsChecked == true)
            {
                try
                {
                    using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                    using (var key = hklm.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", RegistryKeyPermissionCheck.ReadWriteSubTree))
                    {

                        key.CreateSubKey("NoLowDiskSpaceChecks");
                        key.SetValue("NoLowDiskSpaceChecks", 1, RegistryValueKind.DWord);
                        key.CreateSubKey("LinkResolveIgnoreLinkInfo");
                        key.SetValue("LinkResolveIgnoreLinkInfo", 1, RegistryValueKind.DWord);
                        key.CreateSubKey("NoResolveSearch");
                        key.SetValue("NoResolveSearch", 1, RegistryValueKind.DWord);
                        key.CreateSubKey("NoResolveTrack");
                        key.SetValue("NoResolveTrack", 1, RegistryValueKind.DWord);
                        key.CreateSubKey("NoInternetOpenWith");
                        key.SetValue("NoInternetOpenWith",1, RegistryValueKind.DWord);
                    }
                }
                catch (Exception) { }

                try
                {
                    using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                    using (var key = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", RegistryKeyPermissionCheck.ReadWriteSubTree))
                    {

                        key.CreateSubKey("NetworkThrottlingIndex");
                        key.SetValue("NetworkThrottlingIndex", 0x0000000a, RegistryValueKind.DWord);
                        key.CreateSubKey("SystemResponsiveness");
                        key.SetValue("SystemResponsiveness", 00000000, RegistryValueKind.DWord);
                        key.CreateSubKey("NoLazyMode");
                        key.SetValue("NoLazyMode", "1");
                    }
                }
                catch (Exception) { }
                try
                {
                    using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                    using (var key1 = hklm.OpenSubKey(@"Control Panel\Desktop", RegistryKeyPermissionCheck.ReadWriteSubTree))

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
                        key1.SetValue("LowLevelHooksTimeout", 00001000, RegistryValueKind.DWord);
                        key1.CreateSubKey("WaitToKillServiceTimeout");
                        key1.SetValue("WaitToKillServiceTimeout", "00002000");
                    }
                }
                catch (Exception) { }
            }
        }

        private void Optimize_Ram_Click(object sender, RoutedEventArgs e)
        {
            if (Optimize_Ram.IsChecked == true)
            {
                try
                {
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Control", true))
                    {
                        ulong x = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
                        ulong y = x / 1024;
                        key.CreateSubKey("SvcHostSplitThresholdInKB");
                        key.SetValue("SvcHostSplitThresholdInKB", y, RegistryValueKind.DWord);
                    }
                }
                catch (Exception) { }
               

            }
        }

        private void Latency_Optimizations_Click(object sender, RoutedEventArgs e)
        {
            
                Wow64Interop.EnableWow64FSRedirection(false);
                ExecuteCommand("Fsutil behavior set memoryusage 2");
                ExecuteCommand("bcdedit /set disabledynamictick yes");
                ExecuteCommand("bcdedit /set useplatformclock false");
                ExecuteCommand("bcdedit /set tscsyncpolicy enhanced");
                ExecuteCommand("bcdedit /set x2apicpolicy enable");
                ExecuteCommand("bcdedit /set useplatformtick yes ");
                ExecuteCommand("bcdedit /deletevalue useplatformclock");
            

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

        private void OptimizeHDDSSD_Click(object sender, RoutedEventArgs e)
        {
            ExecuteCommand("fsutil behavior set encryptpagingfile 0 > nul");
            ExecuteCommand("fsutil behavior set mftzone 2 > nul ");
            ExecuteCommand("fsutil behavior set disablelastaccess 1 > nul");
            ExecuteCommand("fsutil behavior set memoryusage 2 > nul");
            MessageBox.Show("Operation Completed Succesfully!");
        }

        private void Disable_Ads_Click(object sender, RoutedEventArgs e)
        {
            if (Disable_Ads.IsChecked==true)
            {
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true))
                    {
                        key.CreateSubKey("ShowSyncProviderNotifications");
                        key.SetValue("ShowSyncProviderNotifications", 0, RegistryValueKind.DWord);
                    }
                }
                catch (Exception) { }
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", true))
                    {
                        key.SetValue("FeatureManagementEnabled", 0, RegistryValueKind.DWord);
                        key.SetValue("OemPreInstalledAppsEnabled", 0, RegistryValueKind.DWord);
                        key.SetValue("PreInstalledAppsEnabled", 0, RegistryValueKind.DWord);
                        key.SetValue("PreInstalledAppsEverEnabled", 0, RegistryValueKind.DWord);
                        key.SetValue("RotatingLockScreenEnabled", 0, RegistryValueKind.DWord);
                        key.SetValue("RotatingLockScreenOverlayEnabled", 0, RegistryValueKind.DWord);
                        key.SetValue("SilentInstalledAppsEnabled", 0, RegistryValueKind.DWord);
                        key.SetValue("SoftLandingEnabled", 0, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-310093Enabled", 0, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-338387Enabled", 0, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-338388Enabled", 0, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-338389Enabled", 0, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-338393Enabled", 0, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-353694Enabled", 0, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-353696Enabled", 0, RegistryValueKind.DWord); 
                        key.SetValue("SystemPaneSuggestionsEnabled", 0, RegistryValueKind.DWord);
                    }
                }
                catch (Exception) { }


            }
            else
            {
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true))
                    {
                        key.CreateSubKey("ShowSyncProviderNotifications");
                        key.SetValue("ShowSyncProviderNotifications", 1, RegistryValueKind.DWord);
                    }
                }
                catch (Exception) { }
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", true))
                    {
                        key.SetValue("FeatureManagementEnabled", 1, RegistryValueKind.DWord);
                        key.SetValue("OemPreInstalledAppsEnabled", 1, RegistryValueKind.DWord);
                        key.SetValue("PreInstalledAppsEnabled", 1, RegistryValueKind.DWord);
                        key.SetValue("PreInstalledAppsEverEnabled",1, RegistryValueKind.DWord);
                        key.SetValue("RotatingLockScreenEnabled", 1, RegistryValueKind.DWord);
                        key.SetValue("RotatingLockScreenOverlayEnabled", 1, RegistryValueKind.DWord);
                        key.SetValue("SilentInstalledAppsEnabled", 1, RegistryValueKind.DWord);
                        key.SetValue("SoftLandingEnabled", 1, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-310093Enabled", 1, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-338387Enabled", 1, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-338388Enabled", 1, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-338389Enabled", 1, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-338393Enabled", 1, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-353694Enabled", 1, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-353696Enabled", 1, RegistryValueKind.DWord);
                        key.SetValue("SystemPaneSuggestionsEnabled", 1, RegistryValueKind.DWord);
                    }
                }
                catch (Exception) { }

            }

        }

        private void Uninstall_Click(object sender, RoutedEventArgs e)
        {
            Wow64Interop.EnableWow64FSRedirection(false);
            ExecuteCommand("rundll32.exe shell32.dll,Control_RunDLL appwiz.cpl");

        }

        private void Disable_UAC_Click(object sender, RoutedEventArgs e)
        {
            if (Disable_UAC.IsChecked== true)
            {
                try
                {
                    using (RegistryKey Key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", true))
                    {
                        Key.CreateSubKey("EnableLUA");
                        Key.SetValue("EnableLUA", 0, RegistryValueKind.DWord);                    }
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    using (RegistryKey Key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", true))
                    {
                        Key.CreateSubKey("EnableLUA");
                        Key.SetValue("EnableLUA", 1, RegistryValueKind.DWord);
                    }
                }
                catch (Exception) { }

            }
        }

        private void Disable_Updates_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (RegistryKey Key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\wuauserv", true))
                {
                    Key.SetValue("Start", 3, RegistryValueKind.DWord);
                }
                using (RegistryKey Key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\UsoSvc", true))
                {
                    Key.SetValue("Start", 3, RegistryValueKind.DWord);
                }
                Wow64Interop.EnableWow64FSRedirection(false);
                ExecuteCommand("taskkill -F -FI \"IMAGENAME eq SystemSettings.exe\"");
                ExecuteCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\" /v \"DoNotConnectToWindowsUpdateInternetLocations\" /t REG_DWORD /d \"1\" /f");
                ExecuteCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\" /v \"SetDisableUXWUAccess\" /t REG_DWORD /d \"1\" /f");
                ExecuteCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\" /v \"NoAutoUpdate\" /t REG_DWORD /d \"1\" /f");
                ExecuteCommand("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\" /v \"ExcludeWUDriversInQualityUpdate\" /t REG_DWORD /d \"1\" /f");
                ExecuteCommand("rd s q \"%SystemRoot%\\Windows\\SoftwareDistribution\"");
                ExecuteCommand("md \"%SystemRoot%\\Windows\\SoftwareDistribution\"");
            }
            catch (Exception) { }


      

        }
    }
}