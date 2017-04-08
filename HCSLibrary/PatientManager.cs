using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSLibrary
{
    public static class PatientManager
    {
        // Tüm Hastalar...
        public static IEnumerable<Patient> All()
        {
            return Database.client.Cypher
                .Match("(patient:Patient)")
                .Return(patient => patient.As<Patient>())
                .Results;
        }

        // Tüm hastalardan sevk tarihi 'start' ve 'end' arası olanlar...
        public static IEnumerable<Patient> Filter(DateTime start, DateTime end)
        {
            return Database.client.Cypher
                .Match("(patient:Patient)")
                .Where((Patient patient) => patient.shipment >= start && patient.shipment <= end)
                .Return(patient => patient.As<Patient>())
                .Results;
        }

        // Taburcu olan/Taburcu Olmayan (discharged) ve sevk tarihi 'start' ve 'end' arası olanlar...
        public static IEnumerable<Patient> Filter(DateTime start, DateTime end, bool discharged)
        {
            return Database.client.Cypher
                .Match("(patient:Patient)")
                .Where((Patient patient) => patient.shipment >= start && patient.shipment <= end && patient.is_discharged == discharged)
                .Return(patient => patient.As<Patient>())
                .Results;
        }

        // Veritabanında Yeni bir hasta oluşturur.
        public static void Create(long id, string name, string surname, string identity, DateTime shipment, bool is_discharged)
        {
            var newPatient = new Patient { id = id, name = name, surname = surname, identity = identity, shipment = shipment, is_discharged = is_discharged };
            Database.client.Cypher
                .Merge("(patient: Patient{ id: {id} })")
                .OnCreate()
                .Set("patient = {newPatient}")
                .WithParams(new
                {
                    id = newPatient.id,
                    newPatient
                })
                .ExecuteWithoutResults();
        }

        // Veritabanındaki son ID yi döndürür.
        public static long LastId()
        {
            var query = Database.client.Cypher
                .Match("(patient:Patient)")
                .Return(patient => patient.As<Patient>())
                .OrderByDescending("patient.id")
                .Limit(1)
                .Results;
            if(query.Count() > 0)
            {
                return query.Single().id;
            } else
            {
                return 1;
            }
        }

        // Verilen hastayı veritabanından siler.
        public static void Delete(Patient pat)
        {
            Database.client.Cypher
                .OptionalMatch("(patient:Patient)<-[r]-()")
                .Where((Patient patient) => patient.id == pat.id)
                .Delete("r")
                .ExecuteWithoutResults();

            Database.client.Cypher
                .Match("(patient:Patient)")
                .Where((Patient patient) => patient.id == pat.id)
                .Delete("patient")
                .ExecuteWithoutResults();
        }

        // Veritabanından belirtilen ID deki hastayı çeker.
        public static Patient GetById(long id)
        {
            return Database.client.Cypher
                            .Match("(patient:Patient)")
                            .Where((Patient patient) => patient.id == id)
                            .Return(patient => patient.As<Patient>())
                            .Results.Single();
        }

        public static void AddAction(Patient otherPatient, Polyclinic otherPolyclinic, Doctor otherDoctor, decimal order, string action, decimal quantity, string price)
        {
            var newAction = new Action { order = order, action = action, quantity = quantity, price = price, dateTime = DateTime.Now };
            Database.client.Cypher
                .Match("(patient:Patient)", "(polyclinic: Polyclinic)", "(doctor: Doctor)")
                .Where((Patient patient) => patient.id == otherPatient.id)
                .AndWhere((Polyclinic polyclinic) => polyclinic.name == otherPolyclinic.name)
                .AndWhere((Doctor doctor) => doctor.name == otherDoctor.name)
                .Create("(action:Action {newAction})-[:BELONGS_TO]->(patient), (action)-[:BELONGS_TO]->(polyclinic), (action)-[:BELONGS_TO]->(doctor)")
                .WithParam("newAction", newAction)
                .ExecuteWithoutResults();

        }

        public static IEnumerable<Action> Actions(Patient fromPatient)
        {
            return Database.client.Cypher
                .OptionalMatch("(action:Action)-[BELONGS_TO]-(patient:Patient)")
                .Where((Patient patient) => patient.id == fromPatient.id)
                .Return(action => action.As<Action>())
                .Results;
        }
    }
}
