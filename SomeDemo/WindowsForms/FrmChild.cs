using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public class FrmChild:Form
    {
        public FrmChild()
        {
            this.Load += new EventHandler(FrmChild_Load);
            this.FormClosed += new FormClosedEventHandler(FrmChild_FormClosed);
        }
        public void FrmChild_Load(object sender, EventArgs e)
        {
            Program.formList.Add(this);
        }

        public void FrmChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formList.Remove(this);
        }
    }
}
