using CommonToolLibary;
using CommonToolLibary.Util;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolLibary
{
    public partial class Form1 : Form
    {
        public static Logger logger = LogManager.GetLogger("*");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logger.Info("打开界面");
            var minites = new Dictionary<object, object>();
            minites.Add(1, "1分钟");
            minites.Add(2, "2分钟");
            minites.Add(3, "3分钟");
            minites.Add(4, "4分钟");
            minites.Add(5, "5分钟");
            SetComboBox(cmbMinites, minites);


            this.cmbMinites.SelectedIndex = 4;
         
        }

        /// <summary>
        /// 设置ComboBox
        /// </summary>
        /// <param name="cmoboBox"></param>
        /// <param name="datas"></param>
        void SetComboBox(ComboBox cmoboBox, Dictionary<object, object> datas)
        {
            ArrayList mylist = new ArrayList();
            foreach (var item in datas)
            {
                mylist.Add(new DictionaryEntry(item.Key, item.Value));
            }
            cmoboBox.DataSource = mylist;
            cmoboBox.DisplayMember = "Value";
            cmoboBox.ValueMember = "Key";



        }

        private void btnUpadateGitHubHosts_Click(object sender, EventArgs e)
        {
            //string combobox1_value = this.cmbMinites.Text;
            //string combobox1_index = this.cmbMinites.SelectedIndex.ToString();
            //var SelectedValue = this.cmbMinites.SelectedValue;
            // MessageBox.Show(combobox1_value);
            //MessageBox.Show(SelectedValue.ToString());

            UpdateGitHubHosts();
        }
        private void UpdateGitHubHosts()
        {

            GithubLibary.UpdateGithubHosts();
            logger.Info($"更新GitHub Hosts时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}");
           
            var minites = (int)this.cmbMinites.SelectedValue;
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



    }
}
