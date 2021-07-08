using System;
using System.Collections.Generic;

namespace Console_Challenge_Three
{
    public class BadgeRepo
    {
        Dictionary<string, List<String>> _dictionaryOfBadges = new Dictionary<string, List<String>>();

        // create
        public void AddBadge(string badgeId, List<String> doors)
        {
            _dictionaryOfBadges.Add(badgeId, doors);
        }

        // read (list or get one)
        public Dictionary<string, List<String>> GetBadgeList()
        {
            return _dictionaryOfBadges;
        }

        public void UpdateBadgeDoors(string badgeId, List<String> doors)
        {
            _dictionaryOfBadges[badgeId] = doors;
        }

        // helper
        public List<String> GetBadgeByBadgeId(string badgeId)
        {
            return _dictionaryOfBadges[badgeId];
        }
    }
}
