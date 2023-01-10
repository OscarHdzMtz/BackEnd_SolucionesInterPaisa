using BackEnd_SolucionesInterPaisa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tik4net;
using tik4net.Objects;
using tik4net.Objects.Ip.Hotspot;

namespace BackEnd_SolucionesInterPaisa.ApiMikrotik
{
    [TikEntity("ip/hotspot", IsReadOnly = true)]
    public class HotspotServer
    {                
            [TikProperty(".id", IsReadOnly = true, IsMandatory = true)]
            public string Id { get; set; }

            [TikProperty("name", IsReadOnly = true, IsMandatory = true)]
            public string Name { get; set; }

            [TikProperty("interface", IsReadOnly = true, IsMandatory = true)]
            public string Interface { get; private set; }

            [TikProperty("profile", IsReadOnly = true, IsMandatory = true)]
            public string Profile { get; private set; }
            [TikProperty("address-pool", IsReadOnly = true, IsMandatory = false)]
            public string AddressPool { get; private set; }
            [TikProperty("addresses-per-mac", IsReadOnly = true, IsMandatory = true)]
            public string AddressesPerMac { get; private set; }
            [TikProperty("https", IsReadOnly = true, IsMandatory = true)]
            public string HTTPS { get; private set; }
            [TikProperty("login-timeout", IsReadOnly = true, IsMandatory = true)]
            public string LoginTimeout { get; private set; }
            [TikProperty("ip-of-dns-name", IsReadOnly = true, IsMandatory = false)]
            public string IpOfDnsName { get; private set; }
            [TikProperty("idle-timeout", IsReadOnly = true, IsMandatory = true)]
            public string IdleTimeout { get; private set; }
            [TikProperty("keepalive-timeout", IsReadOnly = true, IsMandatory = true)]
            public string KeepaliveTimeout { get; private set; }
            [TikProperty("proxy-status", IsReadOnly = true, IsMandatory = false)]
            public string ProxyStatus { get; private set; }           
    }
}
