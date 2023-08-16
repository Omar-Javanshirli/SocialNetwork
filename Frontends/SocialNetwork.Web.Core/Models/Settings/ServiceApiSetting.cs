using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Core.Models.Settings
{
    public class ServiceApiSetting
    {
        public string IdentityBaseUri { get; set; }
        public string GetewayBaseUri { get; set; }
        public ServiceApi Discover { get; set; }
        public ServiceApi Feed { get; set; }
        public ServiceApi Graph { get; set; }
        public ServiceApi Live { get; set; }
        public ServiceApi Media { get; set; }
        public ServiceApi Message { get; set; }
        public ServiceApi Notification { get; set; }
        public ServiceApi Post { get; set; }
        public ServiceApi Search { get; set; }
        public ServiceApi Profil { get; set; }
        public ServiceApi Story { get; set; }

        public class ServiceApi
        {
            public string Path { get; set; }
        }
    }
}
