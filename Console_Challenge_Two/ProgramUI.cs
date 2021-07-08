using System;
using System.Collections.Generic;

namespace Console_Challenge_Two
{
    public class ProgramUI
    {
        // init repos
        ClaimRepo claimRepo = new ClaimRepo();

        public void Run()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            Console.WriteLine("Select an Option: \n" +
                "1. See All Claims \n" +
                "2. Take care of next claim \n" +
                "3. Enter a new claim \n" +
                "4. Exit");
            string input = Console.ReadLine();
            bool wasSuccessful;

            string claimId;
            string type;
            string description;
            string amount;
            string dateOfAccidentString;
            string dateOfClaimString;
            DateTime dateOfAccident;
            DateTime dateOfClaim;
            string isValid;

            List<Claim> claims;


            switch (input)
            {
                case "1":
                    // List Claims
                    claims = claimRepo.GetClaimList();
                    Console.WriteLine(claims.Count);
                    if (claims.Count > 0)
                    {
                        Console.WriteLine("ClaimID	Type	Description	Amount	DateOfAccident	DateOfClaim	IsValid");
                        foreach (Claim claim in claims)
                        {
                            Console.WriteLine(claim.ClaimId + "  " + claim.Type + "  " + claim.Description + "  " + claim.Amount + "  " + claim.DateOfAccident + "  " + claim.DateOfClaim + "  " + claim.IsValid);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No claims yet. Please create one.");
                    }
                    MainMenu();
                    break;
                case "2":
                    // Take care of a claim
                    claims = claimRepo.GetClaimList();
                    Claim thisClaim = claims[0];
                    Console.WriteLine("ClaimID: " + thisClaim.ClaimId);
                    Console.WriteLine("Type: " + thisClaim.Type);
                    Console.WriteLine("Description: " + thisClaim.Description);
                    Console.WriteLine("DateOfAccident: " + thisClaim.DateOfAccident);
                    Console.WriteLine("DateOfClaim: " + thisClaim.DateOfClaim);
                    Console.WriteLine("IsValid: " + thisClaim.IsValid);


                    Console.WriteLine("Do you want to deal with this claim now(y/n)?");
                    string claimResponse = Console.ReadLine();

                    if (claimResponse == "y")
                    {
                        
                        claimId = thisClaim.ClaimId;

                        wasSuccessful = claimRepo.RemoveClaimFromList(claimId);
                        Console.WriteLine("Your claim was successful :" + wasSuccessful);
                    }
                    
                    MainMenu();
                    break;
                case "3":
                    // Add Claim
                    Console.WriteLine("Enter the claim id: ");
                    claimId = Console.ReadLine();
                    Console.WriteLine("Enter the claim type: ");
                    type = Console.ReadLine();
                    Console.WriteLine("Enter a claim description: ");
                    description = Console.ReadLine();
                    Console.WriteLine("Amount of Damage: ");
                    amount = Console.ReadLine();
                    Console.WriteLine("Date Of Accident: ");
                    dateOfAccidentString = Console.ReadLine();
                    Console.WriteLine("Date Of Claim: ");
                    dateOfClaimString = Console.ReadLine();

                    // https://docs.microsoft.com/en-us/dotnet/api/system.datetime.parse?view=net-5.0
                    dateOfAccident = DateTime.Parse(dateOfAccidentString);
                    dateOfClaim = DateTime.Parse(dateOfClaimString);

                    // figure out of DateOfClaim is within 30 days of dateOfAccident
                    // https://stackoverflow.com/questions/528368/datetime-compare-how-to-check-if-a-date-is-less-than-30-days-old/528380
                    bool isValidBool = (dateOfClaim - dateOfAccident).TotalDays < 30;


                    Claim newclaim = new Claim(claimId, type, description, amount, dateOfAccidentString, dateOfClaimString, isValidBool.ToString());

                    claimRepo.AddClaim(newclaim);
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
