using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLBS
{
    public enum LazyLocationType
    {
        /// <summary>
        /// GPS坐标
        /// </summary>
        GPS = 1,
        /// <summary>
        /// sogou经纬度
        /// </summary>
        Sogou,
        /// <summary>
        /// baidu经纬度
        /// </summary>
        Baidu,
        /// <summary>
        /// mapbar经纬度
        /// </summary>
        Mapbar,
        /// <summary>
        /// 腾讯、google、高德坐标
        /// </summary>
        TencentOrGoogleOrAmap,
        /// <summary>
        /// 墨卡托
        /// </summary>
        SogouMercator
    }
}
