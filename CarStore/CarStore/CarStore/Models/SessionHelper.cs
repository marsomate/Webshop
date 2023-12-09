using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace CarStore.Models
{
    // This class provides helper methods for working with session data using JSON serialization.
    public static class SessionHelper
    {
        // Extension method to set an object as JSON in the session.
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // Serialize the object to JSON and store it in the session.
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // Generic extension method to retrieve an object from JSON in the session.
        public static T? GetObjectFromJson<T>(this ISession session, string key)
        {
            // Retrieve the JSON string from the session.
            var value = session.GetString(key);

            // Deserialize the JSON string to the specified object type (T).
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
