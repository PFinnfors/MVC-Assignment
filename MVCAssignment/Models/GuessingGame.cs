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
        public List<string> guessRecord = new List<string>();
        public bool wonGame = false;

        //HttpCookie Highscore = new HttpCookie("Highscore");

        public Random rand = new Random();

        public int NumRandomizer(int num)
        {
            num = rand.Next(1, 100);
            return num;
        }

        public string ChoiceEvaluation(GuessingGame guessClass, int SessionRand)
        {
            if (guessClass.NumChoice == SessionRand)
            {
                guessClass.Result = "You got it right!";
                wonGame = true;

            }
            else if (guessClass.NumChoice < SessionRand)
            {
                guessClass.Result = "Sorry, your number was too small!";
            }
            else if (guessClass.NumChoice > SessionRand)
            {
                guessClass.Result = "Shooting for the stars? Number was too big!";
            }

            //Gives a new random number
            guessClass.NumRand = guessClass.NumRandomizer(guessClass.NumRand);

            return guessClass.Result;
        }

        public void AddToRec(GuessingGame guessClass, List<string> sessionRec)
        {
            if (NumChoice >= 1 && NumChoice <= 100)
            {
                guessRecord.Add(NumChoice.ToString());
                sessionRec = guessRecord;
            }
            //
            else
            {
                Result = "Oops! Your guess must be between 1 and 100!";
            }
        }

    }
}