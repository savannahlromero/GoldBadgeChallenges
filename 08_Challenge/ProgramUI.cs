using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Challenge
{
    class ProgramUI
    {
        DriverRepository _repo = new DriverRepository();
        Random _rnd = new Random();
        internal void Run()
        {
            Console.WriteLine("For instructors: Recieve a few driving reports, and then enter 566636 in the home menu for an easter egg.");
            Console.ReadKey();
            Console.Clear();
            Start:
            Console.WriteLine("Hello, welcome to Smart Insurance. What would you like to do today?\n" +
                "\n1. Recieve your full driving report\n" +
                "2. Exit");
            int navigation = int.Parse(Console.ReadLine());
            switch (navigation)
            {
                case 1:
                    Console.Clear();
                    DrivingReport();
                    break;
                case 2:
                    Console.Clear();
                    goto EndOfTheLine;
                case 566636:
                    Console.Clear();
                    AdministrativeList();
                    break;
                default:
                    goto EndOfTheLine;

            }
            Console.WriteLine("\nWould you like to continue using our application?\n" +
                "1. Yes\n" +
                "2. No\n");
            int cont = int.Parse(Console.ReadLine());
            switch (cont)
            {
                case 1:
                    Console.Clear();
                    goto Start;
                case 2:
                    Console.Clear();
                    break;
            }
        EndOfTheLine:
            Console.WriteLine("Thank you. Please come again.");
            Console.ReadKey();
        }
        private void DrivingReport()
        {
            Driver newDriver = new Driver();
            newDriver.FollowCarsCount = _rnd.Next(13);
            newDriver.RollStopCount = _rnd.Next(13);
            newDriver.SpeedCount = _rnd.Next(13);
            newDriver.SwerveCount = _rnd.Next(13);

            Console.WriteLine($"Driving Report:\n" +
                $"You have been caught speeding {newDriver.SpeedCount} times.\n" +
                $"You have been caught swerving {newDriver.SwerveCount} times.\n" +
                $"You haven't stopped at stop signs {newDriver.RollStopCount} times.\n" +
                $"You have followed cars too closely {newDriver.FollowCarsCount} times.\n");

            int score =_repo.CalculateDriverScore(newDriver);
            Console.WriteLine($"\nYour Komodo Driving Score is {score}\n");
            newDriver.DriverScore = score;

            decimal finalPremium = _repo.CalculateFinalPremium(score);
            Console.WriteLine($"Your total bill will be ${finalPremium}.\n");
            newDriver.CostOfPremium = finalPremium;
            
            Console.WriteLine("\nYour driving incidents and reports have been measured by your smart car. Cost of premium is final.\nIf you have any questions, feel free to call us at 1-800-123-4567.");

            _repo.AddDriverToList(newDriver);
        }

        private  void AdministrativeList()
        {

            Console.WriteLine("CONFIDENTIAL CONFIDENTIAL CONFIDENTIAL.\n");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("THIS MENU IS FOR ADMINISTRATOR USE ONLY.\nIF YOU ARE NOT A MEMBER OF SMART INSURANCE WITH CLEARANCE TYPE-C, CLOSE THE CLIENT IMMEDIATELY.");
            Console.ReadKey();
            List<Driver> driverList = _repo.GetDriverList();
            Console.Clear();
            Console.WriteLine("Welcome, Smart Insurance Associate. Press any key to access our current list of drivers and their relevant information.\n");
            Console.ReadKey();
            Console.Clear();
            int c = driverList.Count();
            Console.WriteLine($"Total number of entries in list: {c}.\n");
            foreach (Driver driver in driverList)
            {
                Console.WriteLine($"Caught Speeding: {driver.SpeedCount} times\n" +
                    $"Caught Swerving: {driver.SpeedCount} times\n" +
                    $"Rolled Through Stop Signs: {driver.RollStopCount} times\n" +
                    $"Followed Cars Too Closely: {driver.FollowCarsCount} times\n" +
                    $"Driver Score: {driver.DriverScore}\n" +
                    $"Cost of Premium: {driver.CostOfPremium}\n" +
                    $"-");
            }
            Console.WriteLine("\nNames, usernames, passwords, and other sensitive data have already been forwarded to Komodo Incorporated.\nThe information you are currently viewing will be forwarded at our discretion to be used by Komodo\nand it's associates for marketing and pricing purposes.\nForward only on business days from 1-3 AM.");
            Console.ReadLine();
            Console.WriteLine("Would you like to push this data to Komodo Incorporated?\n" +
                "1. Yes\n" +
                "2. No\n");
            int push = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (push)
            {
                case 1:
                    goto Push;
                case 2:
                    goto Leave;
            }
        Push:
            List<Driver> komodoList = _repo.GetDriverList();
            foreach (Driver driver in komodoList)
            {
                _repo.PushToKdo(driver);
                Console.WriteLine("Pushed.");
            }
            Console.WriteLine("All data was successfully pushed.\n");
            Console.ReadKey();
        Leave:
            Console.Clear();
            Console.WriteLine("\nYou will be sent to the main menu.");
        }
    }
}
