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
        public string GuessRecord { get; set; }

        public Random rand = new Random();

        public int NumRandomizer(int num)
        {
            num = rand.Next(1, 10);
            return num;
        }

        public string ChoiceEvaluation(GuessingGame guessClass, int SessionVar)
        {
            if (guessClass.NumChoice == SessionVar)
            {
                guessClass.Result = "You got it right!";
            }
            else if (guessClass.NumChoice < SessionVar)
            {
                guessClass.Result = "Close, but no dice. Your number was too small!";
            }
            else if (guessClass.NumChoice > SessionVar)
            {
                guessClass.Result = "Shooting for the stars? Number was too big!";
            }
            else
            {
                guessClass.Result = "Something went wrong...";
            }
            return guessClass.Result;
        }
    }
}