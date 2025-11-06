using System;
using System.Collections.Generic;
using AccesoDatosConsultorioMedico;
using EntidadesConsultorioMedico;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestConsultorioMedico
{
    [TestClass]
    public class ObjPacienteTests
    {
        private Mock<IDbWrapper> _mockDbWrapper;

        [TestInitialize]
        public void Setup()
        {
            _mockDbWrapper = new Mock<IDbWrapper>();
        }

        [TestMethod]
        public void GetAllPaciente_DebeRetornarListaDePacientes_ConMock()
        {
            var pacientesEsperados = new List<ObjPaciente>
            {
                new ObjPaciente {Id = 1, Nombre = "Paciente 1" },
                new ObjPaciente {Id = 2, Nombre = "Paciente 2" }
            };

            _mockDbWrapper
                .Setup(x => x.GetAllPaciente())
                .Returns(pacientesEsperados);

            var pacientes = _mockDbWrapper.Object.GetAllPaciente();

            Assert.IsNotNull(pacientes);
        }

        [TestMethod]
        public void GetPacienteById_DebeRetornarPacienteCorrecto_ConMock()
        {
            long id = 1;
            var pacienteEsperado = new ObjPaciente { Id = id, Nombre = "Paciente Mock" };

            _mockDbWrapper
                .Setup(x => x.GetPacienteById(It.IsAny<long>()))
                .Returns(pacienteEsperado);

            var paciente = _mockDbWrapper.Object.GetPacienteById(id);

            Assert.IsNotNull(paciente);
            Assert.AreEqual(id, paciente.Id);
        }

        [TestMethod]
        public void SaveOrUpdatePaciente_DebeAsignarIdYRetornarPaciente_ConMock()
        {
            var paciente = new ObjPaciente
            {
                Nombre = "Victor Manuel",
                ApellidoP = "Hernandez",
                ApellidoM = "Luna",
                Genero = "M",
                FechaNacimiento = new DateTime(2003, 1, 2),
                Edad = 22,
                Telefono = "7828298018",
                Email = "vmhl02012003@gmail.com",
                FechaRecepcion = DateTime.Now,
                Comentario = "Paciente nuevo"
            };

            _mockDbWrapper
                .Setup(x => x.SaveOrUpdatePaciente(It.IsAny <ObjPaciente>()))
                .Returns((ObjPaciente obj) =>
                {
                    obj.Id = 1;
                    obj.Nombre = "Victor Manuel";
                    obj.ApellidoP = "Bautista";
                    obj.ApellidoM = "Santes";
                    obj.Genero = "M";
                    obj.FechaNacimiento = new DateTime(2004, 10, 19);
                    obj.Edad = 21;
                    obj.Telefono = "7821245678";
                    obj.Email = "victorbautista@gmail.com";
                    obj.FechaRecepcion = DateTime.Now;
                    obj.Comentario = "Paciente actualizado";

                    return obj;
                });

            var resultado = _mockDbWrapper.Object.SaveOrUpdatePaciente(paciente);

            Assert.IsNotNull(resultado);
        }
    }
}
