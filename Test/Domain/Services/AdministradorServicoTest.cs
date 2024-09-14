using MinimalApi.Dominio.Entidades;
using MinimalApi.Infraestrutura.Db;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Servicos;

namespace Test.Domain.Services
{
    [TestClass]
    public class AdministradorServicoTest
    {
        private DbContexto CriarContextoTeste()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

            var builder = new ConfigurationBuilder().SetBasePath(path ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);    
        }

        [TestMethod]
        public void TestarSalvarAdministrador()
        {
            //Arrange
            var context = CriarContextoTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

            var adm = new Administrador()
            {
                Email = "teste@teste.com",
                Senha = "teste",
                Perfil = "Adm"
            };

            var administradorServico = new AdministradorServico(context);

            //Act
            administradorServico.Incluir(adm);

            //Assert
            Assert.AreEqual(1, administradorServico.Todos(1).Count);
        }

        [TestMethod]
        public void TestarBuscarPorId()
        {
            //Arrange
            var context = CriarContextoTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

            var adm = new Administrador()
            {
                Email = "teste@teste.com",
                Senha = "teste",
                Perfil = "Adm"
            };

            var administradorServico = new AdministradorServico(context);

            //Act
            administradorServico.Incluir(adm);
            var admDb = administradorServico.BuscaPorId(adm.Id); 

            //Assert
            Assert.AreEqual(1, admDb?.Id);
        }
    }
}