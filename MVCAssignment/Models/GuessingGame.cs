using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCAssignment.Models;

namespace MVCAssignment.Models
{
    public class GuessingGame
    {
        //
        public string NumLabel { get; set; }
        public string Result { get; set; }
        public int NumChoice { get; set; }
        public int NumRand { get; set; }

        public HttpCookie guessCookie = new HttpCookie("guess");
        public Random rand = new Random();

        public int NumRandomizer(int num)
        {
            num = rand.Next(1, 10);
            return num;
        }
    }
}