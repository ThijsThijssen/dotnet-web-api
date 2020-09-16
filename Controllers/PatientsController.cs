using Microsoft.AspNetCore.Mvc;  
using TodoApi.DataAccess;  
using TodoApi.Models;  
using System;  
using System.Collections.Generic;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientDAO _dataAccessProvider;

        public PatientsController(IPatientDAO dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            Console.WriteLine("test line");
            return _dataAccessProvider.GetPatientRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody]Patient patient)
        {
            Console.WriteLine(patient.ToString());
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                patient.id = obj.ToString();
                _dataAccessProvider.AddPatientRecord(patient);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]  
        public Patient Details(string id)  
        {  
            return _dataAccessProvider.GetPatientSingleRecord(id);  
        }  
  
        [HttpPut]  
        public IActionResult Edit([FromBody]Patient patient)  
        {  
            if (ModelState.IsValid)  
            {  
                _dataAccessProvider.UpdatePatientRecord(patient);  
                return Ok();  
            }  
            return BadRequest();  
        }  
  
        [HttpDelete("{id}")]  
        public IActionResult DeleteConfirmed(string id)  
        {  
            var data = _dataAccessProvider.GetPatientSingleRecord(id);  
            if (data == null)  
            {  
                return NotFound();  
            }  
            _dataAccessProvider.DeletePatientRecord(id);  
            return Ok();  
        }
    }
}