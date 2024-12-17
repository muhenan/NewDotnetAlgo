namespace NewDotnetAlgo.DynamicProgramming.BuyAndSellStock;

/// <summary>
/// Leetcode 188
/// https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-iv/
/// </summary>
public class BestTimeToBuyAndSellStock188
{
    public int MaxProfit_1(int k, int[] prices) {
        if (prices.Length <= 1) return 0;
        if (k >= prices.Length / 2)
        {
            // you can trade any times you want
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

        // k times
        int[,] dp = new int[k * 2, prices.Length];
        // todo
        return 0;
    }
}
