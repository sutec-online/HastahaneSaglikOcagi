using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;

namespace HCSLibrary
{
    public static class Database
    {
        public static GraphClient client;

        public static bool Connect(string uri, string username, string password)
        {
            client = new GraphClient(new Uri(uri), username, password);

            try
            {
                client.Connect();
                return true;
            } catch (Exception e)
            {
                return false;
            }
        }
    }
}
