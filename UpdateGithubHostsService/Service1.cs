using CommonToolLibary;
using CommonToolLibary.Util;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace UpdateGithubHostsService
{
    public partial class Service1 : ServiceBase
    {
        public static Logger logger = LogManager.GetLogger("*");

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            logger.Info($"服务开始启动");
            UpdateGitHubHosts();

            System.Timers.Timer timer2 = new System.Timers.Timer(1000 * 60 * 5);//实例化Timer类，设置间隔时间为2 min； 
            timer2.Elapsed += new System.Timers.ElapsedEventHandler(UpdateGitHubHostsDelegate);//到时间的时候执行事件； 
            timer2.AutoReset = true;//设置是执行一次（false）还是一直执行(true)； 
            timer2.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件； 
            logger.Info("启动结束");



        }

        protected override void OnStop()
        {
            logger.Info($"服务停止");
        }


        #region 使用Task+while true DateTime执行
        //private void UpdateGitHubHosts()
        //{
        //    try
        //    {
        //        GithubLibary.UpdateGithubHosts();
        //        logger.Info($"更新GitHub Hosts时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}");

        //        var minites = 5;
        //        DateTime dt1 = DateTime.Now;
        //        Task.Factory.StartNew(() =>
        //        {
        //            while (true)
        //            {

        //                DateTime dt2 = DateTime.Now;
        //                var ts = Common.DateDiff(dt2, dt1);
        //                if (ts.Minutes > minites)
        //                {
        //                    GithubLibary.UpdateGithubHosts();
        //                    logger.Info($"更新GitHub Hosts时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}");
        //                    dt1 = DateTime.Now;
        //                }

        //            }
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex);
        //    }
        //}
        #endregion



        #region 使用timer执行
        private void UpdateGitHubHostsDelegate(object source, System.Timers.ElapsedEventArgs e)
        {
            UpdateGitHubHosts();
        }

        private void UpdateGitHubHosts()
        {
            try
            {
                logger.Info($"更新GitHub Hosts时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}");
                GithubLibary.UpdateGithubHosts();
                logger.Info($"更新GitHub Hosts时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        #endregion

    }
}
