using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAMCIS.GeoJSON;

namespace TestGJsonLib.Data
{
    public class MyGeojson : GeoJson
    {
        public string guid;
        public List<Feature> features = new List<Feature>();
        public MyGeojson(GeoJsonType type, bool is3D, IEnumerable<double> boundingBox, string guid) : base(type, is3D, boundingBox = null)
        {
            this.guid = guid;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            //return features.GetHashCode();
            return guid.GetHashCode();
        }
    }
}
