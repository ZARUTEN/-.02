using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work
{
    class Class1
    {
        private static Entities5 _context; //Костыль 1
        public static Entities5 GetContext()
        {
            if (_context == null)
                _context = new Entities5();
            return _context;
        }
    }
}
