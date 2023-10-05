using eTickets.Data.Base.BaseClasses;
using eTickets.Data.Services.InterFaces;
using eTickets.Models;

namespace eTickets.Data.Services.ServicesClasses
{
    public class ProducerServices : EntityBaseRepository<Producer> , IProducerServices
    {
        public ProducerServices(AppDbContext dbContext):base(dbContext) 
        {

        }

    }
}
