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
    public partial class SetUser : Form
    {
        public SetUser()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void Btn_SetUser_Click(object sender, EventArgs e)
        {
            MainWnd mainWnd = (this.Owner as MainWnd);
            mainWnd.CurrentUser = mainWnd.BugTrackingSystem.employees[(uint)cmbbx_ID.SelectedValue];
            mainWnd.Text = string.Format("Добро пожаловать, {0}! Ваша должность: {1}. Ваш ID: {2}", 
                                            mainWnd.CurrentUser.Name, mainWnd.CurrentUser.Position, mainWnd.CurrentUser.ID);
            DialogResult = DialogResult.OK;
        }

        private void SetUser_Shown(object sender, EventArgs e)
        {
            MainWnd mainWnd = (this.Owner as MainWnd);
            cmbbx_ID.DataSource = new List<uint>(mainWnd.BugTrackingSystem.employees.Keys.ToList());
            if (mainWnd.isUserLogIn) // отобразить текущего
            {
                foreach(uint id in cmbbx_ID.Items)
                    if(id == mainWnd.CurrentUser.ID)
                    {
                        cmbbx_ID.SelectedItem = id;
                        break;
                    }
            }
            else // по умолчанию отображается первый элемент в списке
            {
                cmbbx_ID.SelectedIndex = 0;
            }
        }

        private void Cmbbx_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainWnd mainWnd = (this.Owner as MainWnd);
            lab_Name.Text = mainWnd.BugTrackingSystem.employees[(uint)cmbbx_ID.SelectedValue].Name;
            lab_Emp.Text = mainWnd.BugTrackingSystem.employees[(uint)cmbbx_ID.SelectedValue].Position.ToString();
        }
    }
}
