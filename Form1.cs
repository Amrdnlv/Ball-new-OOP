using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ball_new
{
    public partial class Form1 : Form
    {
        
        Ball ball;
        Tablo tablo;
        Point[] apt = new Point[] { new Point(455, 151), new Point(470, 220),
                                    new Point(520, 151), new Point(510, 220),
                                    new Point(470, 220), new Point(510, 220),
                                    new Point(455, 151), new Point(510, 220),
                                    new Point(520, 151), new Point(470, 220)};
    
        public Form1()
        {
            InitializeComponent();
            ball = new Ball(Brushes.OrangeRed, new Point(50, 260));
            tablo = new Tablo(new Point(10,10 ),Brushes.Gray);
            ball.EventMoveDelegate += ball.ThreadForDown;
            ball.EventMoveDelegate1 += tablo.score;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
            user_1.Text = Convert.ToString(ball.User1_score);
            user_2.Text = Convert.ToString(ball.User2_score);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ball.Draw(e.Graphics);
            tablo.Draw(e.Graphics);
            e.Graphics.FillRectangle(new SolidBrush(Color.OrangeRed), 450, 140, 80, 12);
            e.Graphics.DrawLine(Pens.Gray, apt[0], apt[1]);
            e.Graphics.DrawLine(Pens.Gray, apt[2], apt[3]);
            e.Graphics.DrawLine(Pens.Gray, apt[4], apt[5]);
            e.Graphics.DrawLine(Pens.Gray, apt[6], apt[7]);
            e.Graphics.DrawLine(Pens.Gray, apt[8], apt[9]);
            e.Graphics.FillRectangle(new SolidBrush(Color.OrangeRed), 530, 140, 20, 7);
            e.Graphics.FillRectangle(new SolidBrush(Color.OrangeRed), 545, 50, 15, 150);
            e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 570, 140, 20, 300);
            e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 560, 140, 20, 20);
        }

        private void user_1_Click(object sender, EventArgs e)
        {
                ball.User_game = 1;
                ball.ThreadForStart();
        }

        private void user_2_Click(object sender, EventArgs e)
        {
                ball.User_game = 2;
                ball.ThreadForStart();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Point clic = e.Location;
            if(clic.X >=10 && clic.X <= 40 && clic.Y>=20 && clic.Y <=60)
            {
                ball.User_game = 1;
                tablo.User_game = 1;
                ball.ThreadForStart();
            }
            if(clic.X >= 70 && clic.X <= 100 && clic.Y >= 20 && clic.Y <= 60)
            {
                ball.User_game = 2;
                tablo.User_game = 2;
                ball.ThreadForStart();
            }

        }
    }
}
