using PizzaShop.DataAccess.Data;
using PizzaShop.DataAccess.Interfaces;
using PizzaShop.Service.Interfaces;

namespace PizzaShop.Service.Implementation;

public class AddressService : IAddressService
{
    private readonly ICountryRepository _country;
    private readonly IStateRepository _state;
    private readonly ICityRepository _city;

    public AddressService(ICountryRepository country, IStateRepository state, ICityRepository city)
    {
        _country = country;
        _city = city;
        _state = state;
    }

    public List<State> GetAllStates(int id)
    {
        List<State> states;
        if (id == -1)
        { states = _state.GetAllStates(); }
        else
        { states = _state.GetStatesByCountryId(id); }
        return states;
    }

    public List<City> GetAllCities(int id)
    {
        List<City> cities;
        if (id == -1)
        { cities = _city.GetAllCities(); }
        else
        { cities = _city.GetCitiesByStateId(id); }
        return cities;
    }

    public List<Country> GetAllCountries()
    {
        var countries = _country.GetAllCountry();
        return countries;
    }

}
