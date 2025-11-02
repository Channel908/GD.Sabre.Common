using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GD.Sabre.Common.Service.Session;

public static class SabreSessionExtensions
{
    public static bool Approved(this SessionCloseRS? session) => session?.status?.ToLower().Trim() == "approved";
}
