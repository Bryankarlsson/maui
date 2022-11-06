using Lounge.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lounge.Domain
{
    public interface IDatabaseService
    {
        Task Insert(UserInfo userInfo);
    }
}
