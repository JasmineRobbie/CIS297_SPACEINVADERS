
﻿using Microsoft.Graphics.Canvas;
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
        bool CollidesLeftEdge(int x, int y);
        bool CollidesRightEdge(int x, int y);
        bool CollidesTopEdge(int x, int y);
        bool CollidesBottomEdge(int x, int y);
    }

    public interface IDestroyable : ICollidable
    { }


    public class Play
    {
        private Sprite sprite;
        public List<IDrawable> drawables;
        private ship PlayerShooter;
        public Bullet bullet;

        public static int LEFT_EDGE = 10;
        public static int TOP_EDGE = 10;
        public static int RIGHT_EDGE = 790;
        public static int BOTTOM_EDGE = 450;

        public Play()
        {
            drawables = new List<IDrawable>();

     
            bullet = new Bullet(10000,10000, Colors.Red);
            drawables.Add(bullet);
            

            var leftWall = new Wall(LEFT_EDGE, TOP_EDGE, LEFT_EDGE, BOTTOM_EDGE, Colors.White);
            drawables.Add(leftWall);

            var rightWall = new Wall(RIGHT_EDGE, TOP_EDGE, RIGHT_EDGE, BOTTOM_EDGE, Colors.White);
            drawables.Add(rightWall);

            PlayerShooter = new ship(LEFT_EDGE + RIGHT_EDGE / 2, BOTTOM_EDGE, 75, 10, Colors.Red);
            drawables.Add(PlayerShooter);

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


        public void SetPaddleTravelingLeftward(bool travelingLeftward)
        {
            PlayerShooter.TravelingLeftward = travelingLeftward;
        }

        public void SetPaddleTravelingRightward(bool travelingRightward)
        {
            PlayerShooter.TravelingRightward = travelingRightward;
        }

        public void SetShooting(bool shooting)
        {
            PlayerShooter.Shooting = shooting;
        }


        public void Update()
        {
            bullet.Y -= 3;
            if (PlayerShooter.Shooting)
            {
                bullet.X = PlayerShooter.X + 35;
                bullet.Y = PlayerShooter.Y;
            }
            PlayerShooter.Update();
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
            TravelingDownward = false;
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

    //Add idestroyable
    public class Sprite : IDrawable
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

    public class Wall : IDrawable, ICollidable
    {
        public static int WIDTH = 3;
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }
        public Color color { get; set; }
        public Wall(int X1, int Y1, int X2, int Y2, Color coloR)
        {
            x1 = X1;
            y1 = Y1;
            x2 = X2;
            y2 = Y2;
            color = coloR;
        }

        public void Draw(CanvasDrawingSession canvas)
        {
            canvas.DrawLine(x1, y1, x2, y2, color, WIDTH);
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

        public bool Collides(int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }
    }


    public class ship : IDrawable, ICollidable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }

        public Color color { get; set; }

        public bool TravelingLeftward { get; set; }
        public bool TravelingRightward { get; set; }
        public bool Shooting { get; set; }

        public ship(int x, int y, int width, int height, Color coloR)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            color = coloR;
            TravelingLeftward = false;
            TravelingRightward = false;
        }

        public void Update()
        {
            if (TravelingRightward)
            {
                if (X >= 710)
                {
                    //STOP MOVING
                }
                else
                {
                    X += 2;
                }
            }
            else if (TravelingLeftward)
            {
                if (X <= 10)
                {
                    //STOP MOVING
                }
                else
                {
                    X -= 2;
                }
            }
            else if (Shooting)
            {
               
            }
        }
        public void Draw(CanvasDrawingSession canvas)
        {
            canvas.DrawRectangle(X + 20, Y - 20, Width - 40, Height, color, 10);
            canvas.DrawRectangle(X+10, Y-10, Width - 20, Height, color, 10);
            canvas.DrawRectangle(X, Y, Width, Height, color, 10);
            
        }

        public bool CollidesLeftEdge(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
        public bool CollidesRightEdge(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
        public bool CollidesTopEdge(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }

        public bool CoolidesBottomEdge(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }

        bool ICollidable.CollidesLeftEdge(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }

        bool ICollidable.CollidesRightEdge(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }

        bool ICollidable.CollidesTopEdge(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }

        bool ICollidable.CollidesBottomEdge(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }

        public bool Collides(int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }
    }

}

