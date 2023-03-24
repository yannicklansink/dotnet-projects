namespace Dag9.IntList.Test;

[TestClass]
public class ListTest
{
    [TestMethod]
    public void Create_ListWithSize2()
    {
        // arrange
        IntList list = new IntList(2);

        // act
        int listSize = list.GetListSize();

        // assert
        Assert.AreEqual(2, listSize);
    }
    
    [TestMethod]
    public void Add_ItemToList()
    {
        // arrange
        IntList list = new IntList();

        // act
        list.Add(2);

        // assert
        Assert.AreEqual(2, list[0]);
    }
    
    [TestMethod]
    public void Get_Index_OutOfRange()
    {
        // arrange
        IntList list = new IntList();
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