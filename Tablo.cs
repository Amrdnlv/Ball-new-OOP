using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball_new
{
    class Tablo
    {
        Point point_tablo;
        Size size_tablo;
        Brush brush_tablo;
        int score_1;
        int score_2;
        int user_game;

        public int User_game
        {
            set { user_game = value; }
        }
        public Tablo(Point point_tablo, Brush brush_tablo)
        {
            this.point_tablo = point_tablo;
            this.size_tablo = new Size(200,100);
            this.brush_tablo = brush_tablo;
            score_1 = 0;
            score_2 = 0;
            user_game = 0;
        }
        public void score()
        {
            if(user_game ==1) this.score_1 += 3;
            else this.score_2 += 3;

        }

        public void Draw(Graphics e)
        {
            e.FillRectangle(brush_tablo, new Rectangle(point_tablo, size_tablo));
            e.DrawString(Convert.ToString(score_1), new Font("Arial", 32), new SolidBrush(Color.Black), 10, 20);
            e.DrawString(Convert.ToString(score_2), new Font("Arial", 32), new SolidBrush(Color.Black), 70, 20);
        }
    }


}
