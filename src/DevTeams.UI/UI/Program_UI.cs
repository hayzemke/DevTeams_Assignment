using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program_UI
{
    private readonly DeveloperRepo _devRepo = new DeveloperRepo();
    private readonly DevTeamRepo _devTeamRepo;
    public Program_UI()
    {
        _devTeamRepo = new DevTeamRepo(_devRepo);
    }

    public void Run()
    {
        SeedData();

        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();

            System.Console.WriteLine("~~~~~~~ Welcome to Komodo's Insurance ~~~~~~~");
            System.Console.WriteLine("Please Make a Selection:\n" +
            "==== Developr Database ====\n" +
            "1. Add Developer\n" +
            "2. See All Developers\n" +
            "3. Find Developer by ID \n" +
            "4. Update Existing Developer Info\n" +
            "5. Remove Developer\n" +
            "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
            "==== Developer Team Database ====\n" +
            "6. Create Team\n" +
            "7. See All Teams\n" +
            "8. Find Team by ID\n" +
            "9. Add Developer to Team\n" +
            "10. Remove Developr from Team\n" +
            "11. Remove Team\n" +
            "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
            "12. Close Application!\n");

            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    AddDeveloper();
                    break;

                case "2":
                    SeeAllDevelopers();
                    break;

                case "3":
                    FindDeveloperByID();
                    break;

                case "4":
                    UpdateExistingDeveloperInfo();
                    break;

                case "5":
                    RemoveDeveloper();
                    break;

                case "6":
                    CreateTeam();
                    break;

                case "7":
                    SeeAllTeams();
                    break;

                case "8":
                    FindTeamByID();
                    break;

                case "9":
                    RemoveTeam();
                    break;
                    
                case "12":
                    isRunning = CloseApplication();
                    break;

                default:
                    System.Console.WriteLine("Invalid Selection!");
                    PressAnyKeyToContinue();
                    break;
            }
        }


        PressAnyKeyToContinue();
    }

    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Have a Great Day!");
        PressAnyKeyToContinue();
        return false;
    }

    private void RemoveTeam()
    {
        Console.Clear();

        try
        {
            System.Console.WriteLine("Please Input An Existing DevTeam ID:");
            int teamID = int.Parse(Console.ReadLine());
            var selectedDevTeam = _devTeamRepo.GetDevTeamsByID(teamID);
            if (selectedDevTeam != null)
            {
                bool isSuccessful = _devTeamRepo.RemoveDevTeamFromList(selectedDevTeam.TeamID);
                if (isSuccessful)
                {
                    System.Console.WriteLine("Success!");
                }
                else
                {
                    System.Console.WriteLine("Failed!");
                }
            }
            else
            {
                System.Console.WriteLine("Developer Does Not Exist!");
            }

        }
        catch
        {

            System.Console.WriteLine("Sorry Invalid Selection!");
        }

        PressAnyKeyToContinue();
    }

    private void FindTeamByID()
    {
        Console.Clear();
        try
        {
            System.Console.WriteLine("Please Input An Existing Team ID:");
            int devTeamID = int.Parse(Console.ReadLine());
            var selectedDevTeam = _devTeamRepo.GetDevTeamsByID(devTeamID);
            if (selectedDevTeam != null)
            {
                DisplayDevTeamInfo(selectedDevTeam);
            }
            else
            {
                System.Console.WriteLine("Developer Does Not Exist!");
            }

        }
        catch
        {

            System.Console.WriteLine("Sorry Invalid Selection!");
        }

        PressAnyKeyToContinue();
    }

    private void SeeAllTeams()
    {
        Console.Clear();

        List<DevTeam> devTeamsInDatabase = _devTeamRepo.GetDevTeamsList();
        foreach (var devTeam in devTeamsInDatabase)
        {
            DisplayDevTeamInfo(devTeam);

        }
        PressAnyKeyToContinue();
    }

    private void DisplayDevTeamInfo(DevTeam devTeam)
    {
        System.Console.WriteLine($"devTeamID: {devTeam.TeamID}\nDevTeamName: {devTeam.TeamName}");
        System.Console.WriteLine("===========================");
        System.Console.WriteLine("Developers");
        if (devTeam.Developers.Count > 0)
        {
            foreach (var dev in devTeam.Developers)
            {
                System.Console.WriteLine(dev.ToString());
            }
        }
    }

    private void CreateTeam()
    {
        Console.Clear();

        var newDevTeam = new DevTeam();
        System.Console.WriteLine("==== Developer Team Form ====\n ");

        System.Console.WriteLine("Please Enter Team Name:");
        newDevTeam.TeamName = Console.ReadLine();

        bool isSuccessful = _devTeamRepo.AddDevTeamToList(newDevTeam);
        if (isSuccessful)
        {
            System.Console.WriteLine($"{newDevTeam.TeamName} was added to the database!");
        }
        else
        {
            System.Console.WriteLine("Developer was not added to database");
        }

        PressAnyKeyToContinue();
    }

    private void RemoveDeveloper()
    {
        Console.Clear();

        try
        {
            System.Console.WriteLine("Please Input An Existing Developer ID:");
            int devID = int.Parse(Console.ReadLine());
            var selectedDeveloper = _devRepo.GetDeveloperByID(devID);
            if (selectedDeveloper != null)
            {
                bool isSuccessful = _devRepo.RemoveDeveloperFromList(selectedDeveloper.developerID);
                if (isSuccessful)
                {
                    System.Console.WriteLine("Success!");
                }
                else
                {
                    System.Console.WriteLine("Failed!");
                }
            }
            else
            {
                System.Console.WriteLine("Developer Does Not Exist!");
            }

        }
        catch
        {

            System.Console.WriteLine("Sorry Invalid Selection!");
        }

        PressAnyKeyToContinue();
    }

    private void UpdateExistingDeveloperInfo()
    {
        Console.Clear();

        var developers = _devRepo.GetAllDevelopers();
        System.Console.WriteLine("Please Enter Developer ID");
        var developerID = int.Parse(Console.ReadLine());
        var selectedDeveloper = _devRepo.GetDeveloperByID(developerID);

        if (selectedDeveloper != null)
        {
            var newDeveloper = new Developer();
            System.Console.WriteLine("==== Developer Info Form ====\n ");

            System.Console.WriteLine("Please Enter Employee's First Name:");
            newDeveloper.FirstName = Console.ReadLine();

            System.Console.WriteLine("Please Enter Employee's Last Name:");
            newDeveloper.LastName = Console.ReadLine();

            System.Console.WriteLine("Do You Have A PluralSight Account? Y/N");
            string userInput = Console.ReadLine();
            if (userInput == "Y".ToLower())
            {
                newDeveloper.pluralsightAccess = true;
            }
            else
            {
                newDeveloper.pluralsightAccess = false;
            }

            bool isSuccessful = _devRepo.UpdateDeveloperData(selectedDeveloper.developerID, newDeveloper);
            if (isSuccessful)
            {
                System.Console.WriteLine("Update Successful!!");
            }
            else
            {
                System.Console.WriteLine("Update Failed!");
            }
        }
        else
        {
            System.Console.WriteLine("Sorry the Developer Doesn't Exist!");
        }

        PressAnyKeyToContinue();
    }

    private void FindDeveloperByID()
    {
        Console.Clear();
        try
        {
            System.Console.WriteLine("Please Input An Existing Developer ID:");
            int devID = int.Parse(Console.ReadLine());
            var selectedDeveloper = _devRepo.GetDeveloperByID(devID);
            if (selectedDeveloper != null)
            {
                System.Console.WriteLine(selectedDeveloper.ToString());
            }
            else
            {
                System.Console.WriteLine("Developer Does Not Exist!");
            }

        }
        catch
        {

            System.Console.WriteLine("Sorry Invalid Selection!");
        }


        PressAnyKeyToContinue();
    }

    private void SeeAllDevelopers()
    {
        Console.Clear();
        //* we need a variable that will hold all of the values from the dev repo
        List<Developer> devsInDatabase = _devRepo.GetAllDevelopers();
        //* have to loop through devsInDatabase in order to get values
        foreach (var dev in devsInDatabase)
        {
            //* create a helped method
            System.Console.WriteLine(dev.ToString());
        }


        PressAnyKeyToContinue();
    }

    private void AddDeveloper()
    {
        Console.Clear();

        var newDeveloper = new Developer();
        System.Console.WriteLine("==== Developer Info Form ====\n ");

        System.Console.WriteLine("Please Enter Employee's First Name:");
        newDeveloper.FirstName = Console.ReadLine();

        System.Console.WriteLine("Please Enter Employee's Last Name:");
        newDeveloper.LastName = Console.ReadLine();

        System.Console.WriteLine("Do You Have A PluralSight Account? Y/N");
        string userInput = Console.ReadLine();
        if (userInput == "Y".ToLower())
        {
            newDeveloper.pluralsightAccess = true;
        }
        else
        {
            newDeveloper.pluralsightAccess = false;
        }

        bool isSuccessful = _devRepo.AddDeveloper(newDeveloper);
        if (isSuccessful)
        {
            System.Console.WriteLine($"{newDeveloper.FirstName} - {newDeveloper.LastName} was added to the database!");
        }
        else
        {
            System.Console.WriteLine("Developer was not added to database");
        }

        PressAnyKeyToContinue();
    }

    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press Any Key to Continue!");
        Console.ReadKey();
    }

    private void SeedData()
    {
        //* first i have to create my developers for seeding
        Developer developerA = new Developer("Haley", "Zemkewicz", true);
        Developer developerB = new Developer("John", "Zemkewicz", false);
        Developer developerC = new Developer("Matt", "Kish", true);
        Developer developerD = new Developer("Jess", "Young", true);
        Developer developerE = new Developer("Bahige", "Owens", false);

        //* have to add them to _devRepo
        _devRepo.AddDeveloper(developerA);
        _devRepo.AddDeveloper(developerB);
        _devRepo.AddDeveloper(developerC);
        _devRepo.AddDeveloper(developerD);
        _devRepo.AddDeveloper(developerE);

        DevTeam backEndDev = new DevTeam("Back End Devs", new List<Developer> { developerA, developerC });
        DevTeam frontEndDev = new DevTeam("Front End Devs", new List<Developer> { developerB });
        DevTeam fullStackDev = new DevTeam("Full Stack Devs", new List<Developer> { developerD,  developerE });

        _devTeamRepo.AddDevTeamToList(backEndDev);
        _devTeamRepo.AddDevTeamToList(frontEndDev);
        _devTeamRepo.AddDevTeamToList(fullStackDev);
    }
}