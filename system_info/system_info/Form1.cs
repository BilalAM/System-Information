using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Management.Instrumentation;
namespace system_info
{
    public partial class Form1 : Form
    {
        public static int Date;
      
       // public static string status;
        public Form1()
        {
            InitializeComponent();
        }

        public void general_Info()
        {
            try
            {
                ManagementObjectSearcher uGI = new ManagementObjectSearcher("select * from Win32_ComputerSystem");
                foreach (ManagementObject oGI in uGI.Get())
                {
                    tx1.Text =
                    oGI["UserName"].ToString();

                }
                ManagementObjectSearcher mGI = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
                foreach (ManagementObject oGI in mGI.Get())
                {
                    tx2.Text =
                    oGI["Caption"].ToString();
                    DateTime dt = ManagementDateTimeConverter.ToDateTime("20130217161130.000000+300");
                    tx3.Text = dt.ToString();
                    tx4.Text = oGI["Manufacturer"].ToString();


                }
            }
            catch(ManagementException ep)
            {
                MessageBox.Show("Error " + ep.Message);
            }


        }
        public void proces_Info()
        {
            try
            {
            ManagementObjectSearcher pOS = new ManagementObjectSearcher("select * from Win32_Processor");
            foreach(ManagementObject pS in pOS.Get())
            {
                tx5.Text = pS["Caption"].ToString();
                tx6.Text = pS["MaxClockSpeed"].ToString();
                tx7.Text = pS["ProcessorId"].ToString();
                tx8.Text = pS["NumberOfCores"].ToString();
                textBox2.Text = pS["CurrentClockSpeed"].ToString();
                DateTime dtP = ManagementDateTimeConverter.ToDateTime("20130217161130.000000+300");
                tx9.Text = dtP.ToString();
                tx10.Text = pS["Architecture"].ToString();
                textBox1.Text = pS["Manufacturer"].ToString();
                
            }
            
            
                ManagementObjectSearcher temp = new ManagementObjectSearcher("root\\WMI" ,"SELECT * FROM MSAcpi_ThermalZoneTemperature");
                foreach (ManagementObject tempO in temp.Get())
                {
                    textBox3.Text = tempO["CurrentTemperature"].ToString();
                }
            }
            catch(ManagementException e)
            {
                MessageBox.Show("ERROR" + e.Message);
            }
            

        }

        /*------*/
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            general_Info();
            proces_Info();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tx3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
