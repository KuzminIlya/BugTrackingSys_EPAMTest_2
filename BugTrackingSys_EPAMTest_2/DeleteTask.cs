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
    public partial class DeleteTask : Form
    {
        public DeleteTask()
        {
            InitializeComponent();
        }

        uint projid = 0, addid = 0, exid = 0;
        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                MainWnd mainWnd = (this.Owner as MainWnd);
                uint id = uint.Parse(cmbbxID.SelectedValue.ToString());
                Task t = new Task(id, labTheme.Text, projid,
                              (TaskType)Enum.Parse(typeof(TaskType), labType.Text),
                              (TaskPriority)Enum.Parse(typeof(TaskPriority), labPrior.Text),
                              addid, exid, (TaskStatus)Enum.Parse(typeof(TaskStatus), labStat.Text), rchtxtDescr.Text);
                mainWnd.BugTrackingSystem.Delete(new Tasks(new List<Task>() { t }));
                (mainWnd.changed_tasks as Tasks).AddItemByKey(t);
                mainWnd.tasks_oper.Add(SQCommands.Delete);
                DialogResult = DialogResult.OK;
            }
            catch (AccessRightsException a)
            {
                MessageBox.Show(a.Message, "Нарушение прав доступа!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteTask_Shown(object sender, EventArgs e)
        {
            List<uint> t = new List<uint>();
            foreach (uint key in (this.Owner as MainWnd).BugTrackingSystem.tasks.Keys)
                t.Add((this.Owner as MainWnd).BugTrackingSystem.tasks[key].ID);
            cmbbxID.DataSource = t;
            cmbbxID.SelectedIndex = 0;
        }

        private void BtnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void CmbbxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainWnd mainWnd = (this.Owner as MainWnd);
            uint id = uint.Parse(cmbbxID.SelectedValue.ToString());
            projid = mainWnd.BugTrackingSystem.tasks[id].ProjectID;
            addid = mainWnd.BugTrackingSystem.tasks[id].AddedEmployeeID;
            exid = mainWnd.BugTrackingSystem.tasks[id].ExecutorEmployeeID;
            string ProjName = mainWnd.BugTrackingSystem.projects[projid].Name;
            string ExName = mainWnd.BugTrackingSystem.employees[exid].Name;
            string TaskType = mainWnd.BugTrackingSystem.tasks[id].Type.ToString();
            string TaskPrior = mainWnd.BugTrackingSystem.tasks[id].Priority.ToString();
            labTheme.Text = mainWnd.BugTrackingSystem.tasks[id].Theme;
            rchtxtDescr.Text = mainWnd.BugTrackingSystem.tasks[id].Description;
            labAddName.Text = string.Format("{0}: {1}", mainWnd.BugTrackingSystem.employees[addid].ID,
                                                mainWnd.BugTrackingSystem.employees[addid].Name);
            labStat.Text = mainWnd.BugTrackingSystem.tasks[id].Status.ToString();
            labProj.Text = string.Format("{0}: {1}", projid, ProjName);
            labExName.Text = string.Format("{0}: {1}", exid, ExName);
            labType.Text = TaskType;
            labPrior.Text = TaskPrior;
        }
    }
}
