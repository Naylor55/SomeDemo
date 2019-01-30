using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }


        public static List<Form> formList = new List<Form>();
        /// <summary>
        /// 找窗体或创建窗体的方法
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static Form FindOrCreateFrom(Type type)
        {
            Form form = null;
            foreach (Form formItem in Program.formList)
            {
                if (formItem.GetType() == type)
                {
                    form = formItem;
                    form.Activate();
                    break;
                }
            }
            if (form == null)
            {
                object obj = Activator.CreateInstance(type);
                if (obj is Form)
                {
                    form = obj as Form;
                    form.Show();
                }
            }
            return form;
        }
    }
}
