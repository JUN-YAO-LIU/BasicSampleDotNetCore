using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicSample.DbAccess.Models
{
    public class AuthUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}