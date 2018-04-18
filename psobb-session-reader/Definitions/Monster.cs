using System.Collections.Generic;

namespace psobb_session_reader.Definitions
{
    public class Monster
    {
        // Creates a new Monster
        private Monster(int id, string name, string ultimateName, bool isUnknown = false)
        {
            ID = id;
            Name = name;
            UltimateName = ultimateName;
            IsUnknown = isUnknown;

            if (!isUnknown)
                LookupByID.Add(id, this);
        }

        // Properties
        public int ID { get; }
        public string Name { get; }
        public string UltimateName { get; }
        public bool IsUnknown { get; }
        public override string ToString() => Name;

        public string ToString(Difficulty difficulty) => (difficulty == Difficulty.Ultimate)
            ? UltimateName
            : Name;

        // Static lookup table by id
        private static readonly Dictionary<int, Monster> LookupByID = new Dictionary<int, Monster>();

        public static Monster GetMonster(int id)
        {
            if (LookupByID.TryGetValue(id, out Monster monster))
                return monster;

            string name = $"Unknown ({id})";
            return new Monster(id, name, name, true);
        }

        #region [ Monster Definitions ]

        // Forest
        public static readonly Monster Hildebear = new Monster(1, "Hildebear", "Hildelt");
        public static readonly Monster Hildeblue = new Monster(2, "Hildeblue", "Hildetorr");
        public static readonly Monster Mothmant = new Monster(3, "Mothmant", "Mothvert");
        public static readonly Monster Monest = new Monster(4, "Monest", "Mothvist");
        public static readonly Monster RagRappy = new Monster(5, "Rag Rappy", "El Rappy");
        public static readonly Monster AlRappy = new Monster(6, "Al Rappy", "Pal Rappy");
        public static readonly Monster SavageWolf = new Monster(7, "Savage Wolf", "Gulgus");
        public static readonly Monster BarbarousWolf = new Monster(8, "Barbarous Wolf", "Gulgus-gue");
        public static readonly Monster Booma = new Monster(9, "Booma", "Bartle");
        public static readonly Monster Gobooma = new Monster(10, "Gobooma", "Barble");
        public static readonly Monster Gigobooma = new Monster(11, "Gigobooma", "Tollaw");

        // Cave
        public static readonly Monster GrassAssassin = new Monster(12, "Grass Assassin", "Crimson Assassin");
        public static readonly Monster PoisonLily = new Monster(13, "Poison Lily", "Ob Lily");
        public static readonly Monster NarLily = new Monster(14, "Nar Lily", "Mil Lily");
        public static readonly Monster NanoDragon = new Monster(15, "Nano Dragon", "Nano Dragon");
        public static readonly Monster EvilShark = new Monster(16, "Evil Shark", "Vulmer");
        public static readonly Monster PalShark = new Monster(17, "Pal Shark", "Govulmer");
        public static readonly Monster GuilShark = new Monster(18, "Guil Shark", "Melqueek");
        public static readonly Monster PofuillySlime = new Monster(19, "Pofuilly Slime", "Pofuilly Slime");
        public static readonly Monster PouillySlime = new Monster(20, "Pouilly Slime", "Pouilly Slime");
        public static readonly Monster PanArms = new Monster(21, "Pan Arms", "Pan Arms");
        public static readonly Monster Migium = new Monster(22, "Migium", "Migium");
        public static readonly Monster Hidoom = new Monster(23, "Hidoom", "Hidoom");

        // Mine
        public static readonly Monster Dubchic = new Monster(24, "Dubchic", "Dubchich");
        public static readonly Monster Garanz = new Monster(25, "Garanz", "Baranz");
        public static readonly Monster SinowBeat = new Monster(26, "Sinow Beat", "Sinow Blue");
        public static readonly Monster SinowGold = new Monster(27, "Sinow Gold", "Sinow Red");
        public static readonly Monster Canadine = new Monster(28, "Canadine", "Canabin");
        public static readonly Monster Canane = new Monster(29, "Canane", "Canune");
        public static readonly Monster Dubwitch = new Monster(49, "Dubwitch", "Dubwitch");
        public static readonly Monster Gillchic = new Monster(50, "Gillchic", "Gillchich");

