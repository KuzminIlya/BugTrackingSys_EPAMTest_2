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
    public partial class NewTask : Form
    {
        public NewTask()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                MainWnd mainWnd = (this.Owner as MainWnd);
                uint id;
                uint exemp_id, addemp_id, proj_id;
                exemp_id = uint.Parse(bxExec.SelectedValue.ToString().Substring(0, bxExec.SelectedValue.ToString().IndexOf(':')));
                addemp_id = uint.Parse(lab_AddedName.Text.Substring(0, lab_AddedName.Text.IndexOf(':')));
                proj_id = uint.Parse(bxPrj.SelectedValue.ToString().Substring(0, bxPrj.SelectedValue.ToString().IndexOf(':')));
                TaskStatus stat = chckbx_SetStatus.Checked ? (TaskStatus)Enum.Parse(typeof(TaskStatus), bxSetStatus.SelectedValue.ToString()) :
                                    (TaskStatus)Enum.Parse(typeof(TaskStatus), lab_Status.Text);
                if (mainWnd.isAddedTask) id = mainWnd.BugTrackingSystem.tasks[mainWnd.BugTrackingSystem.tasks.Keys.Last()].ID + 1;
                else id = uint.Parse(bx_ID.SelectedValue.ToString());
                Task t = new Task(id, bxTheme.Text, proj_id, 
                              (TaskType)Enum.Parse(typeof(TaskType), bxType.SelectedValue.ToString()),
                                (TaskPriority)Enum.Parse(typeof(TaskPriority), bxPrioryty.SelectedValue.ToString()),
                                addemp_id, exemp_id, stat, rchtxtbxDescr.Text);

                if (mainWnd.isAddedTask)
                {
                    mainWnd.BugTrackingSystem.Insert(new Tasks(new List<Task>() { t }));
                    (mainWnd.changed_tasks as Tasks).AddItemByKey(t);
                    mainWnd.tasks_oper.Add(SQCommands.Insert);
                }
                else
                {
                    mainWnd.BugTrackingSystem.Update(new Tasks(new List<Task>() { t }));
                    (mainWnd.changed_tasks as Tasks).AddItemByKey(t);
                    mainWnd.tasks_oper.Add(SQCommands.Update);
                }
                DialogResult = DialogResult.OK;
            }
            catch(LinkError l)
            {
                MessageBox.Show(l.Message, "Нарушения связности объектов системы!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (AccessRightsException a)
            {
                MessageBox.Show(a.Message, "Нарушение прав доступа!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (BTSystemException b)
            {
                MessageBox.Show(b.Message, "Нарушение логики системы!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NewTask_Shown(object sender, EventArgs e)
        {
            MainWnd mainWnd = (this.Owner as MainWnd);
            bxPrj.DataSource = (from keys in mainWnd.BugTrackingSystem.projects.Keys
                                select string.Format("{0}: {1}", keys.ToString(), mainWnd.BugTrackingSystem.projects[keys].Name)).ToList<string>();
            bxExec.DataSource = (from keys in mainWnd.BugTrackingSystem.employees.Keys
                                 select string.Format("{0}: {1}", keys.ToString(), mainWnd.BugTrackingSystem.employees[keys].Name)).ToList<string>();
            bxType.DataSource = new List<string>() { "Task", "Error", "Improvement" };
            bxPrioryty.DataSource = new List<string>() { "NotAssigned", "Low", "Medium", "High", "Critical" };
            bxSetStatus.DataSource = new List<string>() { "New", "InProcess", "Resolved", "NotResolved", "InTesting", "Tested", "Completed", "Rejected" };
            bxPrj.SelectedIndex = bxExec.SelectedIndex = bxType.SelectedIndex = bxPrioryty.SelectedIndex = bxSetStatus.SelectedIndex = 0;
            if (mainWnd.isAddedTask)
            {
                Lab_ID.Text = (mainWnd.BugTrackingSystem.tasks[mainWnd.BugTrackingSystem.tasks.Keys.Last()].ID + 1).ToString();
            }
            else
            {
                bx_ID.DataSource = mainWnd.BugTrackingSystem.tasks.Keys.ToList();
            }
        }

        private void Chckbx_SetStatus_CheckedChanged(object sender, EventArgs e)
        {
            bxSetStatus.Enabled = chckbx_SetStatus.Checked;
        }

        private void Bx_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainWnd mainWnd = (this.Owner as MainWnd);
            uint id = uint.Parse(bx_ID.SelectedValue.ToString());
            uint proj_id = mainWnd.BugTrackingSystem.tasks[id].ProjectID, 
                 added_id = mainWnd.BugTrackingSystem.tasks[id].AddedEmployeeID, 
                 ex_id = mainWnd.BugTrackingSystem.tasks[id].ExecutorEmployeeID;
            string ProjName = mainWnd.BugTrackingSystem.projects[proj_id].Name;
            string ExName = mainWnd.BugTrackingSystem.employees[ex_id].Name;
            string TaskType = mainWnd.BugTrackingSystem.tasks[id].Type.ToString();
            string TaskPrior = mainWnd.BugTrackingSystem.tasks[id].Priority.ToString();
            bxTheme.Text = mainWnd.BugTrackingSystem.tasks[id].Theme;
            rchtxtbxDescr.Text = mainWnd.BugTrackingSystem.tasks[id].Description;
            lab_AddedName.Text = string.Format("{0}: {1}", mainWnd.BugTrackingSystem.employees[added_id].ID,
                                                mainWnd.BugTrackingSystem.employees[added_id].Name);
            lab_Status.Text = mainWnd.BugTrackingSystem.tasks[id].Status.ToString();
            bxPrj.SelectedIndex = bxPrj.Items.IndexOf(string.Format("{0}: {1}", proj_id, ProjName));
            bxExec.SelectedIndex = bxExec.Items.IndexOf(string.Format("{0}: {1}", ex_id, ExName));
            bxType.SelectedIndex = bxType.Items.IndexOf(TaskType);
            bxPrioryty.SelectedIndex = bxPrioryty.Items.IndexOf(TaskPrior);
        }
    }
}
