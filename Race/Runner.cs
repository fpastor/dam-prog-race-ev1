namespace Race
{
    public enum teamType
    {
        ROJO,
        VERDE,
        AZUL,
        UNKWOWN
    }

    public class Runner
    {
        private int _age;
        private String _name;
        private double _velocity;
        private double _position;
        private teamType _team;

        public Runner(int age, String name, double velocity, double position, teamType team)
        {
            this._age = age;
            this._name = name;
            this._velocity = velocity;
            this._position = position;
            this._team = team;
        }

        public int GetAge() { return _age; }    
        public String GetName() { return _name; }
        public double GetVelocity() { return _velocity; }
        public double GetPosition() { return _position; }
        public teamType GetTeam() { return _team; }
        public void SetAge(int age) { _age = age; }
        public void SetName(String name) { _name = name; }
        public void SetVelocity(double velocity) { _velocity = velocity; }  
        public void SetPosition(double position) { _position = position; }
        public void SetTeam(teamType team) { _team = team;} 

        public void Simulate()
        {
            double position = GetPosition();
            double velocity = GetVelocity();
            double random = Queries.GetRandom(0.1,0.5);
            SetPosition(position + velocity + random);

            Console.Write(GetName());
            Console.Write(" [" + GetTeam() + "] ");
            Console.Write(GetVelocity() + ": ");
            Console.Write(GetPosition());
            Console.WriteLine();

        }

    }
}
