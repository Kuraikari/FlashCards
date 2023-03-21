using FlashCards.Helpers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FlashCards.Models.FlashCards
{
    [PrimaryKey("Id")]
    public class FlashCardSideModel
    {
        public int Id { get; set; }
        [Required]
        public string[]? Content { get; set; }
        public string? BackgroundColor { get; set; }
    }
}
