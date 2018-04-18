using psobb_session_reader.Definitions;

namespace psobb_session_reader
{
    public class KillCount
    {
        public KillCount(Area area, Monster monster, int kills)
        {
            Area = area;
            Monster = monster;
            Kills = kills;
        }

        public Area Area { get; }
        public Monster Monster { get; }
        public int Kills { get; }
        public override string ToString() => Kills.ToString();
    }
}
