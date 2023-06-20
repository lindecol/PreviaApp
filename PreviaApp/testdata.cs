
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace PivotGrid_FlatDataBinding
{
    public class SampleFlatData
    {
        #region Properties
        private const int DATA_COUNT = 100;
        private List<CityData> _cities;
        private List<string> _sports;
        private readonly Random _rand = new Random(DateTime.Now.Millisecond);
        #endregion
        public SampleFlatData()
        { }
        #region Methods
        #region Initialize SportsData
        public IEnumerable<SportsData> InitSportsData()
        {
            InitCities();
            InitSports();
            var items = new List<SportsData>();
            for (var i = 0; i < DATA_COUNT; i++)
            {
                int a = _rand.Next(1, 10);
                var dt = DateTime.Today.AddDays(a);
                var cityNation = _cities[_rand.Next(_cities.Count)];
                var newItem = new SportsData
                {
                    Sport = _sports[_rand.Next(_sports.Count)],
                    Nation = cityNation.Nation,
                    City = cityNation.City,
                    Budget = _rand.Next(1000, 1000000) / 100,
                    Players = _rand.Next(1, 100),
                    Date = dt
                };
                items.Add(newItem);
            }
            return items;
        }
        #endregion
        #region Populate SportsData
        private void InitSports()
        {
            if (_sports != null)
                return;
            _sports = new List<string>
                {
                    "Soccer",
                    "Soccer",
                    "Bandy",
                    "Baseball",
                    "Billiards",
                    "Boules",
                    "Bowling",
                    "Bridge",
                    "Chess",
                    "Cricket",
                    "Dance",
                    "Floorball",
                    "Golf",
                    "Karate",
                    "Korfball",
                    "Lifesaving",
                    "Motorcycle Racing",
                    "Mountaineering and Climbing",
                    "Netball",
                    "Orienteering",
                    "Pelota Vasca",
                    "Polo",
                    "Powerboating",
                    "Racquetball",
                    "Roller Sports",
                    "Rugby",
                    "Softball",
                    "Sport climbing",
                    "Squash",
                    "Sumo",
                    "Surfing",
                    "Tug of War",
                    "Underwater Sports",
                    "Water Ski",
                    "Wushu"
                };
        }
        #endregion
        #region Populate CityData
        private void InitCities()
        {
            if (_cities != null)
                return;
            _cities = new List<CityData>
                {
                    new CityData {City = "Los Angeles", Nation = "United States"},
                    new CityData {City = "San Diego", Nation = "United States"},
                    new CityData {City = "San Francisco", Nation = "United States"},
                    new CityData {City = "Detroit", Nation = "United States"},
                    new CityData {City = "Miami", Nation = "United States"},
                    new CityData {City = "Fort Lauderdale", Nation = "United States"},
                    new CityData {City = "New York", Nation = "United States"},
                    new CityData {City = "Pittsburgh", Nation = "United States"},
                    new CityData {City = "Philadelphia", Nation = "United States"},
                    new CityData {City = "Chicago", Nation = "United States"},
                    new CityData {City = "Denver", Nation = "United States"},
                    new CityData {City = "Minneapolis", Nation = "United States"},
                    new CityData {City = "Kansas City", Nation = "United States"},
                    new CityData {City = "Memphis", Nation = "United States"},
                    new CityData {City = "New Orleans", Nation = "United States"},
                    new CityData {City = "Dallas", Nation = "United States"},
                    new CityData {City = "Houston", Nation = "United States"},
                    new CityData {City = "Washington D.C.", Nation = "United States"},
                    new CityData {City = "Seattle", Nation = "United States"},
                    new CityData {City = "Portland", Nation = "United States"},
                    new CityData {City = "Phoenix", Nation = "United States"},
                    new CityData {City = "Tuscon", Nation = "United States"},
                    new CityData {City = "Salt Lake City", Nation = "United States"},
                    new CityData {City = "Boston", Nation = "United States"},
                    new CityData {City = "Cheyenne", Nation = "United States"},
                    new CityData {City = "Santa Fe", Nation = "United States"},
                    new CityData {City = "Virginia Beach", Nation = "United States"},
                    new CityData {City = "London", Nation = "United Kingdom"},
                    new CityData {City = "Manchester", Nation = "United Kingdom"},
                    new CityData {City = "Newcastle", Nation = "United Kingdom"},
                    new CityData {City = "Belfast", Nation = "United Kingdom"},
                    new CityData {City = "Cardiff", Nation = "United Kingdom"},
                    new CityData {City = "Birmingham", Nation = "United Kingdom"},
                    new CityData {City = "Glasgow", Nation = "United Kingdom"},
                    new CityData {City = "Dublin", Nation = "Ireland"},
                    new CityData {City = "Cork", Nation = "Ireland"},
                    new CityData {City = "Galway", Nation = "Ireland"},
                    new CityData {City = "Paris", Nation = "France"},
                    new CityData {City = "Milan", Nation = "Italy"},
                    new CityData {City = "Venice", Nation = "Italy"},
                    new CityData {City = "Barcelona", Nation = "Spain"},
                    new CityData {City = "Seville", Nation = "Spain"},
                    new CityData {City = "Madrid", Nation = "Spain"},
                    new CityData {City = "Berlin", Nation = "Germany"},
                    new CityData {City = "Munich", Nation = "Germany"},
                    new CityData {City = "Dusseldorf", Nation = "Germany"},
                    new CityData {City = "Cologne", Nation = "Germany"},
                    new CityData {City = "Frankfurt", Nation = "Germany"},
                    new CityData {City = "Warsaw", Nation = "Poland"},
                    new CityData {City = "Athens", Nation = "Greece"},
                    new CityData {City = "Sophia", Nation = "Bulgaria"},
                    new CityData {City = "Amsterdam", Nation = "Netherlands"},
                    new CityData {City = "Bruges", Nation = "Belgium"},
                    new CityData {City = "Lisbon", Nation = "Portugal"},
                    new CityData {City = "Leningrad", Nation = "Russia"},
                    new CityData {City = "Moscow", Nation = "Russia"},
                    new CityData {City = "Tel Aviv", Nation = "Israel"},
                    new CityData {City = "Jerusalem", Nation = "Israel"},
                    new CityData {City = "Beijing", Nation = "China"},
                    new CityData {City = "Shanghai", Nation = "China"},
                    new CityData {City = "Hong Kong", Nation = "China"},
                    new CityData {City = "Zhengzhou", Nation = "China"},
                    new CityData {City = "Mumbai", Nation = "India"},
                    new CityData {City = "Hyderabad", Nation = "India"},
                    new CityData {City = "Ahmedabad", Nation = "India"},
                    new CityData {City = "Chennai", Nation = "India"},
                    new CityData {City = "Chennai", Nation = "India"},
                    new CityData {City = "Chennai", Nation = "India"},
                    new CityData {City = "Bangkok", Nation = "Thailand"},
                    new CityData {City = "Phnom Penh", Nation = "Cambodia"},
                    new CityData {City = "Ho Chi Minh City", Nation = "Vietnam"},
                    new CityData {City = "Seoul", Nation = "South Korea"},
                    new CityData {City = "Tokyo", Nation = "Japan"},
                    new CityData {City = "Nagano", Nation = "Japan"},
                    new CityData {City = "Osaka", Nation = "Japan"},
                    new CityData {City = "Vancouver", Nation = "Canada"},
                    new CityData {City = "Calgary", Nation = "Canada"},
                    new CityData {City = "Montreal", Nation = "Canada"},
                    new CityData {City = "Toronto", Nation = "Canada"},
                    new CityData {City = "Mexicy City", Nation = "Mexico"},
                    new CityData {City = "Rio de Janeiro", Nation = "Brazil"},
                    new CityData {City = "La Pz", Nation = "Bolivia"},
                    new CityData {City = "Lima", Nation = "Peru"},
                    new CityData {City = "Quito", Nation = "Ecuador"},
                    new CityData {City = "Bogota", Nation = "Columbia"},
                    new CityData {City = "Buenos Aires", Nation = "Argentina"},
                    new CityData {City = "Havana", Nation = "Cuba"},
                    new CityData {City = "Port au-Prince", Nation = "Haiti"},
                    new CityData {City = "Managua", Nation = "Nicaragua"},
                    new CityData {City = "Antigua", Nation = "Guatemala"},
                    new CityData {City = "San Jose", Nation = "Costa Rica"},
                    new CityData {City = "Reykjavik", Nation = "Iceland"},
                    new CityData {City = "Oslo", Nation = "Norway"},
                    new CityData {City = "Stockholm", Nation = "Sweden"},
                    new CityData {City = "Helsinki", Nation = "Finland"},
                    new CityData {City = "Tirana", Nation = "Albania"},
                    new CityData {City = "El-Biar", Nation = "Algeria"},
                    new CityData {City = "Budapest", Nation = "Hungary"},
                    new CityData {City = "Salzburg", Nation = "Austria"},
                    new CityData {City = "Sidney", Nation = "Australia"},
                    new CityData {City = "Perth", Nation = "Australia"},
                    new CityData {City = "Newcastle", Nation = "Australia"},
                    new CityData {City = "Timbu", Nation = "Bhutan"},
                    new CityData {City = "Fada", Nation = "Chad"},
                    new CityData {City = "Bangui", Nation = "Central African Republic"},
                    new CityData {City = "Ikelemba", Nation = "Congo"},
                    new CityData {City = "Auckland", Nation = "New Zealand"},
                    new CityData {City = "Christchurch", Nation = "New Zealand"},
                    new CityData {City = "Durban", Nation = "South Africa"},
                    new CityData {City = "Cape Town", Nation = "South Africa"},
                    new CityData {City = "Cairo", Nation = "Egypt"},
                    new CityData {City = "Amman", Nation = "Jordan"},
                    new CityData {City = "Kingston", Nation = "Jamaica"}
                };
        }
        #endregion
        #endregion
    }
    #region CityData class
    public class CityData
    {
        public string City { get; set; }
        public string Nation { get; set; }
    }
    #endregion
    #region SportsData class
    public class SportsData
    {
        [System.ComponentModel.Category("Location")]
        public string Nation { get; set; }
        [System.ComponentModel.Category("Location")]
        public string City { get; set; }
        [System.ComponentModel.Category("Sport")]
        public string Sport { get; set; }
        [System.ComponentModel.Category("Metrics")]
        public double Budget { get; set; }
        [System.ComponentModel.Category("Metrics")]
        public int Players { get; set; }
        [System.ComponentModel.Category("Calendar")]
        public System.DateTime Date { get; set; }
    }
    #endregion
}