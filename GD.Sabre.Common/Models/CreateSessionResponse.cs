using GD.Sabre.Common.Core.Reference;
using GD.Sabre.Common.Service.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Sabre.Common.Models;

public class CreateSessionResponse
{
    public SessionCreateRS? SessionCreateRS { get; set; }
    public Security? Security { get; set; }
}
