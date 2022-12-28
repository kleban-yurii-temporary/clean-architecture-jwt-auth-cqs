using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Infrastracture.Authentication
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";
        public string? Secret { get; set; }
        public int TokenExpiryMinutes { get; set; }
        public int RefreshTokenExpiryMinutes { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
    }
}
