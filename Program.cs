using System;
using System.Collections.Generic;

namespace PremierLeagueSorter
{
    // Клас за представяне на отбор
    public class Team
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }

        // Изчисляване на брой мачове
        public int MatchesPlayed => Wins + Draws + Losses;

        // Изчисляване на разлика в голове
        public int GoalDifference => GoalsFor - GoalsAgainst;

        // Изчисляване на точки
        public int Points => Wins * 3 + Draws;

        // Output
        public override string ToString()
        {
            return $"{Name} Matches played: {MatchesPlayed}  Wins: {Wins}  Draws: {Draws}  Losses: {Losses}  Goals: {GoalsFor}  Goals missed: {GoalsAgainst}  Goals difference: {GoalDifference}  Points: {Points}";
        }
    }

    public class TeamRankingComparer : IComparer<Team>
    {
        public int Compare(Team x, Team y)
        {
            if (x == null || y == null)
                return 0;

            int result = y.Points.CompareTo(x.Points); // По точки
            if (result == 0)
            {
                result = y.GoalDifference.CompareTo(x.GoalDifference); // По разлика
            }
            if (result == 0)
            {
                result = y.Wins.CompareTo(x.Wins); // По победи
            }
            if (result == 0)
            {
                result = x.Name.CompareTo(y.Name); // По име
            }

            return result;
        }
    }

    public class TeamNameComparer : IComparer<Team>
    {
        public int Compare(Team x, Team y)
        {
            if (x == null || y == null)
                return 0;

            return x.Name.CompareTo(y.Name); // Сортиране по име
        }
    }

    class Program
    {
        static void Main()
        {
            List<Team> teams = new List<Team>
            {
                //добавяне на отборите от лигата
                new Team { Name = "Арсенал", Wins = 22, Draws = 6, Losses = 4, GoalsFor = 70, GoalsAgainst = 30 },
                new Team { Name = "Манчестър Юнайтед", Wins = 20, Draws = 5, Losses = 7, GoalsFor = 65, GoalsAgainst = 40 },
                new Team { Name = "Челси", Wins = 18, Draws = 10, Losses = 4, GoalsFor = 60, GoalsAgainst = 38 },
                new Team { Name = "Астън Вила", Wins = 19, Draws = 6, Losses = 7, GoalsFor = 55, GoalsAgainst = 42 },
                new Team { Name = "Лестър", Wins = 16, Draws = 8, Losses = 8, GoalsFor = 58, GoalsAgainst = 47 },

                
                new Team { Name = "Ливърпул", Wins = 30, Draws = 4, Losses = 4, GoalsFor = 85, GoalsAgainst = 25 },
                new Team { Name = "Манчестър Сити", Wins = 28, Draws = 6, Losses = 4, GoalsFor = 75, GoalsAgainst = 33 },
                new Team { Name = "Тотнъм Хотспър", Wins = 18, Draws = 8, Losses = 10, GoalsFor = 60, GoalsAgainst = 45 },
                new Team { Name = "Евертън", Wins = 14, Draws = 10, Losses = 12, GoalsFor = 50, GoalsAgainst = 48 },
                new Team { Name = "Уест Хем Юнайтед", Wins = 19, Draws = 6, Losses = 9, GoalsFor = 58, GoalsAgainst = 44 },

                new Team { Name = "Лийдс Юнайтед", Wins = 12, Draws = 8, Losses = 16, GoalsFor = 52, GoalsAgainst = 60 },
                new Team { Name = "Нюкасъл Юнайтед", Wins = 10, Draws = 10, Losses = 16, GoalsFor = 45, GoalsAgainst = 60 },
                new Team { Name = "Брайтън", Wins = 9, Draws = 12, Losses = 15, GoalsFor = 42, GoalsAgainst = 58 },
                new Team { Name = "Кристъл Палас", Wins = 11, Draws = 9, Losses = 16, GoalsFor = 35, GoalsAgainst = 53 },
                new Team { Name = "Саутхемптън", Wins = 12, Draws = 7, Losses = 19, GoalsFor = 40, GoalsAgainst = 60 },

                new Team { Name = "Уотфорд", Wins = 7, Draws = 5, Losses = 26, GoalsFor = 28, GoalsAgainst = 70 },
                new Team { Name = "Норич Сити", Wins = 5, Draws = 4, Losses = 29, GoalsFor = 25, GoalsAgainst = 75 }
            };

            Console.WriteLine("Първоначален списък:\n");
            PrintTeams(teams);

            Console.WriteLine("\n Сортиране по класиране:\n");
            teams.Sort(new TeamRankingComparer());
            PrintTeams(teams);

            Console.WriteLine("\n Сортиране по име:\n");
            teams.Sort(new TeamNameComparer());
            PrintTeams(teams);
        }

        // Функция за извеждане
        static void PrintTeams(List<Team> teams)
        {
            foreach (var team in teams)
            {
                Console.WriteLine(team);
            }
        }


    }
}
