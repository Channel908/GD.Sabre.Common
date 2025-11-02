using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Sabre.Common.Service.Session;

public enum SessionType
{ 
    None,
    Transient,
    Pooled,
    Limited
}
