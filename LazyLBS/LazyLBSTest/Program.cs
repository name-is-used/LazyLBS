using LazyLBS;
using System;

namespace LazyLBSTest
{
    class Program
    {
        /// <summary>
        /// secret key
        /// </summary>
        public static string Secretkey = "";

        static void Main(string[] args)
        {
            LazyTencentLBS tencentLBS = new LazyTencentLBS("Z5HBZ-TBNCP-4BPDV-VPV5B-KPBO6-2YFJR", "");

            // 转换
            //Console.WriteLine(tencentLBS.Translate(new List<LazyLBSPoint>() {
            //    new LazyLBSPoint(39.12, 116.83),
            //    new LazyLBSPoint(30.21,115.43)
            //}, LazyLocationType.Baidu));

            // 路线规划服务
            Console.WriteLine(tencentLBS.Direction(LazyTripMode2.Walking, new LazyLBSPoint(39.915285, 116.403857), new LazyLBSPoint(39.915285, 116.803857)));

            // Console.WriteLine(tencentLBS.Geocoder(new LazyLBSPoint(39.984154, 116.307490)));

            // 搜索
            // Console.WriteLine(tencentLBS.Search("美食", "region(北京,0)"));

            // 关键词输入提示
            // Console.WriteLine(tencentLBS.Suggestion("北京", "美食"));

            // 广东省深圳市展滔科技大厦
             Console.WriteLine(tencentLBS.Geocoder("广东省深圳市展滔科技大厦"));

            // 距离计算·
            // Console.WriteLine(tencentLBS.GetDistance(LazyTripMode.Bicycling, new LazyLBSPoint(39.071510, 117.190091), new LazyLBSPoint(39.071510, 117.170091)));

            Console.ReadKey();
        }
    }
}
