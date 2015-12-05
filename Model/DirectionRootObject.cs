using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPlaces.Model
{



    public class GeocodedWaypoint
    {
        public string geocoder_status { get; set; }
        public string place_id { get; set; }
        public List<string> types { get; set; }
    }

    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Bounds
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class ArrivalTime
    {
        public string text { get; set; }
        public string time_zone { get; set; }
        public int value { get; set; }
    }

    public class DepartureTime
    {
        public string text { get; set; }
        public string time_zone { get; set; }
        public int value { get; set; }
    }

    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class EndLocation
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class StartLocation
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Distance2
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration2
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class EndLocation2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Polyline
    {
        public string points { get; set; }
    }

    public class StartLocation2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Distance3
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration3
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class EndLocation3
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Polyline2
    {
        public string points { get; set; }
    }

    public class StartLocation3
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Step2
    {
        public Distance3 distance { get; set; }
        public Duration3 duration { get; set; }
        public EndLocation3 end_location { get; set; }
        public string html_instructions { get; set; }
        public Polyline2 polyline { get; set; }
        public StartLocation3 start_location { get; set; }
        public string travel_mode { get; set; }
        public string maneuver { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }

        public Location(double lat, double lng)
        {
            this.lat = lat;
            this.lng = lng;
        }
    }

    public class ArrivalStop
    {
        public Location location { get; set; }
        public string name { get; set; }
    }

    public class ArrivalTime2
    {
        public string text { get; set; }
        public string time_zone { get; set; }
        public int value { get; set; }
    }

    public class Location2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class DepartureStop
    {
        public Location2 location { get; set; }
        public string name { get; set; }
    }

    public class DepartureTime2
    {
        public string text { get; set; }
        public string time_zone { get; set; }
        public int value { get; set; }
    }

    public class Agency
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string url { get; set; }
    }

    public class Vehicle
    {
        public string icon { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Line
    {
        public List<Agency> agencies { get; set; }
        public string short_name { get; set; }
        public string url { get; set; }
        public Vehicle vehicle { get; set; }
    }

    public class TransitDetails
    {
        public ArrivalStop arrival_stop { get; set; }
        public ArrivalTime2 arrival_time { get; set; }
        public DepartureStop departure_stop { get; set; }
        public DepartureTime2 departure_time { get; set; }
        public string headsign { get; set; }
        public Line line { get; set; }
        public int num_stops { get; set; }
    }

    public class Step
    {
        public Distance2 distance { get; set; }
        public Duration2 duration { get; set; }
        public EndLocation2 end_location { get; set; }
        public string html_instructions { get; set; }
        public Polyline polyline { get; set; }
        public StartLocation2 start_location { get; set; }
        public List<Step2> steps { get; set; }
        public string travel_mode { get; set; }
        public TransitDetails transit_details { get; set; }
    }

    public class Leg
    {
        public ArrivalTime arrival_time { get; set; }
        public DepartureTime departure_time { get; set; }
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string end_address { get; set; }
        public EndLocation end_location { get; set; }
        public string start_address { get; set; }
        public StartLocation start_location { get; set; }
        public List<Step> steps { get; set; }
        public List<object> via_waypoint { get; set; }
    }

    public class OverviewPolyline
    {
        public string points { get; set; }
    }

    public class Route
    {
        public Bounds bounds { get; set; }
        public string copyrights { get; set; }
        public List<Leg> legs { get; set; }
        public OverviewPolyline overview_polyline { get; set; }
        public string summary { get; set; }
        public List<string> warnings { get; set; }
        public List<object> waypoint_order { get; set; }
    }

    public class DirectionRootObject
    {
        public List<GeocodedWaypoint> geocoded_waypoints { get; set; }
        public List<Route> routes { get; set; }
        public string status { get; set; }
    }
}
