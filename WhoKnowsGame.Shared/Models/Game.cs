namespace WhoKnowsGame.Shared.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Status { get; set; }
        public ICollection<Riddle> Riddles { get; set; } = new List<Riddle>();
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
