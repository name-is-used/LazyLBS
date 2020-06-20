using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLBS
{
    public class LazyLBSPoint
    {
        /// <summary>
        /// 纬度
        /// </summary>
        public double Lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Lng { get; set; }

        public LazyLBSPoint(double lat, double lng)
        {
            this.Lat = lat;
            this.Lng = lng;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", this.Lat, this.Lng);
        }

    }
}
