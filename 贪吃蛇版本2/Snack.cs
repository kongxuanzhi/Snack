using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace 贪吃蛇版本2
{
    class Snack
    {
        public Snack(int InitLen)
        {
            size = new Size(15,15);
            InitP = new Point(60,90);

            snackhead = new Label();
            snackhead.Location = InitP;
            snackhead.BorderStyle = BorderStyle.FixedSingle;
            snackhead.AutoSize = false;
            snackhead.Size = size;
            snackhead.BackColor = Color.Red;

            snack = new List<Label>();
            snack.Add(snackhead);

            direction = "Right";
            Random color = new Random();
            for (int i=1;i<InitLen;i++)
            {
                Label L = new Label();
                L.BorderStyle = BorderStyle.FixedSingle;
                L.AutoSize = false;
                L.Size = size;
                L.Location = new Point(snackhead.Left - i * size.Width, snackhead.Top);
                L.BackColor = Color.FromArgb(color.Next(60, 255), color.Next(60, 255), color.Next(60, 255));
                snack.Add(L);
            }
        }
        public void MoveHead() //放到time事件中
        {
            //while(1)
            //{
                InitP = snackhead.Location;
            
                switch (direction)
                {
                    case "Up":
                        snackhead.Top -= size.Height;
                        break;
                    case "Down":
                        snackhead.Top += size.Height;
                        break;
                    case "Left":
                        snackhead.Left -= size.Width;
                        break;
                    case "Right":
                        snackhead.Left += size.Width;
                        break;
                    case "Space":
                        break;
                }
                MoveBody();
              //  System.Threading.Thread.Sleep(1000);
           // }
            
        }
        private void MoveBody()
        {
            for (int i=snack.Count-2; i>=1; i--)
            {
                snack[i+1].Location = snack[i].Location;
            }
            snack[1].Location = InitP;
        }

        public bool IsDead(Floor floor)
        {
            if (snackhead.Location.X < 0 || snackhead.Location.Y < 0 ||
                snackhead.Location.X > floor.Width || snackhead.Location.Y > floor.Height)
                return true;
            for (int i = 1; i < snack.Count;i++)
            {
                if(snackhead.Location==snack[i].Location)
                {
                    return true; 
                }
            }
            return false;
        }

        public Size SnackSize
        {
            get { return size;}
            set { size = value;}
        }
 
        public List<Label> Body
        {
            get { return snack; }
        }
        public string Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        public Label SnackHead
        {
            get { return snackhead; }
        }
        private List<Label> snack;
        private Label snackhead;
        private Size size;
        private Point InitP;
        private string direction;
    }
}
