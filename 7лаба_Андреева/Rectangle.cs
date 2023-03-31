using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7лаба_Андреева
{
    public class Rectangle
    {
        public Rectangle()
        {
            this.width = 0;
            this.height = 0;
            this.position_X = 0;
            this.position_Y = 0;
        }
        public Rectangle(int height, int width)
        {
            this.width = width;
            this.height = height;
            this.position_X = 0;
            this.position_Y = 0;
        }
        public Rectangle(int height, int width, int position_X, int position_Y)
        {
            this.width = width;
            this.height = height;
            this.position_X = position_X;
            this.position_Y = position_Y;
        }
        public Rectangle(int height, int width, Point point)
        {
            this.height = height;
            this.width = width;
            position_X = point.X;
            position_Y = point.Y;
        }

        public int width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value < 0)
                    throw new Exception("Ширина отрицательная");
                else
                    _width = value;
            }
        }
        public int height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value < 0)
                    throw new Exception("Высота отрицательная");
                else
                    _height = value;
            }
        }
        public int position_X
        {
            get
            {
                return _position_X;
            }
            set
            {
                if (value < 0)
                    throw new FormatException("Позиция x отрицательна");
                else
                    _position_X = value;
            }
        }
        public int position_Y
        {
            get
            {
                return _position_Y;
            }
            set
            {
                if (value < 0)
                    throw new FormatException("Позиция y отрицательна");
                else
                    _position_Y = value;
            }
        }

        private int _width;
        private int _height;
        private int _position_X;
        private int _position_Y;

        public void Transfer(int addX, int addY)
        {
            position_X += addX;
            position_Y += addY;
        }
        public static Rectangle Cross(Rectangle rectangle1, Rectangle rectangle2)
        {
            int maxStartX = Math.Max(rectangle1.position_X, rectangle2.position_X);
            int minEndX = Math.Min(rectangle1.position_X + rectangle1.width, rectangle2.position_X + rectangle2.width);
            int MaxStartY = Math.Max(rectangle1.position_Y, rectangle2.position_Y);
            int minEndY = Math.Min(rectangle1.position_Y + rectangle1.height, rectangle2.position_Y + rectangle2.height);

            if (minEndX >= maxStartX && minEndY >= MaxStartY)
            {
                return new Rectangle(minEndY - MaxStartY, minEndX - maxStartX, maxStartX, MaxStartY );
            }
            return null;
        }
        public static Rectangle Unite(Rectangle rectangle1, Rectangle rectangle2)
        {
            int minStartX = Math.Min(rectangle1.position_X, rectangle2.position_X);
            int maxEndX = Math.Max(rectangle1.position_X + rectangle1.width, rectangle2.position_X + rectangle2.width);
            int minStartY = Math.Min(rectangle1.position_Y, rectangle2.position_Y);
            int MaxEndY = Math.Max(rectangle1.position_Y + rectangle1.height, rectangle2.position_Y + rectangle2.height);
            return new Rectangle(MaxEndY - minStartY, maxEndX - minStartX, minStartX, minStartY);
        }

        public override string ToString()
        {
            return $"Ширина: {width} Высота: {height} Позиция: X:{position_X} Y:{position_Y}";
        }
    }
}
