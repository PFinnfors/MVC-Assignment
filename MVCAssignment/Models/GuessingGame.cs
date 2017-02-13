using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCAssignment.Models;

namespace MVCAssignment.Models
{
    public class GuessingGame
    {
        //Declaring variables
        public List<string> guessRecord;
        public string Result { get; set; }
        public Random rand;
        public HttpCookie highscore;

        public int NumChoice { get; set; }
        public int NumRand { get; set; }
        public bool wonGame;

        //Initializing through constructor
        public GuessingGame()
        {
            Result = "Your result will show up here.";
            wonGame = false;
            NumChoice = 0;
            NumRand = 0;
            guessRecord = new List<string>();

            rand = new Random();
        }

        //Method to randomize input numbers
        public int NumRandomizer()
        {
            NumRand = rand.Next(1, 100);
            return NumRand;
        }

        //Evaluates guess and returns result
        public string ChoiceEvaluation(int SessionRand)
        {
            //If you win
            if (NumChoice == SessionRand)
            {
                Result = "You got it right! Guess again to continue playing.";
                wonGame = true;
            }
            //Guess too low
            else if (NumChoice < SessionRand)
            {
                Result = "Sorry, your number was too small!";
            }
            //Guess too high
            else if (NumChoice > SessionRand)
            {
                Result = "Shooting for the stars? Number was too big!";
            }

            return Result;
        }

        //Decides whether to add the guess to record or not
        public List<string> AddToRec(List<string> guessRecord)
        {
            //If choice is within margins, add it to record
            if (NumChoice >= 1 && NumChoice <= 100)
            {
                guessRecord.Add(NumChoice.ToString());
            }
            //Error if input is invalid
            else
            {
                Result = "Oops! Your guess must be between 1 and 100!";
            }

            return guessRecord;
        }

        //Selects highscore result
        public string SetHighscore(string prevScore)
        {
            int prevScoreInt = Convert.ToInt16(prevScore);
            string newScore = "0";

            //Sets highscore first time (previous is zero)
            if (prevScoreInt == 0)
            {
                newScore = guessRecord.Count.ToString();
            }
            //Sets new highscore if previous number is lower than the new
            else if (guessRecord.Count < prevScoreInt)
            {
                newScore = guessRecord.Count.ToString();
            }
            //Echoes the score back if highscore wasn't achieved
            else
            {
                newScore = prevScore;
            }

                return newScore;
        }
    }
}