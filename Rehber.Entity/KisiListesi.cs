using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rehber.Entity
{
    public class KisiListesi
    {

        [Key]
        public int id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(13)]
        public string Name { get; set; }
        [DataType(DataType.Text)]
        [MaxLength(13)]
        public string LastName { get; set; }
        [DataType(DataType.Text)]
        [MaxLength(30)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [MaxLength(25)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
