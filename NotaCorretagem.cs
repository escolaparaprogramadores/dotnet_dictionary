using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;

namespace dotnet_dictionary
{
    public class NotaCorretagem
    {
        public long Cci { get; set; }
        public int NumeroNota { get; set; }
        public DateTime DataPregao { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public int NumeroDaConta { get; set; }
        public decimal Saldo { get; set; }


        public List<NotaCorretagem> GerarNotasCorretagem(int quantidade)
        {
            var faker = new Faker<NotaCorretagem>("pt_BR").StrictMode(true)
            .RuleFor(p => p.Cci, f => f.Random.Number(1, quantidade))
            .RuleFor(p => p.NumeroNota, f => f.Random.Number(1, quantidade))
            .RuleFor(p => p.DataPregao, f => f.Person.DateOfBirth)
            .RuleFor(p => p.Email,f => f.Person.Email)
            .RuleFor(p => p.Nome, f => f.Person.FullName)
            .RuleFor(p => p.NumeroDaConta, f => f.Random.Number(1, quantidade))
            .RuleFor(p => p.Saldo, f => f.Finance.Amount(1, quantidade));

            return faker.Generate(quantidade);
        }
    }
}