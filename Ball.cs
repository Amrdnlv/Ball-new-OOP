using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Ball_new
{
    class Ball
    {
        Point point_ball;
        Size size_ball;
        Brush brush_ball;
        int user1_score;
        int user2_score;
        int user_game;
        bool reverse = false;

        public delegate void MoveDelegate(); //создаём делегат MoveDelegate()
        public event MoveDelegate EventMoveDelegate; //создаём событие EventMoveDelegat
        public delegate void MoveDelegate1(); //создаём делегат MoveDelegate()
        public event MoveDelegate1 EventMoveDelegate1; //создаём событие EventMoveDelegat

        public int User_game
        {
            set { user_game = value; }
        }
        public int User1_score
        {
            get { return user1_score; }
        }
        public int User2_score
        {
            get { return user2_score; }
        }
        public Ball(Brush brush, Point point)
        {
            this.brush_ball = brush;
            this.point_ball = point;
            size_ball = new Size(50, 50);
            user_game = 0;
            user1_score = 0;
            user2_score = 0;
        }
        public void Draw(Graphics e)
        {
            e.FillEllipse(brush_ball, new Rectangle(point_ball, size_ball));
        }

        public void ThreadForStart()
        {
            Thread cast = new Thread(MoveUp);
            cast.Start();
        }
        public void ThreadForDown()
        {
            Thread cast2 = new Thread(MoveDown);
            cast2.Start();
        }


        public void MoveUp()
        {
            while (point_ball.X < 460)
            {
                if (point_ball.X < 280 && reverse ==false)
                {
                    point_ball.X += 8;
                    point_ball.Y -= 8;
                    
                }else
                {
                    reverse = true;
                    point_ball.X += 8;
                    point_ball.Y += 4;

                }
                Thread.Sleep(100);
            }
            EventMoveDelegate();

        }
        public void MoveDown()
        {
            while (point_ball.Y < 165)
            {
                point_ball.Y += 5;
                Thread.Sleep(100);
            }
            if (user_game == 1) user1_score += 3; else user2_score += 3;
            EventMoveDelegate1();
            point_ball= new Point(50, 260);
            reverse = false;
        }
    }
}
