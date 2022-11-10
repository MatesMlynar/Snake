using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Plocha gameField = new Plocha(10, 10);
            gameField.Render();
        }
    }
}
