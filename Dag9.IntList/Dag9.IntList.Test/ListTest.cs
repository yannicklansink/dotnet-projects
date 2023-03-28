namespace Dag9.IntList.Test;

[TestClass]
public class ListTest
{

    // private List<int> list;
    //
    // [TestInitialize]
    // public ListTest()
    // {
    //     list = new List<int>();
    // }
    
    [TestMethod]
    public void Create_ListWithSize2()
    {
        // arrange
        List<int> list = new List<int>(2);

        // act
        int listSize = list.GetListSize();

        // assert
        Assert.AreEqual(2, listSize);
    }
    
    [TestMethod]
    public void Add_ItemToList()
    {
        // arrange
        List<int> list = new List<int>();

        // act
        list.Add(2);

        // assert
        Assert.AreEqual(2, list[0]);
    }
    
    [TestMethod]
    public void Get_Index_OutOfRange()
    {
        // arrange
        List<int> list = new List<int>();
        list.Add(2);
        
        // act
        void act()
        {
            int listItem = list[5];
        }
        
        // assert
        Assert.ThrowsException<IndexOutOfRangeException>(act);
    }
    
    
    
}