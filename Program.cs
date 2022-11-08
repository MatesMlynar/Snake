using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Field gameField = new Field(10, 10);
            gameField.Render();
            
            Console.WriteLine();

            Field2 gameField2 = new Field2(20, 20, 3, 3);
            gameField2.Render();
        }
    }
}
