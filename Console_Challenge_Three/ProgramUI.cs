using System;
using System.Collections.Generic;

namespace Console_Challenge_Three
{
    public class ProgramUI
    {
        // init repos
        BadgeRepo badgeRepo = new BadgeRepo();

        public void Run()
        {
            MainMenu();
        }

        private List<String> AddDoor(List<String> doors)
        {
            string doorToEdit;
            Console.WriteLine("List a door that it needs access to: ");
            doorToEdit = Console.ReadLine();
            Console.WriteLine("Any other doors(y/ n)?");
            string lineInput = Console.ReadLine();
            doors.Add(doorToEdit);
            if (lineInput == "y")
            {
                doors = AddDoor(doors);
            }

            return doors;
        }

        private List<String> RemoveDoor(List<String> doors)
        {
            string doorToEdit;
            Console.WriteLine("List a door that needs removed: ");
            doorToEdit = Console.ReadLine();
            Console.WriteLine("Any other doors(y/ n)?");
            string lineInput = Console.ReadLine();
            doors.Remove(doorToEdit);
            if (lineInput == "y")
            {
                doors = RemoveDoor(doors);
            }

            return doors;
        }

        private void MainMenu()
        {
            Console.WriteLine("Select an Option: \n" +
                "1. Add a new badge \n" +
                "2. Edit a badge \n" +
                "3. List All Badges \n" +
                "4. Exit");
            string input = Console.ReadLine();
            bool wasSuccessful;

            string badgeId;
            List<String> doors = new List<string>();
            Dictionary<string, List<String>> badges;
            Badge badge;
            string doorToEdit;

            switch (input)
            {
                case "1":
                    // List Badges
                    badges = badgeRepo.GetBadgeList();
                    Console.WriteLine(badges.Count);


                    foreach (KeyValuePair<string, List<String>> entry in badges)
                    {
                        // do something with entry.Value or entry.Key
                        Console.WriteLine("BadgeID: " + entry.Key);
                        Console.WriteLine("Doors: ");
                        foreach(string door in entry.Value)
                        {
                            Console.WriteLine(door);
                        }
                    }

                    MainMenu();
                    break;
                case "2":
                    // update badge
                    Console.WriteLine("What is the badge number to update? ");
                    badgeId = Console.ReadLine();
                    doors = badgeRepo.GetBadgeByBadgeId(badgeId);
                    Console.WriteLine(badgeId + " has access to ");
                    foreach (string door in doors) {
                        Console.WriteLine(door);
                    }
                    Console.WriteLine("What would you like to do? \n" +
                    "1. Remove a door \n" +
                    "2. Add a door \n");

                    string menuInput = Console.ReadLine();

                    switch (menuInput)
                    {
                        case "1":
                            // update remove door
                            //  Remove door
                            doors = RemoveDoor(doors);
                            badgeRepo.UpdateBadgeDoors(badgeId, doors);
                            Console.WriteLine("Door Removed");
                            doors = badgeRepo.GetBadgeByBadgeId(badgeId);
                            Console.WriteLine(badgeId + " has access to ");
                            foreach (string door in doors)
                            {
                                Console.WriteLine(door);
                            }
                            break;
                        case "2":
                            // update add door
                            // Add door
                            doors = AddDoor(doors);
                            badgeRepo.UpdateBadgeDoors(badgeId, doors);
                            doors = badgeRepo.GetBadgeByBadgeId(badgeId);
                            Console.WriteLine(badgeId + " has access to ");
                            foreach (string door in doors)
                            {
                                Console.WriteLine(door);
                            }
                            break;
                        default:
                            MainMenu();
                            break;
                    }

                    break;
                case "3":
                    // Add Badge
                    Console.WriteLine("Enter the badge id: ");
                    badgeId = Console.ReadLine();
                    doors = AddDoor(doors);

                    badgeRepo.AddBadge(badgeId, doors);
                    MainMenu();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please make a different selection.");
                    MainMenu();
                    break;
            }

         
        }
    }
}
