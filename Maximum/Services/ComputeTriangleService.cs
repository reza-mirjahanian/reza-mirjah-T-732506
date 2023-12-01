namespace Maximum.Services;

public class ComputeTriangleService : IComputeTriangleService
{
    public int ComputeMax(int[][] triangle)
    {
        if (  triangle.Length < 1 || triangle[0].Length == 0 ) // is empty.
        {
            return 0;
        }
        
        return  MaxPathSumDp(triangle);
        
        // -------------------------- Recursive Function
        // var cacheTableMaxSums = new int?[triangle.Length, triangle[^1].Length];
        // return  MaximumPathSumRecursive(triangle, 0, 0, cacheTableMaxSums);

    }
    
    private int MaxPathSumDp(int[][] triangle) {
        var rowSize = triangle.Length - 1;
        var maxSumsTable = new int[rowSize + 1]; // DP table
        
        for (var i = rowSize; i >= 0; i--) 
        {
            for (var j = 0; j <= i; j++)
            {
                // Last row or calc max
                maxSumsTable[j] = (i == rowSize) ? triangle[i][j] : Math.Max(maxSumsTable[j], maxSumsTable[j + 1]) + triangle[i][j];
            }
        }

        return maxSumsTable[0];
    }
    
    private int MaximumPathSumRecursive(int[][] triangle, int row, int col, int?[,] tableMaxSums)
    {
        // Finished?
        if (row == triangle.Length - 1)
            return triangle[row][col];
            
        // If cached 
        if (tableMaxSums[row, col].HasValue)
            return tableMaxSums[row, col]!.Value;
            
        // calculate right and left paths 
        var max = Math.Max(
            MaximumPathSumRecursive(triangle, row + 1, col, tableMaxSums), 
            MaximumPathSumRecursive(triangle, row + 1, col + 1, tableMaxSums));
        
        tableMaxSums[row, col] = max + triangle[row][col];
        
        return tableMaxSums[row, col]!.Value;
    }

}