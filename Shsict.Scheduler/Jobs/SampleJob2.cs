using System;
using System.IO;
using System.Threading;

namespace Shsict.Scheduler
{
    public class SampleJob2 : Job
    {
        public SampleJob2()
        {
            ScheduleType = "Shsict.Scheduler.ISampleJob2";
            DueTimeInterval = 1000 * 10;
            PeriodInterval = 1000 * 65;
        }
    }

    public class ISampleJob2 : IJob
    {
        private int _IsRunning;
        public void Execute(object sender)
        {
            if (Interlocked.Exchange(ref _IsRunning, 1) == 0)
            {
                try
                {
                    //文件保存的物理路径，CSTest为虚拟目录名称，F:\Inetpub\wwwroot\CSTest为物理路径 
                    string p = @"C:\WebRoot";
                    //我们在虚拟目录的根目录下建立SchedulerJob文件夹，并设置权限为匿名可修改， 
                    //SchedulerJob.txt就是我们所写的文件 
                    string FILE_NAME = p + "\\SchedulerJob.txt";
                    //取得当前服务器时间，并转换成字符串 
                    string c = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //标记是否是新建文件的标量 
                    bool flag = false;
                    //如果文件不存在，就新建该文件

                    if (!File.Exists(FILE_NAME))
                    {
                        flag = true;
                        StreamWriter sr = File.CreateText(FILE_NAME);
                        sr.Close();
                    }

                    //向文件写入内容 
                    StreamWriter x = new StreamWriter(FILE_NAME, true, System.Text.Encoding.Default);

                    if (flag)
                    { x.Write("计划任务测试开始："); }

                    x.Write("\r\n -Job2- " + c);

                    x.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Interlocked.Exchange(ref _IsRunning, 0);
                }
            }
        }
    }
}
