using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Developer
    {

        public Developer(){}

        public Developer(string firstName, string lastName, bool pluralsightAccess)
        {
            FirstName=firstName;
            LastName=lastName;
            this.pluralsightAccess=pluralsightAccess;
        }

        public int developerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";

            }
        }
        public bool pluralsightAccess { get; set; }
        public  override string ToString()
        {
            return $"developerID: {this.developerID}\nName: {this.FullName}\nPluralsightAccess: {this.pluralsightAccess}\n";
        }
        
    }
