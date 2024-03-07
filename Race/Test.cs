namespace Race
{
    public class Test
    {
        public static void RaceTest()
        {
            Race race = new Race();
            race.CreateRunners();

            while (race.GetRunnersCount() > 0)
                race.Simulate();

            Runner? winner = Queries.GetWinner(race);

            Console.WriteLine();
            Console.WriteLine("And the winner is...");
            Console.WriteLine(winner.GetName());
            Console.WriteLine(winner.GetTeam());
            Console.WriteLine(winner.GetAge());
            Console.WriteLine(winner.GetPosition());
            Console.WriteLine(winner.GetVelocity());
            Console.WriteLine();

        }
    }
}
