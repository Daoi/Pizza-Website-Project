using System.Collections.Generic;
using System.Linq;

namespace WebApplication3
{
    public class SumCollection
    {

        public static decimal SumValues(Dictionary<string,decimal> dict, string[] keys)
        {
            return keys.ToList().Where(dict.ContainsKey).Sum(k => dict[k]);

        }

    }
}