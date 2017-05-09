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
    class UserUnitOfWork : SharedUnitOfWork
    {
        public readonly IRepository<Players> PlayersRepository;
        public readonly IRepository<Transfers> TransfersRepository;
       
        public UserUnitOfWork(DbContext context) : base(context)
        {
            PlayersRepository = RepositoryFactory.CreateRepository<IRepository<Players>>(context);
            TransfersRepository = RepositoryFactory.CreateRepository<IRepository<Transfers>>(context);
        }
    }
}
