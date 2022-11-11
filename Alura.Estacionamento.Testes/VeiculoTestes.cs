using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {

        private Veiculo veiculo;

        public VeiculoTestes()
        {
            veiculo = new Veiculo();
        }


        [Fact(DisplayName = "Teste acelerar Veículo")]
        [Trait("Fucionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComParametro10()
        {
            
            veiculo.Acelerar(10);
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste frear Veículo")]
        [Trait("Fucionalidade", "Frear")]
        public void TestaVeiculoFrearComParametro10()
        {
            
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaFichaDeDadosVeiculo()
        {
            
            veiculo.Proprietario = "Joe Doe";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "ASD-9999";

            string dados = veiculo.ToString();

            Assert.Contains("Tipo do Veículo: Automovel", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosdeTresCaracteres()
        {
            string nomeProprietario = "Ab";

            var mensagem = Assert.Throws<System.FormatException>(
            () => new Veiculo(nomeProprietario)
            );

            Assert.Equal("Nome do proprietário deve conter mais de dois caracteres.", mensagem.Message);
        }

        [Fact]
        public void TestaMensagemExcecaoQuartoCaracterDaplaca()
        {
            string placa = "ASDF8888";

            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
            );

            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }


        [Fact(Skip ="Ainda não implementado")]
        public void TestaNaoImplementado()
        {
            
        }
    }
}
