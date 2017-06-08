using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayIM.NetClient.Pages.Model
{
   public class LayimChatMessage
    {
        public long uid { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string content { get; set; }
        public string addtime { get; set; }

        public bool self { get; set; }
    }
}
