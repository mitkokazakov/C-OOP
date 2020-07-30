

using System;

namespace ClassBoxData
{
    public class Box
    {
        private const int MIN_VALUE_SIDE = 0;
        private const string ERROR_MESAGE = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length 
        {
            get 
            {
                return this.length;
            }

            private set
            {
                if (value <= MIN_VALUE_SIDE)
                {
                    throw new ArgumentException(String.Format(ERROR_MESAGE,nameof(this.Length)));
                }

                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= MIN_VALUE_SIDE)
                {
                    throw new ArgumentException(String.Format(ERROR_MESAGE, nameof(this.Width)));
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= MIN_VALUE_SIDE)
                {
                    throw new ArgumentException(String.Format(ERROR_MESAGE, nameof(this.Height)));
                }

                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            return (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height); 
        }

        public double LateralSurafceArea()
        {
            return  (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }

        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}
