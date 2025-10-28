using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ministore
{
    // Form nhận role để bật/tắt các control
    public interface IRequirePermission
    {
        void SetPermissions(UserRole role);
    }
}
