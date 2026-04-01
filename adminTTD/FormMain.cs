using System;
using System.Windows.Forms;

namespace adminTTD
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            
            this.Text = "Trang Admin";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormMain
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}