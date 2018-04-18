using System.Collections.Generic;

namespace psobb_session_reader.Definitions
{
    public class Quest
    {
        // Creates a new Quest
        private Quest(int id, string name, bool isUnknown = false)
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
        private static IDictionary<int, Quest> LookupByID = new Dictionary<int, Quest>();

        public static Quest GetQuest(int id)
        {
            if (LookupByID.TryGetValue(id, out Quest quest))
                return quest;

            return new Quest(id, $"Unknown ({id})", true);
        }

        #region [ Quest Definitions ]

        public static readonly Quest None = new Quest(000, "None");
        public static readonly Quest MagnitudeOfMetal = new Quest(001, "Magnitude of Metal");
        public static readonly Quest ClaimingAStake = new Quest(002, "Claiming a Stake");
        public static readonly Quest TheValueOfMoney = new Quest(003, "The Value of Money");
        public static readonly Quest BattleTraining = new Quest(004, "Battle Training");
        public static readonly Quest JournalisticPursuit = new Quest(005, "Journalistic Pursuit");
        public static readonly Quest TheFakeinYellow = new Quest(006, "The Fake in Yellow");
        public static readonly Quest NativeResearch = new Quest(007, "Native Research");
        public static readonly Quest ForestOfSorrow = new Quest(008, "Forest of Sorrow");
        public static readonly Quest GranSquall = new Quest(009, "Gran Squall");
        public static readonly Quest AddictingFood = new Quest(010, "Addicting Food");
        public static readonly Quest TheLostBride = new Quest(011, "The Lost Bride");
        public static readonly Quest WaterfallTears = new Quest(012, "Waterfall Tears");
        public static readonly Quest BlackPaper = new Quest(013, "Black Paper");
        public static readonly Quest SecretDelivery = new Quest(014, "Secret Delivery");
        public static readonly Quest SoulOfABlacksmith = new Quest(015, "Soul of a Blacksmith");
        public static readonly Quest LetterfromLionel = new Quest(016, "Letter from Lionel");
        public static readonly Quest TheGravesButler = new Quest(017, "The Grave's Butler");
        public static readonly Quest KnowingOnesHeart = new Quest(018, "Knowing One's Heart");
        public static readonly Quest TheRetiredHunter = new Quest(019, "The Retired Hunter");
        public static readonly Quest DrOstosResearch = new Quest(020, "Dr. Osto's Research");
        public static readonly Quest UnsealedDoor = new Quest(021, "Unsealed Door");
        public static readonly Quest SoulOfSteel = new Quest(022, "Soul of Steel");
        public static readonly Quest DocsSecretPlan = new Quest(023, "Doc's Secret Plan");
        public static readonly Quest SeekMyMaster = new Quest(024, "Seek my Master");
        public static readonly Quest FromTheDepths = new Quest(025, "From the Depths");
        public static readonly Quest CentralDomeFireSwirl_OfflineVersion = new Quest(026, "Central Dome Fire Swirl (Offline Version)");
        public static readonly Quest SeatOfTheHeart_OfflineVersion = new Quest(027, "Seat of The Heart (Offline Version)");
        public static readonly Quest TheEastTower_OfflineVersion = new Quest(028, "The East Tower (Offline Version)");
        public static readonly Quest TheWestTower_OfflineVersion = new Quest(029, "The West Tower (Offline Version)");
        public static readonly Quest WarriorsPride = new Quest(030, "Warrior's Pride");
        public static readonly Quest BlackPapersDangerousDeal = new Quest(031, "Black Paper's Dangerous Deal");
        public static readonly Quest TheRestlessLion = new Quest(032, "The Restless Lion");
        public static readonly Quest PioneerSpirits = new Quest(033, "Pioneer Spirits");
        public static readonly Quest BlackPapersDangerousDeal2 = new Quest(034, "Black Paper's Dangerous Deal 2");
        public static readonly Quest GallonsPlan = new Quest(035, "Gallon's Plan");
        public static readonly Quest ToTheEndOftheWilderness = new Quest(036, "To the End of the Wilderness");
        public static readonly Quest TheMissingMaracas = new Quest(068, "The Missing Maracas");
        public static readonly Quest FamitsuCup = new Quest(069, "Famitsu Cup");
        public static readonly Quest FamitsuCupv2_v1 = new Quest(070, "Famitsu Cup v2 (v1)");
        public static readonly Quest DawnOfE_Access_v1 = new Quest(071, "Dawn of E-Access (v1)");
        public static readonly Quest CentralDomeFireSwirl_OnlineVersion_V2 = new Quest(072, "Central Dome Fire Swirl (Online version) (V2)");
        public static readonly Quest TheTinkerbellsDog2 = new Quest(073, "The Tinkerbell's Dog 2");
        public static readonly Quest _FamitsuMaximumAttack_v2 = new Quest(080, "-Famitsu Maximum Attack- (v2)");
        public static readonly Quest SunsetAtTheSecretBase_v2 = new Quest(081, "Sunset at The Secret Base (v2)");
        public static readonly Quest MopUpOperation1 = new Quest(101, "Mop-up Operation #1");
        public static readonly Quest MopUpOperation2 = new Quest(102, "Mop-up Operation #2");
        public static readonly Quest MopUpOperation3 = new Quest(103, "Mop-up Operation #3");
        public static readonly Quest MopUpOperation4 = new Quest(104, "Mop-up Operation #4");
        public static readonly Quest LostHeatSword = new Quest(105, "Lost HEAT SWORD");
        public static readonly Quest LostIceSpinner = new Quest(106, "Lost ICE SPINNER");
        public static readonly Quest LostSoulBlade = new Quest(107, "Lost SOUL BLADE");
        public static readonly Quest EndlessNightmare1 = new Quest(108, "Endless Nightmare #1");
        public static readonly Quest EndlessNightmare2 = new Quest(109, "Endless Nightmare #2");
        public static readonly Quest EndlessNightmare3 = new Quest(110, "Endless Nightmare #3");
        public static readonly Quest EndlessNightmare4 = new Quest(111, "Endless Nightmare #4");
        public static readonly Quest TodaysRate = new Quest(117, "Today's Rate");
        public static readonly Quest TowardstheFuture = new Quest(118, "Towards the Future");
        public static readonly Quest FragmentsOfAMemory = new Quest(119, "Fragments of a Memory");
        public static readonly Quest LostHellPallasch = new Quest(120, "Lost HELL PALLASCH");
        public static readonly Quest StValentinesDay = new Quest(124, "St. Valentine's Day");
        public static readonly Quest WhiteDay = new Quest(125, "White Day");
        public static readonly Quest GoodLuck = new Quest(126, "Good Luck!");
        public static readonly Quest Sugoroku = new Quest(127, "Sugoroku");
        public static readonly Quest RappysHoliday = new Quest(137, "Rappy's Holiday");
        public static readonly Quest GallonsTreachery = new Quest(138, "Gallon's Treachery");
        public static readonly Quest StValentinesDay2003_v2 = new Quest(140, "St. Valentine's Day 2003 (v2)");
        public static readonly Quest LabyrinthineTrial = new Quest(141, "Labyrinthine Trial");
        public static readonly Quest AOLCUP_MaximumAttack_E = new Quest(142, "AOL CUP -Maximum Attack- (E)");
        public static readonly Quest AOLCUP_SunsetBase_ = new Quest(143, "AOL CUP -Sunset Base-");
        public static readonly Quest MaximumAttack4thStage_A_EpI_E = new Quest(144, "Maximum Attack 4th Stage -A- (Ep I, E)");
        public static readonly Quest MaximumAttack4thStage_B_EpI_E = new Quest(145, "Maximum Attack 4th Stage -B- (Ep I, E)");
        public static readonly Quest MaximumAttack4thStage_C_EpI_E = new Quest(146, "Maximum Attack 4th Stage -C- (Ep I, E)");
        public static readonly Quest DreamMessenger = new Quest(201, "Dream Messenger");
        public static readonly Quest PioneerWarehouse = new Quest(202, "Pioneer Warehouse");
        public static readonly Quest ReachfortheDream = new Quest(203, "Reach for the Dream");
        public static readonly Quest GallonsShop = new Quest(204, "Gallon's Shop");
        public static readonly Quest ItemPresent = new Quest(205, "Item Present");
        public static readonly Quest GallonsShop_QQQ = new Quest(206, "Gallon's Shop (???)");
        public static readonly Quest PioneerHalloween = new Quest(207, "Pioneer Halloween");
        public static readonly Quest MaximumAttack2_E = new Quest(211, "Maximum Attack 2 (E)");
        public static readonly Quest SingingAtTheBeach_QQQ = new Quest(214, "Singing at the Beach (???)");
        public static readonly Quest SingingAtTheBeach = new Quest(216, "Singing at the Beach");
        public static readonly Quest GallonsShop_ValentinesEvent = new Quest(219, "Gallon's Shop (Valentines Event)");
        public static readonly Quest PrincipalsGift = new Quest(220, "Principal's Gift");
        public static readonly Quest SeatOfTheHeart_OnlineVersion = new Quest(222, "Seat of the Heart (Online Version)");
        public static readonly Quest TheEastTower_OnlineVersion = new Quest(223, "The East Tower (Online Version)");
        public static readonly Quest TheWestTower_OnlineVersion = new Quest(224, "The West Tower (Online Version)");
        public static readonly Quest BlueStarMemories_QQQ = new Quest(230, "Blue Star Memories (???)");
        public static readonly Quest RespectiveTomorrow = new Quest(231, "Respective Tomorrow");
        public static readonly Quest FestivityOnTheBeach = new Quest(232, "Festivity On The Beach");
        public static readonly Quest PhantasmalWorld1 = new Quest(233, "Phantasmal World #1");
        public static readonly Quest PhantasmalWorld2 = new Quest(234, "Phantasmal World #2");
        public static readonly Quest PhantasmalWorld3 = new Quest(235, "Phantasmal World #3");
        public static readonly Quest PhantasmalWorld4 = new Quest(236, "Phantasmal World #4");
        public static readonly Quest MaximumAttack1Ver2_E = new Quest(237, "MAXIMUM ATTACK 1 Ver2 (E)");
        public static readonly Quest MaximumAttack2Ver2_E = new Quest(238, "MAXIMUM ATTACK 2 Ver2 (E)");
        public static readonly Quest BeachLaughter = new Quest(239, "Beach Laughter");
        public static readonly Quest PioneerChristmas = new Quest(240, "Pioneer Christmas");
        public static readonly Quest MaximumAttack4thStage_A_EpII_E = new Quest(241, "Maximum Attack 4th Stage -A- (Ep II, E)");
        public static readonly Quest MaximumAttack4thStage_B_EpII_E = new Quest(242, "Maximum Attack 4th Stage -B- (Ep II, E)");
        public static readonly Quest MaximumAttack4thStage_C_EpII_E = new Quest(243, "Maximum Attack 4th Stage -C- (Ep II, E)");
        public static readonly Quest CurrentlyUndecided_40000000kills = new Quest(244, "*Currently Undecided* (40,000,000 kills)");
        public static readonly Quest CurrentlyUndecided_80000000kills = new Quest(245, "*Currently Undecided* (80,000,000 kills)");
        public static readonly Quest CurrentlyUndecided_100000000kills = new Quest(246, "*Currently Undecided* (100,000,000 kills)");
        public static readonly Quest CurrentlyUndecided_40000000kills_debug = new Quest(247, "*Currently Undecided* (40,000,000 kills, debug)");
        public static readonly Quest CurrentlyUndecided_80000000kills_debug = new Quest(248, "*Currently Undecided* (80,000,000 kills, debug)");
        public static readonly Quest CurrentlyUndecided_100000000kills_debug = new Quest(249, "*Currently Undecided* (100,000,000 kills, debug)");
        public static readonly Quest MaximumAttack_3rdStage_ = new Quest(301, "Maximum Attack -3rd Stage-");
        public static readonly Quest CurrentlyUndecided = new Quest(302, "*Currently Undecided*");
        public static readonly Quest MaximumAttack4thStage_A_EpIV_E = new Quest(303, "Maximum Attack 4th Stage -A- (Ep IV, E)");
        public static readonly Quest MaximumAttack4thStage_B_EpIV_E = new Quest(304, "Maximum Attack 4th Stage -B- (Ep IV, E)");
        public static readonly Quest MaximumAttack4thStage_C_EpIV_E = new Quest(305, "Maximum Attack 4th Stage -C- (Ep IV, E)");
        public static readonly Quest CurrentlyUndecided_1 = new Quest(306, "*Currently Undecided*");
        public static readonly Quest ClairesDeal1 = new Quest(308, "Claire's Deal 1");
        public static readonly Quest ClairesDeal2 = new Quest(309, "Claire's Deal 2");
        public static readonly Quest ClairesDeal3 = new Quest(310, "Claire's Deal 3");
        public static readonly Quest ClairesDeal4 = new Quest(311, "Claire's Deal 4");
        public static readonly Quest ClairesDeal5 = new Quest(312, "Claire's Deal 5");
        public static readonly Quest BeyondTheHorizon = new Quest(313, "Beyond the Horizon");
        public static readonly Quest MaximumAttack3Ver2_E = new Quest(314, "MAXIMUM ATTACK 3 Ver2 (E)");
        public static readonly Quest CurrentlyUndecided_2 = new Quest(315, "*Currently Undecided*");
        public static readonly Quest _1_1_PlanetRagol = new Quest(401, "1-1:Planet Ragol");
        public static readonly Quest _1_2_TorrentialWoods = new Quest(402, "1-2:Torrential Woods");
        public static readonly Quest _1_3_SubterraneanDen = new Quest(403, "1-3:Subterranean Den");
        public static readonly Quest _2_1_InfernalCavern = new Quest(404, "2-1:Infernal Cavern");
        public static readonly Quest _2_2_DeepWithin = new Quest(405, "2-2:Deep Within");
        public static readonly Quest _2_3_TheMutation = new Quest(406, "2-3:The Mutation");
        public static readonly Quest _2_4_WaterwayShadow = new Quest(407, "2-4:Waterway Shadow");
        public static readonly Quest _3_1_TheFacility = new Quest(408, "3-1:The Facility");
        public static readonly Quest _3_2_MachinesAttack = new Quest(409, "3-2:Machines Attack");
        public static readonly Quest _3_3_CentralControl = new Quest(410, "3-3:Central Control");
        public static readonly Quest _4_1_TheLostRuins = new Quest(411, "4-1:The Lost Ruins");
        public static readonly Quest _4_2_BuriedRelics = new Quest(412, "4-2:Buried Relics");
        public static readonly Quest _4_3_HeroAndDaughter = new Quest(413, "4-3:Hero & Daughter");
        public static readonly Quest _4_4_TheTombStirs = new Quest(414, "4-4:The Tomb Stirs");
        public static readonly Quest _4_5_DarkInheritance = new Quest(415, "4-5:Dark Inheritance");
        public static readonly Quest _5_1_Test_VRTemple1 = new Quest(451, "5-1:Test/VR Temple 1");
        public static readonly Quest _5_2_Test_VRTemple2 = new Quest(452, "5-2:Test/VR Temple 2");
        public static readonly Quest _5_3_Test_VRTemple3 = new Quest(453, "5-3:Test/VR Temple 3");
        public static readonly Quest _5_4_Test_VRTemple4 = new Quest(454, "5-4:Test/VR Temple 4");
        public static readonly Quest _5_5_Test_VRTemple5 = new Quest(455, "5-5:Test/VR Temple 5");
        public static readonly Quest _6_1_Test_Spaceship1 = new Quest(456, "6-1:Test/Spaceship 1");
        public static readonly Quest _6_2_Test_Spaceship2 = new Quest(457, "6-2:Test/Spaceship 2");
        public static readonly Quest _6_3_Test_Spaceship3 = new Quest(458, "6-3:Test/Spaceship 3");
        public static readonly Quest _6_4_Test_Spaceship4 = new Quest(459, "6-4:Test/Spaceship 4");
        public static readonly Quest _6_5_Test_Spaceship5 = new Quest(460, "6-5:Test/Spaceship 5");
        public static readonly Quest _7_1_FromthePast = new Quest(461, "7-1:From the Past");
        public static readonly Quest _7_2_SeekingClues = new Quest(462, "7-2:Seeking Clues");
        public static readonly Quest _7_3_SilentBeach = new Quest(463, "7-3:Silent Beach");
        public static readonly Quest _7_4_CentralControl = new Quest(464, "7-4:Central Control");
        public static readonly Quest _7_5_IsleOfMutants = new Quest(465, "7-5:Isle of Mutants");
        public static readonly Quest _8_1_BelowtheWaves = new Quest(466, "8-1:Below the Waves");
        public static readonly Quest _8_2_DesiresEnd = new Quest(467, "8-2:Desire's End");
        public static readonly Quest _8_3_PurpleLamplight = new Quest(468, "8-3:Purple Lamplight");
        public static readonly Quest BlueStarMemories = new Quest(486, "Blue Star Memories");
        public static readonly Quest Battle1 = new Quest(501, "Battle1");
        public static readonly Quest Battle2 = new Quest(502, "Battle2");
        public static readonly Quest Battle3 = new Quest(503, "Battle3");
        public static readonly Quest Battle4 = new Quest(504, "Battle4");
        public static readonly Quest Battle5 = new Quest(505, "Battle5");
        public static readonly Quest Battle6 = new Quest(506, "Battle6");
        public static readonly Quest Battle7 = new Quest(507, "Battle7");
        public static readonly Quest Battle8 = new Quest(508, "Battle8");
        public static readonly Quest _9_1_MissingResearch = new Quest(701, "9-1:Missing Research");
        public static readonly Quest _9_2_DataRetrieval = new Quest(702, "9-2:Data Retrieval");
        public static readonly Quest _9_3_RealityAndTruth = new Quest(703, "9-3:Reality & Truth");
        public static readonly Quest _9_4_Pursuit = new Quest(704, "9-4:Pursuit");
        public static readonly Quest _9_5_TheChosen = new Quest(705, "9-5:The Chosen");
        public static readonly Quest _9_6_TheChosen = new Quest(706, "9-6:The Chosen");
        public static readonly Quest _9_7_SacredGround = new Quest(707, "9-7:Sacred Ground");
        public static readonly Quest _9_8_TheFinalCycle = new Quest(708, "9-8:The Final Cycle");
        public static readonly Quest PointOfDisaster = new Quest(709, "Point of Disaster");
        public static readonly Quest TheRobotsReckoning = new Quest(710, "The Robots' Reckoning");
        public static readonly Quest WarOfLimits1 = new Quest(811, "War of Limits 1");
        public static readonly Quest WarOfLimits2 = new Quest(812, "War of Limits 2");
        public static readonly Quest WarOfLimits3 = new Quest(813, "War of Limits 3");
        public static readonly Quest WarOfLimits4 = new Quest(814, "War of Limits 4");
        public static readonly Quest WarOfLimits5 = new Quest(815, "War of Limits 5");
        public static readonly Quest NewMopUpOperation1 = new Quest(816, "New Mop-up Operation #1");
        public static readonly Quest NewMopUpOperation2 = new Quest(817, "New Mop-up Operation #2");
        public static readonly Quest NewMopUpOperation3 = new Quest(818, "New Mop-up Operation #3");
        public static readonly Quest NewMopUpOperation4 = new Quest(819, "New Mop-up Operation #4");
        public static readonly Quest NewMopUpOperation5 = new Quest(820, "New Mop-up Operation #5");
        public static readonly Quest ChallengeMode = new Quest(65535, "Challenge Mode");

        #endregion
    }
}
