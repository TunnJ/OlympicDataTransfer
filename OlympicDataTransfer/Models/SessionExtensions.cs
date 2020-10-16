using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace OlympicDataTransfer.Models
{
    public static class SessionExtensions
    {
       
            public static void SetObject<C>(this ISession session, string key, C value)
            {
                session.SetString(key, JsonConvert.SerializeObject(value));
            }

            public static C GetObject<C>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return (value == null) ? default(C) : JsonConvert.DeserializeObject<C>(value);
        }
    }
}
