namespace TestMaximum;

using Maximum.Services;

public class UnitTestGenerateTriangleFromFileService
{
    
    [Fact]
    public void TestShouldGenerate100Row()
    {
        var generateTriangleFromFileService = new GenerateTriangleFromFileService("TestInputs\\Triangle.txt");
        var testData = generateTriangleFromFileService.Generate();
        Assert.Equal(100, testData.Length);
    }
    
    [Fact]
    public void TestShouldThrowErrorWhenFileIsEmpty()
    {
        var generateTriangleFromFileService = new GenerateTriangleFromFileService("TestInputs\\TriangleEmpty.txt");
        var ex = Assert.Throws<ArgumentException>(() => generateTriangleFromFileService.Generate());
        Assert.Equal("Input file is empty!, TestInputs\\TriangleEmpty.txt", ex.Message);
    }
    
    [Fact]
    public void TestShouldThrowErrorWhenFileIsInvalid()
    {
        var generateTriangleFromFileService = new GenerateTriangleFromFileService("TestInputs\\TriangleInvalid.txt");
        var ex = Assert.Throws<ArgumentException>(() => generateTriangleFromFileService.Generate());
        Assert.Equal("Invalid triangle data!, TestInputs\\TriangleInvalid.txt", ex.Message);
    }
    
        
    [Fact]
    public void TestShouldThrowErrorWhenFileNotExist()
    {
        var generateTriangleFromFileService = new GenerateTriangleFromFileService("TestInputs\\notExist.txt");
        Assert.Throws<FileNotFoundException>(() => generateTriangleFromFileService.Generate());
   
    }



}