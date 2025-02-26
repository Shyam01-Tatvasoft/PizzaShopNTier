using PizzaShop.DataAccess.Data;

namespace PizzaShop.DataAccess.Interfaces;

public interface IStateRepository
{
    public List<State> GetAllStates();

    public List<State> GetStatesByCountryId(int id);
}
