namespace TestMaximum;

using Maximum.Services;

public class UnitTestComputeTriangleService
{
    [Fact]
    public void TestShouldComputeMaxFor0RowsCorrectly()
    {
        var computeTriangleService = new ComputeTriangleService();
        var testData = new[] { new int[] { } };
        Assert.Equal(0, computeTriangleService.ComputeMax(testData));
    }

    [Fact]
    public void TestShouldComputeMaxFor1RowsCorrectly()
    {
        var computeTriangleService = new ComputeTriangleService();
        var testData = new[] { new[] { 50 } };
        Assert.Equal(50, computeTriangleService.ComputeMax(testData));
    }

    [Fact]
    public void TestShouldComputeMaxFor2RowsCorrectly()
    {
        var computeTriangleService = new ComputeTriangleService();
        var testData = new[] { new[] { 5 }, new[] { 9, 15 }, };
        Assert.Equal(20, computeTriangleService.ComputeMax(testData));
    }

    [Fact]
    public void TestShouldComputeMaxFor5RowsCorrectly()
    {
        var computeTriangleService = new ComputeTriangleService();
        var testData = new[]
        {
            new[] { 5 },
            new[] { 9, 6 },
            new[] { 4, 6, 8 },
            new[] { 0, 7, 1, 5 },
            new[] { 8, 3, 1, 1, 2 },
        };
        Assert.Equal(30, computeTriangleService.ComputeMax(testData));
    }

    [Fact]
    public void TestShouldComputeMaxFor100RowsCorrectly()
    {
        var computeTriangleService = new ComputeTriangleService();
        var generateTriangleFromFileService = new GenerateTriangleFromFileService(
            "TestInputs/Triangle.txt"
        );
        var testData = generateTriangleFromFileService.Generate();
        Assert.Equal(732506, computeTriangleService.ComputeMax(testData));
    }
}
