using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entities
{
    public class VeiculoTest
    {
        [TestMethod]
        public void TestarGetPropriedades()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Id = 1;
            veiculo.Nome = "Teste";
            veiculo.Marca = "Teste Motors";
            veiculo.Ano = 2024;

            //Assert
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("Teste", veiculo.Nome);
            Assert.AreEqual("Teste Motors", veiculo.Marca);
            Assert.AreEqual(2024, veiculo.Ano);
        }
    }
}