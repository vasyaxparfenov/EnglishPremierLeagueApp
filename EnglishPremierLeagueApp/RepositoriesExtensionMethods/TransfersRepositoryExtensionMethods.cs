using System.Collections.Generic;
using System.Linq;
using Data;
using EnglishPremierLeagueApp.Models;

namespace EnglishPremierLeagueApp.RepositoriesExtensionMethods
{
    public static class TransfersRepositoryExtensionMethods
    {
        /// <summary>
        /// Returns a list of incoming transfers propositions for certain team based on id
        /// </summary>
        /// <param name="transfersRepository"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IEnumerable<Transfers> GetIncomingTransferPropositions(this IRepository<Transfers> transfersRepository ,int id) 
            => transfersRepository
                .Find(transfer => transfer.FromId == id)
                .ToList();
            
        /// <summary>
        /// Returns a list of incoming transfer propositions for certain team based on name
        /// </summary>
        /// <param name="transfersRepository"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<Transfers> GetIncomingTransferPropositions(this IRepository<Transfers> transfersRepository, string name) 
            => transfersRepository
                .Find(transfer => transfer.From.Name.Equals(name))
                .ToList();

        /// <summary>
        /// Returns a list of outcoming transfer propositions for certain team based on id
        /// </summary>
        /// <param name="transfersRepository"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IEnumerable<Transfers> GetOutcomingTransferPropositions(this IRepository<Transfers> transfersRepository ,int id) 
            => transfersRepository
                .Find(transfer => transfer.ToId == id)
                .ToList();

        /// <summary>
        /// Returns a list of outcoming transfer propositions for certain team based on name 
        /// </summary>
        /// <param name="transfersRepository"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<Transfers> GetOutcomingTransferPropositions(this IRepository<Transfers> transfersRepository, string name) 
            => transfersRepository
                .Find(transfer => transfer.To.Name.Equals(name))
                .ToList();

        /// <summary>
        /// Returns a list of transfer propositions based on transfer status
        /// </summary>
        /// <param name="transfersRepository"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static IEnumerable<Transfers> GetTransfers(this IRepository<Transfers> transfersRepository ,TransferStatus status) 
            => transfersRepository
                .Find(transfer => transfer.Status == status)
                .ToList();

        /// <summary>
        /// Returns a transfer history of certain team based on id
        /// </summary>
        /// <param name="transfersRepository"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IEnumerable<Transfers> GetTransferHistory(this IRepository<Transfers> transfersRepository ,int id) 
            => transfersRepository
                .GetIncomingTransferPropositions(id)
                .Concat(transfersRepository.GetOutcomingTransferPropositions(id))
                .ToList();

        /// <summary>
        /// Returns a transfer history of certain team based on name 
        /// </summary>
        /// <param name="transfersRepository"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<Transfers> GetTransferHistory(this IRepository<Transfers> transfersRepository, string name) 
            => transfersRepository
                .GetIncomingTransferPropositions(name)
                .Concat(transfersRepository.GetOutcomingTransferPropositions(name))
                .ToList();
    }
}