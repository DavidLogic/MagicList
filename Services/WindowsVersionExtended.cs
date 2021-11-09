using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicList.Services
{
    public class WindowsVersionExtended
    {
        public enum VersionType
        {
            Unknown = 0,
            Threshold1 = 1507, // 10240 
            Threshold2 = 1511, // 10586 
            Anniversary = 1607, // 14393 Redstone 1 
            Creators = 1703,  // 15063 Redstone 2 
            FallCreators = 1709, // 16299 Redstone 3 
            Redstone4 = 1803,
            Redstone5 = 1809,
            Y19H1 =1903,
            Y19H2 =1909,

        }

    }
}
