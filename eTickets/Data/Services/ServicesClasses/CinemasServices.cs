using eTickets.Data.Base.BaseClasses;
using eTickets.Data.Services.InterFaces;
using eTickets.Models;

namespace eTickets.Data.Services.ServicesClasses
{
    public class CinemasServices :EntityBaseRepository<Cinema> , ICinemasServices
    {

        public CinemasServices(AppDbContext dbContext):base(dbContext) 
        {

        }
    }
}
