using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakage.Data
{
    public partial class BreakageMishaEntities
    {
        private static BreakageMishaEntities _context;
        public static BreakageMishaEntities GetContext()
        {
            if( _context == null )
                _context = new BreakageMishaEntities();

            return _context;
        }
    }
}
