using System.ComponentModel.DataAnnotations;

namespace WhoKnowsGame.Shared.Dtos
{
    public class EnterGameDto
    {
        [Required]
        public int? GameId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public byte[] Image { get; set; }
    }
}
