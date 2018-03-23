using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PENEXCErsize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox4.Text))
            {
                FileStream fs = new FileStream(textBox4.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<Pen>));
                    List<Pen> penCollection = (List<Pen>)xs.Deserialize(fs);
                    listBox1.Items.Clear();
                    foreach (Pen pen in penCollection)
                    {
                        listBox1.Items.Add(pen.GetPenInfo());
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    fs.Close();
                }
            }
            else
                MessageBox.Show("File is not Present At Location");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text)))
            {
                double prize = 0;
                if (double.TryParse(textBox3.Text, out prize))
                {
                    if (File.Exists(textBox4.Text))
                    {

                        try
                        {
                            FileStream fs = new FileStream(textBox4.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                            XmlSerializer xsRead = new XmlSerializer(typeof(List<Pen>));
                            List<Pen> listPens = (List<Pen>)xsRead.Deserialize(fs);
                            fs.Close();
                            FileStream fs1 = new FileStream(textBox4.Text, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                            XmlSerializer xsWrite = new XmlSerializer(typeof(List<Pen>));
                            Pen pen = new Pen(textBox1.Text, textBox2.Text, prize);
                            listPens.Add(pen);
                            xsWrite.Serialize(fs1, listPens);
                            fs1.Close();
                            MessageBox.Show("Pen Info Saved Successfully..");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            FileStream fs1 = new FileStream(textBox4.Text, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                            XmlSerializer xsWrite = new XmlSerializer(typeof(List<Pen>));
                            Pen pen = new Pen(textBox1.Text, textBox2.Text, prize);
                            List<Pen> listPens = new List<Pen>();
                            listPens.Add(pen);
                            xsWrite.Serialize(fs1, listPens);
                            fs1.Close();
                            MessageBox.Show("Pen Info Saved Successfully..");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }
                else
                    MessageBox.Show("Please EnterValid Prize..(int or double) ");
            }
            else
                MessageBox.Show("Please Enter Values Of Color,Brand and Prize..");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            radioButton1.Checked = true;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                        {
                            textBox4.Text = openFileDialog1.FileName;
                            button1.Enabled = true;
                            button2.Enabled = true;
                        }
                    }
                }
                else
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
                        {
                            textBox4.Text = saveFileDialog1.FileName;
                            button1.Enabled = true;
                            button2.Enabled = true;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
