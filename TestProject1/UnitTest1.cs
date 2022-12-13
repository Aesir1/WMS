using Shouldly;
namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        int test = 1;
        test.ShouldBe(1);
    }
}