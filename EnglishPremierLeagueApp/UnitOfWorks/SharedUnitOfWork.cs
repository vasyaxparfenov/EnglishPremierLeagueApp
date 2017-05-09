using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using EnglishPremierLeagueApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EnglishPremierLeagueApp.UnitOfWorks
{
    public class SharedUnitOfWork : UnitOfWork
    {
        public readonly IRepository<Games> GamesRepository;
        public readonly IRepository<LeagueTable> LeagueTableRepositry;
        public readonly IRepository<Seasons> SeasonsRepository;
        public readonly IRepository<Teams> TeamsRepository;
        
        public SharedUnitOfWork(DbContext context) : base(context)
        {
            GamesRepository = RepositoryFactory.CreateRepository<IRepository<Games>>(context);
            LeagueTableRepositry = RepositoryFactory.CreateRepository<IRepository<LeagueTable>>(context);
            SeasonsRepository = RepositoryFactory.CreateRepository<IRepository<Seasons>>(context);
            TeamsRepository = RepositoryFactory.CreateRepository<IRepository<Teams>>(context);
        }
    }
}
