using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSLibrary
{
    public static class UserManager
    {
        // Tüm Kullanıcılar...
        public static IEnumerable<User> All()
        {
            return Database.client.Cypher
                .Match("(user:User)")
                .Return(user => user.As<User>())
                .Results;
        }

        // Verilen isimde kullanıcı olup olmadığını kontrol edilir...
        public static bool Check(string username)
        {
            return Database.client.Cypher
                            .Match("(user:User)")
                            .Where((User user) => user.username == username)
                            .Return(user => user.As<User>())
                            .Results.Count() > 0;
        }

        // Veritabanından 1 kullanıcı getir
        public static User Get(string username)
        {
            return Database.client.Cypher
                            .Match("(user:User)")
                            .Where((User user) => user.username == username)
                            .Return(user => user.As<User>())
                            .Results.Single();
        }

        // Verilen kullanıcıyı veritabanından siler.
        public static void Delete(User delUser)
        {
            Database.client.Cypher
                .Match("(user:User)")
                .Where((User user) => user.username == delUser.username)
                .Delete("user")
                .ExecuteWithoutResults();
        }

        // Veritabanında Yeni bir kullanıcı oluşturur.
        public static void Create(string username, string password = "", string firstname = "", string lastname = "", string phone = "", bool admin = false)
        {
            var newUser = new User { username = username, password = password, firstname = firstname, lastname = lastname, phone = phone, admin = admin };
            Database.client.Cypher
                .Merge("(user: User{ username: {username} })")
                .OnCreate()
                .Set("user = {newUser}")
                .WithParams(new
                {
                    username = newUser.username,
                    newUser
                })
                .ExecuteWithoutResults();
        }
    }
}
