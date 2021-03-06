﻿using System;
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

        //Game restarts when page is reloaded outside the form
        [HttpGet]
        public ActionResult GuessingGame()
        {
            //Page model
            GuessingGame Guess = new GuessingGame();

            //Initializes cookie used for highscore outside game session, set to last 1 day
            if (Request.Cookies["score"] != null)
            {
                Guess.highscore = new HttpCookie("score", "0");
                Guess.highscore.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(Guess.highscore);
            }

            //Gives NumRand a random number, will be hidden from user
            Guess.NumRand = Guess.NumRandomizer();

            //Initializing session variables
            Session["Random"] = Guess.NumRand;
            Session["Choice"] = 0;
            Session["Evaluation"] = Guess.Result;
            Session["GuessRecord"] = Guess.guessRecord;

            return View(Guess);
        }

        //This Action is called when number form is submitted (postback)
        [HttpPost]
        public ActionResult GuessingGame(GuessingGame Guess)
        {
            //Adds choice to its Session so user can keep their last guess in the box after guessing
            Session["Choice"] = Guess.NumChoice;

            //Updates random variable with stored value
            Guess.NumRand = (int)Session["Random"];

            //Updates record with its Session
            Guess.guessRecord = (List<string>)Session["GuessRecord"];

            //Calls on method to select result based on a comparison between the random and the guess
            Guess.Result = Guess.ChoiceEvaluation(Guess.NumRand);

            //If choice is valid, add to record and update record Session, otherwise give error message
            Guess.AddToRec((List<string>)Session["GuessRecord"]);

            //Result text to its session
            Session["Evaluation"] = Guess.Result;

            //IF WON
            if (Guess.wonGame)
            {
                //When record is lower than previously stored highscore, update highscore cookie
                Response.Cookies["score"].Value = Guess.SetHighscore(Request.Cookies["score"].Value);

                //Resets for next round
                Guess.guessRecord.Clear();
                Guess.NumChoice = 0;

                //Gives a new random number for next round
                Guess.NumRand = Guess.NumRandomizer();
            }
            Session["Random"] = Guess.NumRand;

            return View(Guess);
        }


        // -------------------------------------------------------------------------------

        People people = new People();

        //GET: People
        [HttpGet]
        public ActionResult People(People People, People people, int? remove = null)
        {

            //Updates reference list-of-lists if a saved session of it exists
            if ((List<List<string>>)(Session["ReferenceList"]) != null)
            {
                People.ReferenceList = (List<List<string>>)(Session["ReferenceList"]);
            }

            //Resets ViewList with reference for consistency
            People.ViewList = People.ReferenceList;

            //If optional int was passed into Action, trigger row removal of the suggested index
            if (remove != null)
            {
                People.ViewList.RemoveAt((int)(remove));
                People.ReferenceList.RemoveAt((int)(remove));
            }

            //Filters ViewList if SearchString isn't null
            people.Search(People, people);

            return View(people);
        }

        [HttpPost]
        public ActionResult People(People People, People people)
        {
            //Only if the entire form is filled out
            if (people.AddName != null && people.AddPhone != null && people.AddCity != null)
            {
                //Method that builds a new person list and adds it to the collection, based on form inputs
                people.Add(people);

                //Saves current list-of-lists into a session state
                Session["ReferenceList"] = People.ReferenceList;
            }
            else
            {
                people.ErrorMsg = "All fields are required!";
            }

            return View(people);
        }
    }
}