        // Ruins
        public static readonly Monster Delsaber = new Monster(30, "Delsaber", "Delsaber");
        public static readonly Monster ChaosSorcerer = new Monster(31, "Chaos Sorcerer", "Gran Sorcerer");
        public static readonly Monster BeeR = new Monster(32, "Bee R", "Gee R");
        public static readonly Monster BeeL = new Monster(33, "Bee L", "Gee L");
        public static readonly Monster DarkGunner = new Monster(34, "Dark Gunner", "Dark Gunner");
        public static readonly Monster DeathGunner = new Monster(35, "Death Gunner", "Death Gunner");
        public static readonly Monster DarkBringer = new Monster(36, "Dark Bringer", "Dark Bringer");
        public static readonly Monster IndiBelra = new Monster(37, "Indi Belra", "Indi Belra");
        public static readonly Monster Claw = new Monster(38, "Claw", "Claw");
        public static readonly Monster Bulk = new Monster(39, "Bulk", "Bulk");
        public static readonly Monster Bulclaw = new Monster(40, "Bulclaw", "Bulclaw");
        public static readonly Monster Dimenian = new Monster(41, "Dimenian", "Arlan");
        public static readonly Monster LaDimenian = new Monster(42, "La Dimenian", "Merlan");
        public static readonly Monster SoDimenian = new Monster(43, "So Dimenian", "Del-D");

        // Episode 1 Bosses
        public static readonly Monster Dragon = new Monster(44, "Dragon", "Sil Dragon");
        public static readonly Monster DeRolLe = new Monster(45, "De Rol Le", "Dal Ral Lie");
        public static readonly Monster VolOpt = new Monster(46, "Vol Opt", "Vol Opt ver.2");
        public static readonly Monster DarkFalz = new Monster(47, "Dark Falz", "Dark Falz");

        // VR Temple
        public static readonly Monster LoveRappy = new Monster(51, "Love Rappy", "Love Rappy");
        public static readonly Monster BarbaRay = new Monster(73, "Barba Ray", "Barba Ray");
        public static readonly Monster PigRay = new Monster(74, "Pig Ray", "Pig Ray");
        public static readonly Monster UlRay = new Monster(75, "Ul Ray", "Ul Ray");
        public static readonly Monster StRappy = new Monster(79, "St. Rappy", "St. Rappy");
        public static readonly Monster HalloRappy = new Monster(80, "Hallo Rappy", "Hallo Rappy");
        public static readonly Monster EggRappy = new Monster(81, "Egg Rappy", "Egg Rappy");

        // VR Spaceship
        public static readonly Monster GolDragon = new Monster(76, "Gol Dragon", "Gol Dragon");

        // Central Control Area
        public static readonly Monster Merillia = new Monster(52, "Merillia", "Merillia");
        public static readonly Monster Meriltas = new Monster(53, "Meriltas", "Meriltas");
        public static readonly Monster Gee = new Monster(54, "Gee", "Gee");
        public static readonly Monster GiGue = new Monster(55, "Gi Gue", "Gi Gue");
        public static readonly Monster Mericarol = new Monster(56, "Mericarol", "Mericarol");
        public static readonly Monster Merikle = new Monster(57, "Merikle", "Merikle");
        public static readonly Monster Mericus = new Monster(58, "Mericus", "Mericus");
        public static readonly Monster UlGibbon = new Monster(59, "Ul Gibbon", "Ul Gibbon");
        public static readonly Monster ZolGibbon = new Monster(60, "Zol Gibbon", "Zol Gibbon");
        public static readonly Monster Gibbles = new Monster(61, "Gibbles", "Gibbles");
        public static readonly Monster SinowBerill = new Monster(62, "Sinow Berill", "Sinow Berill");
        public static readonly Monster SinowSpigell = new Monster(63, "Sinow Spigell", "Sinow Spigell");
        public static readonly Monster GalGryphon = new Monster(77, "Gal Gryphon", "Gal Gryphon");
        public static readonly Monster IllGill = new Monster(82, "Ill Gill", "Ill Gill");
        public static readonly Monster DelLily = new Monster(83, "Del Lily", "Del Lily");
        public static readonly Monster Epsilon = new Monster(84, "Epsilon", "Epsilon");
        public static readonly Monster Epsigard = new Monster(87, "Epsigard", "Epsigard");

