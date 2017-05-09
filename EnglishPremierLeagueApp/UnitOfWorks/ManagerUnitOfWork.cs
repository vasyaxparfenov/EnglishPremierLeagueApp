using Data;
using EnglishPremierLeagueApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EnglishPremierLeagueApp.UnitOfWorks
{
    public class ManagerUnitOfWork : SharedUnitOfWork
    {
        public readonly IMutableRepository<Players> PlayersRepository;
        public readonly IMutableRepository<Transfers> TransfersRepository;

        public ManagerUnitOfWork(DbContext context) : base(context)
        {
            PlayersRepository = RepositoryFactory.CreateRepository<IMutableRepository<Players>>(context);
            TransfersRepository = RepositoryFactory.CreateRepository<IMutableRepository<Transfers>>(context);
        }
    }
}