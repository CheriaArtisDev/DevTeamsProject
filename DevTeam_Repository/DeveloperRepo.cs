using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developers_Repository
{
    public class DeveloperRepo
    {
        private List<Developer> developerList = new List<Developer>();

        //Add developer to list of developers
        public void AddDeveloper(Developer developer)
        {
            developerList.Add(developer);
        }

        //List the developers
        public List<Developer> GetDeveloperList()
        {
            return developerList;
        }

        //Get developer by Id
        public Developer GetDeveloperById(int developerId)
        {
            foreach(Developer developer in developerList)
            {
                if(developer.DeveloperId == developerId)   
                {
                    return developer;
                }
            }
            return null;
        }

        //Remove a developer from the list
        public bool RemoveDeveloper(int devloperId)
        {
            Developer developer = GetDeveloperById(devloperId);

            if(developer != null)
            {
                int count = developerList.Count;
                developerList.Remove(developer);

                if(count > developerList.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        //Update a Developer's record
        public bool UpdateDeveloper(int developerId, Developer newDeveloper)
        {
            Developer oldDeveloper = GetDeveloperById(developerId);
            if(oldDeveloper != null)
            {
                oldDeveloper.FullName = newDeveloper.FullName;
                oldDeveloper.DeveloperId = newDeveloper.DeveloperId;
                oldDeveloper.AccessToPluralsight = newDeveloper.AccessToPluralsight;
                return true;
            }
            return false;
        }

    }
}
