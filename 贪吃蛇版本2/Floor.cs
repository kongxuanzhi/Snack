using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace 贪吃蛇版本2
{
    class Floor
    {
        public Floor(int width, int Height, Color BackColor)
        {
            this.Width = width;
            this.Height = Height;
            this.BackGoundColor = BackColor;
        }

        public void CreateFloor(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 8);
            SolidBrush Brush = new SolidBrush(BackGoundColor);
            Rectangle BackRect = new Rectangle(0,0,this.Width,this.Height);
            g.FillRegion(Brush, new Region(BackRect));
            g.DrawRectangle(pen, BackRect);   
        }

        private void ShowSnack(Form1 f)
        {
            for (int i = 0; i < snack1.Body.Count; i++)
            {
                f.Controls.Add(snack1.Body[i]);
            }
        }

        public void InitSnack(int len, Form1 form)
        {
            snack1 = new Snack(len);
            ShowSnack(form);
            //Thread thread = new Thread(new ThreadStart(snack1.MoveHead)); //线程实现
            //thread.Start();//写入线程的委托函数是个无限循环的函数。
            //snack1.MoveHead();
            form.timer1.Tick += timer1_Tick;
            form.KeyDown += form_KeyDown;
            CreateFood(form);
        }

        private void form_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            string Dir = snack1.Direction;
            snack1.Direction = e.KeyCode.ToString();
            if (Dir == "Up" && snack1.Direction == "Down"||
                Dir == "Down" && snack1.Direction == "Up"||
                Dir == "Left" && snack1.Direction == "Right"||
                Dir == "Right" && snack1.Direction == "Left")
                snack1.Direction = Dir;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            snack1.MoveHead();
            if(snack1.IsDead(this))
            {
                //MessageBox.Show("xin da");
                Environment.Exit(0);
            }
            if(snack1.SnackHead.Location == food.FOOD.Location)
            {
                snack1.Body.Add(food.FOOD);
            }
        }

        public void CreateFood(Form1 form)
        {
            Random color = new Random();
            food = new Food(snack1.SnackSize, Color.FromArgb(color.Next(60, 255), color.Next(60, 255), color.Next(60, 255)));
            Random foodPos = new Random();
            int x = 0, y = 0;
            while (true)
            {
                x = foodPos.Next(snack1.SnackSize.Width, this.Width - 2 * snack1.SnackSize.Width);
                y = foodPos.Next(snack1.SnackSize.Height, this.Height - 2 * snack1.SnackSize.Height);
                if (x % snack1.SnackSize.Width == 0 && y % snack1.SnackSize.Height == 0)
                {
                    food.FOOD.Location = new Point(x, y);
                    break;
                }
            }
            food.FOOD.Move += form.FOOD_Move;
            form.Controls.Add(food.FOOD);
        }

        public Food foods
        {
            get { return food; }
            set { food = value; }
        }
        public int Width;
        public int Height;
        private Color BackGoundColor;
        private Snack snack1;
        private Food food;
    }
}
