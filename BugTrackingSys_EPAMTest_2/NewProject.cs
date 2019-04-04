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
    public partial class NewProject : Form
    {
        public NewProject()
        {
            InitializeComponent();
        }

        private void NewProject_Shown(object sender, EventArgs e)
        {
            MainWnd mainWnd = (this.Owner as MainWnd);
            LabID.Text = (mainWnd.BugTrackingSystem.projects[mainWnd.BugTrackingSystem.projects.Keys.Last()].ID + 1).ToString();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                MainWnd mainWnd = (this.Owner as MainWnd);
                uint id = mainWnd.BugTrackingSystem.projects[mainWnd.BugTrackingSystem.projects.Keys.Last()].ID + 1;
                Project t = new Project(id, txtbxName.Text, tchtxtDescr.Text);

                mainWnd.BugTrackingSystem.Insert(new Projects(new List<Project>() { t }));
                (mainWnd.changed_proj as Projects).AddItem(t);
                mainWnd.proj_oper.Add(SQCommands.Insert);
                DialogResult = DialogResult.OK;
            }
            catch (AccessRightsException a)
            {
                MessageBox.Show(a.Message, "Нарушение прав доступа!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}
