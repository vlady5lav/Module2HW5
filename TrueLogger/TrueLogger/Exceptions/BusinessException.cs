using System;

namespace TrueLogger
{
    public class BusinessException : Exception
    {
        public BusinessException(string msg)
            : base(msg)
        {
        }
    }
}
