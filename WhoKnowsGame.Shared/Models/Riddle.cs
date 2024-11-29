namespace WhoKnowsGame.Shared.Models
{
    public class Riddle
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<Answer> Answers { get; set; }
        public int AnswerId { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
