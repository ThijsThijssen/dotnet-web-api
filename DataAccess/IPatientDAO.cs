using TodoApi.Models;
using System.Collections.Generic;

namespace TodoApi.DataAccess
{
    public interface IPatientDAO
    {
        void AddPatientRecord(Patient patient);
        void UpdatePatientRecord(Patient patient);
        void DeletePatientRecord(string id);
        Patient GetPatientSingleRecord(string id);
        List<Patient> GetPatientRecords();
    }
}