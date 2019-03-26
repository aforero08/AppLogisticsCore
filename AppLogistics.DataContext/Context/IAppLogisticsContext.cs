using AppLogistics.DataContext.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AppLogistics.DataContext.Context
{
    public interface IAppLogisticsContext
    {
        DbSet<Activity> Activity { get; set; }
        DbSet<Afp> Afp { get; set; }
        DbSet<BranchOffice> BranchOffice { get; set; }
        DbSet<Carrier> Carrier { get; set; }
        DbSet<Client> Client { get; set; }
        DbSet<ClientArea> ClientArea { get; set; }
        DbSet<DocumentType> DocumentType { get; set; }
        DbSet<Employee> Employee { get; set; }
        DbSet<Eps> Eps { get; set; }
        DbSet<Holding> Holding { get; set; }
        DbSet<MaritalStatus> MaritalStatus { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<Rate> Rate { get; set; }
        DbSet<Service> Service { get; set; }
        DbSet<VehicleType> VehicleType { get; set; }

        DatabaseFacade Database { get; }
        ChangeTracker ChangeTracker { get; }
        IModel Model { get; }

        EntityEntry Add([NotNull] object entity);
        EntityEntry<TEntity> Add<TEntity>([NotNull] TEntity entity) where TEntity : class;
        Task<EntityEntry> AddAsync([NotNull] object entity, CancellationToken cancellationToken = default(CancellationToken));
        Task<EntityEntry<TEntity>> AddAsync<TEntity>([NotNull] TEntity entity, CancellationToken cancellationToken = default(CancellationToken)) where TEntity : class;
        void AddRange([NotNull] IEnumerable<object> entities);
        void AddRange([NotNull] params object[] entities);
        Task AddRangeAsync([NotNull] IEnumerable<object> entities, CancellationToken cancellationToken = default(CancellationToken));
        Task AddRangeAsync([NotNull] params object[] entities);
        EntityEntry<TEntity> Attach<TEntity>([NotNull] TEntity entity) where TEntity : class;
        EntityEntry Attach([NotNull] object entity);
        void AttachRange([NotNull] params object[] entities);
        void AttachRange([NotNull] IEnumerable<object> entities);
        void Dispose();
        EntityEntry<TEntity> Entry<TEntity>([NotNull] TEntity entity) where TEntity : class;
        EntityEntry Entry([NotNull] object entity);
        object Find([NotNull] Type entityType, [CanBeNull] params object[] keyValues);
        TEntity Find<TEntity>([CanBeNull] params object[] keyValues) where TEntity : class;
        Task<TEntity> FindAsync<TEntity>([CanBeNull] params object[] keyValues) where TEntity : class;
        Task<object> FindAsync([NotNull] Type entityType, [CanBeNull] object[] keyValues, CancellationToken cancellationToken);
        Task<TEntity> FindAsync<TEntity>([CanBeNull] object[] keyValues, CancellationToken cancellationToken) where TEntity : class;
        Task<object> FindAsync([NotNull] Type entityType, [CanBeNull] params object[] keyValues);
        DbQuery<TQuery> Query<TQuery>() where TQuery : class;
        EntityEntry Remove([NotNull] object entity);
        EntityEntry<TEntity> Remove<TEntity>([NotNull] TEntity entity) where TEntity : class;
        void RemoveRange([NotNull] IEnumerable<object> entities);
        void RemoveRange([NotNull] params object[] entities);
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry Update([NotNull] object entity);
        EntityEntry<TEntity> Update<TEntity>([NotNull] TEntity entity) where TEntity : class;
        void UpdateRange([NotNull] params object[] entities);
        void UpdateRange([NotNull] IEnumerable<object> entities);
    }
}