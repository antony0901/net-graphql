using HotChocolate.Types;
using HotChocolate.Types.Relay;
using src.Services;

namespace src.Schema.Types
{
    public class RestaurantQueries : ObjectType<RestaurantServices>
    {
        protected void RestaurantQueryType(IObjectTypeDescriptor<RestaurantServices> descriptor)
        {
            descriptor.Field("Restaurants").Resolver(ctx => 
            {
                var restService = ctx.Service<RestaurantServices>();
                return restService.GetRestaurants();
            });
        }
    }
}