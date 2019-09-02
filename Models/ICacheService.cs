using System;
using System.Threading.Tasks;

namespace simple_redis_api.Models
{
    /// <summary>
    /// Kullanılacak cache servisi bu interface'i implemente eder ve bunun üzerinden çağırımlar yapılır.
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        /// Sonsuz süreyle cache'e atar.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Set(string key, string value);

        /// <summary>
        /// Sonsuz süreyle cache'e atar.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="TValue"></typeparam>
        void Set<TValue>(string key, TValue value) where TValue : class;

        /// <summary>
        /// Sonsuz süreyle cache'e atar.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        Task SetAsync(string key, object value);

        /// <summary>
        /// Verilen süreye kadar cache'e atar.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiration"></param>
        void Set(string key, object value, TimeSpan expiration);

        /// <summary>
        /// Verilen süreye kadar cache'e atar.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiration"></param>
        Task SetAsync(string key, object value, TimeSpan expiration);

        /// <summary>
        /// Eğer bu key'e ait bir obje varsa getirir.
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        TValue Get<TValue>(string key) where TValue : class;

        /// <summary>
        /// Eğer bu key'e ait bir string varsa getirir.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string Get(string key);

        /// <summary>
        /// Eğer bu key'e ait bir obje varsa getirir.
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        Task<TValue> GetAsync<TValue>(string key) where TValue : class;

        /// <summary>
        /// Cache'ten bu key'i siler.
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);
    }
}
