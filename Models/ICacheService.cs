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
        /// <typeparam name="T"></typeparam>
        void Set<T>(string key, T value) where T : class;

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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Get<T>(string key) where T : class;

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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<T> GetAsync<T>(string key) where T : class;

        /// <summary>
        /// Cache'ten bu key'i siler.
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);
    }
}
