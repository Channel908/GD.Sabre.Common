using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GD.Sabre.Common.Models.AirAvail;

public class AirAvailResponseModel : ResponseModelBase
{
    public OriginDestinations? OriginDestinations { get; set; } = null;
}


public class OriginDestinations
{
    public string? OriginTimeZone { get; set; } = null;
    public string? DestinationTimeZone { get; set; } = null;
    public IEnumerable<FlightItinerary> Itineraries { get; set; } = [];
}


public class FlightItinerary
{
    public int RPH { get; set; }
    public IEnumerable<FlightSegment> FlightSegments { get; set; } = [];

    public int SegmentCount => FlightSegments.Count();

}

public class FlightSegment 
{
    public int RPH { get; set; }
    public IEnumerable<BookingClassAvailability> BookingClassAvailabilies { get; set; } = [];
    public DaysOfOperation? DaysOfOperation { get; set; } = null;

    public string OriginName { get; set; } = string.Empty;
    public string OriginCode { get; set; } = string.Empty;
    public string DestinationName { get; set; } = string.Empty;
    public string DestinationCode { get; set; } = string.Empty;

    public DateTime DepartureDateTime { get; set; }
    public DateTime ArrivalDateTime { get; set; }

    public string FlightNumber { get; set; } = string.Empty;

    public FlightSegmentAirlineDetails? MarketingAirline { get; set; } = null;
    public FlightSegmentAirlineDetails? OperatingAirline { get; set; } = null;

    public string? EquipmentCode { get; set; } = null;
    public string? EquipmentName { get; set; } = null;

    public string? Text { get; set; } = null;
    public bool? Cancelled { get; set; } = null;
    public bool? Charter { get; set; } = null;
    public DateTime? DiscontinueDate { get; set; } = null;
    public DateTime? EffectiveDate { get; set; } = null;
    public int? GroundTime { get; set; } = null;
    public int? TotalTravelTime { get; set; } = null;
    public string? TrafficRestrictionCode { get; set; } = null;

    public IEnumerable<FlightSegmentMealCode> MealCodes { get; set; } = [];
    public string? ConnectionIndicator { get; set; } = null;
    public string? DOTIndicator { get; set; } = null;
    public bool? ETicket { get; set; } = null;
    public int NumberOfStops { get; set; }
}


public class BookingClassAvailability
{
    public int RPH { get; set; }
    public int Availability { get; set; }
    public string? BrandId { get; set; }
    public string BookingCode { get; set; } = string.Empty;
}


public class DaysOfOperation
{
    public bool? Monday { get; set; }
    public bool? Tuesday { get; set; }
    public bool? Wednesday { get; set; }
    public bool? Thursday { get; set; }
    public bool? Friday { get; set; }
    public bool? Saturday { get; set; }
    public bool? Sunday { get; set; }

}

public class FlightSegmentAirlineDetails
{
    public string[]? Text { get; set; } = null;
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string FlightNumber { get; set; } = string.Empty;
}

public class FlightSegmentMealCode
{
    public string Code { get; set; } = string.Empty;
    public string? Name { get; set; } = null;

    public string GetMeal() => Name ?? Code;
}