using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KillService
{
    public partial class Form1 : Form
    {
        string serverpath = "C:\\Users\\elite\\Desktop\\Z++Server.exe";
        System.Diagnostics.Process builderprocess;
        //static System.Timers.Timer timer = new System.Timers.Timer();
        bool state = false;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < service11.process.Length; i++)
            {
                listBox1.Items.Add(service11.process[i].ProcessName);
            }

            builderprocess = new System.Diagnostics.Process()
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = serverpath
                }
            };

            timer1.Start();
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Clear();
                service11.GetProcessEvent();
                for (int n = 0; n < service11.process.Length; n++)
                {
                    if (!service11.processname.Contains(service11.process[n].ProcessName))
                    {
                        listBox2.Items.Add(service11.process[n].ProcessName);
                    }
                }
                for (int i = 0; i < service11.process.Length; i++)
                {
                    if (service11.process[i].ProcessName == "Z++Server")
                    {
                        state = true;
                        break;
                    }
                    else
                    {
                        state = false; 
                    }
                }
                if (state != true)
                {
                    builderprocess.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误:" + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            service11.GetProcessEvent();
            try
            {
                System.IO.FileStream testfile = new System.IO.FileStream("C:\\Users\\elite\\Desktop\\test.txt", System.IO.FileMode.OpenOrCreate);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(testfile);
                for (int i = 0; i < service11.process.Length; i++)
                {
                    Console.WriteLine(service11.process[i].ProcessName);
                    sw.Write(service11.process[i].ProcessName + "\n ");
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误" + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            service11.GetProcessEvent();
            try
            {
                for (int i = 0; i < service11.process.Length; i++)
                {
                    if (service11.process[i].ProcessName == "Z++Server")
                    {
                        state = true;
                    }
                    else
                    {
                        state = false; ;
                    }
                }
                if (state != true)
                {
                    builderprocess.Start();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("错误"+ex);
            }
        }
    }
}
