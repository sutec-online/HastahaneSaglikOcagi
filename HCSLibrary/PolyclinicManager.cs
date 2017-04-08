using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSLibrary
{
    public static class PolyclinicManager
    {
        // Tüm Poliklinikler...
        public static IEnumerable<Polyclinic> All()
        {
            return Database.client.Cypher
                .Match("(polyclinic:Polyclinic)")
                .Return(polyclinic => polyclinic.As<Polyclinic>())
                .Results;
        }

        // Verilen isimde poliklinik olup olmadığını kontrol edilir...
        public static bool Check(string name)
        {
            return Database.client.Cypher
                            .Match("(polyclinic:Polyclinic)")
                            .Where((Polyclinic polyclinic) => polyclinic.name == name)
                            .Return(polyclinic => polyclinic.As<Polyclinic>())
                            .Results.Count() > 0;
        }

        // Veritabanından 1 polikliniği getir
        public static Polyclinic Get(string name)
        {
            return Database.client.Cypher
                            .Match("(polyclinic:Polyclinic)")
                            .Where((Polyclinic polyclinic) => polyclinic.name == name)
                            .Return(polyclinic => polyclinic.As<Polyclinic>())
                            .Results.Single();
        }

        // Verilen polikliniği veritabanından siler.
        public static void Delete(Polyclinic poly)
        {
            Database.client.Cypher
                .OptionalMatch("(polyclinic:Polyclinic)<-[r]-()")
                .Where((Polyclinic polyclinic) => polyclinic.name == poly.name)
                .Delete("r")
                .ExecuteWithoutResults();

            Database.client.Cypher
                .Match("(polyclinic:Polyclinic)")
                .Where((Polyclinic polyclinic) => polyclinic.name == poly.name)
                .Delete("polyclinic")
                .ExecuteWithoutResults();
    }

    // Veritabanında Yeni bir poliklinik oluşturur.
    public static void Create(string name, string description = "", bool status = true)
        {
            var newPolyclinic = new Polyclinic { name = name, description = description, status = status };
            Database.client.Cypher
                .Merge("(polyclinic: Polyclinic{ name: {name} })")
                .OnCreate()
                .Set("polyclinic = {newPolyclinic}")
                .WithParams(new
                {
                    name = newPolyclinic.name,
                    newPolyclinic
                })
                .ExecuteWithoutResults();
        }
    }
}
