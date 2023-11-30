namespace Maximum.Services;

public class GenerateTriangleFromFileService(string path = GenerateTriangleFromFileService.InputsTriangleTxt)
    : IGenerateTriangleService
{
    private const string InputsTriangleTxt = "Inputs\\Triangle.txt";

    public int[][] Generate()
    {
        var triangle = ReadFromFile();
        ValidateTriangle(triangle);
        return triangle;
    }

    private int[][] ReadFromFile()
    {
        var triangle = File.ReadAllLines(path)
            .Select(l => l.Trim().Split(' ').Select(int.Parse).ToArray())
            .ToArray();
        return triangle;
    }

    private void ValidateTriangle(int[][] triangle)
    {
        //@todo logs error messages

        if (triangle.Length == 0)
        {
            throw new ArgumentException("Input file is empty!, " + path);
        }

        if (triangle.Where((t, i) => t.Length != i + 1).Any())
        {
            throw new ArgumentException("Invalid triangle data!, " + path);
        }
    }
}