using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCAssignment.Models
{
    public class People
    {

        //Populating lists in constructor
        public People()
        {
            Person1 = new List<string>() { Name1, Phone1, City1 };
            Person2 = new List<string>() { Name2, Phone2, City2 };
            Person3 = new List<string>() { Name3, Phone3, City3 };
            Person4 = new List<string>() { Name4, Phone4, City4 };
            Person5 = new List<string>() { Name5, Phone5, City5 };

            ViewList = new List<List<string>>() { Person1, Person2, Person3, Person4, Person5 };
            ReferenceList = new List<List<string>>() { Person1, Person2, Person3, Person4, Person5 };
        }

        /* PROPERTIES-------------------
         * NAME - PHONE NUMBER - CITY */

        //Emma Svenson
        private string Name1 { get; set; } = "Emma Svenson";
        private string Phone1 { get; set; } = "202-555-0107";
        private string City1 { get; set; } = "San Francisco";

        private string Name2 { get; set; } = "Arnold Jonsson";
        private string Phone2 { get; set; } = "202-555-0162";
        private string City2 { get; set; } = "San Diego";

        private string Name3 { get; set; } = "Yumi Waterman";
        private string Phone3 { get; set; } = "202-555-0175";
        private string City3 { get; set; } = "Seattle";

        private string Name4 { get; set; } = "Bluma Finnin";
        private string Phone4 { get; set; } = "202-555-0147";
        private string City4 { get; set; } = "Nashville";

        private string Name5 { get; set; } = "Levon Ferro";
        private string Phone5 { get; set; } = "202-555-0190";
        private string City5 { get; set; } = "New York";

        public static List<string> Person1 { get; set; }
        public static List<string> Person2 { get; set; }
        public static List<string> Person3 { get; set; }
        public static List<string> Person4 { get; set; }
        public static List<string> Person5 { get; set; }

        public static List<List<string>> ViewList { get; set; }

        public List<List<string>> ReferenceList { get; set; }

        [Display(Name = "Search:")]
        public string SearchString { get; set; }

        [Display(Name = "Add person:")]
        public string AddString { get; set; }

        //METHODS-------------------

        //
        public void Search(People people, People People)
        {
            //Skip filtering if search is null
            if (SearchString != null)
            {

                    //Selects lists from list which contain any strings with substring == SearchString
                    var matchingvalues =
                        from liLi in ViewList
                        from li in liLi
                        where li.ToLower().Contains(SearchString.ToLower())
                        select liLi;

                    //Creates new list-of-lists with identified list(s)
                    List<List<string>> filteredList = new List<List<string>>(matchingvalues);

                    //Clears list-of-lists and replaces with filtered list-of-lists
                    ViewList.Clear();
                    ViewList = filteredList;
            }    
        }

        //
        public List<string> Add(People people, string name, string phoneNum, string city)
        {
            List<string> test = new List<string>();


            return test;
        }
    }
}