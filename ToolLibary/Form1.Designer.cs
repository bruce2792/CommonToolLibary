
namespace ToolLibary
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUpadateGitHubHosts = new System.Windows.Forms.Button();
            this.cmbMinites = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpadateGitHubHosts
            // 
            this.btnUpadateGitHubHosts.Location = new System.Drawing.Point(135, 85);
            this.btnUpadateGitHubHosts.Name = "btnUpadateGitHubHosts";
            this.btnUpadateGitHubHosts.Size = new System.Drawing.Size(89, 44);
            this.btnUpadateGitHubHosts.TabIndex = 0;
            this.btnUpadateGitHubHosts.Text = "开始";
            this.btnUpadateGitHubHosts.UseVisualStyleBackColor = true;
            this.btnUpadateGitHubHosts.Click += new System.EventHandler(this.btnUpadateGitHubHosts_Click);
            // 
            // cmbMinites
            // 
            this.cmbMinites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMinites.FormattingEnabled = true;
            this.cmbMinites.Location = new System.Drawing.Point(80, 47);
            this.cmbMinites.Name = "cmbMinites";
            this.cmbMinites.Size = new System.Drawing.Size(144, 20);
            this.cmbMinites.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "分钟：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("华文楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(15, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "定时更新GitHub Hosts";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 143);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMinites);
            this.Controls.Add(this.btnUpadateGitHubHosts);
            this.Name = "Form1";
            this.Text = "工具库";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpadateGitHubHosts;
        private System.Windows.Forms.ComboBox cmbMinites;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

