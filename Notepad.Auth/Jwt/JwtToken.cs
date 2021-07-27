using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using Notepad.Utilities.Config;
using Notepad.Utilities.Exceptions.Api;
using Notepad.Utilities.Messages;

namespace Notepad.Auth.Jwt
{
    public class JwtToken
    {
        private const string SecretKey = AuthConfig.JwtSecret;

        private readonly IJwtAlgorithm              _algorithm  = new HMACSHA256Algorithm();
        private readonly IJsonSerializer            _serializer = new JsonNetSerializer();
        private readonly IBase64UrlEncoder          _urlEncoder = new JwtBase64UrlEncoder();
        private          Dictionary<string, string> Payload { get; set; } = new Dictionary<string, string>();


        public string Create(Dictionary<string, string> payload = null, int expHour = 250)
        {
            CreateMainPayloads(expHour);

            if ( payload != null )
            {
                AppendPayload(payload);
            }
            
            IJwtEncoder encoder = new JwtEncoder(_algorithm, _serializer, _urlEncoder);
            return encoder.Encode(Payload, SecretKey);
        }

        public Dictionary<string, string> Decode(string token)
        {
            try
            {
                var           provider  = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(_serializer, provider);
                IJwtDecoder   decoder   = new JwtDecoder(_serializer, validator, _urlEncoder, _algorithm);
                var           payload      = decoder.DecodeToObject<IDictionary<string, string>>(token, SecretKey, verify: true);
                return (Dictionary<string, string>) payload;
            }
            catch ( TokenExpiredException )
            {
                throw new ApiAuthException("Lütfen Kullanıcı Girişi Yapınız.");
            }
            catch ( SignatureVerificationException )
            {
                throw new ApiAuthException("Lütfen Kullanıcı Girişi Yapınız.");
            }
            catch ( Exception )
            {
                throw new ApiAuthException("Lütfen Kullanıcı Girişi Yapınız.");
            }
        }

        public Dictionary<string, string> DecodeToObject(string token)
        {
            try
            {
                var           provider  = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(_serializer, provider);
                IJwtDecoder   decoder   = new JwtDecoder(_serializer, validator, _urlEncoder, _algorithm);
                var           payload      = decoder.DecodeToObject<IDictionary<string, string>>(token, SecretKey, verify: true);
                return (Dictionary<string, string>) payload;
            }
            catch ( TokenExpiredException )
            {
                throw new ApiAuthException(ResultMessages.NoLoginError);
            }
            catch ( SignatureVerificationException )
            {
                throw new ApiAuthException(ResultMessages.NoLoginError);
            }
            catch ( Exception )
            {
                throw new ApiAuthException(ResultMessages.NoLoginError);
            }
        }

        private void AppendPayload(Dictionary<string, string> payload)
        {
            payload.ToList().ForEach(x => { CreatePayload(x.Key, x.Value); });
        }

        public void CreatePayload(string key, string value)
        {
            if ( !Payload.ContainsKey(key) )
            {
                Payload.Add(key, value);
            }
            else
            {
                Payload[key] = value;
            }
        }

        private void CreateMainPayloads(int expHour)
        {
            var tokenExp = DateTimeOffset.UtcNow
                .AddHours(expHour)
                .ToUnixTimeSeconds()
                .ToString();

            var nowDate      = DateTime.Now
                .ToString(CultureInfo.CurrentCulture);
            
            CreatePayload("exp", tokenExp);
            CreatePayload("iss", nowDate);
            CreatePayload("aud", AppConfig.AppName);
            CreatePayload("sub", AuthConfig.JwtSubject);
        }
    }
}