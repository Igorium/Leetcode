	public class Solution
	{
		public int MinPathSum(int[][] grid)
		{
			if (grid.Length == 0)
				return 0;

			var h = grid.Length;
			var w = grid[0].Length;

            var dp = new int[h][];

            for(var i = 0; i < h; i++)
            {
                dp[i] = new int[w];
                for(var j = 0; j < w; j++)
                {
                    dp[i][j] = grid[i][j];
                    if (i>0 && j>0){
                        dp[i][j] += Math.Min(dp[i-1][j],dp[i][j-1]);
                    } else if(i > 0){
                        dp[i][j] += dp[i-1][j];
                    } else if(j > 0){
                        dp[i][j] += dp[i][j-1];
                    }

                }
            }
                return dp[h-1][w-1];
            }
            
        }

