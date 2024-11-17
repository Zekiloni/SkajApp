namespace Server.Infrastructure.Utilities
{
    public class GuidUtils
    {
        public static Guid Parse(string value)
        {
            if (value == null)
                return Guid.Empty;

            return Guid.Parse(value);
        }
    }
}
