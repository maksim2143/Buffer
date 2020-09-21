using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Buffer
{
    public class QueryMessage<R>
    {
        public R info { set; get; }
        public object[] param { set; get; }
    }
}
