using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BugTrackingSys_EPAMTest_2
{
    public partial class ChangeDataSource : Form
    {
        public ChangeDataSource()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            using ((this.Owner as MainWnd).setDataSource = new SetDataSource())
                DialogResult = (this.Owner as MainWnd).setDataSource.ShowDialog(this.Owner);
        }

        private void ChangeDataSource_Shown(object sender, EventArgs e)
        {
            lab_File_Path.Text = (this.Owner as MainWnd).DataSourcePath;
            lab_File_Name.Text = (this.Owner as MainWnd).DataSourceFileName;

        }
    }
}
