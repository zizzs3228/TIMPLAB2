using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIMPLAB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string path = @"C:\Users\zizzs\source\repos\TIMPLAB2\FIOS.txt";
            if (File.Exists("FIOS.txt"))
            {
                using (StreamReader sr = File.OpenText("FIOS.txt"))
                {
                    string fio = textBox1.Text;
                    Console.WriteLine(fio);
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s == fio)
                        {
                            textBox2.Text = "Да, такое имя есть";
                            break;
                        }
                        else
                        {
                            textBox2.Text = "Не, такого имени нет";
                            button2.Location = new Point(42, 82);
                            button2.Size = new Size(133, 24);
                            button2.Text = "Добавить в файл??";
                            button2.Enabled = true;
                        }
                    }
                    sr.Close();
                }
            }
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //string path = @"FIOS.txt";
            string fio = textBox1.Text;
            using (StreamWriter sw = File.AppendText("FIOS.txt"))
            {
                sw.WriteLine(fio);
                sw.Close();
            }
            button2.Enabled = false;
        }
    }
}
