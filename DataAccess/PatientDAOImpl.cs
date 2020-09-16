using TodoApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace TodoApi.DataAccess
{
    public class PatientDAOImpl: IPatientDAO
    {
        private readonly PostgreSqlContext _context;

        public PatientDAOImpl(PostgreSqlContext context) 
        {
            _context = context;
        }

        public void AddPatientRecord(Patient patient)
        {
            _context.patients.Add(patient);
            _context.SaveChanges();
        }

        public void DeletePatientRecord(string id)
        {
            var entity = _context.patients.FirstOrDefault(x => x.id == id);
            _context.patients.Remove(entity);
            _context.SaveChanges();
        }

        public List<Patient> GetPatientRecords()
        {
            return _context.patients.ToList();
        }

        public Patient GetPatientSingleRecord(string id)
        {
            return _context.patients.FirstOrDefault(x => x.id == id);
        }

        public void UpdatePatientRecord(Patient patient)
        {
            _context.patients.Update(patient);
            _context.SaveChanges();
        }
    }
}