using System;
using System.Text;

using HtmlAgilityPack;
using LotteryTools.Model;
using System.Data.EntityClient;
using System.Data.Entity;

namespace LotteryTools.Utils
{

    public class LotteryFetcher
    {
        private static LotteryFetcher instance = null;

        private LotteryFetcher() { }

        public static LotteryFetcher GetInstance()
        {
            if (instance == null)
            {
                instance = new LotteryFetcher();
            }

            return instance;
        }

        public Lottery fetchLottery(int id)
        {
            HtmlWeb htmlWeb = new HtmlWeb();

            htmlWeb.OverrideEncoding = Encoding.GetEncoding("GB2312");

            HtmlDocument doc = htmlWeb.Load("http://www.17500.cn/ssq/details.php?issue=" + id);


            HtmlNode idNode = doc.DocumentNode.SelectSingleNode("//td[not(@valign) and @align='right']");

            if (idNode == null)
            {
                return null;
            }

            Lottery lottery = new Lottery();

            lottery.ID = id;

            lottery.DATE = DateTime.Parse(idNode.InnerText.Replace("开奖", "").Trim());

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//td/font[@color='red']");

            if (nodes.Count == 6)
            {
                lottery.RED1 = int.Parse(nodes[0].InnerText.Trim());
                lottery.RED2 = int.Parse(nodes[1].InnerText.Trim());
                lottery.RED3 = int.Parse(nodes[2].InnerText.Trim());
                lottery.RED4 = int.Parse(nodes[3].InnerText.Trim());
                lottery.RED5 = int.Parse(nodes[4].InnerText.Trim());
                lottery.RED6 = int.Parse(nodes[5].InnerText.Trim());
            }

            lottery.BLUE = int.Parse(doc.DocumentNode.SelectSingleNode("//font[@color='blue']").InnerText);

            LotteryUtils.GetInstance().CalcLotteryTrait(lottery);

            return lottery;

        }
    }
}