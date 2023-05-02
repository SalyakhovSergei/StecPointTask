using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StecPointTask.Data.DTO
{
    [Table("Organization")]
    public class OrganizationDto
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Наименование организации
        /// </summary>
        public string Name { get; set; }
    }
}