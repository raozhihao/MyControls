using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTextLine
{
    public class MyTextLine : Control
    {
        /// <summary>
        /// 设置控件的宽度和高度是否随文字长度更改而改变
        /// </summary>
        private bool autoSize;

        
        /// <summary>
        /// 控件的宽度是否随文字长度而更改
        /// </summary>
        [
           Category ("布局"),
           DefaultValue (false),
           Description ("设置控件的宽度和高度是否随文字长度更改而改变"),
           Browsable (true),
       ]
        public bool MyAutoSize
        {
            get
            {
                return autoSize;
            }
            set
            {
                autoSize = value;
               // TextColorChanged?.Invoke (this , ea);
                //更改了此值后判断
                if ( value )
                {
                    SetAutoSize ();
                }
                //刷新控件
                Invalidate ();
            }
        }

        /// <summary>
        /// 线条的颜色
        /// </summary>
        private Color lineColor;

        /// <summary>
        /// 线条颜色改变事件
        /// </summary>
        [
           Category ("属性已更改"),
           Description ("线条颜色改变事件"),
           Browsable (true),
           DesignOnly (false)
       ]
        public event Action<object , EventArgs> LineColorChanged;
       
        /// <summary>
        /// 线条的颜色
        /// </summary>
        [
            Category ("外观"),
             DefaultValue (typeof (Color) , "Black"),
            Description ("线条的颜色设置")
        ]
        public Color LineColor
        {
            get
            {
                return lineColor;
            }
            set
            {
                lineColor = value;
                LineColorChanged?.Invoke (this , new EventArgs());
                Invalidate ();
            }
        }

        /// <summary>
        /// 线条粗细度已更改
        /// </summary>
        [
            Category ("属性已更改"),
            Description ("线条粗细度已更改")
        ]
        public event Action<object , EventArgs> LineWidthChanged;

        /// <summary>
        /// 线条粗细度
        /// </summary>
        private int lineBold;

        private TextBox LineBox;


        /// <summary>
        /// 线条粗细度
        /// </summary>
        [
          Category ("外观"),
             DefaultValue (typeof (int) , "1"),
          Description ("线条粗细度更改")
      ]
        public int LineBold
        {
            get
            {
                return lineBold;
            }
            set
            {
                lineBold = value;
                LineWidthChanged?.Invoke (this , new EventArgs ());
                SetAutoSize ();
                Invalidate ();
            }
        }

        /// <summary>
        /// 不可编辑
        /// </summary>
        [
          Category ("行为"),
             DefaultValue (false),
          Description ("线条粗细度更改")
      ]
        public bool ReadOnly
        {
            get; set;
        } = false;
        
        private char passWordChar;
        /// <summary>
        /// 指示将输入的字符替换成指定的字符
        /// </summary>
        [
          Category ("行为"),
          Description ("线条粗细度更改")
      ]
        public char PassWordChar
        {
            get
            {
                return passWordChar;
            }
            set
            {
                passWordChar = value;
                Invalidate ();
            }
        }

        /// <summary>
        /// 重写Text
        /// </summary>
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
                Invalidate ();
            }
        }
        

        public MyTextLine ()
        {
            //初始化一些参数
            lineColor = Color.Black;
            lineBold = 1;
            InitializeComponent ();
        }
        
        /// <summary>
        /// 重写
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint (PaintEventArgs e)
        {
            base.OnPaint (e);
            using ( Graphics g = e.Graphics )
            {
                //将当前Text暂存
                string input = this.Text;
               
                //画上文字之前判断是否有替换符
                if ( passWordChar != '\0' )
                {
                    string pass = string.Empty;
                    //如果有,就将Text替换一下
                    for ( int i = 0; i < Text.Length; i++ )
                    {
                        pass += PassWordChar;
                    }
                    //如果有替换符,则将暂存变量全替换成替换符
                    //以备等会画上去
                    input = pass;
                   
                }
                else
                {
                    input = Text;
                    
                }

                //获取当前字体的相关尺寸信息
                SizeF fontSize = g.MeasureString (Text , Font);
                //设置当前Text应该画在控件的高度的位置
                float drawHeighPoint = 0;
                //如果当前控件的高度大于文字的高度
                if ( (this.Size.Height-lineBold ) > fontSize.Height )
                {
                    //则应让文字在控件内垂直居中
                    drawHeighPoint = ( this.Height - fontSize.Height-lineBold ) / 2;
                }
                //创建一个画刷对象
                SolidBrush sb = new SolidBrush (ForeColor);
                
               
                //画上文字
                g.DrawString (input , Font , sb , 0 , drawHeighPoint);

                //创建画笔对象
                Pen pen = new Pen (LineColor);
                pen.Width = lineBold;
                
                //如果当前的自动大小更改打开了的话
                float drawLineHeight = 0;
                if ( autoSize )
                {
                    this.Width = (int)fontSize.Width;
                    this.Height = (int)fontSize.Height + lineBold;
                    this.Size = new Size (Width , Height);
                    drawLineHeight =(int)fontSize.Height;
                }
                else
                {
                    drawLineHeight = this.Height - lineBold;
                }
                //画上线条
                g.FillRectangle (new SolidBrush (lineColor) , 0 , drawLineHeight , this.Width , lineBold);
                
            }
           
        }


      

        /// <summary>
        /// 重写鼠标按下函数
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown (MouseEventArgs e)
        {
            base.OnMouseDown (e);

            if ( ReadOnly )
            {
                //如果选择了不可编辑,则取消
                return;
            }
            //当鼠标点击的时候,让其可编辑
            //思路就是参照DataGridVeiw中的编辑功能
            //在当前控件的位置放置一个TextBox
            LineBox_Enter (LineBox , new EventArgs ());
            
        }

        private void Tb_KeyPress (object sender , KeyPressEventArgs e)
        {
            //如果当前按下的是Enter键
            if ( e.KeyChar == 13 )
            {
                e.Handled = true;
            }
        }
       
        protected override void OnEnter (EventArgs e)
        {
            base.OnEnter (e);
            
            //调用控件中的文本框进入事件
            LineBox_Enter (LineBox,new EventArgs());
        }
        protected override void OnLeave (EventArgs e)
        {
            base.OnLeave (e);
            //调用控件中的文本框失去焦点事件
            LineBox_Leave (LineBox , new EventArgs ());
        }

        protected override void OnFontChanged (EventArgs e)
        {
            base.OnFontChanged (e);
            //字体更改时重置控件大小
            SetAutoSize ();
            
        }

        protected override void OnTextChanged (EventArgs e)
        {
            base.OnTextChanged (e);
            //文字更改时重置控件大小
            SetAutoSize ();
        }

       

        /// <summary>
        /// 设置自动尺寸
        /// </summary>
        private void SetAutoSize ()
        {
            //确定当前是否需要自适应宽度
            if ( autoSize )
            {
                //获取当前字体的相关尺寸信息
                SizeF fontSize = GetFontSize (Text , Font);
                
                this.Width = (int)fontSize.Width;
                this.Height = (int)fontSize.Height+lineBold;
                this.Size = new Size (Width , Height);
                //重绘控件
                Invalidate ();
            }
            

        }

        /// <summary>
        /// 获取指定文字的字体尺寸信息
        /// </summary>
        /// <param name="getSizeText">需要获取的文字</param>
        /// <param name="font">该文字当前使用的字体</param>
        /// <returns></returns>
        private SizeF GetFontSize (string getSizeText , Font font)
        {
            SizeF fontSize;
            //获取绘图对象
            using ( Graphics g = Graphics.FromHwnd (this.Handle) )
            {
                //获取当前字体的相关尺寸信息
                fontSize = g.MeasureString (getSizeText , font);
            }
            return fontSize;
        }

        
        private void InitializeComponent ()
        {
            this.LineBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LineBox
            // 
            this.LineBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.LineBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LineBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LineBox.Location = new System.Drawing.Point(0, 0);
            this.LineBox.Name = "LineBox";
            this.LineBox.Size = new System.Drawing.Size(100, 14);
            this.LineBox.TabIndex = 0;
            this.LineBox.Visible = false;
            
            // 
            // MyTextLine
            // 
            this.Controls.Add(this.LineBox);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LineBox_Enter (object sender , EventArgs e)
        {
            //先检查是否开启了密码替换符功能
            if ( passWordChar != '\0' )
            {
                //如果开启则也开启文本框的
                LineBox.PasswordChar = passWordChar;
            }

            //显示文本框
            LineBox.Visible = true;
            //[定位文本框
            LineBox.Location =new Point(0, ( this.Height - LineBold - LineBox.Height ) / 2);
            //设置文本框的一些其它属性
            LineBox.Width = this.Width;
            LineBox.Text = this.Text;
            LineBox.BackColor = this.BackColor;
            LineBox.ForeColor = this.ForeColor;
            LineBox.Font = this.Font;
            //使文本框得到焦点
            LineBox.SelectionStart = LineBox.TextLength;
            LineBox.Select ();
        }

        private void LineBox_Leave (object sender , EventArgs e)
        {
            LineBox.Visible = false;
            this.Text = LineBox.Text;
        }
    }
}
