using FlashCards.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FlashCards.Models.FlashCards
{
    [PrimaryKey("Id")]
    public class FlashCardModel
    {
        public int Id { get; set; }
        public Topics Topics { get; set; }
        public string SubTopics { get; set; }           = string.Empty;
        [Required]
        public FlashCardSideModel Front { get; set; }        = new FlashCardSideModel();
        [Required]
        public FlashCardSideModel Back { get; set; }         = new FlashCardSideModel();   
    }
}
