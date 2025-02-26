using PizzaShop.DataAccess.Data;
using PizzaShop.DataAccess.Interfaces;

namespace PizzaShop.DataAccess.Implementation;

public class CountryRepository: ICountryRepository
{
    private readonly PizzashopContext _context;

    public CountryRepository(PizzashopContext context)
    {
        _context = context;
    }
    public List<Country> GetAllCountry(){
        var allCountries = _context.Countries.ToList();
        return allCountries;
    }
}