        // Seabed
        public static readonly Monster Dolmolm = new Monster(64, "Dolmolm", "Dolmolm");
        public static readonly Monster Dolmdarl = new Monster(65, "Dolmdarl", "Dolmdarl");
        public static readonly Monster Morfos = new Monster(66, "Morfos", "Morfos");
        public static readonly Monster Recobox = new Monster(67, "Recobox", "Recobox");
        public static readonly Monster Recon = new Monster(68, "Recon", "Recon");
        public static readonly Monster SinowZoa = new Monster(69, "Sinow Zoa", "Sinow Zoa");
        public static readonly Monster SinowZele = new Monster(70, "Sinow Zele", "Sinow Zele");
        public static readonly Monster Deldepth = new Monster(71, "Deldepth", "Deldepth");
        public static readonly Monster Delbiter = new Monster(72, "Delbiter", "Delbiter");
        public static readonly Monster OlgaFlow = new Monster(78, "Olga Flow", "Olga Flow");
        public static readonly Monster Gael = new Monster(85, "Gael", "Gael");
        public static readonly Monster Giel = new Monster(86, "Giel", "Giel");

        // Crater
        public static readonly Monster Astark = new Monster(88, "Astark", "Astark");
        public static readonly Monster Yowie = new Monster(89, "Yowie", "Yowie");
        public static readonly Monster SatelliteLizard = new Monster(90, "Satellite Lizard", "Satellite Lizard");
        public static readonly Monster Zu = new Monster(94, "Zu", "Zu");
        public static readonly Monster Pazuzu = new Monster(95, "Pazuzu", "Pazuzu");
        public static readonly Monster Boota = new Monster(96, "Boota", "Boota");
        public static readonly Monster ZaBoota = new Monster(97, "Za Boota", "Za Boota");
        public static readonly Monster BaBoota = new Monster(98, "Ba Boota", "Ba Boota");
        public static readonly Monster Dorphon = new Monster(99, "Dorphon", "Dorphon");
        public static readonly Monster DorphonEclair = new Monster(100, "Dorphon Eclair", "Dorphon Eclair");
        public static readonly Monster SandRappy = new Monster(104, "Sand Rappy", "Sand Rappy");
        public static readonly Monster DelRappy = new Monster(105, "Del Rappy", "Del Rappy");

        // Desert
        public static readonly Monster MerissaA = new Monster(91, "Merissa A", "Merissa A");
        public static readonly Monster MerissaAA = new Monster(92, "Merissa AA", "Merissa AA");
        public static readonly Monster Girtablulu = new Monster(93, "Girtablulu", "Girtablulu");
        public static readonly Monster Goran = new Monster(101, "Goran", "Goran");
        public static readonly Monster GoranDetonator = new Monster(102, "Goran Detonator", "Goran Detonator");
        public static readonly Monster PyroGoran = new Monster(103, "Pyro Goran", "Pyro Goran");
        public static readonly Monster SaintMilion = new Monster(106, "Saint-Milion", "Saint-Milion");
        public static readonly Monster Shambertin = new Monster(107, "Shambertin", "Shambertin");
        public static readonly Monster Kondrieu = new Monster(108, "Kondrieu", "Kondrieu");

        // Other
        public static readonly Monster Container = new Monster(48, "Container", "Container");
        public static readonly Monster Darvant = new Monster(999, "Darvant", "Darvant");

        #endregion
    }
}
