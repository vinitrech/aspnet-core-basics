using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.Data;
using HotelListing.Core.Models.Country;
using AutoMapper;
using HotelListing.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using HotelListing.Data.Configurations;
using HotelListing.Core.Exceptions;
using HotelListing.Core.Models;
using Microsoft.AspNetCore.OData.Query;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesController(IMapper mapper, ICountriesRepository countriesRepository) // the db context is killed automatically in the background   
        {
            this._mapper = mapper;
            this._countriesRepository = countriesRepository;
        }

        // GET: api/Countries/GetAll
        [HttpGet("GetAll")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<GetCountryDTO>>> GetCountries()
        {
            var countries = await _countriesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountryDTO>>(countries);

            return Ok(records);
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<PagedResult<GetCountryDTO>>> GetPagedCountries([FromQuery] QueryParameters queryParameters)
        {

            var pagedCountries = await _countriesRepository.GetAllAsync<GetCountryDTO>(queryParameters);

            return Ok(pagedCountries);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDTO>> GetCountry(int id)
        {

            // var country = await _context.Countries.Include(country => country.Hotels).FirstOrDefaultAsync(country => country.Id == id);
            var country = await _countriesRepository.GetDetails(id);

            if (country == null)
            {
                throw new NotFoundException(nameof(GetCountry), id);
            }

            var countryDTO = _mapper.Map<CountryDTO>(country);

            return Ok(countryDTO);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDTO updateCountryDTO)
        {
            if (id != updateCountryDTO.Id)
            {
                return BadRequest();
            }

            // _context.Entry(country).State = EntityState.Modified;

            // var country = await _context.Countries.FindAsync(id);
            var country = await _countriesRepository.GetAsync(id);


            if (country == null)
            {
                throw new NotFoundException(nameof(PutCountry), id);
            }

            _mapper.Map(updateCountryDTO, country); // set country data based on the updateCountryDTO

            try
            {
                // await _context.SaveChangesAsync(); <- automatically identifies that changes were made, then update
                await _countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await CountryExists(id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDTO createCountryDTO)
        {

            // var country = new Country
            // {
            //     Name = createCountryDTO.Name,
            //     ShortName = createCountryDTO.ShortName
            // };

            var country = _mapper.Map<Country>(createCountryDTO); // map dto to country

            await _countriesRepository.AddASync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize(Roles = ApiRoles.Admin)]
        public async Task<IActionResult> DeleteCountry(int id)
        {

            var country = await _countriesRepository.GetAsync(id);
            if (country == null)
            {
                throw new NotFoundException(nameof(DeleteCountry), id);
            }

            await _countriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}
