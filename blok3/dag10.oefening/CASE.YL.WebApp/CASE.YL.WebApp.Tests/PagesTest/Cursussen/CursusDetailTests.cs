using CASE.YL.WebApp.Models;
using CASE.YL.WebApp.Pages;
using CASE.YL.WebApp.Repository;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASE.YL.WebApp.Tests.PagesTest.Cursussen
{
    public class CursusDetailTests
    {

        [Fact]
        public void OnGet_ShouldCreateCursusWithCursisten_WhenCursusExists()
        {
            // Arrange
            var mockCursusRepository = new Mock<ICursusRepository>();
            var cursusInstanties = new List<Cursusinstantie>
            {
                new Cursusinstantie { Cursist = new Particulier { Id = 1, Voornaam = "P", Achternaam = "PA" } },
                new Cursusinstantie { Cursist = new Bedrijfsmedewerker { Id = 1, Voornaam = "B", Achternaam = "BA" } },
            };
            Cursus cursus = new Cursus { Id = 1, Duur = 5, Code = "test", Titel = "test", Cursusinstanties = cursusInstanties };

            mockCursusRepository.Setup(r => r.GetCursusWithCursisten(1)).Returns(cursus);
            CursusDetailModel cursusDetailModel = new CursusDetailModel(mockCursusRepository.Object);

            // Act
            cursusDetailModel.OnGet(1);

            // Assert
            cursusDetailModel.Cursus.Should().BeOfType<Cursus>();
            cursusDetailModel.Cursisten.Should().NotBeNull();
            cursusDetailModel.Cursisten.Count.Should().Be(2);

        }


        [Fact]
        public void OnGet_ShouldNotCreateCursusOrCursisten_WhenCursusNotExist()
        {
            // Arrange
            var mockCursusRepository = new Mock<ICursusRepository>();
            mockCursusRepository.Setup(repo => repo.GetCursusWithCursisten(1)).Returns(value: null);
            CursusDetailModel cursusDetailModel = new CursusDetailModel(mockCursusRepository.Object);

            // Act
            cursusDetailModel.OnGet(1);

            // Assert
            cursusDetailModel.Cursus.Should().BeNull();
            cursusDetailModel.Cursisten.Should().BeNull();
        }
    }
}
