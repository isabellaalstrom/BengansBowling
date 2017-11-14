using System;
using System.Collections.Generic;
using System.Text;

namespace CompetitionLib
{
    public class Venue
    {
        public Guid VenueId { get; set; }
        public string VenueName { get; set; }
        public VenueType VenueType { get; set; }
    }

    public enum VenueType
    {
        Lane
    }
}
