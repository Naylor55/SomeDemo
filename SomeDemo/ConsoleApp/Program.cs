using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
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

            #region 控制台应用单例模式运行
            //bool appIsRuning = false;
            //Mutex mutex = new Mutex(true, System.Diagnostics.Process.GetCurrentProcess().ProcessName, out appIsRuning);
            //if (!appIsRuning)
            //{
            //    Console.WriteLine("应用已经在运行。");
            //    Console.WriteLine("按任意键退出");
            //    Console.ReadKey();
            //    Environment.Exit(1);
            //}
            //string app = ConsoleSingleton.run();
            //Console.WriteLine(app);
            //Console.ReadLine();
            #endregion

            #region 生成随机数
            //System.Random random = new System.Random((int)System.DateTime.Now.Ticks);
            //var str = string.Concat(random.Next(10000001, 99999999));
            #endregion


            #region  List 去重
            //List<string> list = new List<string> { "中性笔", "得力", "中性笔" };
            //list = list.Distinct().ToList();
            #endregion

            #region  加密解密

            //string key = "ABCDEFGHIJKLMNOP";
            //string clearText = "欢迎访问www.tracefact.net";
            //CryptoHelper helper = new CryptoHelper(key);
            //string encryptedText = helper.Encrypt(clearText);
            //Console.WriteLine(encryptedText);
            //clearText = CryptoHelper.Decrypt(encryptedText, key);
            //Console.WriteLine(clearText);

            #endregion

            #region   List的Contains

            //List<string> list = new List<string>() {
            //    "得力","得力1"
            //};
            //bool one = list.Contains("得力");

            #endregion

            #region TXT 去重
            // 读取 txt        
            //List<string> list = Tool.ReadTextFileToList(AppDomain.CurrentDomain.BaseDirectory + "\\dict.txt");
            //Console.WriteLine("list的长度为：" + list.Count);
            //Console.WriteLine("去重");
            //List<string> list1 = list.Distinct().ToList();
            //Console.WriteLine("list去重后的长度为：" + list1.Count);
            //Console.WriteLine("去重后重新写入txt");
            //foreach (string item in list1)
            //{
            //    WriteStrToTxtUseFileStream(item);
            //}
            //Console.WriteLine("去重后重新写入完毕");
            //Console.Read();

            #endregion

            #region  字符串分词
            string str = "陈明亮";
            Console.WriteLine("关键字为：" + str);
            List<string> list = Tool.ReadTextFileToList(AppDomain.CurrentDomain.BaseDirectory + "\\dict.txt");
            List<string> data = Tool.FindSearchWords(str, ref list);
            Console.WriteLine("匹配的结果为：");
            data.ForEach(delegate (string s)
            {
                Console.WriteLine(s);
            });
            Console.Read();
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
                string path = AppDomain.CurrentDomain.BaseDirectory + "dict5.txt";
                byte[] bytes = Encoding.UTF8.GetBytes(str + "\r\n");
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

    public class Student
    {
        public int Id;
        public string Name;
    }
}
