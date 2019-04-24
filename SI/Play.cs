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
        bool Collides(int x, int y, int width, int height);
    }

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

    public class Sprite : IDrawable, ICollidable
    {
        public bool Collides(int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void Draw(CanvasDrawingSession canvas)
        {
            throw new NotImplementedException();
        }
    }


/*
    public class Wall : IDrawable, ICollidable
    {
        public bool Collides(int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void Draw(CanvasDrawingSession canvas)
        {
            throw new NotImplementedException();
        }
    }
    */


    public class ship : IDrawable
    {
        public void Draw(CanvasDrawingSession canvas)
        {
            throw new NotImplementedException();
        }
    }
}
