using System;
using Xunit;
using System.Collections.Generic;

using Console_Challenge_Two;

namespace Console_Challenge_Two_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void AddClaimTest()
        {
            // Arrange
            ClaimRepo claimRepo = new ClaimRepo();
            Claim claim = new Claim("1", "Car", "Item Description", "5.00", "4/27/2021", "4/29/2021");

            List<Claim> expected = new List<Claim>(claim);
            // Act
            claimRepo.add(claim);

            // Assert
            List<Claim> actual = claimRepo.GetClaimList();
            Assert.AreEqual(expected, actual);
        }
    }
}
