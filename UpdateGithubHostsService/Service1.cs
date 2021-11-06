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
        }

        protected override void OnStop()
        {
            logger.Info($"服务停止");
        }


        private void UpdateGitHubHosts()
        {
            try
            {
                GithubLibary.UpdateGithubHosts();
                logger.Info($"更新GitHub Hosts时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}");

                var minites = 5;
                DateTime dt1 = DateTime.Now;
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {

                        DateTime dt2 = DateTime.Now;
                        var ts = Common.DateDiff(dt2, dt1);
                        if (ts.Minutes > minites)
                        {
                            GithubLibary.UpdateGithubHosts();
                            logger.Info($"更新GitHub Hosts时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}");
                            dt1 = DateTime.Now;
                        }

                    }
                });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
