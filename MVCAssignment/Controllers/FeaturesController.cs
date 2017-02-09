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

        public ActionResult GuessingGame()
        {
            //Initializing everything
            GuessingGame Guess = new GuessingGame();
            Guess.NumLabel = "Guess a number between 1-10!";
            Guess.Result = "Your result will show up here.";
            Guess.NumChoice = 0;
            Guess.NumRand = 0;
            Guess.Test = "X";

            Session["Random"] = 0;
            Session["Choice"] = 0;
            Session["Guess"] = 0;

            //Gives NumRand a random number
            Guess.NumRand = Guess.NumRandomizer(Guess.NumRand);

            return View(Guess);
        }

        [HttpPost]
        public ActionResult GuessingGame(GuessingGame Guess)
        {
            //
            //Guess.guessCookie[$"Guess{Request.Cookies.}"] = "5";
            //Response.Cookies.Add(Guess.guessCookie);

            //New random for next page
            Guess.NumRand = Guess.NumRandomizer(Guess.NumRand);

            //Adding result to be displayed
            Guess.Result = "POST action executed.";

            return View(Guess);
        }
    }
}