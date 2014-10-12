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
    public partial class Form1 : Form
    {
        #region private_parameter
        private String[] strColumn = { "タイトル", "録画日時", "残り時間", "録画時間", "入力端子", "チャンネル" };
        private ColumnHeader[] columnArray;
        #endregion

        #region private_function
        private void initListView()
        {
            try
            {
                listView1.View = View.Details;
                listView1.GridLines = true;

                this.columnArray = new ColumnHeader[this.strColumn.Length];
                for (int ii = 0; ii < this.strColumn.Length; ii++ )
                {
                    ColumnHeader col = new ColumnHeader();
                    col.Text = strColumn[ii];
                    columnArray.SetValue(col, ii);
                }
                
                listView1.Columns.AddRange(this.columnArray);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
            this.initListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CtrlParam cp = CtrlParam.getInstance();

            //Win32APIwrapper w32 = new Win32APIwrapper();
            //w32.EnumWindow();

            Form2 fm = new Form2();
            fm.ShowDialog();

            string[] tmp = new string[6];
            tmp[0] = cp.curTitle;
            tmp[1] = cp.curRecDateTime;
            tmp[2] = cp.curNextTime;
            tmp[3] = cp.curRecTime;
            tmp[4] = cp.curInDevice;
            tmp[5] = cp.curChannel;
            listView1.Items.Add(new ListViewItem(tmp));

            //string[] tmp = { "テスト番組", "2014/10/21 10:15", "120分", "30分", "A", "AT-X" };
            //listView1.Items.Add(new ListViewItem(tmp));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
