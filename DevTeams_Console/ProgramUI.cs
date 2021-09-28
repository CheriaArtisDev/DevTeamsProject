using Developers_Repository;
using DevTeams_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Console
{
    public class ProgramUI
    {
        private DeveloperRepo developerRepo = new DeveloperRepo();
        private DevTeamRepo devTeamRepo = new DevTeamRepo();

        public void Run()
        {
            bool exit = false;
            while (exit != true)
            {
                Console.Clear();
                Console.WriteLine("Komodo Management Main Menu");
                Console.WriteLine("1. Developer Menu \n" +
                    "2. Team Menu \n" +
                    "3. Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                Run();


                switch (option)
                {
                    case 1:
                        DeveloperMenu();
                        break;
                    case 2:
                        TeamMenu();
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please select from options 1 thru 3");
                        break;
                }
            }
        }
        private void DeveloperMenu()
        {
            bool exit = false;
            while (exit != true)
            {
                Console.Clear();
                DisplayListOfDevelopers();

                Console.WriteLine("Select an option below: \n" +
                    "1. Add a Developer \n" +
                    "2. Update a Developer's Information \n" +
                    "3. Delete a Developer \n" +
                    "4. Return to the previous menu");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddDeveloper();
                        break;
                    case 2:
                        UpdateDeveloper();
                        break;
                    case 3:
                        RemoveDeveloper();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
        private void TeamMenu()
        {
            bool exit = false;
            while (exit != true)
            {
                Console.Clear();
                DisplayListOfTeams();
                int option = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Select an option below: \n" +
                "1. Add a Team \n" +
                "2. Update a Team's Information \n" +
                "3. Delete a Team \n" +
                "4. Return to the previous menu");

                switch (option)
                {
                    case 1:
                        AddTeam();
                        break;
                    case 2:
                        UpdateTeam();
                        break;
                    case 3:
                        RemoveTeam();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public void AddDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Developer Id:");
            int developerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Developer Name:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Pluralsight Access (y/n):");
            string pluralAccess = Console.ReadLine().ToLower();
            bool accessToPluralsight;

            if (pluralAccess == "y")
            {
                accessToPluralsight = true;
            }
            else
            {
                accessToPluralsight = false;
            }

            Developer developer = new Developer()
            {
                DeveloperId = developerId,
                FullName = fullName,
                AccessToPluralsight = accessToPluralsight
            };

            developerRepo.AddDeveloper(developer);
        }

     }

        private void UpdateDeveloper()
        {
        Console.Clear();
        Developer developer = SearchForDeveloper();
        int oldId = developer.DeveloperId;
        string oldName = developer.FullName;
        bool oldAccess = developer.AccessToPluralsight;

        if(developer != null)
        {
            int newId = 0;
            string newName = "";
            bool newAccess = false;
            bool exitLoop = true;
            string answer = null;

            if(developer == null)
            {
                return false;
            }
            DisplayDeveloper(developer);

            while(exitLoop)
            {
                Console.WriteLine("New Developer Id (x to abort change):");
                answer = Console.ReadLine().ToLower();
                if(answer != "x")
                {
                    newId = int.Parse(answer);
                    exitLoop = false;
                }
                else
                {
                    newId = oldId;
                }
                exitLoop = false;
            }
            exitLoop = true;

            Console.Clear();
            DisplayDeveloper(developer);
            while(exitLoop)
            {
                Console.WriteLine("New developer name (x to abort change):");
                answer = Console.ReadLine().ToLower();
                if(answer != "x")
                {
                    newName = answer;
                    exitLoop = false;
                }
                else
                {
                    newName = oldName;
                }
                exitLoop = false;
            }
            exitLoop = true;

            Console.Clear();
            DisplayDeveloper(developer);
            while (exitLoop)
            {
                Console.WriteLine("New Access (y/n) (n for no change):");
                answer = Console.ReadLine().ToLower();
                if (answer != "n")
                {
                    newAccess = true;   
                }  
                else
                {
                    newAccess = oldAccess;
                }
                exitLoop = false;
            }

            DisplayDeveloper(newId, newName, newAccess);
            Console.WriteLine("Please confirm (y/n)");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                developerRepo.UpdateExistingDeveloper(oldId, new Developer() { FullName = newName, DeveloperId = newId, AccessToPluralsight = newAccess });
            }
            else if (answer == "n")
            {
                UpdateDeveloper();
            }
        }
        return false;
    }
        }

        private void RemoveDeveloper()
        {

        }
        private void DisplayListOfDevelopers()
        {
            
        }
        private void SearchForDeveloper()
        {
        DisplayListOfDevelopers();
        Console.WriteLine("Developer Id (x to exit):");
        string answer = Console.ReadLine();
        if (answer.ToLower() != "x")
        {
            int oldId = int.Parse(answer);
            return DeveloperRepo.GetDeveloperById(oldId);
        }
        return null;
    }

    private void DisplayDeveloper(Developer developer)
        {
        Console.WriteLine($"Developer Id: {developer.DeveloperId} Developer Name: {developer.FullName} Pluralsight Access: {developer.AccessToPluralsight}");
        }

        private void DisplayDeveloper(int developerId, string fullName, bool accessToPluralsight)
    {
        Console.WriteLine($"Developer Id: {developerId} Full Name: {fullName} Pluralsight Access: {accessToPluralsight}");
    }

        private void AddTeam()
        {
            
        }

        private void AddDeveloperToTeam()
        {

        }

        private void UpdateTeam()
        {

        }

        private void RemoveTeam()
        {
            DevTeam devTeam = SearchForTeam();
            DisplayTeam(devTeam);
            Console.WriteLine("Remove this team? (y/n)");

            string answer = Console.ReadLine().ToLower();
            if(answer == "y")
            {
                devTeamRepo.RemoveDevTeam(devTeam.TeamId);
                Console.WriteLine("Team removed.");
            }
        }

        private void DisplayListOfTeams()
        {

        }

        private void DisplayTeam()
        {

        }

        private void SearchForTeam()
        {

        }


        

    }
}
