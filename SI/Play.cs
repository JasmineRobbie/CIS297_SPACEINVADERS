using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace SI
{
    public interface IDrawable
    {
        void Draw(CanvasDrawingSession canvas);
    }

    public interface ICollidable
    {
        bool CollidesLeftEdge(int x, int y);
        bool CollidesRightEdge(int x, int y);
        bool CollidesTopEdge(int x, int y);
        bool CollidesBottomEdge(int x, int y);
    }

    public interface IDestroyable : ICollidable
    { }

    public class Play
    {
        private Bullet bullet;
        private ship PlayerShooter; 
        private List<IDrawable> drawables;

        public Play()
        {
            drawables = new List<IDrawable>();
            bullet = new Bullet(100, 100, Colors.White);
            drawables.Add(bullet);
        }

        public void DrawGame(CanvasDrawingSession canvas)
        {
            foreach (var drawable in drawables)
            {
                drawable.Draw(canvas);
            }
        }
    }

    public class Bullet : IDrawable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }
        public Color Color { get; set; }

        public Bullet(int x, int y, Color color, int radius = 5)
        {
            X = x;
            Y = y;
            Radius = radius;
            Color = color;
        }

        public void Draw(CanvasDrawingSession canvas)
        {
            canvas.DrawEllipse(X, Y, Radius, Radius, Color, 3);
        }
    }

    public class Sprite : IDrawable
    {
        public void Draw(CanvasDrawingSession canvas)
        {
            throw new NotImplementedException();
        }
    }



    public class Wall : IDrawable, ICollidable
    {
        public static int WIDTH = 3;
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }

        public Wall(int X1, int Y1, int X2, int Y2)
        {
            x1 = X1;
            y1 = Y1;
            x2 = X2;
            y2 = Y2;
        }

        public void Draw(CanvasDrawingSession canvas)
        {
            canvas.DrawLine(x1, y1, x2, y2, WIDTH);
        }
        public bool CollidesLeftEdge(int x, int y)
        {
            return x == x1 && y >= y1 && y <= y1;
        }
        public bool CollidesRightEdge(int x, int y)
        {
            return x == x2 + WIDTH && y >= y1 && y <= y2;
        }
        public bool CollidesTopEdge(int x, int y)
        {
            return x >= x1 && x <= x2 && y == y2;
        }
        public bool CollidesBottomEdge(int x, int y)
        {
            return x >= x1 && x <= x2 && y + WIDTH == y1;
        }
        
    }



    public class ship : IDrawable, ICollidable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }

        public bool TravelingLeftward { get; set; }
        public bool TravelingRightWard { get; set; }

        public ship(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            TravelingLeftward = false;
            TravelingRightWard = false;
        }

        public void Update()
        {
            if(TravelingRightWard)
            {
                X += 1;
            }
            else if(TravelingLeftward)
            {
                X -= 1;
            }
        }

        public void Draw(CanvasDrawingSession canvas)
        {
            throw new NotImplementedException();
        }

        public bool CollidesLeftEdge(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
        public bool CollidesRightEdge(int x, int y)
        {
            return x>= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
        public bool CollidesTopEdge(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }

        public bool CoolidesBottomEdge(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
    }
}
