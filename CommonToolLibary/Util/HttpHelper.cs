using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLibary
{
    public class HttpHelper
    {

        //public static string GetResponseBySimpleGet(List<KeyValuePair<string, string>> paramArray, string url)
        //{

        //    var httpclient =new  HttpClient().GetAsync(,)

        //    url = url + "?" + BuildParam(paramArray);
        //    var result = httpclient.GetStringAsync(url).Result;
        //    return result;
        //}


        /// <summary>
        /// Get请求数据
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetResponse(string url)
        {
            HttpClient httpClient = new HttpClient();

            //string credentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("Bearer" + ":" + accessToken));
            ////accessToken
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            HttpResponseMessage res = httpClient.GetAsync(url).Result;
            if (res.IsSuccessStatusCode)
            {
                Task<string> t = res.Content.ReadAsStringAsync();
                return t.Result;
            }
            return string.Empty;
        }

        /// <summary>  
        /// 创建GET方式的HTTP请求  
        /// </summary>  
        public async Task<HttpResponseMessage> CreateGetHttpResponse(string url, int timeout = 60, string userAgent = "", CookieCollection cookies = null)
        {

            return new HttpClient().GetAsync(url).Result;


            //HttpWebRequest request = null;
            //if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            //{
            //    //对服务端证书进行有效性校验（非第三方权威机构颁发的证书，如自己生成的，不进行验证，这里返回true）
            //    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            //    request = WebRequest.Create(url) as HttpWebRequest;
            //    request.ProtocolVersion = HttpVersion.Version10;    //http版本，默认是1.1,这里设置为1.0
            //}
            //else
            //{
            //    request = WebRequest.Create(url) as HttpWebRequest;
            //}
            //request.Method = "GET";
            //request.ContentType = "text/html; charset=utf-8";

            ////设置代理UserAgent和超时
            ////request.UserAgent = userAgent;
            ////request.Timeout = timeout;
            //if (cookies != null)
            //{
            //    request.CookieContainer = new CookieContainer();
            //    request.CookieContainer.Add(cookies);
            //}

            //var response = request.GetResponse();
            //var response1 = response as HttpWebResponse;
            //return response1;
        }

        /// <summary>  
        /// 创建POST方式的HTTP请求  
        /// </summary>  
        public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters, int timeout, string userAgent, CookieCollection cookies)
        {
            HttpWebRequest request = null;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                //request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            //设置代理UserAgent和超时
            //request.UserAgent = userAgent;
            //request.Timeout = timeout; 

            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            //发送POST数据  
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                        i++;
                    }
                }
                byte[] data = Encoding.ASCII.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            string[] values = request.Headers.GetValues("Content-Type");
            return request.GetResponse() as HttpWebResponse;
        }

        /// <summary>
        /// 获取请求的数据
        /// </summary>
        public static string GetResponseString(HttpWebResponse webresponse)
        {
            using (Stream s = webresponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(s, Encoding.UTF8);
                return reader.ReadToEnd();

            }
        }

        /// <summary>
        /// 验证证书
        /// </summary>
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if (errors == SslPolicyErrors.None)
                return true;
            return false;
        }
    }
}
