namespace Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        NodeList<string> list = new NodeList<string>();
        list.Add("vlad");
        Assert.Equal(1, list.Count);
    }
    [Fact]
    public void Test2() 
    {
        NodeList<int> list = new NodeList<int>();
        list.Add(1);
        list.Add(2);
        list.Remove(1);
        Assert.True(list.Contains(2));
    }
}