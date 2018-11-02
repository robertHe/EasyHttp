using EasyHttp.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Stopwatch stopwatch = new Stopwatch();
        public MainWindow()
        {
            InitializeComponent();

            var http = new HttpClient();
            http.Request.Accept = HttpContentTypes.ApplicationJson;
            stopwatch.Start();
            var response = http.Get("http://192.168.0.249/api/signdata/queryFuturesMinInfo.m", new { subAccountId = "11", instrumentCode = "ag1902" });
            stopwatch.Stop();
            Console.WriteLine("Name: {0}", stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            var root = response.StaticBody<Root>();
            stopwatch.Stop();
            Console.WriteLine("Name: {0}", stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            response = http.Get("http://192.168.0.249/api/signdata/getKlineData.m", new { instrumentCode = "ag1904" });
            KLineRoot lineRoot = response.StaticBody<KLineRoot>();
            Console.WriteLine("Name: {0}", stopwatch.ElapsedMilliseconds);
        }


    }
    public class RecordsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public double closePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double highPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string instrumentCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double lastPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double lowPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double marketTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double minuteHighPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double minuteLowPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double minuteOpenPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double minuteTurnoverVol { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double openInterest { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double openPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double preClose { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double preSettlementPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double settlementPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double turnoverValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double turnoverVol { get; set; }
    }

    public class Dr
    {
        /// <summary>
        /// 
        /// </summary>
        public string page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double pageNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double pageSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RecordsItem> records { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double totalPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double totalRecords { get; set; }
    }

    public class FutureConditionItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string clientTab { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string deleteFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string direction { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double entrustNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double entrustPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hedgeFlagType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double isTiggered { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double lastmodifyTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string positionType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string priceType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double runStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double sourceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double sourceOrderId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double sourceType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string stockCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string stockName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double subAccountId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double targetOrderId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tiggerCondition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tiggerPriceType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double tiggerValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double type { get; set; }
    }

    public class HisDrRecordsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public double applyNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string applyPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double applyTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double isLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string maxSignTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string minSignTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double openClose { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double pastTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double scaleType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double signTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double signalNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string stockCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string stockName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double tradeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double type { get; set; }
    }

    public class HisDr
    {
        /// <summary>
        /// 
        /// </summary>
        public string page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double pageNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double pageSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<HisDrRecordsItem> records { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double totalPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double totalRecords { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> coord { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dr dr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<FutureConditionItem> futureCondition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public HisDr hisDr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string stockCondition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string upAndDownPenetrateData { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public double code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
        /// <summary>
        /// 请求成功
        /// </summary>
        public string message { get; set; }
    }


    public class DataItem
    {
        /// <summary>
        /// 
        /// </summary>
        public double close_price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double high_price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string instrument_code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double low_price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double open_interest { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double open_price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double pre_close { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double pre_settlement_price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double settlement_price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double trade_date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double turnover_value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double turnover_vol { get; set; }
    }

    public class KLineRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public double code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DataItem> data { get; set; }
        /// <summary>
        /// 请求成功
        /// </summary>
        public string message { get; set; }
    }
}
