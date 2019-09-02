using Newtonsoft.Json;

namespace simple_redis_api.Extension
{
    public static class ObjectExteion
    {
        public static string ToJson(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}