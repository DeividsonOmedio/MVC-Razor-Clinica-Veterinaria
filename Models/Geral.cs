using ClinicaVeterinaria.Models.Enums;

namespace ClinicaVeterinaria.Models
{
    public class Geral
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public double Custo { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public string Codigo { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public StatusEnum Status { get; set; }


        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public int Idade { get; set; }
        public string Dono { get; set; }

        List<Animal> NomeAnimais { get; set; } = new List<Animal>();

    }
}
