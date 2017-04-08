using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;

namespace HCSLibrary
{
    public static class Auth
    {

        public static User User;
        public static bool logged = false;

        public static bool Attempt(string username, string password)
        {
            var query = Database.client
                .Cypher
                .Match("(user: User)")
                .Where((User user) => user.username == username && user.password == password)
                .Return(user => user.As<User>())
                .Results;

            if(query.Count() > 0)
            {
                logged = true;
                User = query.Single();
            } else
            {
                logged = false;
            }
            return logged;
        }

        public static bool Check()
        {
            return logged;
        }

    }
}
