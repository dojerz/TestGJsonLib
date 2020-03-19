using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BAMCIS.GeoJSON;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TestGJsonLib.Models;
using TestGJsonLib.Data;

namespace TestGJsonLib.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string jsonString1 = System.IO.File.ReadAllText(@"c:\projects\FIX\18JAN\cegledHelykozi.geojson");
            //string jsonString2 = System.IO.File.ReadAllText(@"c:\projects\_GISAPP\MapSource\2g_indoor.json");
            string jsonString3 = System.IO.File.ReadAllText(@"C:\projects\_GISAPP\MapSource\TESTGEOJSON\multiline_vasut.geojson");

            //
            //GeoJson gdata = JsonConvert.DeserializeObject<GeoJson>(jsonString1);
            //GeoJson gdatapoly = JsonConvert.DeserializeObject<GeoJson>(jsonString2);


            FeatureCollection Col1 = FeatureCollection.FromJson(jsonString1);
            //FeatureCollection Col2 = FeatureCollection.FromJson(jsonString2);
            FeatureCollection Col3 = FeatureCollection.FromJson(jsonString3);

            var egyik = Col1.Features.ToList();
            //var masik = Col2.Features.ToList();
            var harmadik = Col3.Features.ToList();

            //var sum = egyik.Concat(masik);

            MyGeojson myGeojson = new MyGeojson(GeoJsonType.FeatureCollection, false, null, "tesztguid");
            myGeojson.features = harmadik;
            
            //GeoJson gj = new GeoJson();

            object Json = JsonConvert.SerializeObject(myGeojson);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
