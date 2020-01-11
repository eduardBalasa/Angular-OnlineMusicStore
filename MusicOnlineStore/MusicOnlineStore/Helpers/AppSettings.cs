using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicOnlineStore.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }

        [JsonProperty("connectionString")]
        public string ConnectionString { get; set; }
    }
}
