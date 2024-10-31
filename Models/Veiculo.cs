using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocaApi.Models
{
    public class Veiculo
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Marca { get; set; }
        public string Modelo { get; set; }

        [ForeignKey("PatioId")]
        public Guid PatioId { get; set; }
        public Patio? Patio { get; set; }
    }
}
