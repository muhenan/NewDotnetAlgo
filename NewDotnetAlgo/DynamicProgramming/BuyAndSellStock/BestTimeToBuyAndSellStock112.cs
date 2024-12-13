namespace NewDotnetAlgo.DynamicProgramming.BuyAndSellStock;

/// <summary>
/// Leetcode 112
/// best-time-to-buy-and-sell-stock
/// </summary>
public class BestTimeToBuyAndSellStock112
{
    /// <summary>
    /// find min cost
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public int MaxProfit112_1(int[] prices) {
        if (prices.Length == 0) return 0;
        int minCost = prices[0];
        int maxProfit = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] < minCost)
            {
                minCost = prices[i];
            }
            else
            {
                maxProfit = Math.Max(maxProfit, prices[i] - minCost);
            }
        }
        return maxProfit;
    }
    
    /// <summary>
    /// use foreach (var price in prices)
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public int MaxProfit112_2(int[] prices) {
        if (prices.Length <= 1) return 0;

        int minPrice = prices[0];
        int maxProfit = 0;

        foreach (var price in prices)
        {
            minPrice = Math.Min(minPrice, price);
            maxProfit = Math.Max(maxProfit, price - minPrice);
        }

        return maxProfit;
    }
}
