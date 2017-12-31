using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamerSkyLite_CS.Controller
{
    static class GUIDController
    {
        public static string NewGUID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
