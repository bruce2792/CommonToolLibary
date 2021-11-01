using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLibary
{
    public class GithubLibary
    {
        public static void UpdateGithubHosts()
        {

            //取得最新的的hosts

            var getHostsUrl = $"https://raw.hellogithub.com/hosts";
            var hostsContent = HttpHelper.GetResponse(getHostsUrl);

            if (string.IsNullOrWhiteSpace(hostsContent))
                return;

            hostsContent = "\r\n# 开始更新Github Hosts\r\n" + hostsContent;
            hostsContent = hostsContent + $"\r\n# 更新时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}";
            hostsContent = hostsContent + "\r\n# 更新Github Hosts结束\r\n";
            // Console.WriteLine(hostsContent);


            //拿到本地hosts文件

            string localHosts = ReadHosts();

            var flagStartPosition = localHosts.IndexOf("# 开始更新Github Hosts");
            var flagEndPosition = localHosts.IndexOf("# 更新Github Hosts结束");
            Console.WriteLine($"flagStartPosition:{flagStartPosition}");
            Console.WriteLine($"flagEndPosition:{flagEndPosition}");



            if (flagStartPosition == -1)
            {
                localHosts += hostsContent;
                SetHosts(localHosts);

            }
            else
            {
                var oldContent = localHosts.Substring(flagStartPosition, flagEndPosition + "# 更新Github Hosts结束".Length - flagStartPosition);
                //Console.WriteLine(oldContent);
                var newHostsContent = localHosts.Replace(oldContent, hostsContent);
                SetHosts(newHostsContent);

            }

        }


        /// <summary>
        /// 读取hosts文件
        /// </summary>
        /// <returns></returns>
        static string ReadHosts()
        {
            string localHostsFilePath = @"C:\Windows\System32\drivers\etc\hosts";
            var hosts = string.Empty;
            try
            {
                // 创建一个 StreamReader 的实例来读取文件 
                // using 语句也能关闭 StreamReader
                using (StreamReader sr = new StreamReader(localHostsFilePath))
                {


                    hosts = sr.ReadToEnd();
                    //string line;
                    // 从文件读取并显示行，直到文件的末尾 
                    //while ((line = sr.ReadLine()) != null)
                    //{
                    //    Console.WriteLine(line);
                    //}
                }
            }
            catch (Exception e)
            {
                // 向用户显示出错消息
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return hosts;
        }

        /// <summary>
        /// 写入hosts文件
        /// </summary>
        /// <param name="text"></param>
        static void SetHosts(string text)
        {

            string fileName = @"C:\Windows\System32\drivers\etc\hosts";
            var hosts = string.Empty;
            try
            {
                File.WriteAllText(fileName, text);
                //FileStream fs = File.OpenWrite(fileName);
                ////将字符串转换为字节数组
                //Byte[] info = Encoding.UTF8.GetBytes(text);
                ////向文件流中写入文件
                //fs.Write(info, 0, info.Length);

                //fs.Close();   //关闭文件流
            }
            catch (Exception e)
            {
                // 向用户显示出错消息
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }





    }
}
