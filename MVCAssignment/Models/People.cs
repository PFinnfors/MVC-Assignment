using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCAssignment.Models
{
    public class People
    {
        /* PROPERTIES-------------------
         * NAME - PHONE NUMBER - CITY */

        //Emma Svenson
        public static List<string> Person1 { get; set; } = new List<string>()
        { "Emma Svenson", "202-555-0107", "San Francisco" };

        //Arnold Jonsson
        public static List<string> Person2 { get; set; } = new List<string>()
        { "Arnold Jonsson", "202-555-0162", "San Diego" };

        //Yumi Waterman
        public static List<string> Person3 { get; set; } = new List<string>()
        { "Yumi Waterman", "202-555-0175", "Seattle" };

        //Bluma Finnin
        public static List<string> Person4 { get; set; } = new List<string>()
        { "Bluma Finnin", "202-555-0147", "Nashville" };

        //Levon Ferro
        public static List<string> Person5 { get; set; } = new List<string>()
        { "Levon Ferro", "202-555-0190", "New York" };

        public List<string> viewList = new List<string>();

        [Display(Name = "Search:")]
        public string SearchString { get; set; }

        //METHODS-------------------

        //
        public List<string> WriteLists()
        {
            List<string> writeList = new List<string>();

            writeList.AddRange(Person1);
            writeList.AddRange(Person2);
            writeList.AddRange(Person3);
            writeList.AddRange(Person4);
            writeList.AddRange(Person5);

            return writeList;
        }

        //
        public void Filter(string SearchString)
        {
            
        }

        //
        public void Sort()
        {

        }
    }
}