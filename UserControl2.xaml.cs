using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;

namespace KrakenZ_Tweaker.UserControls
{

    public partial class UserControl2 : UserControl
    {


        public UserControl2()
        {
            InitializeComponent();
        


            string[] keys = {
       @"SYSTEM\CurrentControlSet\Services\XblGameSave",
       @"SYSTEM\CurrentControlSet\Services\XboxNetApiSvc",
       @"SYSTEM\CurrentControlSet\Services\XboxGipSvc",
       @"SYSTEM\CurrentControlSet\Services\XblAuthManager",
       @"SYSTEM\CurrentControlSet\Services\wisvc",
       @"SYSTEM\CurrentControlSet\Services\Spooler",
       @"SYSTEM\CurrentControlSet\Services\PrintNotify",
       @"SYSTEM\CurrentControlSet\Services\MapsBroker",
       @"SYSTEM\CurrentControlSet\Services\BTAGService",
       @"SYSTEM\CurrentControlSet\Services\bthserv",
       @"SYSTEM\CurrentControlSet\Services\DiagTrack",
       @"SYSTEM\CurrentControlSet\Services\dmwappushservice",
       @"SYSTEM\CurrentControlSet\Services\diagsvc",
       @"SYSTEM\CurrentControlSet\Services\diagnosticshub.standardcollector.service",
       @"SYSTEM\CurrentControlSet\Services\WdiServiceHost",
       @"SYSTEM\CurrentControlSet\Services\WdiSystemHost",
       @"SYSTEM\CurrentControlSet\Services\AJRouter",
       @"SYSTEM\CurrentControlSet\Services\ALG",
       @"SYSTEM\CurrentControlSet\Services\CertPropSvc",
       @"SYSTEM\CurrentControlSet\Services\Fax",
       @"SYSTEM\CurrentControlSet\Services\CscService",
       @"SYSTEM\CurrentControlSet\Services\RetailDemo",
       @"SYSTEM\CurrentControlSet\Services\seclogon",
       @"SYSTEM\CurrentControlSet\Services\SCardSvr",
       @"SYSTEM\CurrentControlSet\Services\ScDeviceEnum",
       @"SYSTEM\CurrentControlSet\Services\SCPolicySvc",
       @"SYSTEM\CurrentControlSet\Services\SysMain",
       @"SYSTEM\CurrentControlSet\Services\WerSvc",
       @"SYSTEM\CurrentControlSet\Services\DoSvc",
       @"SYSTEM\CurrentControlSet\Services\lfsvc",
       @"SYSTEM\CurrentControlSet\Services\SEMgrSvc",
       @"SYSTEM\CurrentControlSet\Services\PhoneSvc",
       @"SYSTEM\CurrentControlSet\Services\RemoteRegistry",
       @"SYSTEM\CurrentControlSet\Services\feafes",
       @"SYSTEM\CurrentControlSet\Services\FontCache",
       @"SYSTEM\CurrentControlSet\Services\FontCache3.0.0.0",
       @"SYSTEM\CurrentControlSet\Services\GraphicsPerfSvc",
       @"SYSTEM\CurrentControlSet\Services\stisvc",
       @"SYSTEM\CurrentControlSet\Services\PcaSvc",
       @"SYSTEM\CurrentControlSet\Services\Wecsvc",
       @"SYSTEM\CurrentControlSet\Services\tzautoupdate",
        @"SYSTEM\CurrentControlSet\Services\BITS",
        @"SYSTEM\CurrentControlSet\Services\CDPSvc",
        @"SYSTEM\CurrentControlSet\Services\DusmSvc",
        @"SYSTEM\CurrentControlSet\Services\HomeGroupListener",
        @"SYSTEM\CurrentControlSet\Services\HomeGroupProvider",
        @"SYSTEM\CurrentControlSet\Services\SmsRouter",
        @"SYSTEM\CurrentControlSet\Services\pla",
        @"SYSTEM\CurrentControlSet\Services\RasAuto",
        @"SYSTEM\CurrentControlSet\Services\RasMan",
       @"SYSTEM\CurrentControlSet\Services\SessionEnv",
       @"SYSTEM\CurrentControlSet\Services\WalletService",
         @"SYSTEM\CurrentControlSet\Services\WSearch",
           @"SYSTEM\CurrentControlSet\Services\WpnUserService",
           @"SYSTEM\CurrentControlSet\Services\BluetoothUserService",



        };
            string[] keys1 = {
      @"SOFTWARE\Microsoft\PolicyManager\default\ApplicationManagement\AllowGameDVR"
        };

            Dictionary<string, uint> dict2 = new Dictionary<string, uint>();


            foreach (var key in keys1)
            {
                
                    using (
                    var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                    using (var rkey = hklm.OpenSubKey(key, false))



                    {
                    try
                    {
                        if (rkey == null)
                        {
                            dict2.Add(key, 1);
                        }
                        else
                        {
                            dict2.Add(key, Convert.ToUInt32(rkey.GetValue("value")));
                        }
                    }catch(Exception)
                    { }
                    }
             
                 
          



            }

            Dictionary<string, uint> dict = new Dictionary<string, uint>();

            foreach (var key in keys)
            {

                using (var rkey = Registry.LocalMachine.OpenSubKey(key, false))
                {
                    try
                    {

                        if (rkey == null)
                        {
                            dict.Add(key, 0);
                        }
                        else
                        {
                            dict.Add(key, Convert.ToUInt32(rkey.GetValue("Start", RegistryValueKind.DWord)));
                        }
                    }
                    catch (Exception)
                    {

                    }
                    finally { rkey?.Dispose(); }
                }



            }


            if (dict.ElementAt(0).Value + dict.ElementAt(1).Value + dict.ElementAt(2).Value + dict.ElementAt(3).Value == 16)
            {
                Disable_Xbox_Services.IsChecked = true;
            }
            if (dict.ElementAt(4).Value == 4)
            {
                Disable_Windows_Insider.IsChecked = true;
            }
            if (dict.ElementAt(5).Value + dict.ElementAt(6).Value == 8)
            {
                Disable_Print_Services.IsChecked = true;
            }
            if (dict.ElementAt(7).Value == 4)
            {
                Disable_Maps_Broker.IsChecked = true;
            }
            if (dict.ElementAt(8).Value + dict.ElementAt(9).Value + dict.ElementAt(54).Value == 12)
            {
                Disable_Bluethooth.IsChecked = true;
            }
            if (dict.ElementAt(10).Value + dict.ElementAt(11).Value + dict.ElementAt(12).Value + dict.ElementAt(13).Value + dict.ElementAt(14).Value + dict.ElementAt(15).Value == 24)
            {
                Disable_Diagnostics.IsChecked = true;
            }
            if (dict.ElementAt(16).Value + dict.ElementAt(17).Value + dict.ElementAt(18).Value + dict.ElementAt(19).Value + dict.ElementAt(20).Value + dict.ElementAt(21).Value + dict.ElementAt(22).Value + dict.ElementAt(23).Value + dict.ElementAt(24).Value + dict.ElementAt(25).Value + dict.ElementAt(26).Value + dict.ElementAt(27).Value + dict.ElementAt(28).Value + dict.ElementAt(29).Value + dict.ElementAt(30).Value + dict.ElementAt(31).Value + dict.ElementAt(32).Value + dict.ElementAt(33).Value + dict.ElementAt(34).Value + dict.ElementAt(35).Value + dict.ElementAt(36).Value + dict.ElementAt(36).Value + dict.ElementAt(37).Value + dict.ElementAt(38).Value + dict.ElementAt(39).Value + dict.ElementAt(40).Value + dict.ElementAt(41).Value + dict.ElementAt(42).Value + dict.ElementAt(43).Value + dict.ElementAt(44).Value + dict.ElementAt(45).Value + dict.ElementAt(46).Value + dict.ElementAt(47).Value + dict.ElementAt(48).Value + dict.ElementAt(49).Value + dict.ElementAt(50).Value + dict.ElementAt(51).Value + dict.ElementAt(52).Value + dict.ElementAt(53).Value == 152)
            {
                Disable_Services.IsChecked = true;
            }
            if (dict.ElementAt(40).Value == 4)
            {
                Biometric_Services.IsChecked = true;
            }
          
            if (dict2.ElementAt(0).Value == 0)
            {
                Game_DVR.IsChecked = true;
            }
        }










        private void Disable_Xbox_Services_Click(object sender, RoutedEventArgs e)
        {
            string[] keys = {
       @"SYSTEM\CurrentControlSet\Services\XblGameSave",
       @"SYSTEM\CurrentControlSet\Services\XboxNetApiSvc",
       @"SYSTEM\CurrentControlSet\Services\XboxGipSvc",
       @"SYSTEM\CurrentControlSet\Services\XblAuthManager",

                            };

            if (Disable_Xbox_Services.IsChecked == true)
            {


                foreach (string key in keys)
                {

                    using (RegistryKey newKey = Registry.LocalMachine.OpenSubKey(key, true))

                    {
                        try
                        {

                            newKey.SetValue("Start", 4, RegistryValueKind.DWord);
                        }
                        catch (Exception)
                        {

                        }
                    }

                }
            }
            else
            {
                foreach (string key in keys)
                {
                    using (RegistryKey newKey = Registry.LocalMachine.OpenSubKey(key, true))
                    {
                        try
                        {

                            newKey.SetValue("Start", 3, RegistryValueKind.DWord);
                        }
                        catch (Exception)
                        {
                        }
                    }

                }

            }

        }

        private void Disable_Windows_Insider_Click(object sender, RoutedEventArgs e)
        {
            if (Disable_Windows_Insider.IsChecked == true)
            {
                using (RegistryKey key4 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\wisvc", true))
                {
                    try
                    {


                        key4.SetValue("Start", 4, RegistryValueKind.DWord);

                    }
                    catch (Exception)
                    {

                    }
                }

            }
            else
            {
                using (RegistryKey key4 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\wisvc", true))
                {
                    try
                    {
                        key4.SetValue("Start", 3, RegistryValueKind.DWord);
                    }
                    catch (Exception)
                    {

                    }
                }


            }

        }

        private void Disable_Print_Services_Click(object sender, RoutedEventArgs e)
        {
            if (Disable_Print_Services.IsChecked == true)
            {
                string[] keys = {
                @"SYSTEM\CurrentControlSet\Services\Spooler",
                @"SYSTEM\CurrentControlSet\Services\PrintNotify",

                            };

                foreach (string key in keys)
                {
                    using (RegistryKey newKey = Registry.LocalMachine.OpenSubKey(key, true))
                    {

                        try
                        {
                            newKey.SetValue("Start", 4, RegistryValueKind.DWord);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }


            }
            else
            {
                string[] keys = {
                @"SYSTEM\CurrentControlSet\Services\Spooler",
                @"SYSTEM\CurrentControlSet\Services\PrintNotify",

                            };

                foreach (string key in keys)
                {
                    using (RegistryKey newKey = Registry.LocalMachine.OpenSubKey(key, true))
                    {
                        try
                        {
                            newKey.SetValue("Start", 3, RegistryValueKind.DWord);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }


            }

        }

        private void Disable_Maps_Broker_Click(object sender, RoutedEventArgs e)
        {
            if (Disable_Maps_Broker.IsChecked == true)
            {
                using (
                RegistryKey key7 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\MapsBroker", true))
                {
                    try
                    {
                        key7.SetValue("Start", 4, RegistryValueKind.DWord);

                    }
                    catch (Exception)
                    {

                    }
                }

            }
            else
            {
                using (RegistryKey key7 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\MapsBroker", true))
                {
                    try
                    {
                        key7.SetValue("Start", 3, RegistryValueKind.DWord);

                    }
                    catch (Exception)
                    {

                    }
                }

            }

        }

        private void Disable_Bluethooth_Click(object sender, RoutedEventArgs e)
        {
            if (Disable_Bluethooth.IsChecked == true)
            {
                string[] keys = {
                @"SYSTEM\CurrentControlSet\Services\BTAGService",
                @"SYSTEM\CurrentControlSet\Services\bthserv",
                  @"SYSTEM\CurrentControlSet\Services\BluetoothUserService",

                            };

                foreach (string key in keys)
                {
                    using (
                    RegistryKey newKey = Registry.LocalMachine.OpenSubKey(key, true))
                    {
                        try
                        {
                            newKey.SetValue("Start", 4, RegistryValueKind.DWord);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

            }
            else
            {
                string[] keys = {
                @"SYSTEM\CurrentControlSet\Services\BTAGService",
                @"SYSTEM\CurrentControlSet\Services\bthserv",
                  @"SYSTEM\CurrentControlSet\Services\BluetoothUserService",

                            };

                foreach (string key in keys)
                {
                    using (RegistryKey newKey = Registry.LocalMachine.OpenSubKey(key, true))
                    {
                        try
                        {
                            newKey.SetValue("Start", 3, RegistryValueKind.DWord);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

            }

        }

        private void Disable_Diagnostics_Click(object sender, RoutedEventArgs e)
        {
            if (Disable_Diagnostics.IsChecked == true)
            {
                try
                {
                    string[] keys = {
                 @"SYSTEM\CurrentControlSet\Services\DiagTrack",
                 @"SYSTEM\CurrentControlSet\Services\dmwappushservice",
                 @"SYSTEM\CurrentControlSet\Services\diagsvc",
                 @"SYSTEM\CurrentControlSet\Services\diagnosticshub.standardcollector.service",
                 @"SYSTEM\CurrentControlSet\Services\WdiServiceHost",
                 @"SYSTEM\CurrentControlSet\Services\WdiSystemHost",


                            };

                    foreach (string key in keys)
                    {
                        using (RegistryKey newKey = Registry.LocalMachine.OpenSubKey(key, true))
                        {

                            try
                            {

                                if (newKey == null)
                                {

                                }
                                else
                                {
                                    newKey.SetValue("Start", 4, RegistryValueKind.DWord);
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }

                    }
                }
                catch(Exception) { }
            }
            else
            {
                try
                {
                    string[] keys = {
                 @"SYSTEM\CurrentControlSet\Services\DiagTrack",
                 @"SYSTEM\CurrentControlSet\Services\dmwappushservice",
                 @"SYSTEM\CurrentControlSet\Services\diagsvc",
                 @"SYSTEM\CurrentControlSet\Services\diagnosticshub.standardcollector.service",
                 @"SYSTEM\CurrentControlSet\Services\WdiServiceHost",
                 @"SYSTEM\CurrentControlSet\Services\WdiSystemHost"
                            };

                    foreach (string key in keys)
                    {
                        using (RegistryKey newKey = Registry.LocalMachine.OpenSubKey(key, true))
                        {
                            try
                            {

                                if (newKey == null)
                                {

                                }
                                else
                                {
                                    newKey.SetValue("Start", 3, RegistryValueKind.DWord);
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }


                    }
                }
                catch(Exception)
                { }

            }

        }

        private void Disable_Services_Click(object sender, RoutedEventArgs e)
        {
            try { 


                if (Disable_Services.IsChecked == true)
            {
                string[] keys = {
             @"SYSTEM\CurrentControlSet\Services\AJRouter",
       @"SYSTEM\CurrentControlSet\Services\ALG",
       @"SYSTEM\CurrentControlSet\Services\CertPropSvc",
       @"SYSTEM\CurrentControlSet\Services\Fax",
       @"SYSTEM\CurrentControlSet\Services\CscService",
       @"SYSTEM\CurrentControlSet\Services\RetailDemo",
       @"SYSTEM\CurrentControlSet\Services\seclogon",
       @"SYSTEM\CurrentControlSet\Services\SCardSvr",
       @"SYSTEM\CurrentControlSet\Services\ScDeviceEnum",
       @"SYSTEM\CurrentControlSet\Services\SCPolicySvc",
       @"SYSTEM\CurrentControlSet\Services\SysMain",
       @"SYSTEM\CurrentControlSet\Services\WerSvc",
       @"SYSTEM\CurrentControlSet\Services\DoSvc",
       @"SYSTEM\CurrentControlSet\Services\lfsvc",
       @"SYSTEM\CurrentControlSet\Services\SEMgrSvc",
       @"SYSTEM\CurrentControlSet\Services\PhoneSvc",
       @"SYSTEM\CurrentControlSet\Services\RemoteRegistry",
       @"SYSTEM\CurrentControlSet\Services\feafes",
        @"SYSTEM\CurrentControlSet\Services\FontCache",
       @"SYSTEM\CurrentControlSet\Services\FontCache3.0.0.0",
       @"SYSTEM\CurrentControlSet\Services\GraphicsPerfSvc",
       @"SYSTEM\CurrentControlSet\Services\stisvc",
       @"SYSTEM\CurrentControlSet\Services\PcaSvc",
       @"SYSTEM\CurrentControlSet\Services\Wecsvc",
        @"SYSTEM\CurrentControlSet\Services\tzautoupdate",
        @"SYSTEM\CurrentControlSet\Services\CDPSvc",
        @"SYSTEM\CurrentControlSet\Services\DusmSvc",
        @"SYSTEM\CurrentControlSet\Services\BITS",
        @"SYSTEM\CurrentControlSet\Services\HomeGroupListener",
        @"SYSTEM\CurrentControlSet\Services\HomeGroupProvider",
        @"SYSTEM\CurrentControlSet\Services\SmsRouter",
        @"SYSTEM\CurrentControlSet\Services\pla",
        @"SYSTEM\CurrentControlSet\Services\RasAuto",
        @"SYSTEM\CurrentControlSet\Services\RasMan",
       @"SYSTEM\CurrentControlSet\Services\SessionEnv",
       @"SYSTEM\CurrentControlSet\Services\WalletService",
         @"SYSTEM\CurrentControlSet\Services\WSearch",
           @"SYSTEM\CurrentControlSet\Services\WpnUserService",


                            };

                foreach (string key in keys)
                {
                    using (RegistryKey newKey = Registry.LocalMachine.OpenSubKey(key, true))

                    {
                        try
                        {


                            if (newKey == null)
                            {

                            }
                            else
                            {
                                newKey.SetValue("Start", 4, RegistryValueKind.DWord);
                            }

                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(Convert.ToString(x));

                        }
                    }

                }

            }
            else
            {
                string[] keys = {
             @"SYSTEM\CurrentControlSet\Services\AJRouter",
       @"SYSTEM\CurrentControlSet\Services\ALG",
       @"SYSTEM\CurrentControlSet\Services\CertPropSvc",
       @"SYSTEM\CurrentControlSet\Services\Fax",
       @"SYSTEM\CurrentControlSet\Services\CscService",
       @"SYSTEM\CurrentControlSet\Services\RetailDemo",
       @"SYSTEM\CurrentControlSet\Services\seclogon",
       @"SYSTEM\CurrentControlSet\Services\SCardSvr",
       @"SYSTEM\CurrentControlSet\Services\ScDeviceEnum",
       @"SYSTEM\CurrentControlSet\Services\SCPolicySvc",
       @"SYSTEM\CurrentControlSet\Services\SysMain",
       @"SYSTEM\CurrentControlSet\Services\WerSvc",
       @"SYSTEM\CurrentControlSet\Services\DoSvc",
       @"SYSTEM\CurrentControlSet\Services\lfsvc",
       @"SYSTEM\CurrentControlSet\Services\SEMgrSvc",
       @"SYSTEM\CurrentControlSet\Services\PhoneSvc",
       @"SYSTEM\CurrentControlSet\Services\RemoteRegistry",
       @"SYSTEM\CurrentControlSet\Services\feafes",
        @"SYSTEM\CurrentControlSet\Services\FontCache",
       @"SYSTEM\CurrentControlSet\Services\FontCache3.0.0.0",
       @"SYSTEM\CurrentControlSet\Services\GraphicsPerfSvc",
       @"SYSTEM\CurrentControlSet\Services\stisvc",
       @"SYSTEM\CurrentControlSet\Services\PcaSvc",
       @"SYSTEM\CurrentControlSet\Services\Wecsvc",
        @"SYSTEM\CurrentControlSet\Services\tzautoupdate",
        @"SYSTEM\CurrentControlSet\Services\CDPSvc",
        @"SYSTEM\CurrentControlSet\Services\DusmSvc",
     @"SYSTEM\CurrentControlSet\Services\BITS",
        @"SYSTEM\CurrentControlSet\Services\HomeGroupListener",
        @"SYSTEM\CurrentControlSet\Services\HomeGroupProvider",
        @"SYSTEM\CurrentControlSet\Services\SmsRouter",
        @"SYSTEM\CurrentControlSet\Services\pla",
        @"SYSTEM\CurrentControlSet\Services\RasAuto",
        @"SYSTEM\CurrentControlSet\Services\RasMan",
       @"SYSTEM\CurrentControlSet\Services\SessionEnv",
       @"SYSTEM\CurrentControlSet\Services\WalletService",
         @"SYSTEM\CurrentControlSet\Services\WSearch",
           @"SYSTEM\CurrentControlSet\Services\WpnUserService",


                            };

                foreach (string key in keys)
                {
                    using (RegistryKey newKey = Registry.LocalMachine.OpenSubKey(key, true))
                    {
                        try
                        {


                            if (newKey == null)
                            {

                            }
                            else
                            {
                                newKey.SetValue("Start", 3, RegistryValueKind.DWord);
                            }

                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(Convert.ToString(x));
                        }
                    }


                }

            }
        }catch(Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

          
        }


        private void Biometric_Services_Click(object sender, RoutedEventArgs e)
        {
            if (Biometric_Services.IsChecked == true)
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\WbioSrvc", true))
                {
                    try
                    {

                        if (key == null)
                        {

                        }
                        else
                        {
                            key.SetValue("Start", 4, RegistryValueKind.DWord);
                        }
                    }



                    catch (Exception)
                    {

                    }

                }
            }
            else
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\WbioSrvc", true))
                {
                    try
                    {

                        if (key == null)
                        {

                        }
                        else
                        {
                            key.SetValue("Start", 3, RegistryValueKind.DWord);

                        }


                    }
                    catch (Exception)
                    {

                    }
                }

            }

        }

        private void Game_DVR_Click(object sender, RoutedEventArgs e)
        {
            if (Game_DVR.IsChecked == true)
            {
                using (
                    var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var key = hklm.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\BcastDVRUserService", RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    try
                    {
                            key.SetValue("Start", 4, RegistryValueKind.DWord);
                    }
                    catch (Exception)
                    {

                    }
                }
                using (
                   var hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                using (var key = hklm.OpenSubKey(@"System\GameConfigStore", RegistryKeyPermissionCheck.ReadWriteSubTree))
               
                {
                    try
                    {

                        if (key == null)
                        {

                        }
                        else
                        {
                            key.CreateSubKey("GameDVR_Enabled");
                            key.SetValue("GameDVR_Enabled", 0, RegistryValueKind.DWord);


                        }

                    }
                    catch (Exception)
                    {

                    }
                }


                try
                {
                    using (
                   var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                    using (var key1 = hklm.OpenSubKey(@"SOFTWARE\Microsoft\PolicyManager\default\ApplicationManagement\AllowGameDVR", RegistryKeyPermissionCheck.ReadWriteSubTree))
                    
                    {
                        if (key1 == null)
                        {

                        }
                        else
                        {
                            key1.CreateSubKey("value");
                            key1.SetValue("value", 0, RegistryValueKind.DWord);


                        }
                    }

                }
                catch (Exception)
                {

                }

                using (
                  var hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                using (var key2 = hklm.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\GameDVR", RegistryKeyPermissionCheck.ReadWriteSubTree))
               
                {
                    try
                    {

                        if (key2 == null)
                        {

                        }
                        else
                        {
                            key2.CreateSubKey("AppCaptureEnabled");
                            key2.SetValue("AppCaptureEnabled", 0, RegistryValueKind.DWord);


                        }

                    }
                    catch (Exception)
                    {

                    }
                }


            }
            else
            {
                using (
                     var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var key = hklm.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\BcastDVRUserService", RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    try
                    {
                        key.SetValue("Start", 3, RegistryValueKind.DWord);
                    }
                    catch (Exception)
                    {

                    }
                }
                using (
                   var hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                using (var key = hklm.OpenSubKey(@"System\GameConfigStore", RegistryKeyPermissionCheck.ReadWriteSubTree))

                {
                    try
                    {

                        if (key == null)
                        {

                        }
                        else
                        {
                            key.CreateSubKey("GameDVR_Enabled");
                            key.SetValue("GameDVR_Enabled", 1, RegistryValueKind.DWord);


                        }

                    }
                    catch (Exception)
                    {

                    }
                }


                try
                {
                    using (
                   var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                    using (var key1 = hklm.OpenSubKey(@"SOFTWARE\Microsoft\PolicyManager\default\ApplicationManagement\AllowGameDVR", RegistryKeyPermissionCheck.ReadWriteSubTree))

                    {
                        if (key1 == null)
                        {

                        }
                        else
                        {
                            key1.CreateSubKey("value");
                            key1.SetValue("value", 1, RegistryValueKind.DWord);


                        }
                    }

                }
                catch (Exception)
                {

                }

                using (
                  var hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                using (var key2 = hklm.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\GameDVR", RegistryKeyPermissionCheck.ReadWriteSubTree))

                {
                    try
                    {

                        if (key2 == null)
                        {

                        }
                        else
                        {
                            key2.CreateSubKey("AppCaptureEnabled");
                            key2.SetValue("AppCaptureEnabled", 1, RegistryValueKind.DWord);


                        }

                    }
                    catch (Exception)
                    {

                    }
                }


            }


        }

        }
    }












