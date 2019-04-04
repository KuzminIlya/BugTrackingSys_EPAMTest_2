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
    public partial class ChangeDel_User : Form
    {
        public ChangeDel_User()
        {
            InitializeComponent();
        }

        private void ChangeDel_User_Shown(object sender, EventArgs e)
        {
            MainWnd mainWnd = (this.Owner as MainWnd);
            List<string> t = new List<string>();
            foreach (uint key in mainWnd.BugTrackingSystem.employees.Keys)
                t.Add(mainWnd.BugTrackingSystem.employees[key].ID.ToString());
            cmbbxID.DataSource = t;
            cmbbxID.SelectedIndex = 0;
            if (mainWnd.isDeleteUserPrj)
            {
                uint id = mainWnd.BugTrackingSystem.employees[uint.Parse(cmbbxID.SelectedValue.ToString())].ID;
                this.Text = "Удалить пользователя";
                txtbxName.Visible = false;
                cmbbxPos.Visible = false;
                labName.Visible = true;
                labPos.Visible = true;
                labName.Text = mainWnd.BugTrackingSystem.employees[id].Name;
                labPos.Text = mainWnd.BugTrackingSystem.employees[id].Position.ToString();
            }
            else
            {
                uint id = mainWnd.BugTrackingSystem.employees[uint.Parse(cmbbxID.SelectedValue.ToString())].ID;
                this.Text = "Изменить пользователя";
                txtbxName.Visible = true;
                cmbbxPos.Visible = true;
                labName.Visible = false;
                labPos.Visible = false;
                cmbbxPos.DataSource = new List<string>() { "Head", "Developer", "Tester" };
                txtbxName.Text = mainWnd.BugTrackingSystem.employees[id].Name;
                cmbbxPos.SelectedIndex = cmbbxPos.Items.IndexOf(mainWnd.BugTrackingSystem.employees[id].Position.ToString());
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
                    uint id = mainWnd.BugTrackingSystem.employees[uint.Parse(cmbbxID.SelectedValue.ToString())].ID;
                    EmpPosition pos = (EmpPosition)Enum.Parse(typeof(EmpPosition), labPos.Text);
                    Employee emp = new Employee(id, txtbxName.Text, pos);

                    mainWnd.BugTrackingSystem.Delete(new Employees(new List<Employee>() { emp }));
                    (mainWnd.changed_emp as Employees).AddItemKey(emp);
                    mainWnd.emp_oper.Add(SQCommands.Delete);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    uint id = mainWnd.BugTrackingSystem.employees[uint.Parse(cmbbxID.SelectedValue.ToString())].ID;
                    EmpPosition pos = (EmpPosition)Enum.Parse(typeof(EmpPosition), cmbbxPos.SelectedValue.ToString());
                    Employee emp = new Employee(id, txtbxName.Text, pos);

                    mainWnd.BugTrackingSystem.Update(new Employees(new List<Employee>() { emp }));
                    (mainWnd.changed_emp as Employees).AddItemKey(emp);
                    mainWnd.emp_oper.Add(SQCommands.Update);
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
                uint id = mainWnd.BugTrackingSystem.employees[uint.Parse(cmbbxID.SelectedValue.ToString())].ID;
                labName.Text = mainWnd.BugTrackingSystem.employees[id].Name;
                labPos.Text = mainWnd.BugTrackingSystem.employees[id].Position.ToString();
            }
            else
            {
                uint id = mainWnd.BugTrackingSystem.employees[uint.Parse(cmbbxID.SelectedValue.ToString())].ID;
                txtbxName.Text = mainWnd.BugTrackingSystem.employees[id].Name;
                cmbbxPos.SelectedIndex = cmbbxPos.Items.IndexOf(mainWnd.BugTrackingSystem.employees[id].Position.ToString());
            }
        }
    }
}
