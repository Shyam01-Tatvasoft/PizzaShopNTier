using PizzaShop.DataAccess.Data;
using PizzaShop.DataAccess.Interfaces;

namespace PizzaShop.DataAccess.Implementation;

public class CityRepository: ICityRepository
{
    private readonly PizzashopContext _context;

    public CityRepository(PizzashopContext context)
    {
        _context = context;
    }
    
    public List<City> GetAllCities()
    {
        var allCities = _context.Cities.ToList();
        Console.WriteLine("state By country" + allCities.Count());
        return allCities;
    }

    public List<City> GetCitiesByStateId(int id)
    {
        Console.WriteLine("state id"+id);
        var cities = _context.Cities.Where(c => c.Stateid == id).ToList();
        Console.WriteLine("state By country" + cities.Count());
        return cities;
    }
}
