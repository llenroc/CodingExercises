public class Docusign
{
    // Complexity: K (1 or Constant When Matrix has been preporcessed)
    public static int GetRangeSum(int[][] matrix, int x1, int y1, int x2, int y2)
    {
        int[][] sumMatrix = Preprocess(matrix);

        int add = 0;
        if (x1 != 0 && y1 != 0)
            add = sumMatrix[x1 - 1][y1 - 1];
        else if (x1 != 0 || y1 != 0)
            add = (x1 == 0) ? sumMatrix[x1][y1 - 1] : sumMatrix[x1 - 1][y1];
            
        int substract =  (x1 == 0 ? 0 : sumMatrix[x1 - 1][y2]) + (y1 == 0 ? 0 : sumMatrix[x2][y1 - 1]);
        
        return sumMatrix[x2][y2] + add - substract;
    }

    // Complexity: NxM
    private static int[][] Preprocess(int[][] matrix)
    {
        int[][] sumMatrix = new int[matrix.Length][];
        for (int row = 0; row < matrix.Length; row++) sumMatrix[row] = new int[matrix[0].Length];

        // Accumulate sum by Col from top to bottom
        for (int col = 0; col < matrix[0].Length; col++)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                if (row == 0)
                    sumMatrix[row][col] = matrix[row][col];
                else
                    sumMatrix[row][col] = matrix[row][col] + sumMatrix[row - 1][col];
            }
        }

        // Accumulate sum for the corresponding cell (using the previous Accumulate sum by Col)
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                if (col == 0) continue;
                sumMatrix[row][col] += sumMatrix[row][col - 1];
            }
        }

        return sumMatrix;
    }

    public static double GetBirthday(int m, int d)
    {
        double result = 7;

        result*=m;
        result--; // -1
        result*=13;
        result+=5;
        result-=2;
        result+=d;
        result*=11;
        result-=d;
        result-=m;
        result/=5;
        result+=22;
        result/=200;  

        return result;
    }
}