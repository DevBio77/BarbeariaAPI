using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Barbearia.API.Models
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor colocar um nome para o Serviço")]
        [DisplayName("Nome do Serviço")]
        public string? NomeServico { get; set; }

        [DisplayName("Descrição")]
        public string? Descricao { get; set; }
        [Range(10, 999, 
        ErrorMessage = "A duração precisa ficar dê 10 até 999.")]
        public int DuracaoMin { get; set; }
        [Range(0.01, 999.00, 
        ErrorMessage = "O preço deve ficar entre 0.01 até 999.00")]
        public double Preco { get; set; }
    }
}