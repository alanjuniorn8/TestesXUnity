using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {

        private Veiculo veiculo;
        private Operador operador;
        private Patio estacionamento;
       
        public PatioTestes()
        {
            veiculo = new Veiculo();
            operador = new Operador();
            operador.Nome = "Joe One";
            estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;
        }

        [Fact]
        public void ValidaFaturamentoComUmVeiculo()
        {
            
            veiculo.Proprietario = "Joe Doe";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "ASD-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            var faturamento = estacionamento.TotalFaturado();

            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("Joe One", "QWE-1111", "preto", "Gol")]
        [InlineData("Joe Doe", "ASD-1111", "preto", "Fusca")]
        [InlineData("Joe Tre", "ZXC-1111", "azul", "Fusca")]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            var faturamento = estacionamento.TotalFaturado();

            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("Joe One", "QWE-1111", "preto", "Gol")]
        public void LocalizaVeiculoPatio(string proprietario, string placa, string cor, string modelo)
        {
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            estacionamento.RegistrarEntradaVeiculo(veiculo);


            Veiculo consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            Assert.Contains("Placa do Veículo: QWE-1111", consultado.Ticket);
        }

        [Theory]
        [InlineData("Joe One", "QWE-1111", "preto", "Gol")]
        public void AlteraDadosVeiculoPatio(string proprietario, string placa, string cor, string modelo)
        {
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoNovosDados = new Veiculo();
            veiculoNovosDados.Proprietario = "Joe One";
            veiculoNovosDados.Cor = "preto";
            veiculoNovosDados.Modelo = "Fusca";
            veiculoNovosDados.Placa = "QWE-1111";

            Veiculo veiculoAlterado = estacionamento.AlteraDadosVeiculo(veiculoNovosDados);

            Assert.Equal("Fusca", veiculoAlterado.Modelo);

        }

    }
}
