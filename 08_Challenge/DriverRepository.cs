using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Challenge
{
    public class DriverRepository
    {
        List<Driver> driverList = new List<Driver>();

        public void AddDriverToList(Driver driver)
        {
            driverList.Add(driver);
        }
        public List<Driver> GetDriverList()
        {
            return driverList;
        }
        //FOR A HUGE EASTER EGG IN MY PROJECT. USE 566636 IN THE MAIN MENU AFTER ADDING A FEW REPORTS.
        List<Driver> kdoList = new List<Driver>();
        public void PushToKdo(Driver driver)
        {
            kdoList.Add(driver);
        }
        public int CalculateDriverScore(Driver driver)
        {
            //INITIAL DRIVER SCORE
            int driverScore = 0;

            //SPEEDCOUNT CALCULATIONS
            if (driver.SpeedCount <= 1)
            {
                driverScore += 1;
            }
            else if (driver.SpeedCount > 1 && driver.SpeedCount < 6)
            {
                driverScore += 2;
            }
            else
            {
                driverScore += 3;
            }
            //SWERVERCOUNT CALCULATIONS
            if (driver.SwerveCount <= 1)
            {
                driverScore += 1;
            }
            else if (driver.SwerveCount > 1 && driver.SwerveCount < 6)
            {
                driverScore += 2;
            }
            else
            {
                driverScore += 3;
            }
            //ROLLSTOPCOUNT CALCULATIONS
            if (driver.RollStopCount <= 1)
            {
                driverScore += 1;
            }
            else if (driver.RollStopCount > 1 && driver.RollStopCount < 6)
            {
                driverScore += 2;
            }
            else
            {
                driverScore += 3;
            }
            //FOLLOWCARSCOUNT CALCULATIONS
            if (driver.FollowCarsCount <= 1)
            {
                driverScore += 1;
            }
            else if (driver.FollowCarsCount > 1 && driver.FollowCarsCount < 6)
            {
                driverScore += 2;
            }
            else
            {
                driverScore += 3;
            }

            return driverScore;
        }
        public decimal CalculateFinalPremium (int score)
        {
            decimal finalPremium = 50.00m;
            int driverScore = score;

            switch (driverScore)
            {
                case 4:
                    finalPremium = 45.00m;
                    break;
                case 5:
                    finalPremium = 55.00m;
                    break;
                case 6:
                    finalPremium = 65.00m;
                    break;
                case 7:
                    finalPremium = 75.00m;
                    break;
                case 8:
                    finalPremium = 95.00m;
                    break;
                case 9:
                    finalPremium = 125.00m;
                    break;
                case 10:
                    finalPremium = 150.00m;
                    break;
                case 11:
                    finalPremium = 175.00m;
                    break;
                case 12:
                    finalPremium = 200.00m;
                    break;
                default:
                    break;
            }
            return finalPremium;
        }
    }
}
