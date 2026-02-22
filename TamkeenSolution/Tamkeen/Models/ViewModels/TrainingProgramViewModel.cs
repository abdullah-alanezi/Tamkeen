using System.ComponentModel.DataAnnotations;

namespace Tamkeen.Models.ViewModels
{
    public class TrainingProgramViewModel : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Program name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Range(1, 500, ErrorMessage = "Capacity must be between 1 and 500")]
        public int Capacity { get; set; }

        // Logic to ensure EndDate is after StartDate
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return new ValidationResult(
                    "The End Date must be later than the Start Date.",
                    new[] { nameof(EndDate) }
                );
            }
        }
    }
}
