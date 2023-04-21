namespace Numeral.CoffeeShop.Domain.Models;

public class AggregateRoot<TId, TIdType> : Entity<TId>
where TId: AggregateRootId<TIdType>
{
    protected AggregateRoot(TId id) : base(id)
    {
    }
    
   #pragma warning  disable CS6818
    protected AggregateRoot(){}
   #pragma warning  restore CS6818
    
}