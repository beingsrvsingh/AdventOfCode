using System.Collections.Generic;

namespace AdventOfCode
{
    public class Passport
    {
        public int Id { get; set; }
        public Dictionary<string, string> passport { get; set; } = new Dictionary<string, string>();
    }
}
