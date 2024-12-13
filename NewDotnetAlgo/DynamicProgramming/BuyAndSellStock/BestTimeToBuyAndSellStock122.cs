namespace NewDotnetAlgo.DynamicProgramming.BuyAndSellStock;


/// <summary>
/// Leetcode 122
/// best-time-to-buy-and-sell-stock-ii
/// </summary>
public class BestTimeToBuyAndSellStock122
{
    
    /// <summary>
    /// more like greedy, just find the uphill
    /// whenever there is an uphill, it should be in the answer
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public int MaxProfit122_1(int[] prices) {
        if (prices.Length <= 1) return 0;
        int maxProfit = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] > prices[i - 1])
            {
                maxProfit += prices[i] - prices[i - 1];
            }
        }
        return maxProfit;
    }

    /// <summary>
    /// DP way
    /// DP 的关键是找到状态和转态转移方程
    /// 在这个题目中，每一天可以有两种状态，买 1 和 卖 2, or you can say having a stock or no stock
    /// 所以有两个数组表示这两种状态
    /// 状态转移:
    ///     1 -> 1 / 2
    ///     2 -> 1 / 2
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public int MaxProfit122_2(int[] prices)
    {
        if (prices.Length <= 1) return 0;
        int N = prices.Length;
        int[,] dp = new int[2, N]; // dp[0][i] has a stock, dp[1][i] has no stock
        dp[0, 0] = -prices[0];
        dp[1, 0] = 0;
        for (int i = 1; i < N; i++)
        {
            dp[0, i] = Math.Max(dp[0, i - 1], dp[1, i - 1] - prices[i]);
            dp[1, i] = Math.Max(dp[1, i - 1], dp[0, i - 1] + prices[i]);
        }
        return dp[1, N - 1];
    }
}
