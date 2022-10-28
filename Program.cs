using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TIMPLAB2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            if (currentUserKey.OpenSubKey("Registrcheck") == null)
            {
                RegistryKey helloKey = currentUserKey.CreateSubKey("Registrcheck");
                helloKey.SetValue("regcheck", '1');
                helloKey.Close();
            }
            else
            {
                RegistryKey helloKey = currentUserKey.OpenSubKey("Registrcheck", true);
                string regcheck = helloKey.GetValue("regcheck").ToString();
                int regint = Convert.ToInt32(regcheck);
                regint++;
                regcheck = Convert.ToString(regint);
                if (regint > 5)
                {
                    helloKey.Close();
                    MessageBox.Show("Ата-та, вы превысили свой лимит");
                    System.Environment.Exit(0);
                }
                helloKey.SetValue("regcheck", regcheck);
                helloKey.Close();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
