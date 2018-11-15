namespace DemoForm
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose (bool disposing)
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent ()
        {
            this.myTextLine1 = new MyTextLine.MyTextLine();
            this.myTextLine2 = new MyTextLine.MyTextLine();
            this.myTextLine3 = new MyTextLine.MyTextLine();
            this.myTextLine4 = new MyTextLine.MyTextLine();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.myTextLine5 = new MyTextLine.MyTextLine();
            this.SuspendLayout();
            // 
            // myTextLine1
            // 
            this.myTextLine1.LineBold = 0;
            this.myTextLine1.Location = new System.Drawing.Point(190, 46);
            this.myTextLine1.Name = "myTextLine1";
            this.myTextLine1.PassWordChar = '\0';
            this.myTextLine1.Size = new System.Drawing.Size(75, 23);
            this.myTextLine1.TabIndex = 0;
            this.myTextLine1.Text = "myTextLine1";
            // 
            // myTextLine2
            // 
            this.myTextLine2.Location = new System.Drawing.Point(190, 109);
            this.myTextLine2.Name = "myTextLine2";
            this.myTextLine2.PassWordChar = '\0';
            this.myTextLine2.Size = new System.Drawing.Size(75, 23);
            this.myTextLine2.TabIndex = 1;
            this.myTextLine2.Text = "myTextLine2";
            // 
            // myTextLine3
            // 
            this.myTextLine3.Location = new System.Drawing.Point(190, 172);
            this.myTextLine3.Name = "myTextLine3";
            this.myTextLine3.PassWordChar = '*';
            this.myTextLine3.Size = new System.Drawing.Size(75, 23);
            this.myTextLine3.TabIndex = 2;
            this.myTextLine3.Text = "myTextLine3";
            // 
            // myTextLine4
            // 
            this.myTextLine4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.myTextLine4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myTextLine4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.myTextLine4.LineBold = 10;
            this.myTextLine4.LineColor = System.Drawing.Color.DarkRed;
            this.myTextLine4.Location = new System.Drawing.Point(190, 235);
            this.myTextLine4.Name = "myTextLine4";
            this.myTextLine4.PassWordChar = '\0';
            this.myTextLine4.Size = new System.Drawing.Size(151, 43);
            this.myTextLine4.TabIndex = 3;
            this.myTextLine4.Text = "myTextLine4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "无任何效果";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "初始状态";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "密码状态";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "花哨状态";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 334);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "自动调整状态";
            // 
            // myTextLine5
            // 
            this.myTextLine5.Font = new System.Drawing.Font("微软雅黑", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myTextLine5.LineBold = 5;
            this.myTextLine5.LineColor = System.Drawing.Color.DarkRed;
            this.myTextLine5.Location = new System.Drawing.Point(190, 318);
            this.myTextLine5.MyAutoSize = true;
            this.myTextLine5.Name = "myTextLine5";
            this.myTextLine5.PassWordChar = '\0';
            this.myTextLine5.Size = new System.Drawing.Size(111, 28);
            this.myTextLine5.TabIndex = 5;
            this.myTextLine5.Text = "myTextLine5";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(834, 522);
            this.Controls.Add(this.myTextLine5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myTextLine4);
            this.Controls.Add(this.myTextLine3);
            this.Controls.Add(this.myTextLine2);
            this.Controls.Add(this.myTextLine1);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyTextLine.MyTextLine myTextLine1;
        private MyTextLine.MyTextLine myTextLine2;
        private MyTextLine.MyTextLine myTextLine3;
        private MyTextLine.MyTextLine myTextLine4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private MyTextLine.MyTextLine myTextLine5;
    }
}

