    namespace ConaoleApp
    {
        internal interface ICoffeeCleint
        {
            Task<Coffee> GetCoffeeAsync(CancellationToken cancellationToken = default);   
            Task<byte[]> GetCoffeFileAsync(string filename, CancellationToken cancellationToken = default);
        }
    }    