using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormControll
{
    public static class CoordinateCalculation
    {
        static List<int> UnboundedKnapsack(int[] val, int[] wt, int W)
        {
            int n = val.Length;
            int[] dp = new int[W + 1];
            int[] items = new int[W + 1];

            for (int i = 0; i <= W; i++)
                for (int j = 0; j < n; j++)
                    if (wt[j] <= i && dp[i - wt[j]] + val[j] > dp[i])
                    {
                        dp[i] = dp[i - wt[j]] + val[j];
                        items[i] = j;
                    }

            List<int> path = new List<int>();
            for (int i = W; i > 0;)
            {
                int item = items[i];
                if (item == 0 && dp[i] == 0)
                    break;

                path.Add(item);
                i -= wt[item];
            }

            path.Reverse();
            return path.Select(x => val[x]).ToList();
        }


        static (List<int>, bool) GetList(int platformLength, int platformWidth, int itemLength, int itemWidth)
        {

            // 获取以长排列最优解
            var list = UnboundedKnapsack(new int[] { itemWidth, itemLength }, new int[] { itemWidth, itemLength }, platformLength);

            // 获取以宽为边最优解
            var list1 = UnboundedKnapsack(new int[] { itemWidth, itemLength }, new int[] { itemWidth, itemLength }, platformWidth);

            // 求以长排列的数量
            var lh = platformWidth / itemLength;
            var lw = platformWidth / itemWidth;
            var count1 = list.Count(x => x == itemWidth) * lh + list.Count(x => x == itemLength) * lw;
            //Console.WriteLine(count1);

            var wh = platformLength / itemLength;
            var ww = platformLength / itemWidth;
            var count2 = list1.Count(x => x == itemWidth) * wh + list1.Count(x => x == itemLength) * ww;
            //Console.WriteLine(count2);

            //return (list1,true);
            if (count1 > count2)
            {
                return (list, false);
            }
            else
            {
                return (list1, true);
            }
        }


        static List<ItemInfo> GetItems(int platformLength, int platformWidth, int xOffset_platform, int yOffset_platform, int itemLength, int itemWidth, List<int> list, bool isHorizontal)
        {
            // 物品面积（用于求另一边长）
            var area = itemLength * itemWidth;

            List<ItemInfo> itemInfos = new List<ItemInfo>();
            // 坐标转换
            if (!isHorizontal)
            {
                // 计算偏移量
                var xOffset = (decimal)(platformLength - list.Sum()) / 2;
                int step = 0;
                foreach (var item in list)
                {
                    var count = (platformWidth + yOffset_platform * 2) / (area / item);
                    var yOffset = (decimal)(platformWidth - (count * (area / item))) / 2;
                    for (int i = 0; i < count; i++)
                    {
                        itemInfos.Add(new ItemInfo
                        {
                            X = step,
                            Y = i * (area / item),
                            Length = item,
                            Width = area / item,
                            XOffset = xOffset - xOffset_platform,
                            YOffset = yOffset - yOffset_platform
                        });
                    }
                    step += item;
                }
            }
            else
            {
                var yOffset = (decimal)(platformWidth - list.Sum()) / 2;
                int step = 0;
                foreach (var item in list)
                {
                    var count = (platformLength + xOffset_platform * 2) / (area / item);
                    var xOffset = (decimal)(platformLength - (count * (area / item))) / 2;
                    for (int i = 0; i < count; i++)
                    {
                        itemInfos.Add(new ItemInfo
                        {
                            X = i * (area / item),
                            Y = step,
                            Length = area / item,
                            Width = item,
                            XOffset = xOffset,
                            YOffset = yOffset
                        });
                    }
                    step += item;
                }
            }

            //Console.WriteLine(itemInfos);
            return itemInfos;
        }


        /// <summary>
        /// 计算物品位置（左下为 （0，0））
        /// </summary>
        /// <param name="platformLength">平台长度</param>
        /// <param name="platformWidth">平台宽度</param>
        /// <param name="xOffset_platform">平台左右偏移量，左边偏移多少右边也偏移多少</param>
        /// <param name="yOffset_platform">平台上下偏移量，上边偏移多少下边也偏移多少</param>
        /// <param name="itemLength">物品长度</param>
        /// <param name="itemWidth">物品宽度</param>
        /// <returns></returns>
        public static List<ItemInfo> GetItemInfos(int platformLength, int platformWidth, int xOffset_platform, int yOffset_platform, int itemLength, int itemWidth)
        {
            // 获取最优数组
            var (list, isHorizontal) = GetList(platformLength + xOffset_platform * 2, platformWidth + yOffset_platform * 2, itemLength, itemWidth);
            var itemInfos = GetItems(platformLength, platformWidth, xOffset_platform, yOffset_platform, itemLength, itemWidth, list, isHorizontal);
            return itemInfos;
        }
    }
}
