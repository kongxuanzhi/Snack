using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 贪吃蛇版本2
{
    public partial class Form1 : Form
    {
        Floor floor;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            floor = new Floor(405, 405, Color.Green);

            this.Width = floor.Width;
            this.Height = floor.Height;

            int len = 3;
            try
            {
                floor.InitSnack(len, this);
            }
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            timer1.Enabled = true;
            timer1.Interval = 200;

        }
        // 事件写在这里是因为CreeatFood方法需要this做参数， 事件不能传参数
        public void FOOD_Move(object sender, EventArgs e)
        {
            floor.foods.FOOD.Move -= FOOD_Move;
            floor.CreateFood(this);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap BackPicture = new Bitmap(this.Width,this.Height); //创建内存图像
            Graphics g = Graphics.FromImage(BackPicture);//作为画布
            floor.CreateFloor(g);//在画布上绘东西
            this.CreateGraphics().DrawImage(BackPicture,0,0);//在将图片画到窗体上
            //this.BackgroundImage = BackPicture;//特别闪
        }
    }
}
