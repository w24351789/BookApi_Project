﻿using BookApi_Project.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookApi_Project.Services
{
    public class CountryRepository : ICountryRepository
    {
        private BookDbContext _countryContext;
        public CountryRepository(BookDbContext countryContext)
        {
            _countryContext = countryContext;
        }

        public bool CountryExists(int countryId)
        {
            return _countryContext.Countries.Any(c => c.Id == countryId);
        }

        public ICollection<Author> GetAuthorsFromACountry(int countryId)
        {
            return _countryContext.Authors.Where(c => c.Country.Id == countryId).ToList();
        }

        public ICollection<Country> GetCountries()
        {
            return _countryContext.Countries.OrderBy(c => c.Name).ToList();
        }

        public Country GetCountry(int countryId)
        {
            return _countryContext.Countries.Where(c => c.Id == countryId).FirstOrDefault();
        }

        public Country GetCountryOfAnAuthor(int authorId)
        {
            return _countryContext.Authors.Where(a => a.Id == authorId).Select(c => c.Country).FirstOrDefault();
        }
    }
}
