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
    public partial class ChangeDelete_Project : Form
    {
        public ChangeDelete_Project()
        {
            InitializeComponent();
        }

        private void ChangeDelete_UserProject_Shown(object sender, EventArgs e)
        {
            MainWnd mainWnd = (this.Owner as MainWnd);
            List<string> t = new List<string>();
            foreach (uint key in mainWnd.BugTrackingSystem.projects.Keys)
                t.Add(mainWnd.BugTrackingSystem.projects[key].ID.ToString());
            cmbbxID.DataSource = t;
            cmbbxID.SelectedIndex = 0;
            if (mainWnd.isDeleteUserPrj)
            {
                uint id = mainWnd.BugTrackingSystem.projects[uint.Parse(cmbbxID.SelectedValue.ToString())].ID;
                this.Text = "Удалить проект";
                txtbxName.Visible = false;
                labName.Visible = true;
                labName.Text = mainWnd.BugTrackingSystem.projects[id].Name;
                rchtxtbxDescr.Text = mainWnd.BugTrackingSystem.projects[id].Description;
                rchtxtbxDescr.ReadOnly = true;
            }
            else
            {
                uint id = mainWnd.BugTrackingSystem.projects[uint.Parse(cmbbxID.SelectedValue.ToString())].ID;
                this.Text = "Изменить проект";
                txtbxName.Visible = true;
                labName.Visible = false;
                txtbxName.Text = mainWnd.BugTrackingSystem.projects[id].Name;
                rchtxtbxDescr.Text = mainWnd.BugTrackingSystem.projects[id].Description;
                rchtxtbxDescr.ReadOnly = false;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                MainWnd mainWnd = (this.Owner as MainWnd);
                List<string> t = new List<string>();
                if (mainWnd.isDeleteUserPrj)
                {
                    uint id = mainWnd.BugTrackingSystem.projects[uint.Parse(cmbbxID.SelectedValue.ToString())].ID;
                    Project prj = new Project(id, txtbxName.Text, rchtxtbxDescr.Text);

                    mainWnd.BugTrackingSystem.Delete(new Projects(new List<Project>() { prj }));
                    (mainWnd.changed_proj as Projects).AddItem(prj);
                    mainWnd.proj_oper.Add(SQCommands.Delete);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    uint id = mainWnd.BugTrackingSystem.employees[uint.Parse(cmbbxID.SelectedValue.ToString())].ID;
                    Project prj = new Project(id, txtbxName.Text, rchtxtbxDescr.Text);

                    mainWnd.BugTrackingSystem.Update(new Projects(new List<Project>() { prj }));
                    (mainWnd.changed_proj as Projects).AddItem(prj);
                    mainWnd.proj_oper.Add(SQCommands.Update);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (AccessRightsException a)
            {
                MessageBox.Show(a.Message, "Нарушение прав доступа!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (LinkError lk)
            {
                MessageBox.Show(lk.Message, "Нарушение связности объектов!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void CmbbxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainWnd mainWnd = (this.Owner as MainWnd);
            List<string> t = new List<string>();
            if (mainWnd.isDeleteUserPrj)
            {
                uint id = mainWnd.BugTrackingSystem.projects[uint.Parse(cmbbxID.SelectedValue.ToString())].ID;
                labName.Text = mainWnd.BugTrackingSystem.projects[id].Name;
                rchtxtbxDescr.Text = mainWnd.BugTrackingSystem.projects[id].Description;
            }
            else
            {
                uint id = mainWnd.BugTrackingSystem.projects[uint.Parse(cmbbxID.SelectedValue.ToString())].ID;
                txtbxName.Text = mainWnd.BugTrackingSystem.projects[id].Name;
                rchtxtbxDescr.Text = mainWnd.BugTrackingSystem.projects[id].Description;
            }
        }
    }
}
