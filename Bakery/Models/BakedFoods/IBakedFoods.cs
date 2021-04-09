namespace Bakery.Models.BakedFoods
{
    public interface IBakedFoods
    {
        string Name { get; }

        int Portion { get; }

        decimal Price { get; }

        
    }
}