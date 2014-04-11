using System.Configuration;

namespace Shsict.DataAccess
{
    public class ConnectStringOracle
    {
        public static string GetViewConnection()
        {
            return ConfigurationManager.ConnectionStrings["Shsict.Oracle.View.ConnectionString"].ConnectionString;
        }
        public static string GetTableConnection()
        {
            return ConfigurationManager.ConnectionStrings["Shsict.Oracle.Table.ConnectionString"].ConnectionString;
        }
    }
}
