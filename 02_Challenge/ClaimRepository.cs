using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge
{
    public class ClaimRepository
    {
        Queue<Claim> _seeQ = new Queue<Claim>();
        int _userID = 0;

        public void AddClaimToQueue(Claim cName)
        {
            cName.ClaimID = _userID++;
            _seeQ.Enqueue(cName);
        }
        public Queue<Claim> GetQueue()
        {
            return _seeQ;
        }
        public void RemoveClaimFromQueue()
        {
            _seeQ.Dequeue();
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
