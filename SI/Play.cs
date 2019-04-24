using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using Windows.Gaming.Input;
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
        private Sprite sprite;
        private List<IDrawable> drawables;
        private ship userShip;
        private Bullet bullet;

        public static int LEFT_EDGE = 10;
        public static int TOP_EDGE = 10;
        public static int RIGHT_EDGE = 790;
        public static int BOTTOM_EDGE = 450;

        public Play()
        {
            drawables = new List<IDrawable>();
            bullet = new Bullet(LEFT_EDGE + RIGHT_EDGE / 2, BOTTOM_EDGE, Colors.White);
            drawables.Add(bullet);
            userShip = new ship(LEFT_EDGE + RIGHT_EDGE / 2, BOTTOM_EDGE, 50, 5, Colors.White);

            drawables.Add(userShip);

            //List for all sprites
            List<Sprite> sprites = new List<Sprite>();
            sprites.Add(sprite = new Sprite(100, 100, Colors.White));
            sprites.Add(sprite = new Sprite(100, 200, Colors.White));
            sprites.Add(sprite = new Sprite(100, 300, Colors.White));
            sprites.Add(sprite = new Sprite(200, 100, Colors.White));
            sprites.Add(sprite = new Sprite(200, 200, Colors.White));
            sprites.Add(sprite = new Sprite(200, 300, Colors.White));
            sprites.Add(sprite = new Sprite(300, 100, Colors.White));
            sprites.Add(sprite = new Sprite(300, 200, Colors.White));
            sprites.Add(sprite = new Sprite(300, 300, Colors.White));
            sprites.Add(sprite = new Sprite(400, 100, Colors.White));
            sprites.Add(sprite = new Sprite(400, 200, Colors.White));
            sprites.Add(sprite = new Sprite(400, 300, Colors.White));
            sprites.Add(sprite = new Sprite(500, 100, Colors.White));
            sprites.Add(sprite = new Sprite(500, 200, Colors.White));
            sprites.Add(sprite = new Sprite(500, 300, Colors.White));
            sprites.Add(sprite = new Sprite(600, 100, Colors.White));
            sprites.Add(sprite = new Sprite(600, 200, Colors.White));
            sprites.Add(sprite = new Sprite(600, 300, Colors.White));
            sprites.Add(sprite = new Sprite(700, 100, Colors.White));
            sprites.Add(sprite = new Sprite(700, 200, Colors.White));
            sprites.Add(sprite = new Sprite(700, 300, Colors.White));


            //Going through list and drawing all sprites
            for (int i = 0; i < sprites.Count; i++)
            {
                drawables.Add(sprites[i]);
            }
        }



        public void Update()
        {
            bullet.Y -= 1;
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

        public Bullet(int x, int y, Color color, int radius = 10)
        {
            X = x;
            Y = y;
            Radius = radius;
            Color = color;
        }

        public bool TravelingDownward { get; set; }
        public bool TravelingLeftward { get; set; }

        public void Update()
        {
            if (TravelingDownward)
            {
                Y += 1;
            }
            else
            {
                Y -= 1;
            }
            if (TravelingLeftward)
            {
                X -= 1;
            }
            else
            {
                X += 1;
            }
        }




        public void Draw(CanvasDrawingSession canvas)
        {
            canvas.DrawEllipse(X, Y, Radius, Radius, Color, 5);
        }
    }

    public class Sprite : IDrawable, IDestroyable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }
        public Color Color { get; set; }

        public Sprite(int x, int y, Color color, int radius = 20)
        {
            X = x;
            Y = y;
            Radius = radius;
            Color = color;
        }

        public void Draw(CanvasDrawingSession canvas)
        {
            canvas.DrawEllipse(X, Y, Radius, Radius, Color, 5);
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
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }

        public Color Color { get; set; }

        public bool TravelingLeftward { get; set; }
        public bool TravelingRightward { get; set; }

        public ship(int x, int y, int width, int height, Color color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color;
            TravelingLeftward = false;
            TravelingRightward = false;
        }

        public void Update()
        {
            if (TravelingRightward)
            {
                X += 1;
            }
            else if (TravelingLeftward)
            {
                X -= 1;
            }
        }

        public void Draw(CanvasDrawingSession canvas)
        {
            canvas.DrawRectangle(X, Y, Width, Height, Color, 3);
        }


    }
}
