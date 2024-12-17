namespace NewDotnetAlgo.DynamicProgramming.BuyAndSellStock;


/// <summary>
/// Leetcode 123
/// best-time-to-buy-and-sell-stock-iii
/// </summary>
public class BestTimeToBuyAndSellStock123
{
    /// <summary>
    /// DP
    /// 四种状态数组
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public int MaxProfit_1(int[] prices)
    {
        if (prices.Length <= 1) return 0;
        int[,] dp = new int[4, prices.Length];
        dp[0, 0] = -prices[0];
        dp[1, 0] = 0;
        dp[2, 0] = -prices[0];
        dp[3, 0] = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            dp[0, i] = Math.Max(dp[0, i - 1 ], -prices[i]);
            dp[1, i] = Math.Max(dp[1, i - 1 ], dp[0, i - 1] + prices[i]);
            dp[2, i] = Math.Max(dp[2, i - 1 ], dp[1, i - 1] - prices[i]);
            dp[3, i] = Math.Max(dp[3, i - 1 ], dp[2, i - 1] + prices[i]);
        }
        return Math.Max(dp[1, prices.Length - 1], dp[3, prices.Length - 1]);
    }
    
    /// <summary>
    /// 把 DP数组优化为变量
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public int MaxProfit_2(int[] prices)
    {
        int n = prices.Length;
        if (n == 0) return 0;

        int buy1 = -prices[0], sell1 = 0;
        int buy2 = -prices[0], sell2 = 0;

        for (int i = 1; i < n; i++)
        {
            int oldBuy1 = buy1, oldSell1 = sell1, oldBuy2 = buy2, oldSell2 = sell2;

            buy1 = Math.Max(oldBuy1, -prices[i]);
            sell1 = Math.Max(oldSell1, oldBuy1 + prices[i]);
            buy2 = Math.Max(oldBuy2, oldSell1 - prices[i]);
            sell2 = Math.Max(oldSell2, oldBuy2 + prices[i]);
        }
        return sell2;
    }
}
