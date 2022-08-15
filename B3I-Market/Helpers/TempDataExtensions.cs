using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace B3I_Market.Helpers
{
    public static class TempDataExtensions
    {
        public static void AddOrUpdate(this ITempDataDictionary tempData,string key, string value)
        {
            if (tempData.Keys.Contains(key))
            {
                tempData.Remove(key);
            }
            tempData.Add(key, value);
        }
        public static void SetOrUpdate<T>(this ITempDataDictionary tempData, string key, T value)
        {
            if (tempData.Keys.Contains(key))
            {
                tempData.Remove(key);
            }
            var a = JsonSerializer.Serialize<T>(value);
            tempData.Add(key, a);
        }
        public static T Get<T>(this ITempDataDictionary tempData, string key)
        {
            var value = (string)tempData[key];
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }

    }
}