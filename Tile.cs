using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    abstract class Tile
    {
        public class Wall : Tile 
        {
            private static Object _locker = new Object();
            private static Wall _instance;
            public static Wall Instance
            {
                get
                {
                    //double check pattern
                    if (_instance != null)
                        return _instance;

                    //Only one thread allowed in lock
                    lock (_locker)
                        return _instance ?? (_instance = new Wall());
                }
            }
            private Wall()
            {

            }
            public override string ToString() => "#";
        }

        public class Grass : Tile
        {
            private static Grass _instance;
            public static Grass Instance
            {
                get => _instance ?? (_instance = new Grass());
            }

            public override string ToString() => " ";
        }

        public class Food : Tile
        {
            public override string ToString() => "@";
        }

        public virtual void Enter(Snake snake)
        {

        }
    }
}
