namespace WhoKnowsGame.Shared.Models
{
    public class PlayerRiddleAnswer
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int RiddleId { get; set; }
        public Riddle Riddle { get; set; }
        public int AnswerId { get; set; }
    }
}
