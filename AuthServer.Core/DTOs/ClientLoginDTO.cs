using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.DTOs
{
    public class ClientLoginDTO
    {
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
    }
}
