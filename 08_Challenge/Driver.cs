using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Challenge
{
    public class Driver
    {
        public int SpeedCount { get; set; }
        public int SwerveCount { get; set; }
        public int RollStopCount { get; set; }
        public int FollowCarsCount { get; set; }
        public int DriverScore { get; set; }
        public decimal CostOfPremium { get; set; }

        public Driver(int speedCount, int swerveCount, int rollStopCount, int followCarsCount, int driverScore, decimal costOfPremium)
        {
            SpeedCount = speedCount;
            SwerveCount = swerveCount;
            RollStopCount = rollStopCount;
            FollowCarsCount = followCarsCount;
            DriverScore = driverScore;
            CostOfPremium = costOfPremium;
        }
        public Driver()
        {

        }
    }
}
