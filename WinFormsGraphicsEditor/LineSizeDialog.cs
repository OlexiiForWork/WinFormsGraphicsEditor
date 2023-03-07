using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsGraphicsEditor
{
    public partial class LineSizeDialog : Form
    {
        public float PenWidth { get; set; }
        public LineSizeDialog()
        {
            InitializeComponent();
            PenWidth = 1.0f;
            numericUpDown1.DataBindings.Add(new Binding("Value", this, "PenWidth"));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LineSizeDialog_Shown(object sender, EventArgs e)
        {
            //this.Activate();
        }
    }
}
