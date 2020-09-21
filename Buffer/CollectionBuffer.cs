using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buffer
{
    public class CollectionBuffer<R> : Queue<QueryMessage<R>>
    {
        public void Add(R message, params object[] paramet)
        {
            var qu = new QueryMessage<R>();
            qu.info = message;
            qu.param = paramet;
            this.Enqueue(qu);
        }
        public R Check(params object[] paramet)
        {
            var res = this.Where(x => EqualsParameter(x.param,paramet)).FirstOrDefault();
            if (res != null) return res.info;
            return default;
        }
        private bool EqualsParameter(object[] obj, object[] objTwo)
        {
            if (obj?.Length != objTwo?.Length) return false;
            for (int i = 0; i < obj.Length; i++)
            {
                if ((obj[i] == null) || (objTwo[i] != null)) {
                    if ((obj[i] == objTwo[i]) == false) return false;
                        }
                if (!obj[i].Equals(objTwo[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public new QueryMessage<R> Dequeue()
        {
            var val = base.Dequeue();
            if (this.Count > max)
            {
                base.Enqueue(val);
            }
            return val;
        }
        public new void Enqueue(QueryMessage<R> query)
        {
            if (this.Count > max) base.Dequeue();
            base.Enqueue(query);
        }
        int max;
        public CollectionBuffer(int max)
        {
            this.max = max;
        }
    }
}
