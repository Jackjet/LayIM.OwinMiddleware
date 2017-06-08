using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayIM.NetClient
{
    public class LayimOptions
    {
        public LayimOptions()
        {
            Serializer = new DefaultSerializer();
        }

        public string AppPath { get; set; }

        public RongCloudSetting RongCloudSetting { get; set; }

        public IJsonSerializer Serializer { get; set; }
    }

    
}
