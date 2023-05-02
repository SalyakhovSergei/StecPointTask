using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StecPointTask.Data.DTO
{
    [Table("User")]
    public class UserDto
    {
        [Key]
        /// <summary>
        /// Ключ в таблице пользователей
        /// </summary>
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Организация в которой работает пользователь
        /// </summary>
        public OrganizationDto Organization { get; set; }
    }
}