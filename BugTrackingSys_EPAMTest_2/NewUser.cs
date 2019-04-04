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
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void NewUser_Shown(object sender, EventArgs e)
        {
            MainWnd mainWnd = (this.Owner as MainWnd);
            cmbbxPos.DataSource = new List<string>() { "Head", "Developer", "Tester" };
            cmbbxPos.SelectedIndex = 0;
            labID.Text = (mainWnd.BugTrackingSystem.employees[mainWnd.BugTrackingSystem.employees.Keys.Last()].ID + 1).ToString();
        }

        private void BtnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                MainWnd mainWnd = (this.Owner as MainWnd);
                uint id = mainWnd.BugTrackingSystem.employees[mainWnd.BugTrackingSystem.employees.Keys.Last()].ID + 1;
                EmpPosition pos = (EmpPosition)Enum.Parse(typeof(EmpPosition), cmbbxPos.SelectedValue.ToString());
                Employee t = new Employee(id, txtbxName.Text, pos);

                mainWnd.BugTrackingSystem.Insert(new Employees(new List<Employee>() { t }));
                (mainWnd.changed_emp as Employees).AddItemKey(t);
                mainWnd.emp_oper.Add(SQCommands.Insert);
                DialogResult = DialogResult.OK;
            }
            catch (AccessRightsException a)
            {
                MessageBox.Show(a.Message, "Нарушение прав доступа!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
