using Application.Services;
using Domain.Entities;
using Infrastructure.Repositories;
using Persistence.Contexts;

namespace Infrastructure.Services;

public class BackpackService : EntityRepository<Backpack>, IBackpackService
{
    public BackpackService(UserContext context) : base(context)
    {
    }
}
