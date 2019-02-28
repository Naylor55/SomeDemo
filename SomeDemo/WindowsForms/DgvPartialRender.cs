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
    public partial class DgvPartialRender : Form
    {
        private DateTime lastLoading;
        private int firstVisibleRow;
        private ScrollBars gridScrollBars;
        public DgvPartialRender()
        {
            InitializeComponent();
            
            dataGridView1.Scroll += new ScrollEventHandler(dataGridView1_Scroll);            
            LoadRows();
        }
        private void HideScrollBars()
        {
            gridScrollBars = dataGridView1.ScrollBars;
            dataGridView1.ScrollBars = ScrollBars.None;
        }
        //在这里，将datagridview的滑动条显示出来。这时，滑动条的位置会根据行数的变化而变化。
        private void ShowScrollBars()
        {
            dataGridView1.ScrollBars = gridScrollBars;
        }
        //获取显示的行数
        private int GetDisplayedRowsCount()
        {
            int count = dataGridView1.Rows[dataGridView1.FirstDisplayedScrollingRowIndex].Height;
            count = dataGridView1.Height / count;
            return count;
        }

        private void LoadRows()
        {
            HideScrollBars();
            System.Diagnostics.Debug.WriteLine("Load data");
            lastLoading = DateTime.Now;
            //create rows  
            for (int i = 0; i < 100; i++)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = "Row - " + n.ToString();
            }
            //reset displayed row  
            if (firstVisibleRow > -1)
            {
                ShowScrollBars();
                dataGridView1.FirstDisplayedScrollingRowIndex = firstVisibleRow;
            }
        }

        void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.SmallIncrement || e.Type == ScrollEventType.LargeIncrement)
            {
                if (e.NewValue >= dataGridView1.Rows.Count - GetDisplayedRowsCount())
                {
                    //prevent loading from autoscroll.  
                    TimeSpan ts = DateTime.Now - lastLoading;
                    if (ts.TotalMilliseconds > 100)
                    {
                        firstVisibleRow = e.NewValue;
                        LoadRows();
                    }
                    else
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = e.OldValue;
                    }
                }
            }
        }
    }
}
