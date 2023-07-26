﻿namespace UniversityWebApiBackend.Models.DataModels
{
    public class JwtSettings
    {
        public bool ValidateIssuerSigningKey { get; set; }
        public string IssuerSigningKey { get; set; } = String.Empty;
        public bool ValidateIssuer { get; set; } = true;
        public string? ValidIssuer { get; set; }

        public bool ValidateAudience { get; set; } = true;
        public string? ValidAudience { get; set; }

        public bool RequireExpirationTime { get; set; }
        public bool ValidateLifetime { get; set; } = true;

    }
}
