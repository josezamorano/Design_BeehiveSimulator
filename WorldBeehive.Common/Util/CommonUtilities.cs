using System.Collections.Generic;
using WorldBeehive.Common.Interfaces;

namespace WorldBeehive.Common.Util
{
    public class CommonUtilities : ICommonUtilities
    {
        public int GetMinimumNumberFromASequenceOfNumbers(List<int> listOfNumbers)
        {
            //Examples
            //List<int> availableIds1 = new List<int>() { 1, 2, 3, 4 };
            //List<int> availableIds2 = new List<int>() { 1, 5, 7, 8 };
            //List<int> availableIds3 = new List<int>() { 2, 4,5 };
            //List<int> availableIds = bees.Select(a => a.BeeId).ToList();
            var initialNumberInSequence = 1;
            for (var a = 0; a < listOfNumbers.Count; a++)
            {
                if (initialNumberInSequence == listOfNumbers[a])
                {
                    initialNumberInSequence++;
                }
                if (initialNumberInSequence < listOfNumbers[a])
                {
                    return initialNumberInSequence;
                }
            }
            return initialNumberInSequence;
        }
    }
}