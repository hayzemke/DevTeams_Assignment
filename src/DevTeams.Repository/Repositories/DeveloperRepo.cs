using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class DeveloperRepo
    {
        private List<Developer> _developerDatabase = new List<Developer>();
        private int _count;

        //* Create
        public bool AddDeveloper(Developer developer)
        {
            if (developer != null)
            {
                _count++;
                developer.developerID=_count;
                _developerDatabase.Add(developer);
                return true;
            }
            else
            {
                return false;
            } 
        }

          public bool AddDeveloperToTeam(Developer developer, DevTeam devTeam)
        {
            if (devTeam != null)
            {
                _developerDatabase.Add(developer);
                return true;
            }
            else
            {
                return false;
            } 
        }


        //* Read

        public List<Developer> GetAllDevelopers()
        {
            return _developerDatabase;
        }

        public Developer GetDeveloperByID(int id)
        {
            foreach (var developer in _developerDatabase)
            {
                if (developer.developerID == id)
                {
                    return developer;
                }
            }
            return null;
        }

        //* Update
        public bool UpdateDeveloperData(int id, Developer newDeveloperData)
        {
            var oldDeveloperData = GetDeveloperByID(id);
            if (oldDeveloperData != null)
            {
                oldDeveloperData.FirstName = newDeveloperData.FirstName;
                oldDeveloperData.LastName = newDeveloperData.LastName;
                oldDeveloperData.pluralsightAccess = newDeveloperData.pluralsightAccess;
                return true;
            }
            else
            {
                return false;
            }
        }

        //* Delete
        public bool RemoveDeveloperFromList(int id)
        {
            var developer = GetDeveloperByID(id);
            if (developer == null)
            {
                return false;
            }

            int initialCount = _developerDatabase.Count;
            _developerDatabase.Remove(developer);

            if (initialCount >_developerDatabase.Count)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public List<Developer> pluralsightAccess ()
        {
            List<Developer> developersWithPluralsight = new List<Developer>();
            foreach (Developer developers in _developerDatabase)
            {
                if (developers.pluralsightAccess)
                {
                    developersWithPluralsight.Add(developers);
                }
            }
            return developersWithPluralsight;
        }
    
    }