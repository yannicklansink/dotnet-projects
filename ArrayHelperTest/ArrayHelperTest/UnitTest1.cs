namespace ArrayHelperTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        // Arrange
        int[] legeArray = new int[0];
        
        ArrayHelperClass.ArrayHelper sut = new ArrayHelperClass.ArrayHelper();
        
        // Act
        int som = sut.SomVanArray(legeArray);

        // Assert
        Assert.AreEqual(0, som);
    }
}
