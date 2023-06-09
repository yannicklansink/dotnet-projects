using Dag8.oefening1.Models;
using Moq;

namespace Dag8.oefening1.Tests
{
    [TestClass]
    public class TodoTest
    {
        // mock weg van dependency
        // mock framework -> Moq
        // sut == System Under Test

        /*
        Mock<IMovieRepository> _mock;
        Todo _sut;

        [TestInitialize]
        public void Init()
        {
            _mock = new Mock(IMovieRepository);
            _mock.Setup(x => x.GetAll()).Returns(new List<Todo>());
            _sut = new Todo(mock.Object);
        }

        [TestMethod]
        public void TestMethod1()
        {
            

            sut.OnGet(null, null);

            mock.Verify(x => x.GetAll());
        
        }
        */
    }
}