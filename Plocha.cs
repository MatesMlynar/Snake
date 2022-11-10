using System;

namespace Snake
{
    public class Plocha
    {
        public int MaxY { get; set; }
        public int MaxX { get; set; }
   
       
        public Plocha(int maxX, int maxY)
        {
            MaxY = maxY;
            MaxX = maxX;
      
        }




        private Dlazdice[,] _vsechnyDlazdice;
        protected Dlazdice[,] VsechnyDlazdice
        {
            get
            {
                if (_vsechnyDlazdice == null)
                {
                    _vsechnyDlazdice = VytvorPlochu();
                    DoplnZeli();
                }

                return _vsechnyDlazdice;
            }
        }

        public virtual Poloha InitialPoloha
        {
            get
            {
                return new Poloha(3, 3);
            }
        }
        public virtual Smer InitialSmer
        {
            get
            {
                return Smer.Right;
            }
        }
        public virtual byte InitialLength
        {
            get
            {
                return 3;
            }
        }

        public virtual byte InitialPocetZeli
        {
            get
            {
                return 30;
            }
        }

        public int PocetZeli { get; protected set; }

        public Dlazdice this[int x, int y]
        {
            get { return VsechnyDlazdice[x, y]; }
            protected set { VsechnyDlazdice[x, y] = value; }
        }

        public Dlazdice this[Poloha poloha]
        {
            get { return this[poloha.X, poloha.Y]; }
            set
            {
                var currentDlazdice = this[poloha.X, poloha.Y];
                if (currentDlazdice is Zeli && (!(value is Zeli)))
                {
                    PocetZeli--;
                }

                this[poloha.X, poloha.Y] = value;
            }
        }
    

        protected virtual void DoplnZeli()
        {
            //todo: random generuj
            //this[5, 5] = new Zeli();
            //this[16, 6] = new Zeli();
            //this[30, 4] = new MegaZeli();
            PocetZeli = InitialPocetZeli;
        }




        protected virtual Dlazdice[,] VytvorPlochu()
        {

            Dlazdice[,] plocha = new Dlazdice[MaxX, MaxY];

            for (int y = 0; y < MaxY; y++)
            {
                for (int x = 0; x < MaxX; x++)
                {
                    plocha[x, y] = ((x == 0 || x == MaxX - 1 || y == 0 || y == MaxY - 1)
                        ? (Dlazdice)  Zed.Instance : new Vzduch());

                }
            }
            return plocha;
        }

        public void Render()
        {
            var all = VytvorPlochu();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Blue;
            for (var y = 0; y < MaxY; y++)
            {
                for (var x = 0; x < MaxX; x++)
                {
                   
                    //Thread.Sleep(2);
                    Console.Write(all[x, y]);
                }
                Console.WriteLine();

            }
        }
    }
}