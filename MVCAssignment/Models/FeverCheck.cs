///Models/FeverCheck.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAssignment.Models
{
    public class FeverCheck
    {
        public float MyTemp { get; set; }
        public string MyTempResult { get; set; }
        public bool SetBold { get; set; }
        public bool CelsiusOn { get; set; }

        //Calculates normal, fever or hypothermia status
        public static string TempCalc(FeverCheck Fever,float MyTemp)
        {
            bool hasFever = false;
            bool hasHypo = false;

            switch (Fever.CelsiusOn)
            {
                case true:
                    {
                        //When checkbox is set to celsius (checked), it uses these values
                        hasFever = (MyTemp > 37.7) ? true : false;
                        hasHypo = (MyTemp < 35) ? true : false;
                        break;
                    }
                case false:
                    {
                        //When checkbox is set to fahrenheit (unchecked), it uses these values
                        hasFever = (MyTemp > 99.86) ? true : false;
                        hasHypo = (MyTemp < 95) ? true : false;
                        break;
                    }
            }

            //Uses 0 value as indication nothing (worthwhile) has been put in
            if (MyTemp == 0)
            {
                Fever.MyTempResult = "Your result will show up here.";
            }
            //Temperature indicates fever
            else if (hasFever)
            {
                Fever.MyTempResult = "Whoa, you have a fever. Go to bed!";
                Fever.SetBold = true;
            }
            //Temperature indicates hypothermia
            else if (hasHypo)
            {
                Fever.MyTempResult = "You have hypothermia, not fever!";
                Fever.SetBold = true;
            }
            //Temperature is within normal range
            else
            {
                Fever.MyTempResult = "You're fine, stop being paranoid.";
            }

            return Fever.MyTempResult;
        }

        //Sets the display text for unit depending on user choice
        public string UnitChoice(bool CelsiusOn)
        {
            string unitText = "";
            unitText = (CelsiusOn == true) ? " Celsius" : " Fahrenheit";

            return unitText;
        }
    }
}