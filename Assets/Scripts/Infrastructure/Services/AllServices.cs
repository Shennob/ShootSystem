namespace Infrastructure.Services
{
    public class AllServices
    {
        private static AllServices _instance;
        public static AllServices Container => 
            _instance ?? (_instance = new AllServices());

        public void RegisterSingle<TService>(TService implementation) 
            where TService : IService => 
            Implimintation<TService>.ServiceInstance = implementation;

        public TService Single<TService>() 
            where TService : IService => 
            Implimintation<TService>.ServiceInstance;

        private static class Implimintation<TService> 
            where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}