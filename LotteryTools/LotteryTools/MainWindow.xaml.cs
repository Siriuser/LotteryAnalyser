using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using LotteryTools.Utils;
using LotteryTools.Model;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace LotteryTools
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            initDB();
            initPageData(10);
            changeButtonsStatus();
            loadLotteryData(10, 1);
        }

        /// <summary>
        /// 初始化DB
        /// </summary>
        private void initDB()
        {
            using (var lotterysEntities = new LotterysEntities())
            {

                int initialId = int.Parse(ConfigurationManager.AppSettings["initialId"]);

                // 非空库
                if (lotterysEntities.Lotterys.Count<Lottery>() != 0)
                {

                    initialId = lotterysEntities.Lotterys.Max(l => l.ID) + 1;

                }

                loadHistoryLottery(initialId, lotterysEntities);

                lotterysEntities.SaveChanges();

            }
        }

        private void initPageData(int perPage)
        {
            using (var lotterysEntities = new LotterysEntities())
            {
                int count = lotterysEntities.Lotterys.Count();

                int page = count / perPage;

                if (count % perPage > 0)
                {
                    page++;
                }

                

                this.lbCurrentPage.Content = 1;
                this.lbPageCount.Content = page;
                this.lbResultCount.Content = count;
            }
        }

        private void changeButtonsStatus()
        {

            int currentPage = int.Parse(this.lbPageCount.Content.ToString());
            int totalPage = int.Parse(this.lbPageCount.Content.ToString());

            // 只有一页
            if (totalPage == 1)
            {
                this.btnFirstPage.IsEnabled = false;
                this.btnNextPage.IsEnabled = false;
                this.btnPrePage.IsEnabled = false;
                this.btnEndPage.IsEnabled = false;
            }
            else
            {
                if (currentPage == 1)
                {
                    this.btnFirstPage.IsEnabled = false;
                    this.btnNextPage.IsEnabled = true;
                    this.btnPrePage.IsEnabled = false;
                    this.btnEndPage.IsEnabled = true;
                }
                else if (currentPage == totalPage)
                {
                    this.btnFirstPage.IsEnabled = false;
                    this.btnNextPage.IsEnabled = true;
                    this.btnPrePage.IsEnabled = false;
                    this.btnEndPage.IsEnabled = true;
                }
                else
                {
                    this.btnFirstPage.IsEnabled = true;
                    this.btnNextPage.IsEnabled = true;
                    this.btnPrePage.IsEnabled = true;
                    this.btnEndPage.IsEnabled = true;
                }
            }
        }

        private void loadLotteryData(int perPage, int pageNo)
        {
            using (var lotterysEntities = new LotterysEntities())
            {
                var ls = lotterysEntities.Lotterys.OrderByDescending(l => l.ID).Skip(perPage * (pageNo - 1)).Take(perPage).Select(l => l).ToList();

                this.lswLotterys.ItemsSource = ls;
            }
        }

        /// <summary>
        /// 初始加载数据
        /// </summary>
        private void loadHistoryLottery(int id, LotterysEntities lotterysEntities)
        {

            int initId = id;

            LotteryFetcher fetcher = LotteryFetcher.GetInstance();

            Lottery lottery = fetcher.fetchLottery(initId);

            if (lottery == null && initId < ((DateTime.Now.Year + 1) * 1000))
            {
                initId /= 1000;
                initId *= 1000;
                initId += 1001;

                lottery = fetcher.fetchLottery(initId);
            }

            while (lottery != null)
            {
                Console.WriteLine(initId);

                lotterysEntities.Lotterys.Add(lottery);
                initId++;

                lottery = fetcher.fetchLottery(initId);

                if (lottery == null && initId < ((DateTime.Now.Year + 1) * 1000))
                {
                    initId /= 1000;
                    initId *= 1000;
                    initId += 1001;

                    lottery = fetcher.fetchLottery(initId);
                }

            }

        }

        /// <summary>
        /// 每页显示数切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPerPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(this.cmbPerPage.SelectedValue);
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirstPage_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 前一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrePage_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 末页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndPage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
