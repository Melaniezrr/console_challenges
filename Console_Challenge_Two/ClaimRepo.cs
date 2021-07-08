using System;
using System.Collections.Generic;

namespace Console_Challenge_Two
{
    public class ClaimRepo
    {
        private List<Claim> _listOfClaims = new List<Claim>();

        // Create CRUD Methods

        // create
        public void AddClaim(Claim Claim)
        {
            _listOfClaims.Add(Claim);
        }

        // read (list or get one)
        public List<Claim> GetClaimList()
        {
            return _listOfClaims;
        }

        public Claim GetClaim(string number)
        {
            Claim dev = GetClaimByNumber(number);
            return dev;
        }

        // delete
        public bool RemoveClaimFromList(string number)
        {
            Claim Claim = GetClaimByNumber(number);
            if (Claim == null)
            {
                return false;
            }

            int initialCount = _listOfClaims.Count;
            _listOfClaims.Remove(Claim);

            return initialCount > _listOfClaims.Count;
        }

        // helper
        private Claim GetClaimByNumber(string number)
        {
            foreach (Claim Claim in _listOfClaims)
            {
                if (Claim.Number == number)
                {
                    return Claim;
                }

                return null;
            }

            return null;
        }
    }
}
