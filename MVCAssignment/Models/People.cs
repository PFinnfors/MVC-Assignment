using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCAssignment.Models
{
    [Bind(Include = "AddName, AddPhone, AddCity")]
    public class People
    {

        #region DATABASE

        //Creates a static collection to refer to as the actual list of people
        public static List<List<string>> PeopleRefData { get; set; } = new List<List<string>>()
        {
            /* Initializes the default people
            NAME, PHONE NUMBER, CITY */
            new List<string> { "Emma Svenson", "202-555-0107", "San Francisco" },
            new List<string> { "Arnold Jonsson", "202-555-0162", "San Diego" },
            new List<string> { "Yumi Waterman", "202-555-0175", "Seattle" },
            new List<string> { "Bluma Finnin", "202-555-0147", "Nashville" },
            new List<string> { "Levon Ferro", "202-555-0190", "New York" }
        };

        //Copies the previous list content to a new "working"-list for displaying people
        public static List<List<string>> PeopleData { get; set; } = new List<List<string>>(PeopleRefData);

        #endregion DATABASE

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

        public int RowNum { get; set; }

        #endregion FORM PROPS

        #region LOGIC METHODS

        /*Selects anything if SearchString is null, else finds a substring match and selects parent.
            Not perfect since it will select a list up to 3 times if there are 3 different matches in one list,
            but it will do for now.*/
        public void Search(People People, People people)
        {
            if (SearchString != null)
            {
                //Mines out the relevant sources within the master list
                var matchingvalues =
                from li in PeopleData
                from str in li

                    //where at least one substring in lowercase equals the lowercased SearchString
                    where str.ToLowerInvariant().Contains(SearchString.ToLowerInvariant())
                    //Selects the parent list of such a string
                    select li;

                //Replaces main list-of-lists with the final filtered list-of-lists
                PeopleData = new List<List<string>>(matchingvalues);
            }
            else
            {
                //Find any sublists at all
                var matchingvalues =
                    from li in PeopleData
                    select li;

                //Replaces main list-of-lists with the final filtered list-of-lists
                PeopleData = new List<List<string>>(matchingvalues);
            }
        }

        //Function to call with session states to load them into the current states (if they're not null)
        public void LoadStates(List<List<string>> people, List<List<string>> reference, int? row)
        {
            if (people != null)
            {
                PeopleData = people;
            }

            if (reference != null)
            {
                PeopleRefData = reference;
            }

            if (row != null)
            {
                RowNum = (int)(row);
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
            PeopleRefData.Add(newPerson);
        }

        public void RemovePerson(int? removed)
        {
            if (removed != null)
            {
                //
                People.PeopleRefData.RemoveAt((int)(removed));
            }
        }

        #endregion LOGIC METHODS

    }

}