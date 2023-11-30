namespace Maximum.Services;

public class ComputeTriangleService : IComputeTriangleService
{
    public int ComputeMax(int[][] triangle)
    {
        for (var i = triangle.Length - 2; i >= 0; i--)
        {
            for (var j = 0; j <= i; j++)
            {
                triangle[i][j] += Math.Max(triangle[i + 1][j], triangle[i + 1][j + 1]);
            }
        }

        return triangle[0][0];
    }

}