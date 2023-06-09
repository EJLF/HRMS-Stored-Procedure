﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS_Stored_Procedure.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-ZÑñ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Middle Name")]
        [MinLength(1)]
        [RegularExpression(@"^[a-zA-ZÑñ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string MiddleName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-ZÑñ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string LastName { get; set; }
        [DisplayName("Full Name")]
        public string? FullName { get; set; }
        [Required]
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
        //Account UserName
        [Required]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        // Foreign Key
        [DisplayName("Department")]
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
        [DisplayName("Position")]
        public int? PositionId { get; set; }
        [ForeignKey("PositionId")]
        public Position? Position { get; set; }
        [RegularExpression(@"^[a-zA-ZÑñ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string? EmployeeType { get; set; }

        //Benefits
        /*[RegularExpression("[0-9]{13}", ErrorMessage = "This is not a valid SSS Number")]
        [Display(Name = "SSS Number")]
        public string? SSSNumber { get; set; }

        [RegularExpression("[0-9]{12}", ErrorMessage = "This is not a valid PagIbig Number")]
        [Display(Name = "PagIbig Number")]
        public string? PagIbigId { get; set; }
        [RegularExpression("[0-9]{12}", ErrorMessage = "This is not a valid PhilHealth Number")]
        [Display(Name = "Philhealth Number")]
        public string? PhilHealthId { get; set; }*/

        //Addrress
        [Required]
        [RegularExpression(@"^[a-zA-ZÑñ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string Street { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZÑñ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string Barangay { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZÑñ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string City { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZÑñ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string State { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZÑñ]+$", ErrorMessage = "This is not a valid Name. Special characters are not allowed.")]
        public string PostalCode { get; set; }

        //Account Status
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateHired { get; set; }

        public bool ActiveStatus { get; set; }

        public bool DeleteStatus { get; set; }
    }
}
