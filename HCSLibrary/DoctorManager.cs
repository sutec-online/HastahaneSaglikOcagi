using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSLibrary
{
    public static class DoctorManager
    {
        // Tüm Doktorlar...
        public static IEnumerable<Doctor> All()
        {
            return Database.client.Cypher
                .Match("(doctor:Doctor)")
                .Return(doctor => doctor.As<Doctor>())
                .Results;
        }

        // Verilen isimde doktor olup olmadığını kontrol edilir...
        public static bool Check(string name)
        {
            return Database.client.Cypher
                            .Match("(doctor:Doctor)")
                            .Where((Doctor doctor) => doctor.name == name)
                            .Return(doctor => doctor.As<Doctor>())
                            .Results.Count() > 0;
        }

        // Veritabanından 1 doktoru getir
        public static Doctor Get(string name)
        {
            return Database.client.Cypher
                            .Match("(doctor:Doctor)")
                            .Where((Doctor doctor) => doctor.name == name)
                            .Return(doctor => doctor.As<Doctor>())
                            .Results.Single();
        }

        // Verilen doktoru veritabanından siler.
        public static void Delete(Doctor doct)
        {
            Database.client.Cypher
                .OptionalMatch("(doctor:Doctor)<-[r]-()")
                .Where((Doctor doctor) => doctor.name == doct.name)
                .Delete("r, doctor")
                .ExecuteWithoutResults();
        }

        // Veritabanında Yeni bir doktor oluşturur.
        public static void Create(string name, bool status = true)
        {
            var newDoctor = new Doctor { name = name, status = status };
            Database.client.Cypher
                .Merge("(doctor: Doctor{ name: {name} })")
                .OnCreate()
                .Set("doctor = {newDoctor}")
                .WithParams(new
                {
                    name = newDoctor.name,
                    newDoctor
                })
                .ExecuteWithoutResults();
        }
    }
}
