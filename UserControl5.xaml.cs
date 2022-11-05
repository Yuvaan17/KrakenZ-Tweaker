using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KrakenZ_Tweaker
{
    /// <summary>
    /// Interaction logic for UserControl5.xaml
    /// </summary>
    public partial class UserControl5 : UserControl
    {
        public UserControl5()
        {

            InitializeComponent();
            var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey HKCU = hklm.OpenSubKey(LocalMachineRun);
            RegistryKey HKCU1 = hklm.OpenSubKey(LocalMachineRunOnce);
            RegistryKey HKCU2 = hklm.OpenSubKey(LocalMachineRunWoW);
            RegistryKey HKCU3 = hklm.OpenSubKey(LocalMachineRunOnceWow);
            RegistryKey HKCU4 = Registry.CurrentUser.OpenSubKey(CurrentUserRun);
            RegistryKey HKCU5 = Registry.CurrentUser.OpenSubKey(CurrentUserRunOnce);

            foreach (string Programs in HKCU.GetValueNames())
            {
                Startup_Apps.Items.Add(Programs);
            }
            foreach (string Programs in HKCU1.GetValueNames())
            {
                Startup_Apps.Items.Add(Programs);
            }
            foreach (string Programs in HKCU2.GetValueNames())
            {
                Startup_Apps.Items.Add(Programs);
            }
            foreach (string Programs in HKCU3.GetValueNames())
            {
                Startup_Apps.Items.Add(Programs);
            }
            foreach (string Programs in HKCU4.GetValueNames())
            {
                Startup_Apps.Items.Add(Programs);
            }
            foreach (string Programs in HKCU5.GetValueNames())
            {
                Startup_Apps.Items.Add(Programs);
            }
            HKCU.Close();
            HKCU1.Close(); HKCU2.Close(); HKCU3.Close(); HKCU4.Close();

        }
        internal static readonly string LocalMachineRun = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";
        internal static readonly string LocalMachineRunOnce = "Software\\Microsoft\\Windows\\CurrentVersion\\RunOnce";
        internal static readonly string LocalMachineRunWoW = "Software\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run";
        internal static readonly string LocalMachineRunOnceWow = "Software\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\RunOnce";
        internal static readonly string CurrentUserRun = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";
        internal static readonly string CurrentUserRunOnce = "Software\\Microsoft\\Windows\\CurrentVersion\\RunOnce";

        private void Startup_Apps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

       
            foreach (var item in Startup_Apps.SelectedItems)
            {

                list.Add(Convert.ToString(item));
                selected = list.ToArray();
            }
       

        }
        List<string> list = new List<string>();
        string[] selected;


        private void Clear_Startup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RegistryKey startupKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(LocalMachineRun, true);
                RegistryKey startupKey1 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(LocalMachineRunOnce, true);
                RegistryKey startupKey2 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(LocalMachineRunWoW, true);
                RegistryKey startupKey3 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(LocalMachineRunOnceWow, true);
                RegistryKey startupKey4 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(CurrentUserRun, true);
                RegistryKey startupKey5 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(CurrentUserRunOnce, true);
                foreach (string AppName in selected)
                {
                    startupKey.DeleteValue(AppName, false);
                }
                startupKey.Close();
            }
            catch(Exception ex)
            { MessageBox.Show(Convert.ToString(ex)); }
        }
    }
}
