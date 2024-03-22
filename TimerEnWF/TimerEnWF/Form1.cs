using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerEnWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtTemperatura.Text != string.Empty && txtHumedad.Text != string.Empty)
            {
                dataGridView1.Rows.Add(txtTemperatura.Text, txtHumedad.Text, DateTime.Now);
                txtHumedad.Clear();
                txtTemperatura.Clear();
            }
        }

        private void btniniciar_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}