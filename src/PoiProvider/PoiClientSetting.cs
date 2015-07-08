using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices
{
    public class PoiClientSetting
    {
        private string _url;

        public string Url
        {
            get { return _url; }
            set
            {
                _url = new UriBuilder(value).Uri.ToString();
            }
        }

        public NetworkCredential Credential { get; set; }
        public bool ThrowForServerErrors { get; set; }

        public PoiClientSetting()
        {
            ThrowForServerErrors = true;
        }

        private IWebProxy _proxy;

        public IWebProxy Proxy
        {
            get { return _proxy; }
            set
            {
                if (IsHttpClientInitialied)
                    throw new InvalidOperationException("Proxy should be set before first request to server");

                _proxy = value;
            }
        }

        internal volatile bool IsHttpClientInitialied;
    }
}
