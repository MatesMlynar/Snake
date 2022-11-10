using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Housenka
    {
        public bool Mrtva { get; set;}
        public byte Growing { get; set;}
        public Smer Smer { get; set; }
        public Plocha Plocha { get; set; }
        public Poloha Poloha { get; set; }
        
        
        public Housenka(Plocha plocha)
        {
            Plocha = plocha;
            Smer = plocha.InitialSmer;
            Poloha = plocha.InitialPoloha;
            Growing = plocha.InitialLength;

            while (Growing > 0)
            {
                Krok();
            }
            
        }


        public void Krok()
        {
            
        }
        
    }      
}
