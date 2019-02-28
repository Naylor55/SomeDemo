using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable("data");
        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("age", typeof(string));
            dt.Rows.Add("1", "陈明亮", 18);
            dt.Rows.Add("2", "陈名", 19);
            dt.Rows.Add("3", "陈亮", 19);
            this.dataGridView1.DataSource = dt;



        }

        /// <summary>
        /// 按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.EndEdit();
            var comdt = dt;
        }

        /// <summary>
        /// DGV单元格内容点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn dgvc = this.dataGridView1.Columns[e.ColumnIndex];
                if (dgvc is DataGridViewButtonColumn && dgvc.Name == "shouhuo")
                {
                    //收货的点击

                }
                if (dgvc is DataGridViewButtonColumn && dgvc.Name == "ruku")
                {
                    //入库的点击

                }
            }
        }




    }
}
