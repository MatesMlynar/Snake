using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public abstract class Dlazdice
    {
        public virtual void Enter(Housenka housenka)
        {
        }
    }

    public class Zed : Dlazdice
    {

        private Zed()
        {
        }
        public override string ToString()
        {
            return "X";
        }



        //private static Zed _instance;
        //public static Zed Instance
        //{
        //    get
        //    {

        //        return _instance ?? (_instance = new Zed());
        //    }
        //}

        private static Object _locker = new Object();

        private static Zed _instance;
        public static Zed Instance
        {
            get
            {
                //double check pattern
                if (_instance != null)
                    return _instance;

                lock (_locker)
                {
                    if (_instance == null)
                        _instance = new Zed();
                    return _instance;
                }
            }
        }

        public override void Enter(Housenka housenka)
        {
            housenka.Mrtva = true;
        }

       
    }

    public class Vzduch : Dlazdice
    {

        public override string ToString()
        {
            return " ";
        }
    }

    public class Zeli : Dlazdice
    {

        public override string ToString()
        {
            return "*";
        }

        public override void Enter(Housenka housenka)
        {
            housenka.Growing += 1;
            var krajina = housenka.Plocha;
            krajina[housenka.Poloha] = new Vzduch();
        }

        public class MegaZeli : Zeli
        {
            public MegaZeli(byte kolikZeli = 5)
            {
                KolikZeli = kolikZeli;
            }

            public byte KolikZeli { get; }


            public override string ToString()
            {
                return "$";
            }

            public override void Enter(Housenka housenka)
            {
                housenka.Growing += KolikZeli;
                var krajina = housenka.Plocha;
                krajina[housenka.Poloha] = new Vzduch();
            }
        }
    }
}
