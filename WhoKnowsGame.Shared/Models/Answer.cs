namespace WhoKnowsGame.Shared.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int RiddleId { get; set; }
        public Riddle Riddle { get; set; }
    }
}
