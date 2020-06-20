/*******************************************************************************************************
 jssdk api文档地址: https://lbs.qq.com/miniProgram/jsSdk/jsSdkGuide/jsSdkOverview
 webservice api文档地址: https://lbs.qq.com/service/webService/webServiceGuide/webServiceOverview
 *******************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLBS
{
    /// <summary>
    /// 
    /// </summary>
    public class LazyTencentLBS
    {
        /// <summary>
        /// key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// secertKey
        /// </summary>
        public string SecertKey { get; set; }

        public LazyTencentLBS(string key)
            : this(key, string.Empty)
        {
        }

        public LazyTencentLBS(string key, string secertKey)
        {
            this.Key = key;
            this.SecertKey = secertKey;
        }


        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="boundary"></param>
        /// <returns></returns>
        public string Search(string keyword, string boundary)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(this.SecertKey))
            {
                result = LazyTencentLBSInterface.Search(this.Key, this.SecertKey, keyword, boundary, null);
            }
            else
            {
                result = LazyTencentLBSInterface.Search(this.Key, this.SecertKey, keyword, boundary, LazyTencentLBSInterface.GetMethodCountersign);
            }
            return result;
        }


        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="keyword">关键字</param>
        /// <param name="boundary">搜索地理范围</param>
        /// <param name="filter">最多支持五个分类</param>
        /// <param name="pageIndex">第x页，默认第1页</param>
        /// <returns></returns>
        public string Search(string keyword,
            string boundary,
            string filter,
            int pageIndex)
        {

            string result = string.Empty;
            if (string.IsNullOrEmpty(this.SecertKey))
            {
                result = LazyTencentLBSInterface.Search(this.Key, this.SecertKey, keyword, boundary, filter, pageIndex, null);
            }
            else
            {
                result = LazyTencentLBSInterface.Search(this.Key, this.SecertKey, keyword, boundary, filter, pageIndex, LazyTencentLBSInterface.GetMethodCountersign);
            }
            return result;
        }


        /// <summary>
        /// 提示
        /// </summary>
        /// <param name="key"></param>
        /// <param name="searchKey"></param>
        /// <param name="keyword"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public string Suggestion(
            string keyword,
            string region,
            string filter,
            int pageIndex)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(this.SecertKey))
            {
                result = LazyTencentLBSInterface.Suggestion(this.Key, this.SecertKey, keyword, region, filter, pageIndex, null);
            }
            else
            {
                result = LazyTencentLBSInterface.Suggestion(this.Key, this.SecertKey, keyword, region, filter, pageIndex, LazyTencentLBSInterface.GetMethodCountersign);
            }
            return result;
        }


        /// <summary>
        /// 提示
        /// </summary>
        /// <param name="key"></param>
        /// <param name="searchKey"></param>
        /// <param name="keyword"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public string Suggestion(
            string keyword,
            string region)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(this.SecertKey))
            {
                result = LazyTencentLBSInterface.Suggestion(this.Key, this.SecertKey, keyword, region, null);
            }
            else
            {
                result = LazyTencentLBSInterface.Suggestion(this.Key, this.SecertKey, keyword, region, LazyTencentLBSInterface.GetMethodCountersign);
            }
            return result;
        }


        /// <summary>
        /// 本接口提供由坐标到坐标所在位置的文字描述的转换。输入坐标返回地理位置信息和附近poi列表
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public string Geocoder(LazyLBSPoint location)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(this.SecertKey))
            {
                result = LazyTencentLBSInterface.Geocoder(location, this.Key, this.SecertKey, null);
            }
            else
            {
                result = LazyTencentLBSInterface.Geocoder(location, this.Key, this.SecertKey, LazyTencentLBSInterface.GetMethodCountersign);
            }
            return result;
        }


        /// <summary>
        /// 提供由地址描述到所述位置坐标的转换，与逆地址解析的过程正好相反
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns></returns>
        public string Geocoder(string address)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(this.SecertKey))
            {
                result = LazyTencentLBSInterface.Geocoder(address, this.Key, this.SecertKey, null);
            }
            else
            {
                result = LazyTencentLBSInterface.Geocoder(address, this.Key, this.SecertKey, LazyTencentLBSInterface.GetMethodCountersign);
            }
            return result;
        }


        /// <summary>
        /// 位置计算
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="fromPoint"></param>
        /// <param name="toPoint"></param>
        /// <returns></returns>
        public string Distance(
            LazyTripMode mode,
            LazyLBSPoint fromPoint,
            LazyLBSPoint toPoint)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(this.SecertKey))
            {
                result = LazyTencentLBSInterface.Distance(mode, new List<LazyLBSPoint>() { fromPoint }, new List<LazyLBSPoint>() { toPoint }, this.Key, this.SecertKey, null);
            }
            else
            {
                result = LazyTencentLBSInterface.Distance(mode, new List<LazyLBSPoint>() { fromPoint }, new List<LazyLBSPoint>() { toPoint }, this.Key, this.SecertKey, LazyTencentLBSInterface.GetMethodCountersign);
            }
            return result;
        }


        /// <summary>
        /// 实现从其它地图供应商坐标系或标准GPS坐标系
        /// </summary>
        /// <param name="locationList"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string Translate(List<LazyLBSPoint> locationList, LazyLocationType type)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(this.SecertKey))
            {
                result = LazyTencentLBSInterface.Translate(locationList, type, this.Key, this.SecertKey, null);
            }
            else
            {
                result = LazyTencentLBSInterface.Translate(locationList, type, this.Key, this.SecertKey, LazyTencentLBSInterface.GetMethodCountersign);
            }
            return result;
        }


        /// <summary>
        /// 在地图中显示路线需要结合地图API或SDK实现相应功能
        /// </summary>
        /// <param name="mode">方式</param>
        /// <param name="fromPoint">来自点</param>
        /// <param name="toPoint"></param>
        /// <returns></returns>
        public string Direction(
            LazyTripMode2 mode,
            LazyLBSPoint fromPoint, 
            LazyLBSPoint toPoint)
        {
            SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>();
            sortedDict.Add("from", fromPoint.ToString());
            sortedDict.Add("to", toPoint.ToString());
            sortedDict.Add("key", this.Key);
            Func<string, string, SortedDictionary<string, string>, string> countersign = null;
            if (!string.IsNullOrEmpty(this.SecertKey))
            {
                countersign = LazyTencentLBSInterface.GetMethodCountersign;
            }
            string result = string.Empty;
            switch (mode)
            {
                case LazyTripMode2.Driving:
                    result = LazyTencentLBSInterface.Driving(this.SecertKey, sortedDict, countersign);
                    break;
                case LazyTripMode2.Bicycling:
                    result = LazyTencentLBSInterface.Bicycling(this.SecertKey, sortedDict, countersign);
                    break;
                case LazyTripMode2.Transit:
                    result = LazyTencentLBSInterface.Transit(this.SecertKey, sortedDict, countersign);
                    break;
                case LazyTripMode2.Walking:
                    result = LazyTencentLBSInterface.Walking(this.SecertKey, sortedDict, countersign);
                    break;
            }
            return result;
        }


    }
}
