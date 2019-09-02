using Newtonsoft.Json;

namespace simple_redis_api.Extension
{
    public static class StringExtension
    {
        public static TValue ToObject<TValue>(this string value) where TValue : class
        {
            return string.IsNullOrEmpty(value) ? null : JsonConvert.DeserializeObject<TValue>(value);
        }
    }

}