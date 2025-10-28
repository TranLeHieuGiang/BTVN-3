using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ministore
{
    // Form con muốn nhận tìm kiếm: implement ApplySearch
    public interface ISearchable
    {
        void ApplySearch(string text);
    }
}
