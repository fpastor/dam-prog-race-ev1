using System.Reflection;

namespace Race
{
    public class Race
    {
        private List<Runner> _runners = new List<Runner>();
        private List<Runner> _leaderboard = new List<Runner>();
        private double _meta = 1000;
        private int _seconds = 0;

        public double GetMeta()
        {
            return _meta;
        }

        public int GetRunnersCount()
        {
            return _runners.Count;
        }

        public Runner GetRunnerAt(int index)
        {
            return _runners[index];
        }

        public int GetLeaderborardCount()
        {
            return _leaderboard.Count;
        }

        public Runner GetLeaderboardAt(int index)
        {
            return _leaderboard[index];
        }

        public void CreateRunners()
        {
            AddRunner(new Runner(23, "Pepe", 1, 0, teamType.ROJO));
            AddRunner(new Runner(18, "Juan", 1, 0, teamType.ROJO));

            AddRunner(new Runner(19, "Paco", 1, 0, teamType.AZUL));
            AddRunner(new Runner(25, "Lola", 1, 0, teamType.AZUL));

            AddRunner(new Runner(40, "Paco", 1, 0, teamType.VERDE));
            AddRunner(new Runner(23, "Filo", 1, 0, teamType.VERDE));
        }

        public void AddRunner(Runner runner)
        {
            _runners.Add(runner);
        }

        public void AddLeader(Runner runner)
        {
            _leaderboard.Add(runner);
        }

        public Runner? GetRunnerWithName(string name)
        {
            for (int i = 0; i < _runners.Count; i++)
            {
                if(_runners[i].GetName() == name)
                    return _runners[i];
            }
            return null;
        }

        public int GetRunnerIndexWithName(string name)
        {
            for (int i = 0; i < _runners.Count; i++)
            {
                if(_runners[i].GetName() == name)
                    return i;
            }
            return -1;
        }

        public void RemoveRunnerAt(int index)
        {
            _runners.RemoveAt(index);
        }

        public void RemoveRunnerWithName(string runner)
        {
            _runners.RemoveAt(GetRunnerIndexWithName(runner));
        }

        public void Simulate()
        {
            for(int i=0 ; i < _runners.Count; i++)
            {
                _runners[i].Simulate();

                if (_meta - _runners[i].GetPosition() <= 0)
                {
                    AddLeader(_runners[i]);
                    RemoveRunnerAt(i);
                }
            }
            _seconds++;
        }

        public Runner GetMostAdvancedRunner()
        {
            return SortByDistance(_runners, _meta)[0];
        }

        public static List<Runner> Clone(List<Runner> runners)
        {
            List<Runner> clone = new List<Runner>();

            for (int i = 0; i < runners.Count; i++)
            {
                clone.Add(runners[i]);
            }
            return clone;
        }

        public static List<Runner> SortByDistance(List<Runner> runners, Double meta)
        {
            List<Runner> runnersSorByDistance = Clone(runners);

            for (int i = 0; i < runnersSorByDistance.Count - 1; i++)
            {
                for (int j = i + 1; i < runnersSorByDistance.Count ; j++)
                {
                    double distanceI = meta - runnersSorByDistance[i].GetPosition();
                    double distanceJ = meta - runnersSorByDistance[j].GetPosition();

                    if (distanceI > distanceJ)
                    {
                        Swap(runners[i], runners[j]);
                    }
                }
            }
            return runnersSorByDistance;
        }

        public static void Swap(Runner runner1, Runner runner2)
        {
            Runner aux = new Runner(runner1.GetAge(), runner1.GetName(), runner1.GetVelocity(), runner1.GetPosition(), runner1.GetTeam());

            runner1.SetAge(runner2.GetAge());
            runner1.SetName(runner2.GetName());
            runner1.SetVelocity(runner2.GetVelocity());
            runner1.SetPosition(runner2.GetPosition());
            runner1.SetTeam(runner2.GetTeam());

            runner2.SetAge(aux.GetAge());
            runner2.SetName(aux.GetName());
            runner2.SetVelocity(aux.GetVelocity());
            runner2.SetPosition(aux.GetPosition());
            runner2.SetTeam(aux.GetTeam());
        }

    }
}
