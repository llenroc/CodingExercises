using System;

public class RectangularPlot
{
    public static int GetMaxPerimeter(string[] grid)
    {
        int result = -1; 
        for (int row = 0; row < grid.Length; row++)
        {
            for (int col = 0; col < grid[row].Length; col++)
            { 
                if (grid[row][col] == 'x') continue;
                var perimeter = GetPerimeter(grid, row, col);
                if (result == -1 || perimeter > result) result = perimeter;
            }
        }
        return result;
    }

    private static int GetPerimeter(string[] grid, int row, int col)
    {
        int result = -1;
        int maxCol = grid[row].Length;
        int[][] memo = new int[grid.Length - row][];

        for (int i = 0; i < memo.Length; i++) memo[i] = new int[maxCol - col];

        for (int r = row, i = 0; r < grid.Length; r++, i++)
        {
            for (int c = col, j = 0; c < maxCol; c++, j++)
            { 
                if (grid[r][c] == 'x')
                {
                    if (r == row)
                    {
                        maxCol = c;
                        continue;
                    }

                    if (c == col) return result;

                    memo[i][j] = 0;
                }
                else
                {
                    if (j > 0 && memo[i][j-1] == 0)
                    {
                        memo[i][j] = 1;
                        continue;
                    }

                    int per = ((2 * (r - row)) + (2 * (c - col)));
                    memo[i][j] = per;
                    if (result == -1 || per > result) result = per;
                }
            }
        }
        return result;
    }


    private static int GetRow(string[] grid, int row, int col)
    {
        int r = row;
        for (; r < grid.Length; r++)
        {
            if (grid[r][col] == 'x')
            {
                if (r == row) return row;
                return r - 1;
            }
        }
        return r - 1;
    }

    private static int GetCol(string[] grid, int row, int col, int maxRow)
    {
        int result = col;
        for (int r = row; r <= maxRow; r++)
        {
            for (int c = col + 1; c < grid[r].Length; c++)
            {
                if (grid[r][c] == 'x') continue;
                result++;
            }
        }
        return result;
    }
}