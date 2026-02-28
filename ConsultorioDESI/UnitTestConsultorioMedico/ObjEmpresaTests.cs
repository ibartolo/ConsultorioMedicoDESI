using System;
using System.Collections.Generic;
using AccesoDatosConsultorioMedico;
using EntidadesConsultorioMedico;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestConsultorioMedico
{
    [TestClass]
    public class ObjEmpresaTests
    {
        private Mock<IDbWrapper> _mockDbWrapper;

        [TestInitialize]
        public void Setup()
        {
            _mockDbWrapper = new Mock<IDbWrapper>();
        }

        [TestMethod]
        public void GetAllEmpresa_DebeRetornarListaDeEmpresas_ConMock()
        {
            // Arrange
            var empresasEsperadas = new List<ObjEmpresa>
            {
                new ObjEmpresa { Id = 1, Nombre = "Empresa 1" },
                new ObjEmpresa { Id = 2, Nombre = "Empresa 2" }
            };

            _mockDbWrapper
                .Setup(x => x.GetAllEmpresa())
                .Returns(empresasEsperadas);

            // Act
            var empresas = _mockDbWrapper.Object.GetAllEmpresa();

            // Assert
            Assert.IsNotNull(empresas);
        }

        [TestMethod]
        public void GetEmpresaById_DebeRetornarEmpresaCorrecta_ConMock()
        {
            // Arrange
            long id = 1;
            var empresaEsperada = new ObjEmpresa { Id = id, Nombre = "Empresa Mock" };

            _mockDbWrapper
                .Setup(x => x.GetEmpresaById(It.IsAny<long>()))
                .Returns(empresaEsperada);

            // Act
            var empresa = _mockDbWrapper.Object.GetEmpresaById(id);

            // Assert
            Assert.IsNotNull(empresa);
            Assert.AreEqual(id, empresa.Id);
        }

        [TestMethod]
        public void SaveOrUpdateEmpresa_DebeAsignarIdYRetornarEmpresa_ConMock()
        {
            // Arrange
            var empresa = new ObjEmpresa
            {
                Nombre = "Empresa Test",
                Descripcion = "Descripción",
                Representante = "Representante",
                TelContacto = "123456789",
                EmailContacto = "test@empresa.com"
            };

            _mockDbWrapper
                .Setup(x => x.SaveOrUpdateEmpresa(It.IsAny<ObjEmpresa>()))
                .Returns((ObjEmpresa obj) =>
                {
                    obj.Id = 1;
                    obj.Nombre = "DESI Poza Rica";
                    obj.Representante = "Ivan Fco";
                    obj.Descripcion = "Empresa de Software";
                    obj.EmailContacto = "bartolocastro@gmail.com";

                    return obj;
                });

            // Act
            var resultado = _mockDbWrapper.Object.SaveOrUpdateEmpresa(empresa);

            // Assert
            Assert.IsNotNull(resultado);
        }
    }
}
