using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace quote_calculation_Application.Models
{
    public class InsureeVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(1900, 2025, ErrorMessage = "Car year must be between 1900 and 2025")]
        [Display(Name = "Car Year")]
        public int CarYear { get; set; }

        [Required]
        [Display(Name = "Car Make")]
        public string CarMake { get; set; }

        [Required]
        [Display(Name = "Car Model")]
        public string CarModel { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Speeding tickets cannot be negative")]
        [Display(Name = "Speeding Tickets")]
        public int SpeedingTickets { get; set; }

        [Required]
        [Display(Name = "DUI Conviction?")]
        public bool DUI { get; set; }

        [Required]
        [Display(Name = "Full Coverage?")]
        public bool CoverageType { get; set; }

        [Display(Name = "Quote Amount")]
        [Column(TypeName = "decimal(18,2)")] // SQL Precision
        public decimal QuoteAmount { get; set; }
    }
}