using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace BugTrackingSys_EPAMTest_2
{
    public partial class SetDataSource : Form
    {   
        public SetDataSource()
        {
            InitializeComponent();
        }

        public string File_Path = "";
        public string File_Name = "";
        public static bool IsFileNameCorrect(string FileName)
        {
            string RegEX = @"[^a-zA-z\d_]";
            return !string.IsNullOrWhiteSpace(FileName) &&
                   !Regex.IsMatch(FileName, RegEX) &&
                   !string.IsNullOrEmpty(FileName);
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            if (chckbx_NewFile.Checked)
            {
                try
                {
                    if (!IsFileNameCorrect(txtBx_FileName.Text))
                    {
                        throw new WrongFileNameException();
                    }
                    if (!Directory.Exists(File_Path))
                    {
                        throw new DirectoryNotFoundException();
                    }
                    if (File.Exists(File_Path))
                    {
                        DialogResult = MessageBox.Show("Данный файл уже существует! Заменить?", "Файл существует!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                    if (this.Owner is MainWnd) (this.Owner as MainWnd).DataSourcePath = File_Path;
                    if (this.Owner is MainWnd) (this.Owner as MainWnd).DataSourceFileName = txtBx_FileName.Text;
                    File_Path += string.Format("\\{0}.db", txtBx_FileName.Text);
                    if (this.Owner is MainWnd) (this.Owner as MainWnd).DataSourceFullName = File_Path;
                    DialogResult = DialogResult.OK;
                }
                catch (WrongFileNameException)
                {
                    MessageBox.Show("Введите правильное имя файла", "Имя файла не корректно!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                }
                catch (DirectoryNotFoundException)
                {
                    MessageBox.Show("Такого пути не существует!", "Ошибка пути к файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                try
                {
                    if (!File.Exists(string.Format("{0}\\{1}", File_Path, File_Name)))
                    {
                        throw new DirectoryNotFoundException();
                    }
                    if (this.Owner is MainWnd) (this.Owner as MainWnd).DataSourceFullName = string.Format("{0}\\{1}", File_Path, File_Name);
                    if (this.Owner is MainWnd) (this.Owner as MainWnd).DataSourcePath = File_Path;
                    if (this.Owner is MainWnd) (this.Owner as MainWnd).DataSourceFileName = File_Name;

                    DialogResult = DialogResult.Yes;
                }
                catch (DirectoryNotFoundException)
                {
                    MessageBox.Show("Такого файла не существует!", "Ошибка пути к файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                }
            }
        }

        private void Btn_SelectPath_Click(object sender, EventArgs e)
        {
            if (!chckbx_NewFile.Checked)
            {
                if (filedlg_OpenDataSource.ShowDialog() == DialogResult.Cancel)
                    return;
                File_Path = Path.GetDirectoryName(filedlg_OpenDataSource.FileName);
                File_Name = Path.GetFileName(filedlg_OpenDataSource.FileName);
                txtBx_Path.Text = string.Format("{0}\\{1}",File_Path, File_Name);
            }
            else
            {
                if (foldbrowsdlg_DataSourcePath.ShowDialog() == DialogResult.Cancel)
                    return;
                File_Path = foldbrowsdlg_DataSourcePath.SelectedPath;
                txtBx_Path.Text = File_Path;
            }
        }

        private void Chckbx_NewFile_CheckedChanged(object sender, EventArgs e)
        {
            txtBx_FileName.Enabled = !txtBx_FileName.Enabled;
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }

    // Исключения
    public class WrongFileNameException : Exception { }
}
