using System;
namespace Console_Challenge_Two
{
    public class Claim
    {
        public string ClaimId;
        public string Type;
        public string Description;
        public string Amount;
        public string DateOfAccident;
        public string DateOfClaim;
        public string IsValid;

        public Claim(string claimId, string type, string description, string amount, string dateOfAccident, string dateOfClaim, string isValid)
        {
            ClaimId = claimId;
            Type = type;
            Description = description;
            Amount = amount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }
}
