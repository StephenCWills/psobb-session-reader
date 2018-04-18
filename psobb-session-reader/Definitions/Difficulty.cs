using System.Collections.Generic;

namespace psobb_session_reader.Definitions
{
    public class Difficulty
    {
        // Creates a new Difficulty
        private Difficulty(int id, string name, string shortName, bool isUnknown = false)
        {
            ID = id;
            Name = name;
            ShortName = shortName;
            IsUnknown = isUnknown;

            if (!isUnknown)
                LookupByID.Add(id, this);
        }

        // Properties
        public int ID { get; }
        public string Name { get; }
        public string ShortName { get; }
        public bool IsUnknown { get; }
        public override string ToString() => Name;

        // Static lookup table by ID
        private static readonly IDictionary<int, Difficulty> LookupByID = new Dictionary<int, Difficulty>();

        public static Difficulty GetDifficulty(int id)
        {
            if (LookupByID.TryGetValue(id, out Difficulty difficulty))
                return difficulty;

            return new Difficulty(id, $"Unknown ({id})", $"{id}?", true);
        }

        // Difficulty definitions
        public static readonly Difficulty Normal = new Difficulty(0, "Normal", "Norm");
        public static readonly Difficulty Hard = new Difficulty(1, "Hard", "Hard");
        public static readonly Difficulty VeryHard = new Difficulty(2, "Very Hard", "VHard");
        public static readonly Difficulty Ultimate = new Difficulty(3, "Ultimate", "Ult");
    }
}
