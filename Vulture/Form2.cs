using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vulture
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            #region SET_DEFAULT_VALUE
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = dateTimePicker1.Value;
            dateTimePicker3.Value = dateTimePicker1.Value;
            dateTimePicker4.Value = dateTimePicker3.Value.AddMinutes(30);

            comboBox1.Items.Add("A");
            comboBox1.Items.Add("B");
            comboBox1.Text = "A";

            comboBox2.Items.Add("30");
            comboBox2.Items.Add("10");
            comboBox2.Items.Add("15");
            comboBox2.Items.Add("60");
            comboBox2.Items.Add("90");
            #endregion
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            CtrlParam cp = CtrlParam.getInstance();

            bool r_inf = cp.setRecSetting(checkBox8.Checked, textBox1.Text,
                                          radioButton2.Checked, textBox2.Text,
                                          textBox3.Text, comboBox1.SelectedItem.ToString(),
                                          dateTimePicker1.Value, dateTimePicker2.Value,
                                          checkBox9.Checked, dateTimePicker3.Value,
                                          dateTimePicker4.Value,
                                          Convert.ToInt32(numericUpDown1.Value),
                                          Convert.ToInt32(numericUpDown2.Value),
                                          Convert.ToInt32(numericUpDown3.Value));
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();

            textBox1.Text = fbd.SelectedPath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double incMinutes = Convert.ToDouble(comboBox2.Text);
            dateTimePicker3.Value = DateTime.Now;
            dateTimePicker4.Value = dateTimePicker3.Value.AddMinutes(incMinutes);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double incMinutes = Convert.ToDouble(comboBox2.Text);
            dateTimePicker4.Value = dateTimePicker4.Value.AddMinutes(incMinutes);
        }

        private void LastDayCheckedChange(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                dateTimePicker2.Enabled = true;
            }
            else
            {
                dateTimePicker2.Enabled = false;
            }
        }

        private void RecDisableCheckedChange(object sender, EventArgs e)
        {
            try
            {
                bool setVal = true;
                if (checkBox8.Checked == true)
                {
                    setVal = false;
                }

                button4.Enabled = setVal;
                button5.Enabled = setVal;

                label1.Enabled = setVal;
                label2.Enabled = setVal;
                label3.Enabled = setVal;
                label4.Enabled = setVal;
                label9.Enabled = setVal;

                comboBox1.Enabled = setVal;
                comboBox2.Enabled = setVal;

                radioButton1.Enabled = setVal;
                radioButton2.Enabled = setVal;

                checkBox1.Enabled = setVal;
                checkBox2.Enabled = setVal;
                checkBox3.Enabled = setVal;
                checkBox4.Enabled = setVal;
                checkBox5.Enabled = setVal;
                checkBox6.Enabled = setVal;
                checkBox7.Enabled = setVal;
                checkBox9.Enabled = setVal;

                textBox2.Enabled = setVal;
                textBox3.Enabled = setVal;

                dateTimePicker1.Enabled = setVal;
                dateTimePicker2.Enabled = setVal;
                dateTimePicker3.Enabled = setVal;
                dateTimePicker4.Enabled = setVal;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}
