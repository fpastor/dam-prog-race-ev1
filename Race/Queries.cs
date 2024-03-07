namespace Race
{
    public class Queries
    {
        private static Random _random = new Random();

        public static double GetRandom(double min, double max)
        {
            double r = _random.NextDouble();
            double v = r * (max - min);
            return v + min;
        }

        public static Runner? GetWinner(Race race)
        {
            return race.GetLeaderboardAt(0);
        }

        public static int GetRunnerCountWithTeam(teamType team, Race race)
        {
            int runnersCount = race.GetRunnersCount();
            int count = 0;

            for (int i = 0; i < runnersCount; i++)
            {
                if (race.GetRunnerAt(i).GetTeam() == team)
                    count++;
            }
            return count;
        }

        public static teamType GetTeamInHead(Race race)
        {
            int runnersCount = race.GetRunnersCount();
            double distanceTeamROJO = 0;
            double distanceTeamAZUL = 0;
            double distanceTeamVERDE = 0;

            for (int i = 0; i < runnersCount; i++)
            {
                if (race.GetRunnerAt(i).GetTeam() == teamType.ROJO)
                    distanceTeamROJO += race.GetMeta() - race.GetRunnerAt(i).GetPosition();
                if (race.GetRunnerAt(i).GetTeam() == teamType.AZUL)
                    distanceTeamAZUL += race.GetMeta() - race.GetRunnerAt(i).GetPosition();
                if (race.GetRunnerAt(i).GetTeam() == teamType.VERDE)
                    distanceTeamVERDE += race.GetMeta() - race.GetRunnerAt(i).GetPosition();
            }

            double distanceTeamInHead = GetMinorOfThree(distanceTeamROJO, distanceTeamAZUL, distanceTeamVERDE);

            if (distanceTeamInHead == distanceTeamROJO)
                return teamType.ROJO;
            else if (distanceTeamInHead == distanceTeamAZUL)
                return teamType.AZUL;
            else if (distanceTeamInHead == distanceTeamAZUL)
                return teamType.VERDE;
            else
                return teamType.UNKWOWN;
        }

        public static double GetGeaterOfTwo(double a, double b)
        {
            if (a > b)
                return 0;
            return b;
        }

        public static double GetGreaterOfThree(double a, double b, double c)
        {
            return GetGeaterOfTwo(GetGeaterOfTwo(a, b), GetGeaterOfTwo(b, c));
        }

        public static double GetMinorOfTwo(double a, double b)
        {
            if (a < b)
                return a;
            return b;
        }

        public static double GetMinorOfThree(double a, double b, double c)
        {
            return GetMinorOfTwo(GetMinorOfTwo(a, b), GetMinorOfTwo(b, c));
        }

    }
}
