using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCAssignment.Models
{

    public class People
    {

        #region DATABASE LISTS

        //Creates a static collection to refer to as the actual list of people
        public static List<List<string>> PeopleRefData { get; set; } = new List<List<string>>()
        {
            //Initializes the default people
            new List<string> { "Emma Svenson", "202-555-0107", "San Francisco", "0" },
            new List<string> { "Arnold Jonsson", "202-555-0162", "San Diego", "1" },
            new List<string> { "Yumi Waterman", "202-555-0175", "Seattle", "2" },
            new List<string> { "Bluma Finnin", "202-555-0147", "Nashville", "3" },
            new List<string> { "Levon Ferro", "202-555-0190", "New York", "4" }
        };

        //Copies the previous list content to a new "working"-list for displaying people
        public static List<List<string>> PeopleData { get; set; } = new List<List<string>>(PeopleRefData);

        #endregion DATABASE LISTS

        #region FORM PROPS

        [Display(Name = "Search: ")]
        public string SearchString { get; set; }

        [Display(Name = "Name: ")]
        public string AddName { get; set; }

        [Display(Name = "Phone number: ")]
        public string AddPhone { get; set; }

        [Display(Name = "City: ")]
        public string AddCity { get; set; }

        public string ErrorMsg { get; set; }

        #endregion FORM PROPS

        #region LOGIC METHODS

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

                //Change PartialNum to index?
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

        #endregion LOGIC METHODS

    }

}