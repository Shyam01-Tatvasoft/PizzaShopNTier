using PizzaShop.DataAccess.Data;
using PizzaShop.DataAccess.Interfaces;

namespace PizzaShop.DataAccess.Implementation;

public class StateRepository: IStateRepository
{
    private readonly PizzashopContext _context;

    public StateRepository(PizzashopContext context)
    {
        _context = context;
    }

    public List<State> GetAllStates()
    {
        var allStates = _context.States.ToList();
        Console.WriteLine("state By country" + allStates.Count());
        return allStates;
    }

    public List<State> GetStatesByCountryId(int id)
    {
        Console.WriteLine("state id"+id);
        var states = _context.States.Where(s => s.Countryid == id).ToList();
        Console.WriteLine("state By country" + states.Count());
        return states;
    }
}
