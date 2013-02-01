using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LotteryTools.Model;
using System.Data.Entity;

namespace LotteryTools.Utils
{
    public class DBUtils
    {

        private static DBUtils instance = null;

        private DBUtils() { }

        public static DBUtils GetInstance()
        {
            if (instance == null)
            {
                instance = new DBUtils();
            }

            return instance;
        }

        /// <summary>
        /// 清空数据库
        /// </summary>
        public void ClearLotteryDB()
        {
            using (var lotterysEntities = new LotterysEntities())
            {
                foreach (Lottery lottery in lotterysEntities.Lotterys)
                {
                    lotterysEntities.Lotterys.Remove(lottery);
                }

                lotterysEntities.SaveChanges();
            }
        }

    }
}
