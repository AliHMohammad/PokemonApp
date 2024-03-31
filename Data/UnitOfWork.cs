using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace PokemonApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Bruges til at gemme ændringer i databasen
        // Gem så ofte som nødvendigt. I tilfælde af transaction, så ruller transaction.Rollback() det hele tilbage.
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        // Bruges til at påbegynde en transaction. Anvendes øverst inde i en service-metode.
        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            var transaction = _dataContext.Database.BeginTransaction();

            return transaction.GetDbTransaction();
        }

    }
}

