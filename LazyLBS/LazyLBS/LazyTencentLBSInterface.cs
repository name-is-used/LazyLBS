using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LazyLBS
{
    /// <summary>
    /// lbs的接口
    /// </summary>
    internal class LazyTencentLBSInterface
    {
        /// <summary>
        /// host
        /// </summary>
        public static string Host = "https://apis.map.qq.com";


        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="key"></param>
        /// <param name="searchKey"></param>
        /// <param name="keyword"></param>
        /// <param name="boundary"></param>
        /// <param name="countersign"></param>
        /// <returns></returns>
        public static string Search(
            string key,
            string searchKey,
            string keyword,
            string boundary,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>();
            sortedDict.Add("key", key);
            sortedDict.Add("keyword", keyword);
            sortedDict.Add("boundary", boundary);
            string result = Search(searchKey, sortedDict, countersign);
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
        public static string Search(
            string key,
            string searchKey,
            string keyword,
            string boundary,
            string filter,
            int pageIndex,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>();
            sortedDict.Add("key", key);
            sortedDict.Add("keyword", keyword);
            sortedDict.Add("boundary", boundary);
            sortedDict.Add("filter", filter);
            sortedDict.Add("page_index", pageIndex.ToString());
            string result = Search(searchKey, sortedDict, countersign);
            return result;
        }


        public static string Search(
            string searchKey,
            SortedDictionary<string, string> parameters,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            string path = "/ws/place/v1/search/";
            if (countersign != null)
            {
                string sig = countersign(path, searchKey, parameters);
                parameters.Add("sig", sig);
            }

            RestClient restClient = new RestClient(Host + path);
            RestRequest request = new RestRequest();
            foreach (var item in parameters)
            {
                request.AddParameter(item.Key, item.Value);
            }
            var response = restClient.Get(request);
            return response.Content;
        }


        public static string Suggestion(
            string key,
            string searchKey,
            string keyword,
            string region,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>();
            sortedDict.Add("key", key);
            sortedDict.Add("keyword", keyword);
            sortedDict.Add("region", region);
            string result = Suggestion(searchKey, sortedDict, countersign);
            return result;
        }


        public static string Suggestion(
            string key,
            string searchKey,
            string keyword,
            string region,
            string filter,
            int pageIndex,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>();
            sortedDict.Add("key", key);
            sortedDict.Add("keyword", keyword);
            sortedDict.Add("region", region);
            sortedDict.Add("filter", filter);
            sortedDict.Add("page_index", pageIndex.ToString());
            string result = Suggestion(searchKey, sortedDict, countersign);
            return result;
        }


        public static string Suggestion(
           string searchKey,
           SortedDictionary<string, string> parameters,
           Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            string path = "/ws/place/v1/suggestion/";
            if (countersign != null)
            {
                string sig = countersign(path, searchKey, parameters);
                parameters.Add("sig", sig);
            }

            RestClient restClient = new RestClient(Host + path);
            RestRequest request = new RestRequest();
            foreach (var item in parameters)
            {
                request.AddParameter(item.Key, item.Value);
            }
            var response = restClient.Get(request);
            return response.Content;
        }



        /// <summary>
        ///  本接口提供由坐标到坐标所在位置的文字描述的转换。输入坐标返回地理位置信息和附近poi列表
        /// </summary>
        /// <param name="location"></param>
        /// <param name="key"></param>
        /// <param name="secretkey"></param>
        /// <param name="countersign"></param>
        /// <returns></returns>
        public static string Geocoder(
            LazyLBSPoint location,
            string key,
            string secretkey,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>();
            sortedDict.Add("key", key);
            sortedDict.Add("location", location.ToString());
            string result = Geocoder(secretkey, sortedDict, countersign);
            return result;
        }




        /// <summary>
        ///  提供由地址描述到所述位置坐标的转换，与逆地址解析reverseGeocoder()的过程正好相反
        /// </summary>
        /// <param name="address"></param>
        /// <param name="key"></param>
        /// <param name="secretkey"></param>
        /// <param name="countersign"></param>
        /// <returns></returns>
        public static string Geocoder(
            string address,
            string key,
            string secretkey,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>();
            sortedDict.Add("key", key);
            sortedDict.Add("address", address);
            string result = Geocoder(secretkey, sortedDict, countersign);
            return result;
        }


        /// <summary>
        ///  提供由地址描述到所述位置坐标的转换，与逆地址解析reverseGeocoder()的过程正好相反
        /// </summary>
        /// <param name="secretkey"></param>
        /// <param name="parameters"></param>
        /// <param name="countersign"></param>
        /// <returns></returns>
        public static string Geocoder(
            string secretkey,
            SortedDictionary<string, string> parameters,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            string path = "/ws/geocoder/v1/";
            if (countersign != null)
            {
                string sig = countersign(path, secretkey, parameters);
                parameters.Add("sig", sig);
            }

            RestClient restClient = new RestClient(Host + path);
            RestRequest request = new RestRequest();
            foreach (var item in parameters)
            {
                request.AddParameter(item.Key, item.Value);
            }
            var response = restClient.Get(request);
            return response.Content;
        }


        /// <summary>
        /// 通过请求URL参数设置路线查询条件，返回JSON结构化信息，
        /// 在地图中显示路线需要结合地图API或SDK实现相应功能
        /// </summary>
        /// <param name="fromPoint"></param>
        /// <param name="toPoint"></param>
        /// <param name="key"></param>
        /// <param name="secretkey"></param>
        /// <param name="countersign"></param>
        /// <returns></returns>
        public static string Driving(
            LazyLBSPoint fromPoint,
            LazyLBSPoint toPoint,
            string key,
            string secretkey,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>();
            sortedDict.Add("from", fromPoint.ToString());
            sortedDict.Add("to", toPoint.ToString());
            sortedDict.Add("key", key);
            string result = Driving(secretkey, sortedDict, countersign);
            return result;
        }


        /// <summary>
        /// 通过请求URL参数设置路线查询条件，返回JSON结构化信息，
        /// 在地图中显示路线需要结合地图API或SDK实现相应功能
        /// </summary>
        /// <param name="secretkey"></param>
        /// <param name="parameters"></param>
        /// <param name="countersign"></param>
        /// <returns></returns>
        public static string Driving(
            string secretkey,
            SortedDictionary<string, string> parameters,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            string path = "/ws/direction/v1/driving/";
            if (countersign != null)
            {
                string sig = countersign(path, secretkey, parameters);
                parameters.Add("sig", sig);
            }

            RestClient restClient = new RestClient(Host + path);
            RestRequest request = new RestRequest();
            foreach (var item in parameters)
            {
                request.AddParameter(item.Key, item.Value);
            }
            var response = restClient.Get(request);
            return response.Content;
        }



        public static string Walking(
            LazyLBSPoint fromPoint,
            LazyLBSPoint toPoint,
            string key,
            string secretkey,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>();
            sortedDict.Add("from", fromPoint.ToString());
            sortedDict.Add("to", toPoint.ToString());
            sortedDict.Add("key", key);
            string result = Walking(secretkey, sortedDict, countersign);
            return result;
        }



        public static string Walking(
            string secretkey,
            SortedDictionary<string, string> parameters,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            string path = "/ws/direction/v1/walking/";
            if (countersign != null)
            {
                string sig = countersign(path, secretkey, parameters);
                parameters.Add("sig", sig);
            }

            RestClient restClient = new RestClient(Host + path);
            RestRequest request = new RestRequest();
            foreach (var item in parameters)
            {
                request.AddParameter(item.Key, item.Value);
            }
            var response = restClient.Get(request);
            return response.Content;
        }

        public static string Bicycling(
         LazyLBSPoint fromPoint,
         LazyLBSPoint toPoint,
         string key,
         string secretkey,
         Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>();
            sortedDict.Add("from", fromPoint.ToString());
            sortedDict.Add("to", toPoint.ToString());
            sortedDict.Add("key", key);
            string result = Bicycling(secretkey, sortedDict, countersign);
            return result;
        }

        public static string Bicycling(
            string secretkey,
            SortedDictionary<string, string> parameters,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            string path = "/ws/direction/v1/bicycling/";
            if (countersign != null)
            {
                string sig = countersign(path, secretkey, parameters);
                parameters.Add("sig", sig);
            }

            RestClient restClient = new RestClient(Host + path);
            RestRequest request = new RestRequest();
            foreach (var item in parameters)
            {
                request.AddParameter(item.Key, item.Value);
            }
            var response = restClient.Get(request);
            return response.Content;
        }

        public static string Transit(
             LazyLBSPoint fromPoint,
             LazyLBSPoint toPoint,
             string key,
             string secretkey,
             Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>();
            sortedDict.Add("from", fromPoint.ToString());
            sortedDict.Add("to", toPoint.ToString());
            sortedDict.Add("key", key);
            string result = Transit(secretkey, sortedDict, countersign);
            return result;
        }

        public static string Transit(
            string secretkey,
            SortedDictionary<string, string> parameters,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            string path = "/ws/direction/v1/transit/";
            if (countersign != null)
            {
                string sig = countersign(path, secretkey, parameters);
                parameters.Add("sig", sig);
            }

            RestClient restClient = new RestClient(Host + path);
            RestRequest request = new RestRequest();
            foreach (var item in parameters)
            {
                request.AddParameter(item.Key, item.Value);
            }
            var response = restClient.Get(request);
            return response.Content;
        }



        /// <summary>
        /// 计算位置
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="fromPointList"></param>
        /// <param name="toPointList"></param>
        /// <param name="secretkey"></param>
        /// <param name="countersign"></param>
        /// <returns></returns>
        public static string Distance(
            LazyTripMode mode,
            List<LazyLBSPoint> fromPointList,
            List<LazyLBSPoint> toPointList,
            string key,
            string secretkey,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            List<string> fromList = new List<string>();
            foreach (var item in fromPointList)
            {
                fromList.Add(item.ToString());
            }
            List<string> toList = new List<string>();
            foreach (var item in toPointList)
            {
                toList.Add(item.ToString());
            }

            SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>();
            sortedDict.Add("mode", mode.ToString().ToLower());
            sortedDict.Add("from", string.Join(";", fromList));
            sortedDict.Add("to", string.Join(";", toList));
            sortedDict.Add("key", key);
            return Distance(secretkey, sortedDict, countersign);
        }


        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="secretkey"></param>
        /// <param name="parameters"></param>
        /// <param name="countersign"></param>
        /// <returns></returns>
        public static string Distance(
            string secretkey,
            SortedDictionary<string, string> parameters,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            string path = "/ws/distance/v1/matrix";
            if (countersign != null)
            {
                string sig = countersign(path, secretkey, parameters);
                parameters.Add("sig", sig);
            }
            RestClient restClient = new RestClient(Host + path);
            RestRequest request = new RestRequest();
            foreach (var item in parameters)
            {
                request.AddParameter(item.Key, item.Value);
            }
            var response = restClient.Get(request);
            return response.Content;
        }



        /// <summary>
        /// 实现从其它地图供应商坐标系或标准GPS坐标系，批量转换到腾讯地图坐标系。
        /// </summary>
        /// <param name="locationList"></param>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <param name="secretkey"></param>
        /// <param name="countersign"></param>
        /// <returns></returns>
        public static string Translate(
            List<LazyLBSPoint> locationList,
            LazyLocationType type,
            string key,
            string secretkey,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            List<string> locations = new List<string>();
            foreach (var item in locationList)
            {
                locations.Add(item.ToString());
            }
            SortedDictionary<string, string> sortedDict = new SortedDictionary<string, string>();
            sortedDict.Add("locations", string.Join(";", locations));
            sortedDict.Add("type", Convert.ToInt32(type).ToString());
            sortedDict.Add("key", key);
            return Translate(secretkey, sortedDict, countersign);
        }




        /// <summary>
        ///  实现从其它地图供应商坐标系或标准GPS坐标系，批量转换到腾讯地图坐标系。
        /// </summary>
        /// <param name="secretkey"></param>
        /// <param name="parameters"></param>
        /// <param name="countersign"></param>
        /// <returns></returns>
        public static string Translate(
            string secretkey,
            SortedDictionary<string, string> parameters,
            Func<string, string, SortedDictionary<string, string>, string> countersign)
        {
            string path = "/ws/coord/v1/translate/";
            if (countersign != null)
            {
                string sig = countersign(path, secretkey, parameters);
                parameters.Add("sig", sig);
            }
            RestClient restClient = new RestClient(Host + path);
            RestRequest request = new RestRequest();
            foreach (var item in parameters)
            {
                request.AddParameter(item.Key, item.Value);
            }
            var response = restClient.Get(request);
            return response.Content;
        }




        public static string GetMethodCountersign(
            string path,
            string secretkey,
            SortedDictionary<string, string> dict)
        {
            StringBuilder sb = new StringBuilder(path);
            sb.Append("?");
            foreach (var item in dict)
            {
                sb.Append(item.Key + "=" + item.Value);
                sb.Append("&");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(secretkey);
            return MD5(sb.ToString());
        }

        private static string MD5(string value)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(value);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytHash.Length; i++)
            {
                sb.Append(bytHash[i].ToString("X").PadLeft(2, '0'));
            }
            return sb.ToString().ToLower();
        }

        private static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = Encoding.UTF8.GetBytes(str);
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString());
        }

    }
}
