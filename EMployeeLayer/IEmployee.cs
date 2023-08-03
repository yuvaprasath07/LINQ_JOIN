using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMployeeLayer
{
    public interface IEmployee
    {
        public object get();
        public object leftjoin();

        public object groupJoin();
    }
}
