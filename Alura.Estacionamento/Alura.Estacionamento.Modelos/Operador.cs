using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Alura.Estacionamento.Modelos
{
    public class Operador
    {

        private readonly string _matricula;
        public string Maticula { get => _matricula; }
        public string Nome { get; set; }

        public Operador()
        {
            _matricula = new Guid().ToString().Substring(0, 10);
        }


        public override string ToString()
        {
            return $"Operador: {this.Nome} " +
                    $"Matrícula: {this.Maticula}";
        }
    }
}
