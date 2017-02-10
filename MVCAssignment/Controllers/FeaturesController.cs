using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAssignment.Models;

namespace MVCAssignment.Controllers
{
    public class FeaturesController : Controller
    {
        //FEVER CHECK

        //GET: FeverCheck
        [Route("~/FeverCheck")]
        public ActionResult FeverCheck()
        {
            FeverCheck Fever = new Models.FeverCheck();
            Fever.MyTemp = 0.0F;
            Fever.MyTempResult = "Your result will show up here.";
            Fever.SetBold = false;
            Fever.CelsiusOn = true;

            return View(Fever);
        }

        //Action method exclusive to http posting, called by FeverCheck form
        [HttpPost]
        public ActionResult FeverCheck(FeverCheck Fever)
        {
            Fever.MyTempResult = Models.FeverCheck.TempCalc(Fever, Fever.MyTemp);
            return View(Fever);
        }

        
        // -------------------------------------------------------------------------------
        //GUESSING GAME

        [HttpGet]
        public ActionResult GuessingGame()
        {
            //Initializing values
            GuessingGame Guess = new GuessingGame();
            Guess.NumLabel = "Guess a number between 1-10!";
            Guess.Result = "Your result will show up here.";
            Guess.NumChoice = 0;
            Guess.NumRand = 0;

            //Gives NumRand a random number
            Guess.NumRand = Guess.NumRandomizer(Guess.NumRand);

            //Initializing session variables
            Session["Random"] = Guess.NumRand;
            Session["Choice"] = 0;
            Session["Evaluation"] = Guess.Result;
            Session["GuessRecord"] = Guess.guessRecord;

            return View(Guess);
        }

        [HttpPost]
        public ActionResult GuessingGame(GuessingGame Guess)
        {
            //Adds choice to its Session
            Session["Choice"] = Guess.NumChoice;

            //Updates record with its Session
            Guess.guessRecord = (List<string>)Session["GuessRecord"];

            Session["Evaluation"] = Guess.ChoiceEvaluation(Guess, (int)Session["Random"]);

            //If choice is valid, add to record and update record Session, otherwise give error message
            Guess.AddToRec(Guess, (List<string>)Session["GuessRecord"]);

            return View(Guess);
        }
    }
}