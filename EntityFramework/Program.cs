namespace GamesApp
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Mode { get; set; }
        public int SoldCopies { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var game = new Game
                {
                    Name = "Grand Theft Auto V",
                    Studio = "Rockstar Games",
                    Genre = "Action",
                    ReleaseDate = new DateTime(2013, 12, 10),
                    Mode = "Однокористувацький/Онлайн",
                    SoldCopies = 20000000
                };
                context.Games.Add(game);
                context.SaveChanges();
            }

            using (var context = new AppDbContext())
            {
                var game = context.Games.First(x => x.Name == "Grand Theft Auto V");
                game.Name = "Grand Theft Auto V - Mechanic Repack";
                game.SoldCopies = 30000000;
                context.SaveChanges();
            }
            Show();
        }
        private static void Show()
        {
            using (var context = new AppDbContext())
            {
                var games = context.Games.ToList(); // Retrieve all games
                games.ForEach(game =>
                {
                    Console.WriteLine($"Id: {game.Id}");
                    Console.WriteLine($"Название игры: {game.Name}");
                    Console.WriteLine($"Студия создатель: {game.Studio}");
                    Console.WriteLine($"Жанр игры: {game.Genre}");
                    Console.WriteLine($"Дата релиза: {game.ReleaseDate.ToShortDateString()}");
                    Console.WriteLine($"Режим игры: {game.Mode}");
                    Console.WriteLine($"Копий продано: {game.SoldCopies}");
                    Console.WriteLine("======================================");
                });
            }
        }

    }
}
