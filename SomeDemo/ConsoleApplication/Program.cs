using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        delegate string MyDelegate(string name);
        static void Main(string[] args)
        {
            #region  Dictionary字典集合使用Demo
            ////一、创建泛型哈希表，然后加入元素
            //Dictionary<string, string> oscar = new Dictionary<string, string>();
            //oscar.Add("哈莉?贝瑞", "《死囚之舞》");
            //oscar.Add("朱迪?丹奇", "《携手人生》");
            //oscar.Add("尼科尔?基德曼", "《红磨坊》");
            //oscar.Add("詹妮弗?康纳利", "《美丽心灵》");
            //oscar.Add("蕾妮?齐维格", "《BJ单身日记》");

            ////二、删除元素
            //oscar.Remove("詹妮弗?康纳利");

            ////三、假如不存在元素则加入元素
            //if (!oscar.ContainsKey("茜茜?斯派克")) oscar.Add("茜茜?斯派克", "《不伦之恋》");


            ////四、显然容量和元素个数
            //Console.WriteLine("元素个数: {0}", oscar.Count);

            ////五、遍历集合
            //Console.WriteLine("74届奥斯卡最佳女主角及其电影：");
            //foreach (KeyValuePair<string, string> kvp in oscar)
            //{
            //    Console.WriteLine("姓名：{0},电影：{1}", kvp.Key, kvp.Value);
            //}

            ////六、得到哈希表中键的集合
            //Dictionary<string, string>.KeyCollection keyColl = oscar.Keys;
            ////遍历键的集合
            //Console.WriteLine("最佳女主角：");
            //foreach (string s in keyColl)
            //{
            //    Console.WriteLine(s);
            //}

            ////七、得到哈希表值的集合
            //Dictionary<string, string>.ValueCollection valueColl = oscar.Values;
            ////遍历值的集合
            //Console.WriteLine("最佳女主角电影：");
            //foreach (string s in valueColl)
            //{
            //    Console.WriteLine(s);
            //}

            ////八、使用TryGetValue方法获取指定键对应的值
            //string slove = string.Empty;
            //if (oscar.TryGetValue("朱迪?丹奇", out slove))
            //    Console.WriteLine("我最喜欢朱迪?丹奇的电影{0}", slove);
            //else
            //    Console.WriteLine("没找到朱迪?丹奇的电影");

            ////九、清空哈希表
            //oscar.Clear();
            //Console.ReadLine();


            #endregion

            #region  向TXT中写入字符串

            /*****01*****/
            //WriteStrToTxtUseFileStream(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss \t") + "使用FileStream对象向TXT中追加字符串");

            /*****02*****/
            //WriteStrToTxtUseStreamWriter(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss \t") + "使用StreamWriter对象向TXT中追加字符串");

            #endregion

            #region Thread的使用

            // 使用无参数委托ThreadStart
            //Thread t = new Thread(Go);
            //t.Start();
            //Console.WriteLine("时间戳：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            //// 使用带参数委托ParameterizedThreadStart
            ////Thread t2 = new Thread(GoWithParam);
            ////t2.Start("Message from main.");
            ////t2.Join();// 等待线程t2完成。
            ////Console.WriteLine("Thread t2 has ended!" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            //Console.ReadKey();

            #endregion

            #region 郑

            //ThreadMessage("Main Thread");
            ////建立委托
            //MyDelegate myDelegate = new MyDelegate(Hello);
            ////建立Person对象
            //Person person = new Person();
            //person.Name = "Elva";
            //person.Age = 27;
            ////异步调用委托，输入参数对象person, 获取计算结果
            //myDelegate.BeginInvoke("Leslie", new AsyncCallback(Completed), person);
            ////在启动异步线程后，主线程可以继续工作而不需要等待
            //for (int n = 0; n < 6; n++)
            //    Console.WriteLine("  Main thread do work!");
            //Console.WriteLine("");
            //Console.ReadKey();

            #endregion

            #region 测试能否对为null的List执行linq查询操作

            //List<User> strList = new List<User>();
            //User p = new User();
            //User p1 = strList.Where(a => a.Name == "0").FirstOrDefault();
            //string name = p.Name;
            #endregion

            #region 求两个数组的差异集
            //string[] arrRate = new string[] { "a", "b", "c", "d" };//A
            //string[] arrTemp = new string[] { "c", "d", "e" };//B
            //string[] arrUpd = arrRate.Intersect(arrTemp).ToArray();//相同的数据 （结果：c,d）
            //Console.WriteLine("============arrRate和arrTemp两个数组相同的数据集是：===========");
            //foreach (var item in arrUpd)
            //{
            //    Console.WriteLine(item);
            //}
            //string[] arrAdd = arrRate.Except(arrTemp).ToArray();//A中有B中没有的 （结果：a,b）
            //Console.WriteLine("============arrRate和arrTemp两个数组A中有B中没有的是：===========");
            //foreach (var item in arrAdd)
            //{
            //    Console.WriteLine(item);
            //}
            //string[] arrNew = arrTemp.Except(arrRate).ToArray();//B中有A中没有的 （结果：e）
            //Console.WriteLine("============arrRate和arrTemp两个数组B中有A中没有是：===========");
            //foreach (var item in arrNew)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region 找出List和数组中的某列的所有值，然后求差异集

            //List<Student> user = new List<Student>() { 
            //    new Student { Id = 1, Name = "陈明亮" }, 
            //    new Student { Id = 2, Name = "陈亮" } };
            //Student[] usera = new Student[] { 
            //    new Student { Id = 1, Name = "陈亮" },
            //};

            //int[] list = user.Select(a => a.Id).ToArray();
            //Console.WriteLine("获取list中的id列的所有值为：");
            //foreach (int item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //int[] array = usera.ToArray().Select(a => a.Id).ToArray();
            //Console.WriteLine("获取array中的id列的所有值为：");
            //foreach (int item in array)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("list中有的array中没有的【方法1】为：");
            //int[] diff = list.Except(array).ToArray();
            //foreach (int item in diff)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("list中有的array中没有的【方法2】为：");
            //foreach (Student item in user)
            //{
            //    if (!array.Contains(item.Id))
            //    {
            //        Console.WriteLine(item.Id);
            //    }
            //}


            #endregion

            #region 面试题
            //List<Teacher> t = new List<Teacher>()
            //{                
            //    new Teacher(){
            //        Id = 1,
            //        Name = "张老师"
            //    },
            //    new Teacher(){
            //        Id = 2,
            //        Name = "陈老师"
            //    },
            //    new Teacher(){
            //        Id = 3,
            //        Name = "王老师"
            //    },
            //};

            //List<Group> g = new List<Group>()
            //{                
            //    new Group(){
            //        Id = 1,
            //        Name = "VIP班"
            //    },
            //    new Group(){
            //        Id = 2,
            //        Name = "普通班"
            //    },
            //    new Group(){
            //        Id = 3,
            //        Name = "周末班"
            //    },
            //};
            //List<Student> s = new List<Student>()
            //{
            //    new Student(){
            //        SId=1,
            //        SName="小明",
            //        TeacherId=1,
            //        GroupId=1
            //    },
            //    new Student(){
            //        SId=2,
            //        SName="小红",
            //        TeacherId=2,
            //        GroupId=2
            //    },
            //    new Student(){
            //        SId=3,
            //        SName="小白",
            //        TeacherId=3,
            //        GroupId=3
            //    }
            //};

            //List<Result> rList = new List<Result>();
            //foreach (Student sitem in s)
            //{
            //    int tid = sitem.TeacherId;
            //    int gid = sitem.GroupId;
            //    string sname = t.Where(a => a.Id == tid).FirstOrDefault().Name;
            //    string gname = g.Where(a => a.Id == gid).FirstOrDefault().Name;
            //    Result r = new Result() { TeacherName = sname, GroupName = gname, Num = 1 };
            //    rList.Add(r);
            //}

            //foreach (Teacher item in t)
            //{

            //}




            #endregion

            #region 时间日期比较大小
            //DateTime oldtime = Convert.ToDateTime("1900-01-01");
            ////DateTime newtime = DateTime.Now;
            ////DateTime newtime = Convert.ToDateTime("1900-01-01");
            //DateTime newtime = Convert.ToDateTime("2017-10-10"); ;
            //if (DateTime.Compare(oldtime, newtime) <= 0)
            //{
            //    Console.WriteLine("oldtime早于或等于newtime");
            //}
            //else
            //{
            //    Console.WriteLine("oldtime晚于newtime");
            //}
            #endregion

            #region 邮箱校验
            //List<string> strlist = new List<string>();

            //Regex r = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            //foreach (string item in strlist)
            //{
            //    if (!r.IsMatch(item))
            //    {
            //        Console.WriteLine(item + "     这个邮箱正则校验不通过。");
            //    }
            //}
            #endregion

            #region 列出当前进程
            //List<string> processes = new List<string>();
            //foreach (Process item in Process.GetProcesses())
            //{
            //    processes.Add(item.ProcessName);
            //}
            //foreach (var item in processes)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            //TestReferrenceParam();

            #region 绝对值
            absTest();
            #endregion

        }

        /// <summary>
        /// 使用FileStream对象向TXT中写入内容
        /// </summary>
        /// <param name="str"></param>
        private static void WriteStrToTxtUseFileStream(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
                byte[] bytes = Encoding.UTF8.GetBytes(str);
                if (File.Exists(path))
                {
                    FileStream fs = null;
                    try
                    {
                        fs = File.OpenWrite(path);
                        fs.Position = fs.Length;
                        fs.Write(bytes, 0, bytes.Length);
                    }
                    catch { }
                    finally
                    {
                        fs.Flush();
                        fs.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 使用StreamWriter对象向TXT中追加字符串
        /// </summary>
        /// <param name="str"></param>
        private static void WriteStrToTxtUseStreamWriter(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
                if (File.Exists(path))
                {
                    StreamWriter sw = File.AppendText(path);
                    sw.WriteLine(str);
                    sw.Flush();
                    sw.Close();
                }
            }
        }

        static void Go()
        {
            Thread.Sleep(3000);// 模拟耗时操作
            Console.WriteLine("Go!" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
        }

        static void GoWithParam(object msg)
        {
            Console.WriteLine("Go With Param! Message: " + msg + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            Thread.Sleep(3000);// 模拟耗时操作
        }

        /// <summary>
        /// 你好
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static string Hello(string name)
        {
            ThreadMessage("Async Thread");
            Thread.Sleep(2000);
            return "\nHello " + name;
        }

        static void Completed(IAsyncResult result)
        {
            ThreadMessage("Async Completed");
            //获取委托对象，调用EndInvoke方法获取运行结果
            AsyncResult _result = (AsyncResult)result;
            MyDelegate myDelegate = (MyDelegate)_result.AsyncDelegate;
            string data = myDelegate.EndInvoke(_result);
            //获取Person对象
            Person person = (Person)result.AsyncState;
            string message = person.Name + "'s age is " + person.Age.ToString();
            Console.WriteLine(data + "\n" + message);
        }

        static void ThreadMessage(string data)
        {
            string message = string.Format("{0}\n  ThreadId is:{1}", data, Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(message);
        }

        static void TestReferrenceParam()
        {
            Dictionary<int, string> dicemail = new Dictionary<int, string>();
            dicemail.Add(1, "cml");
            UpdateReferrenceParam(dicemail);
            foreach (KeyValuePair<int, string> item in dicemail)
            {
                int key = item.Key;
                string value = item.Value;
            }
        }

        private static void UpdateReferrenceParam(Dictionary<int, string> dicemail)
        {
            dicemail.Add(2, "hn");
        }

        private static void absTest()
        {
            //对负整数Convert        
            int a = -105;
            int b = Convert.ToInt32(-105);
            //负数或者0求绝对值
            int c = 0, d = -5;
            int e = Math.Abs(c);
            int f = Math.Abs(d);

        }

    }


    public class Person
    {
        public string Name;
        public int Age;
    }

    public class User
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = 0; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = ""; }
        }
    }

    //public class Student
    //{
    //    public int Id;
    //    public string Name;
    //}

    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Student
    {
        public int SId { get; set; }
        public string SName { get; set; }
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
    }

    public class Result
    {
        public string TeacherName { get; set; }
        public string GroupName { get; set; }
        public int Num { get; set; }
    }
}
