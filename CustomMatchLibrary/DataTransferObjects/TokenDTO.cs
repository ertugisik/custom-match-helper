using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMatchLibrary.DataTransferObjects
{
    public class TokenDTO
    {
        [DomainPropertyName("token_type")]
        public string TokenType { get; set; }
        [DomainPropertyName("access_token")]
        public string AccessToken { get; set; }
    }
}
