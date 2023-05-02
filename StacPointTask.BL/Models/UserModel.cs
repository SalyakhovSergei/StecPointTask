using StecPointTask.Data.DTO;
using System.ComponentModel.DataAnnotations;

namespace StacPointTask.BL.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public OrganizationModel Organization { get; set; }
    }
}