using DevBlog.Web.DTO;
using Newtonsoft.Json;

namespace DevBlog.Web.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static void SetAccount(this ISession session, AccountDTO value)
        {
            SetObject(session, "Account", value);
        }

        public static AccountDTO? GetAccount(this ISession session)
        {
            return GetObject<AccountDTO>(session, "Account");
        }

    }
}
