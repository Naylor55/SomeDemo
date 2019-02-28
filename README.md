# SomeDemo
积累的一下代码片段。
工具类
开发常用的一些功能的封装


## 控制台程序单例运行
### 核心代码
~~~ c#

  static void Main(string[] args)
  {
            bool appIsRuning = false;
            Mutex mutex = new Mutex(true, System.Diagnostics.Process.GetCurrentProcess().ProcessName, out appIsRuning);
            if (!appIsRuning)
            {
                Console.WriteLine("应用已经在运行。");
                Console.WriteLine("按任意键退出");
                Console.ReadKey();
                Environment.Exit(1);
            }
            string app = ConsoleSingleton.run();
            Console.WriteLine(app);
            Console.ReadLine();
  }

~~~