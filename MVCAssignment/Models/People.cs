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

            PeopleList = new List<List<string>>() { Person1, Person2, Person3, Person4, Person5 };
            ReferenceList = new List<List<string>>() { Person1, Person2, Person3, Person4, Person5 };

            ErrorMsg = " ";
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

        public static List<List<string>> PeopleList { get; set; }
        public static List<List<string>> ReferenceList { get; set; }

        [Display(Name = "Search: ")]
        public string SearchString { get; set; }

        [Required(ErrorMessage = "Name required!")]
        [Display(Name = "Name: ")]
        public string AddName { get; set; }

        [Required(ErrorMessage = "Phone number required!")]
        [Display(Name = "Phone number: ")]
        public string AddPhone { get; set; }

        [Required(ErrorMessage = "City required!")]
        [Display(Name = "City: ")]
        public string AddCity { get; set; }

        public string ErrorMsg { get; set; }

        public int PartialNum { get; set; }

        //METHODS-------------------

        //
        public void Search(People People, People people)
        {
            //Skip filtering if search is null
            if (SearchString != null)
            {

                //Selects lists from list which contain any strings with substring == SearchString
                var matchingvalues =
                    from liLi in PeopleList
                    from li in liLi
                    where li.ToLower().Contains(SearchString.ToLower())
                    select liLi;

                //Creates new list-of-lists with identified list(s)
                List<List<string>> filteredList = new List<List<string>>(matchingvalues);

                //Clears list-of-lists and replaces with filtered list-of-lists
                PeopleList = filteredList;
            }
        }

        //Method for building new person list and adding it
        public void Add(People people)
        {
            //Prepares a list
            List<string> newPerson = new List<string>();

            //Puts together data into the list
            newPerson.Add(people.AddName);
            newPerson.Add(people.AddPhone);
            newPerson.Add(people.AddCity);

            //Adds list to the end result list-of-lists
            //PeopleList = ReferenceList;
            PeopleList.Add(newPerson);
        }

        public void RemovePerson(int? removed)
        {
            if (removed != null)
            {
                People.PeopleList.RemoveAt((int)(removed));

                if (People.PeopleList.Count < ReferenceList.Count)
                {
                    ReferenceList.RemoveAt((int)(removed));
                }
            }
        }
    }
}