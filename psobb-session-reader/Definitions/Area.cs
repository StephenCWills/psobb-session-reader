using System.Collections.Generic;

namespace psobb_session_reader.Definitions
{
    public class Area
    {
        // Creates a new Area
        public Area(int id, string name, bool isUnknown = false)
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
        private static readonly IDictionary<int, Area> LookupByID = new Dictionary<int, Area>();

        public static Area GetArea(int id)
        {
            if (LookupByID.TryGetValue(id, out Area area))
                return area;

            return new Area(id, $"Unknown ({id})", true);
        }

        // Area definitions
        public static readonly Area Forest = new Area(0, "Forest");
        public static readonly Area Caves = new Area(1, "Caves");
        public static readonly Area Mines = new Area(2, "Mines");
        public static readonly Area Ruins = new Area(3, "Ruins");
        public static readonly Area DarkFalz = new Area(4, "Dark Falz");
        public static readonly Area CentralControlArea = new Area(5, "Central Control Area");
        public static readonly Area Seabed = new Area(6, "Seabed");
        public static readonly Area VRTemple = new Area(7, "VR Temple");
        public static readonly Area VRSpaceship = new Area(8, "VR Spaceship");
        public static readonly Area Crater_Exterior = new Area(9, "Crater (Exterior)");
        public static readonly Area Crater_Interior = new Area(10, "Crater (Interior)");
        public static readonly Area SubterraneanDesert = new Area(11, "Subterranean Desert");
    }
}
