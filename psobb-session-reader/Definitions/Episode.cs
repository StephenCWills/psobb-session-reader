using System.Collections.Generic;

namespace psobb_session_reader.Definitions
{
    public class Episode
    {
        // Creates a new Episode
        private Episode(int id, int number)
        {
            ID = id;
            Number = number;

            if (number >= 0)
                LookupByID.Add(id, this);
        }

        // Properties
        public int ID { get; }
        public int Number { get; }
        public bool IsUnknown => !(Number >= 0);

        public override string ToString() => (Number >= 0)
            ? $"Episode {Number}"
            : $"Unknown ({ID})";

        // Static lookup table by ID
        private static IDictionary<int, Episode> LookupByID = new Dictionary<int, Episode>();

        public static Episode GetEpisode(int id)
        {
            if (LookupByID.TryGetValue(id, out Episode episode))
                return episode;

            return new Episode(id, -1);
        }

        // Episode definitions
        public static Episode One = new Episode(0, 1);
        public static Episode Two = new Episode(1, 2);
        public static Episode Four = new Episode(2, 4);
    }
}
