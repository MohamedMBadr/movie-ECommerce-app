using eTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Services.InterFaces
{
    public interface IOrderService
    {
        Task storeOrderAsyns(List<ShoppingCartItem> items , string userId , string userEmail);

        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId , string userRole);



    }
}
