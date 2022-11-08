using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Field
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public Field(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }

        public virtual Coordinates InitCoordinates { get => new Coordinates(0, 0); }

        protected virtual Tile[,] CreateField()
        {

            Tile[,] field = new Tile[MaxX,MaxY];
            
            for (int y = 0; y < MaxY; y++)
            {
                for (int x = 0; x < MaxX; x++)
                {
                    field[x, y] = (x == 0 || x == MaxX - 1 || y == 0 || y == MaxY - 1) ? Tile.Wall.Instance : Tile.Grass.Instance;
                }
            }

            return field;
        }

        public void Render()
        {
            var all = CreateField();
            //Console.SetCursorPosition(0, 0);
            //Console.ForegroundColor = ConsoleColor.Blue;
            for (int y = 0; y < MaxY; y++)
            {
                for (int x = 0; x < MaxX; x++)
                {
                    Console.Write(all[x, y]);
                }
                Console.WriteLine();
            }
        }
        
    }

    class Field2 : Field
    {

        public int OffsetX { get; set; } //Could check if its not -1... but wtv
        public int OffsetY { get; set; }

        public Field2(int maxX, int maxY, int offsetX, int offsetY) : base(maxX, maxY)
        {
            if (OffsetX < 0 || OffsetY < 0)
                throw new ArgumentOutOfRangeException();
            OffsetX = offsetX;
            OffsetY = offsetY;
        }

        protected override Tile[,] CreateField()
        {
            var basic = base.CreateField();
            if (OffsetX < 0 || OffsetY < 0)
                return basic;

            for (int y = OffsetY; y < MaxY - OffsetY; y++)
            {
                for (int x = OffsetX; x < MaxX - OffsetX; x++)
                {
                    if (
                        ((x == OffsetX || x == MaxX - OffsetX - 1) && y % 2 == 0) ||
                        ((y == OffsetY || y == MaxY - OffsetY - 1) && x % 2 == 0)
                        )
                        basic[x, y] = Tile.Wall.Instance;

                }
            }

            return basic;
        }
    }
}
