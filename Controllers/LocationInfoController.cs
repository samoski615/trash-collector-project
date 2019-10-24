using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using TrashCollector.Models.LocationInfo;

namespace TrashCollector.Controllers
{
    public class LocationInfoController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private readonly Keys keys = new Keys();

        // GET: LocationInfo
        public ActionResult Index()
        {
            return View();
        }

       public string ConvertAddressToGoogleFormat(Address address)
        {
            string googleFormattedAddress = address.StreetAddress + "," + address.City + "," + address.StateAbbreviation + "," + address.ZipCode + "," + address.Country;
            return googleFormattedAddress;
        }

        public GeoCode GeoLocate(string address)
        {
            var apiKey = Keys.GoogleApiKey;
            var requestedUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={address}&key={apiKey}";
            var result = new WebClient().DownloadString(requestedUrl);
            GeoCode geoCode = JsonConvert.DeserializeObject<GeoCode>(result);
            return geoCode;
        }
    }
}
