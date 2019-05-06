using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.RestApi;

namespace Web.RestApi.Controllers.ApiController
{
    [Produces("application/json")]
    [Route("api/Companies")]
    public class CompaniesController : Controller
    {
        private readonly ICompanyRepository _companyRepository;

        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpPost]
        [Route("GetCompanies")]
        public IEnumerable<Company> GetCompanies()
        {
            return _companyRepository.Get();
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = _companyRepository.GetById(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/Companies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany([FromRoute] long id, [FromBody] Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.ID)
            {
                return BadRequest();
            }

            _companyRepository.Update(company);

            try
            {
                _companyRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;

            }

            return NoContent();
        }

        // POST: api/Companies
        [HttpPost]
        public async Task<IActionResult> PostCompany([FromBody] Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _companyRepository.Add(company);
            _companyRepository.Save();

            return CreatedAtAction("GetCompany", new { id = company.ID }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = _companyRepository.GetById(id);
            if (company == null)
            {
                return NotFound();
            }

            _companyRepository.Remove(id);
            _companyRepository.Save();

            return Ok(company);
        }

    }
}