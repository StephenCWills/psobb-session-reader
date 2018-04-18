using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using psobb_session_reader.Definitions;

namespace psobb_session_reader
{
    public class Session
    {
        private IList<KillCount> _killCounters;

        public Session(string sessionPath)
        {
            if (!File.Exists(sessionPath))
                throw new ArgumentException($"Session file not found: {sessionPath}", nameof(sessionPath));

            IDictionary<string, string> sessionData = ReadSession(sessionPath);
            int difficulty = ReadInt(sessionData, nameof(Difficulty));
            int episode = ReadInt(sessionData, nameof(Episode));
            int sectionID = ReadInt(sessionData, nameof(SectionID));
            int quest = ReadInt(sessionData, nameof(Quest));
            int meseta = ReadInt(sessionData, nameof(Meseta));
            int experience = ReadInt(sessionData, nameof(Experience));
            int timeSpent = ReadInt(sessionData, nameof(TimeSpent));
            int timeSpentInDungeon = ReadInt(sessionData, nameof(TimeSpentInDungeon));

            SessionFilePath = sessionPath;
            Difficulty = Difficulty.GetDifficulty(difficulty);
            Episode = Episode.GetEpisode(episode);
            SectionID = SectionID.GetSectionID(sectionID);
            Quest = Quest.GetQuest(quest);
            Meseta = meseta;
            Experience = experience;
            TimeSpent = TimeSpan.FromSeconds(timeSpent);
            TimeSpentInDungeon = TimeSpan.FromSeconds(timeSpentInDungeon);

            string sessionDirectory = Path.GetDirectoryName(sessionPath);
            string fileName = Path.GetFileName(sessionPath);
            string timestamp = fileName.Split('-')[0];

            KillCountersPath = Path.Combine(sessionDirectory, $"{timestamp}-kill-counters.txt");

            if (File.Exists(KillCountersPath))
            {
                _killCounters = ReadKillCounters(KillCountersPath)
                    .OrderBy(killCount => killCount.Area.ID)
                    .ThenBy(killCount => killCount.Monster.ToString(Difficulty))
                    .ToList();
            }

            if (DateTime.TryParseExact(timestamp, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out DateTime sessionTime))
                SessionTime = sessionTime;
        }

        public string SessionFileName => Path.GetFileName(SessionFilePath);
        public string SessionFilePath { get; }
        public DateTime SessionTime { get; }
        public Difficulty Difficulty { get; }
        public Episode Episode { get; }
        public SectionID SectionID { get; }
        public Quest Quest { get; }
        public int Meseta { get; }
        public int Experience { get; }
        public TimeSpan TimeSpent { get; }
        public TimeSpan TimeSpentInDungeon { get; }

        public double MesetaPerSecond => Meseta / TimeSpent.TotalSeconds;
        public double MesetaPerMinute => Meseta / TimeSpent.TotalMinutes;
        public double MesetaPerHour => Meseta / TimeSpent.TotalHours;
        public double MesetaPerSecondInDungeon => Meseta / TimeSpentInDungeon.TotalSeconds;
        public double MesetaPerMinuteInDungeon => Meseta / TimeSpentInDungeon.TotalMinutes;
        public double MesetaPerHourInDungeon => Meseta / TimeSpentInDungeon.TotalHours;

        public double ExperiencePerSecond => Experience / TimeSpent.TotalSeconds;
        public double ExperiencePerMinute => Experience / TimeSpent.TotalMinutes;
        public double ExperiencePerHour => Experience / TimeSpent.TotalHours;
        public double ExperiencePerSecondInDungeon => Experience / TimeSpentInDungeon.TotalSeconds;
        public double ExperiencePerMinuteInDungeon => Experience / TimeSpentInDungeon.TotalMinutes;
        public double ExperiencePerHourInDungeon => Experience / TimeSpentInDungeon.TotalHours;

        public string KillCountersFileName => Path.GetFileName(KillCountersPath);
        public string KillCountersPath { get; }
        public IList<KillCount> KillCounters => new List<KillCount>(_killCounters);

        public override string ToString() => SessionTime.ToString();

        public string ToDetail()
        {
            StringBuilder details = new StringBuilder();

            details.AppendLine($"File name: {SessionFileName}");
            details.AppendLine();
            details.AppendLine($"Session time: {SessionTime:M/d/yyyy hh:mm:ss}");
            details.AppendLine($"Difficulty: {Difficulty}");
            details.AppendLine($"Episode: {Episode}");
            details.AppendLine($"Section ID: {SectionID}");
            details.AppendLine($"Quest: {Quest}");
            details.AppendLine($"Meseta earned: {Meseta}");
            details.AppendLine($"Experience earned: {Experience}");
            details.AppendLine($"Time spent: {TimeSpent}");
            details.AppendLine($"Dungeon time: {TimeSpentInDungeon}");
            details.AppendLine();
            details.AppendLine($"Kill counters: {KillCountersFileName}");

            foreach (KillCount killCount in _killCounters)
                details.AppendLine($"({killCount.Area}) {killCount.Monster.ToString(Difficulty)}: {killCount}");

            return details.ToString();
        }

        private static IDictionary<string, string> ReadSession(string sessionPath)
        {
            return File.ReadAllLines(sessionPath)
                .Where(line => line.Contains('='))
                .Select(line => line.Split('='))
                .ToDictionary(line => line[0], line => line[1], StringComparer.OrdinalIgnoreCase);
        }

        private static IEnumerable<KillCount> ReadKillCounters(string killCountersPath)
        {
            return File.ReadAllLines(killCountersPath)
                .Where(line => line.Count(c => c == ',') >= 5)
                .Select(line => line.Split(','))
                .Select(ToKillCount);
        }

        private static int ReadInt(IDictionary<string, string> sessionData, string key)
        {
            if (sessionData.TryGetValue(key, out string value))
                return ParseInt(value);

            return int.MinValue;
        }

        private static KillCount ToKillCount(string[] line)
        {
            int areaID = ParseInt(line[3]);
            int monsterID = ParseInt(line[4]);
            int kills = ParseInt(line[5]);
            Area area = Area.GetArea(areaID);
            Monster monster = Monster.GetMonster(monsterID);
            return new KillCount(area, monster, kills);
        }

        private static int ParseInt(string value)
        {
            if (int.TryParse(value, out int num))
                return num;

            return int.MinValue;
        }
    }
}
