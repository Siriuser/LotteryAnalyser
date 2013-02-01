using LotteryTools.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryTools.Utils
{
    /// <summary>
    /// Lottery工具类
    /// </summary>
    public class LotteryUtils
    {
        private static LotteryUtils instance = null;

        private LotteryUtils() { }

        public static LotteryUtils GetInstance()
        {
            if (instance == null)
            {
                instance = new LotteryUtils();
            }

            return instance;
        }

        /// <summary>
        /// 配置Lottery特征
        /// </summary>
        /// <param name="lottery"></param>
        public void CalcLotteryTrait(Lottery lottery)
        {
            lottery.RTOTAL = lottery.RED1 + lottery.RED2 + lottery.RED3 + lottery.RED4 + lottery.RED5 + lottery.RED6;
            lottery.RAVERAGE = lottery.RTOTAL / 6;
            lottery.TOTAL = lottery.RED1 + lottery.RED2 + lottery.RED3 + lottery.RED4 + lottery.RED5 + lottery.RED6 + lottery.BLUE;
            lottery.AVERAGE = lottery.TOTAL / 7;
            lottery.ODD = 0;
            lottery.EVEN = 0;

            if (lottery.RED1 % 2 > 0)
            {
                lottery.ODD++;
            }
            else
            {
                lottery.EVEN++;
            }

            if (lottery.RED2 % 2 > 0)
            {
                lottery.ODD++;
            }
            else
            {
                lottery.EVEN++;
            }

            if (lottery.RED3 % 2 > 0)
            {
                lottery.ODD++;
            }
            else
            {
                lottery.EVEN++;
            }

            if (lottery.RED4 % 2 > 0)
            {
                lottery.ODD++;
            }
            else
            {
                lottery.EVEN++;
            }

            if (lottery.RED5 % 2 > 0)
            {
                lottery.ODD++;
            }
            else
            {
                lottery.EVEN++;
            }

            if (lottery.RED6 % 2 > 0)
            {
                lottery.ODD++;
            }
            else
            {
                lottery.EVEN++;
            }

            if (lottery.BLUE % 2 > 0)
            {
                lottery.ODD++;
            }
            else
            {
                lottery.EVEN++;
            }

            lottery.RKEY = lottery.RED1 + "," + lottery.RED2 + "," + lottery.RED3 + "," + lottery.RED4 + "," + lottery.RED5 + "," + lottery.RED6;
            lottery.WKEY = lottery.RED1 + "," + lottery.RED2 + "," + lottery.RED3 + "," + lottery.RED4 + "," + lottery.RED5 + "," + lottery.RED6 + "," + lottery.BLUE;
        }

        /// <summary>
        /// 匹配红号
        /// </summary>
        /// <param name="lottery"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool RedContainsGivenNum(Lottery lottery, int num)
        {
            return false;
        }

        /// <summary>
        /// 匹配蓝号
        /// </summary>
        /// <param name="lottery"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool BlueContainGivenNum(Lottery lottery, int num)
        {
            return false;
        }

        /// <summary>
        /// 匹配全部
        /// </summary>
        /// <param name="lottery"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool ContainGivenNum(Lottery lottery, int num)
        {
            return RedContainsGivenNum(lottery, num) | BlueContainGivenNum(lottery, num);
        }

    }
}
