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

namespace CASE.YL.WebApp.Tests.PagesTest.CursistenTest
{
    public class CursistOverzichtTests
    {

        [Fact]
        public void OnGet_ShouldGetFullCursistList_WhenNotEmpty()
        {
            // Arrange
            var mockCursistRepository = new Mock<ICursistRepository>();
            var cursisten = new List<Cursist>
            {
                new Particulier { Id = 1, Voornaam = "P", Achternaam = "PA" },
                new Bedrijfsmedewerker { Id = 2, Voornaam = "B", Achternaam = "BA" }
            }.AsQueryable();

            mockCursistRepository.Setup(repo => repo.GetAll()).Returns(cursisten);
            var cursistenOverzichtModel = new CursistenOverzichtModel(mockCursistRepository.Object);

            // Act
            cursistenOverzichtModel.OnGet();

            // Assert (fluentassertion)
            cursistenOverzichtModel.CursistList.Should().NotBeNull();
            cursistenOverzichtModel.CursistList.Count.Should().Be(2);
        }

        [Fact]
        public void OnGet_ShouldGetEmptyCursistList_WhenEmpty()
        {
            // Arrange
            var mockCursistRepository = new Mock<ICursistRepository>();
            var cursistList = new List<Cursist>().AsQueryable();

            mockCursistRepository.Setup(repo => repo.GetAll()).Returns(cursistList);
            var cursistenOverzichtModel = new CursistenOverzichtModel(mockCursistRepository.Object);

            // Act
            cursistenOverzichtModel.OnGet();

            // Assert
            cursistenOverzichtModel.CursistList.Should().NotBeNull();
            cursistenOverzichtModel.CursistList.Count.Should().Be(0);
        }

    }
}
