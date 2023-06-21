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
    public class CursistDetailTests
    {

        [Fact]
        public void OnGet_ValidId_ShouldCreateCursistAndCursusList()
        {
            // Arrange
            var mockCursistRepository = new Mock<ICursistRepository>();

            //  .Object gives you the instance of the mock that implements
            //  ICursistRepository which can be passed around as if it
            //  were a real object
            var cursistDetailModel = new CursistDetailModel(mockCursistRepository.Object);
            var cursist = new Particulier
            {
                Id = 1,
                Voornaam = "X",
                Achternaam = "Y",
                Cursusinstanties = new List<Cursusinstantie>
                {
                    new Cursusinstantie { Cursus = new Cursus { Id = 1, Titel = "C++" } },
                    new Cursusinstantie { Cursus = new Cursus { Id = 2, Titel = "C#" } },
                }
            };

            // It.IsAny<int>() is a placeholder that tells Moq to match any integer.
            mockCursistRepository.Setup(repo => repo.GetCursistWithCursussen(1)).Returns(cursist);

            // Act
            cursistDetailModel.OnGet(1);

            // Assert
            cursistDetailModel.Cursist.Should().NotBeNull();
            cursistDetailModel.Cursist.Should().BeEquivalentTo(cursist);
            cursistDetailModel.CursusList.Should().HaveCount(2);
        }

        [Fact]
        public void OnGet_InvalidId_ShouldNotPopulateCursistOrCursusList()
        {
            // Arrange
            var mockCursistRepository = new Mock<ICursistRepository>();
            var cursistDetailModel = new CursistDetailModel(mockCursistRepository.Object);

            mockCursistRepository.Setup(repo => repo.GetCursistWithCursussen(1)).Returns(value: null);

            // Act
            cursistDetailModel.OnGet(1);

            // Assert
            cursistDetailModel.Cursist.Should().BeNull();
            cursistDetailModel.CursusList.Should().BeNull();
        }

    }
}
