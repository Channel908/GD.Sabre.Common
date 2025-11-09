using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GD.Sabre.Common.Models.AirAvail;

public class AirAvailRequestModel
{
    public string OriginLocationCode { get; set; } = string.Empty;
    public DateTime? DepartsAt { get; set; }
    public string DestinationLocationCode { get; set; } = string.Empty;
    public DateTime? ArrivesAt { get; set; }

    public int? DepartureTimeWindow { get; set; }
    public int? ArrivalTimeWindow { get; set; }



    public bool DirectFlights { get; set; } = true;
    public int NumberOfStops { get; set; } = 0;
    public int NumberInParty { get; set; } = 1;


}
