﻿namespace ClinicaVeterinaria.Models
{
    public class Procedimento : Generic
    {
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public double Custo { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public string Codigo { get; set; }
    }
}