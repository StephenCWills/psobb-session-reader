
using System.Collections.Generic;

namespace psobb_session_reader.Definitions
{
    public class SectionID
    {
        // Creates a new SectionID
        private SectionID(int id, string name, bool isUnknown = false)
        {
            ID = id;
            Name = name;
            IsUnknown = isUnknown;

            if (!isUnknown)
                LookupByID.Add(id, this);
        }

        // Properties
        public int ID { get; }
        public string Name { get; }
        public bool IsUnknown { get; }
        public override string ToString() => Name;

        // Static lookup table by ID
        private static IDictionary<int, SectionID> LookupByID = new Dictionary<int, SectionID>();

        public static SectionID GetSectionID(int id)
        {
            if (LookupByID.TryGetValue(id, out SectionID sectionID))
                return sectionID;

            return new SectionID(id, $"Unknown ({id})", true);
        }

        // SectionID definitions
        public static readonly SectionID Viridia = new SectionID(0, "Viridia");
        public static readonly SectionID Greenill = new SectionID(1, "Greenill");
        public static readonly SectionID Skyly = new SectionID(2, "Skyly");
        public static readonly SectionID Bluefull = new SectionID(3, "Bluefull");
        public static readonly SectionID Purplenum = new SectionID(4, "Purplenum");
        public static readonly SectionID Pinkal = new SectionID(5, "Pinkal");
        public static readonly SectionID Redria = new SectionID(6, "Redria");
        public static readonly SectionID Oran = new SectionID(7, "Oran");
        public static readonly SectionID Yellowboze = new SectionID(8, "Yellowboze");
        public static readonly SectionID Whitill = new SectionID(9, "Whitill");
    }
}
