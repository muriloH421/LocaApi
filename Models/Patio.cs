using System.ComponentModel.DataAnnotations;

namespace LocaApi.Models
{
    public class Patio
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();
        public string nome { get; set; }
    }
}
