using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_SOLHelper
{
    public static class st_GblVariableHelper
    {

        private static int _timeloading = 0;
        private static int _timemax = 0;

        /// <summary>
        /// 以完成
        /// </summary>
        public static int TimeLoadingI
        {
            set { _timeloading = value; }
            get { return _timeloading; }
        }

        /// <summary>
        /// 总量
        /// </summary>
        public static int TimeMax
        {
            set { _timemax = value; }
            get { return _timemax; }
        }

    }
}
