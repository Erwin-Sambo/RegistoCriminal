using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistoCriminal.Entities
{
    public class AspSystemClaims
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("Type")]
        [StringLength(100)]
        public string Type { get; set; } = null!;

        [Column("Value")]
        [StringLength(100)]
        public string Value { get; set; } = null!;

        [Column("Description")]
        [StringLength(255)]
        public string? Description { get; set; } = null!; 
    }


    public class AspSystemClaimsDto
    {
        public string Type { get; set; } = null!;

        public string Value { get; set; } = null!;

        public string? Description { get; set; } = null!;
    }

}
