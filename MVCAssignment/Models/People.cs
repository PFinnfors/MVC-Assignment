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

        /*Selects anything if SearchString is null, else finds a substring match and selects parent.
            Not perfect since it will select a list up to 3 times if there are 3 different matches in one list,
            but it will do for now.*/
        public void Search(People People, People people)
        {
            if (SearchString == null)
            {
                //Find any sublists at all
                var matchingvalues =
                    from li in PeopleList
                    select li;

                //Creates new list-of-lists with the selection
                List<List<string>> filteredList = new List<List<string>>(matchingvalues);

                //Replaces main list-of-lists with the final filtered list-of-lists
                PeopleList = filteredList;
            }
            else
            {
                //Finds sublist within the list-of-lists
                var matchingvalues =
                from li in PeopleList
                from str in li

                    //where the searched string in lowercase equals the lowercased SearchString
                where str.ToLowerInvariant().Contains(SearchString.ToLowerInvariant())
                select li;

                //Creates new list-of-lists with the selection
                List<List<string>> filteredList = new List<List<string>>(matchingvalues);

                //Replaces main list-of-lists with the final filtered list-of-lists
                PeopleList = filteredList;
            }
        }

        //Function to call with session states to load them into the current states
        public void UpdateStates(List<List<string>> people, List<List<string>> reference)
        {
            if (people != null && reference != null)
            {
                PeopleList = people;
                ReferenceList = reference;
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

            //Adds to list permanently
            ReferenceList.Add(newPerson);
        }

        public void RemovePerson(int? removed)
        {
            if (removed != null)
            {
                //
                People.ReferenceList.RemoveAt((int)(removed));
            }
        }
    }

    //public class Pple : ICollection<Pple>
    //{
    //    public string Name { get; set; }
    //    public string Phone { get; set; }
    //    public string City { get; set; }

    //    // Implementation of IEquatable<T> interface
    //    public bool Equals(Pple pple)
    //    {
    //        if (this.Name == pple.Name &&
    //            this.Phone == pple.Phone &&
    //            this.City == pple.City)
    //        {
    //            return true;
    //        }
    //        else
    //            return false;
    //    }
    //}
}