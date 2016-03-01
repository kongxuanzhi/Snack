using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace 贪吃蛇版本2
{
    class Food
    {
        public Food(Size size, Color foodBackColor)
        {
            food = new Label();
            food.BorderStyle = BorderStyle.FixedSingle;
            food.AutoSize = false;

            food.Size = size;//改变事物的大小
            food.BackColor = foodBackColor;
        }
        public Label FOOD
        {
            get { return food; }
            set { food = value; }
        }
        private Label food;
    }
}
