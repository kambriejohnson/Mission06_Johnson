using System.ComponentModel.DataAnnotations;

namespace Mission06_Johnson.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Title is required.")] // ensures the user enters a title
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")] // ensures the user entered a year that is 1888 or later
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Please select Yes or No for Edited.")] // user must select yes or no
        public bool? Edited { get; set; }

        [Required(ErrorMessage = "Please select Yes or No for Copied To Plex.")] // user must select yes or no
        public bool? CopiedToPlex { get; set; }

        public string? LentTo { get; set; }

        [MaxLength(25)] // user can only enter 25 characters of notes
        public string? Notes { get; set; }
    }
}