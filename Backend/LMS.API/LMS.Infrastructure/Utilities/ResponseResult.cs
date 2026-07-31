using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Utilities
{
    public class ResponseResult
    {
        public dynamic Result { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
