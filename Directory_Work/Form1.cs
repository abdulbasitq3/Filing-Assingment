using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Directory_Work
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            createbox.Visible = false;
            copybox.Visible = false;
            deletebox.Visible = false;
            movebox.Visible = false;


            DriveInfo[] drives = DriveInfo.GetDrives();
            //Create File comboBox
            comboBox1.Items.AddRange(drives);
            //Copy File comboBoxes
            comboBox4.Items.AddRange(drives);
            comboBox6.Items.AddRange(drives);
            //Delete File comboBox
            comboBox12.Items.AddRange(drives);
            //Move File comboBoxes
            comboBox8.Items.AddRange(drives);
            comboBox10.Items.AddRange(drives);
        }
        
        #region "Create File Section"
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(comboBox1.Text);
            DirectoryInfo[] Folder = dir.GetDirectories();
            comboBox2.DataSource = Folder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = comboBox1.Text + comboBox2.Text + "\\" + textBox3.Text + "." + textBox4.Text;
            if (!File.Exists(path))
            {
                File.Create(path);
                MessageBox.Show("File Created Successfully!");
            }
            else
                MessageBox.Show("File Already Exists, Please Rename it!");
        }
        #endregion
        #region "Delete File Section"
        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(comboBox12.Text);
            DirectoryInfo[] Folder = dir.GetDirectories();
            comboBox11.DataSource = Folder;
        }
            private void button4_Click(object sender, EventArgs e)
        {
            string path = comboBox12.Text + comboBox11.Text + "\\" + textBox6.Text + "." + textBox5.Text;
            if (File.Exists(path))
            {
                File.Delete(path);
                MessageBox.Show("File Deleted Successfully!");
            }
            else
                MessageBox.Show("File Does Not Exist!");
        }
        #endregion
        #region "Copy File Section"
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(comboBox4.Text);
            DirectoryInfo[] Folder = dir.GetDirectories();
            comboBox3.DataSource = Folder;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(comboBox6.Text);
            DirectoryInfo[] Folder = dir.GetDirectories();
            comboBox5.DataSource = Folder;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string path = comboBox4.Text + comboBox3.Text + "\\" + textBox2.Text;
            string path1 = comboBox6.Text + comboBox5.Text + "\\" + textBox2.Text;
            if (File.Exists(path))
            {
                File.Copy(path, path1);
                MessageBox.Show("File Copied Successfully!");
            }
            else
                MessageBox.Show("File Does Not Exist!");
        }
        #endregion
        #region "Move File Section"
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(comboBox10.Text);
            DirectoryInfo[] Folder = dir.GetDirectories();
            comboBox9.DataSource = Folder;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(comboBox8.Text);
            DirectoryInfo[] Folder = dir.GetDirectories();
            comboBox7.DataSource = Folder;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string path = comboBox10.Text + comboBox9.Text + "\\" + textBox1.Text;
            string path1 = comboBox8.Text + comboBox7.Text + "\\" + textBox1.Text;
            if (File.Exists(path))
            {
                File.Move(path,path1);
                MessageBox.Show("File Moved Successfully!");
            }
            else
                MessageBox.Show("File Does Not Exist!");
        }
        #endregion

        private void btncreate_Click(object sender, EventArgs e)
        {
            createbox.Visible = true;
            copybox.Visible = false;
            deletebox.Visible = false;
            movebox.Visible = false;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            createbox.Visible = false;
            copybox.Visible = false;
            deletebox.Visible = true;
            movebox.Visible = false;
        }

        private void btncopy_Click(object sender, EventArgs e)
        {
            createbox.Visible = false;
            copybox.Visible = true;
            deletebox.Visible = false;
            movebox.Visible = false;
        }

        private void btnmove_Click(object sender, EventArgs e)
        {
            createbox.Visible = false;
            copybox.Visible = false;
            deletebox.Visible = false;
            movebox.Visible = true;
        }
    }
}
