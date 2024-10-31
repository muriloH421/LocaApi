using System.ComponentModel.DataAnnotations;

namespace LocaApi.Models
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }= Guid.NewGuid();
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

    }
}
