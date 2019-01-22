using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge
{
    public class ClaimRepository
    {
        Queue<Claim> seeQ = new Queue<Claim>();
        int userID = 0;

        public void AddClaimToQueue(Claim cName)
        {
            cName.ClaimID = userID++;
            seeQ.Enqueue(cName);
        }
        public Queue<Claim> GetQueue()
        {
            return seeQ;
        }
        public void RemoveClaimFromQueue()
        {
            seeQ.Dequeue();
        }
        public bool IsThisClaimValid(Claim cName)
        {
            bool claimIsValid;
            double difference = (cName.DateOfClaim - cName.DateOfIncident).TotalDays;

            if (difference <= 30d)
            {
                claimIsValid = true;
            }
            else
            {
                claimIsValid = false;
            }
            return claimIsValid;
        }

    }
}
