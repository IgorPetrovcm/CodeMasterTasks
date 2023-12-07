namespace ReadyEnvironment;
using NodeList;
public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        NodeList<string> list = new NodeList<string>();
        list.Add("vlad");
        Assert.Equal(1,list.count);
    }
}