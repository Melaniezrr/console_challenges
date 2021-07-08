using System;
using System.Collections.Generic;

namespace Console_Challenge_Three
{
    public class Badge
    {
        public string BadgeId;
        public List<String> Doors;

        public Badge(string badgeId, List<String> doors)
        {
            BadgeId = badgeId;
            Doors = doors;
        }
    }
}
