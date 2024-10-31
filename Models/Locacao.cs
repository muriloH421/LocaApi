using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocaApi.Models
{
    public class Locacao
    {
        [Key]
        public Guid Id { get; set; }= Guid.NewGuid();
        public DateTime Datalocacao { get; set; }
        public DateTime? DataDevoluçao { get; set; }

        [ForeignKey("VeiculoId")]
        public Guid VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }


        [ForeignKey("ClienteID")]
        public Guid ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
