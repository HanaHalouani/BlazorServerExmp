using System.ComponentModel.DataAnnotations;

namespace DataAccesslibrairy.Models
{
    public class PeopleModel
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Name is too short")]
        [MinLength(5, ErrorMessage = "name is too short")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "LastName is too short")]
        [MinLength(5, ErrorMessage = "Lastname is too short")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime DateHire { get; set; }
    }
}
