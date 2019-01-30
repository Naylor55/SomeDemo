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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 打印（将打印内容输出到打印机进行打印）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Print_Click(object sender, EventArgs e)
        {
            Program.FindOrCreateFrom(typeof(Print));
        }

        private void btn_DgvPartialRender_Click(object sender, EventArgs e)
        {
            Program.FindOrCreateFrom(typeof(DgvPartialRender));
        }
    }
}
