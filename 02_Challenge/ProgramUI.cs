using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge
{
    internal class ProgramUI
    {
        ClaimRepository _repo = new ClaimRepository();
        internal void Run()
        {
        Start:
            Console.WriteLine("Welcome to Komodo Claims Department. What would you like to do?\n" +
                "1. See all claims\n" +
                "2. Take care of next claim\n" +
                "3. Enter a new claim\n");
            int navigation = int.Parse(Console.ReadLine());
            switch (navigation)
            {
                case 1:
                    SeeAllClaims();
                    break;
                case 2:
                    TakeCareNextClaim();
                    break;
                case 3:
                    AddAClaim();
                    break;
                default:
                    break;
            }
            Console.WriteLine("\nWould you like to continue using this application? (y/n)");
            string endNav = Console.ReadLine();
            switch (endNav)
            {
                case "y":
                    Console.Clear();
                    goto Start;
                case "n":
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    break;
            }
            Console.WriteLine("Thank you. Have a nice day.");
            Console.ReadKey();


        }
        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> newQ = _repo.GetQueue();

            Console.WriteLine("ClaimID\t Type\t Description\t Amount\t DateofAccident\t DateofClaim\t IsValid");
            foreach (Claim claim in newQ)
            {
                Console.WriteLine($"{claim.ClaimID}\t{claim.ClaimType}\t{claim.Description}\t  {claim.Amount}\t {claim.DateOfIncident.ToShortDateString()}\t{claim.DateOfClaim.ToShortDateString()}\t{claim.IsValid}");
            }
        }
        private void TakeCareNextClaim()
        {
            Console.Clear();
            Queue<Claim> newQ = _repo.GetQueue();
            Claim  nextClaim = newQ.Peek();

            Console.WriteLine($"ClaimID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.ClaimType}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: {nextClaim.Amount}\n" +
                $"DateOfIncident: {nextClaim.DateOfIncident.ToShortDateString()}\n" +
                $"DateOfClaim: {nextClaim.DateOfClaim.ToShortDateString()}\n" +
                $"IsValid: {nextClaim.IsValid}");

            Console.WriteLine("\nDo you want to deal with this claim now? (y/n)");
            string claimYN = Console.ReadLine();
            string claimYesNo = claimYN.ToLower();

            if (claimYesNo == "y")
            {
                _repo.RemoveClaimFromQueue();
            }
            else
            {
            }
        }
        private void AddAClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();
            Console.WriteLine("What type of claim is this?\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            int typeClaim = int.Parse(Console.ReadLine());
            switch (typeClaim)
            {
                case 1:
                    newClaim.ClaimType = ClaimType.Car;
                    break;
                case 2:
                    newClaim.ClaimType = ClaimType.Home;
                    break;
                case 3:
                    newClaim.ClaimType = ClaimType.Theft;
                    break;
            }
            Console.WriteLine("What is the claim description?");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("What is the claim amount? Please use numerical values.");
            newClaim.Amount = decimal.Parse(Console.ReadLine());

            DateTime incidentDate = new DateTime();
            DateTime claimDate = new DateTime();
        Incident:
            Console.WriteLine("Write the date of the incident in MM/DD/YYYY format:");
            if (DateTime.TryParse(Console.ReadLine(), out incidentDate))
            {
                newClaim.DateOfIncident = incidentDate;
            }
            else
            {
                Console.WriteLine("There was a formatting error, please try again.");
                goto Incident;
            }

        ClaimDate:
            Console.WriteLine("Write the date of the claim in MM/DD/YYYY format:");
            if (DateTime.TryParse(Console.ReadLine(), out claimDate))
            {
                newClaim.DateOfClaim = claimDate;
            }
            else
            {
                Console.WriteLine("There was a formatting error, please try again.");
                goto ClaimDate;
            }

            newClaim.IsValid = _repo.IsThisClaimValid(newClaim);

            _repo.AddClaimToQueue(newClaim);
        }
    }
}
