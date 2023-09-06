using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactApplication_.Entities
{
    [Table("Contact")]
    public class Contact

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(30)]
        [Column(TypeName = "varchar")]
        [Required]
        public string Name { get; set; }
        [StringLength(30)]
        [Column(TypeName = "varchar")]
        [Required]
        public string PhoneNo { get; set; }
        public int? Age { get; set; }

        [StringLength(40)]
        [Column(TypeName = "varchar")]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(30)]
        [Column(TypeName = "varchar")]
        public string City { get; set; }
        [StringLength(30)]
        [Column(TypeName = "varchar")]
        public string Country { get; set; }
        [StringLength(10)]
        [Column(TypeName = "char")]
        public string Gender { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }


    }
}
