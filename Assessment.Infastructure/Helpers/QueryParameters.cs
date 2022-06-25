using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Infastructure.Helpers
{
    public class QueryParameters
    {
        const int _maxPageSize = 50;
        private int _pageSize = 50;
        public int PageNumber { get; set; } = 1;

        public int PageSize {
            get { return _pageSize; }
            set
            {
                _pageSize = value > _maxPageSize ? _maxPageSize : value;
            }
        }
    }
}
