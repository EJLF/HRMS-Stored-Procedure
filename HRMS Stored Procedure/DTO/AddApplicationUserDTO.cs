﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;

namespace HRMS_Stored_Procedure.DTO
{
    public class AddApplicationUserDTO
    {
 
        [Required]
        [MinLength(2)]
        [DisplayName("First Name")]
        [RegularExpression(@"^[a-zA-ZñÑ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Middle Name")]
        [MinLength(1)]
        [RegularExpression(@"^[a-zA-ZñÑ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string MiddleName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-ZñÑ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "This is not a valid phone number")]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }
        [RegularExpression(@"^[a-zA-ZñÑ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string? EmployeeType { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-ZñÑ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string Street { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string Barangay { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string City { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string State { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string PostalCode { get; set; }

        //Account Status
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateHired { get; set; }

        //Account UserName
        [Required]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirm password doesnt match")]
        public string ConfirmPassword { get; set; } 

    }
}
