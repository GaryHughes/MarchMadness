using System;

namespace MarchMadness
{
    public record Team
    {
        public Team(string name, int seed, string region)
        {
            Name = name;
            Seed = seed;
            Region = region;
        }

        public string Name { get; }
        public int Seed { get; }
        public string Region { get; }
    }
}