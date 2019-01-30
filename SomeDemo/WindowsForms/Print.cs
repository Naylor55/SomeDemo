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
    public partial class Print : FrmChild
    {
        public Print()
        {
            InitializeComponent();
        }

        /// <summary>
        /// PrintDocument控件的PrintPage事件中绘制打印的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //通过GDI+绘制打印文档
            e.Graphics.DrawString("蝶恋花", new Font("宋体", 15), Brushes.Black, 350, 80);
            e.Graphics.DrawLine(new Pen(Color.Black, (float)3.00), 100, 185, 720, 185);
            e.Graphics.DrawString("伫倚危楼风细细，望极春愁，黯黯生天际。", new Font("宋体", 12), Brushes.Black, 110, 195);
            e.Graphics.DrawString("草色烟光残照里,无言谁会凭阑意。", new Font("宋体", 12), Brushes.Black, 110, 220);
            e.Graphics.DrawString("拟把疏狂图一醉,对酒当歌，强乐还无味。", new Font("宋体", 12), Brushes.Black, 110, 245);
            e.Graphics.DrawString("衣带渐宽终不悔。为伊消得人憔悴。", new Font("宋体", 12), Brushes.Black, 110, 270);
            e.Graphics.DrawLine(new Pen(Color.Black, (float)3.00), 100, 300, 720, 300);
        }

        /// <summary>
        /// 执行打印操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DoPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要预览打印文档", "打印预览", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //开启操作系统的防锯齿功能
                this.PrintPreviewDialog.UseAntiAlias = true;
                //设置要预览的文档
                this.PrintPreviewDialog.Document = this.PrintDoc;
                //打开预览窗口
                PrintPreviewDialog.ShowDialog();
            }
            else
            {
                //调用Print方法直接打印文档
                this.PrintDoc.PrinterSettings.PrinterName = this.lab_Printer.Text;
                this.PrintDoc.Print();
            }
        }

        /// <summary>
        /// 设置打印机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SetPrinter_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.ShowDialog();
            if (pd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.lab_Printer.Text = pd.PrinterSettings.PrinterName;
            }
        }
    }
}
