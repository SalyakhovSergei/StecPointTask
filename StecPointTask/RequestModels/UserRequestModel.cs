using StacPointTask.BL.Models;

namespace StecPointTask.RequestModels
{
    public class UserRequestModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public OrganizationRequestModel Organization { get; set; }
    }
}