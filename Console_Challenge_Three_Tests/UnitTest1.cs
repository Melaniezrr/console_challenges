using System;
using Xunit;
using System.Collections.Generic;

using Console_Challenge_Three;

namespace Console_Challenge_Three_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void AddBadgeTest()
        {
            // Arrange
            BadgeRepo badgeRepo = new BadgeRepo();
            string badgeId = "1";
            List<String> doors = new List<String>();

            Badge badge = new Badge(badgeId, doors);

            Dictionary<string, List<String>> expected = new Dictionary<string, List<String>>();
            expected.Add(badge);
            // Act
            badgeRepo.AddBadge(badgeId, doors);

            // Assert
            Dictionary<string, List<String>> actual = BadgeRepo.GetBadgeList();
            Assert.AreEqual(expected, actual);
        }
    }
}
