﻿namespace Todo.Application.Common.AuthSettings
{
    public class JwtSettings
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string DurationInMinutes { get; set; } = string.Empty;
    }
}
