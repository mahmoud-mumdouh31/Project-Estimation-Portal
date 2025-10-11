//using Extension.ToolKit.BaseEntities;
//using MediatR;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore.ChangeTracking;
//using System.Security.Claims;

//namespace Extension.ToolKit.Database;

//public class BaseIdentityDBContext<TUser, TRole, TKey>
//    : IdentityDbContext<TUser, TRole, TKey>
//        where TUser : IdentityUser<TKey>
//        where TRole : IdentityRole<TKey>
//        where TKey : IEquatable<TKey>
//{
//    protected int? _userId;
//    protected readonly IHttpContextAccessor httpContextAccessor;
//    private readonly IPublisher publisher;
//    /// <summary>
//    /// SystemId is used as a fallback user ID when the current user is not authenticated or cannot be determined.
//    /// Make sure to set this to a valid user ID in database.
//    /// </summary>
//    public const int SystemId = 1;

//    public BaseIdentityDBContext(
//        DbContextOptions options,
//        IHttpContextAccessor httpContextAccessor,
//        IPublisher publisher
//        ) : base(options)
//    {
//        this.httpContextAccessor = httpContextAccessor;
//        this.publisher = publisher;
//        this.SetUserId();
//    }

//    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
//    {
//        await PublishDomainEventsAsync();
//        SetAuditableProperties();
//        return await base.SaveChangesAsync(cancellationToken);
//    }
//    public override int SaveChanges()
//    {
//        PublishDomainEventsAsync().GetAwaiter().GetResult();
//        SetAuditableProperties();
//        return base.SaveChanges();
//    }

//    public virtual void SetUserId()
//    {
//        var userId = httpContextAccessor.HttpContext?.User.Claims
//            .FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier)?.Value;

//        if (userId == null) return;

//        if (int.TryParse(userId, out int userIdInt)) _userId = userIdInt;
//    }

//    /// <summary>
//    /// Sets auditable properties for entities that are inherited from <see cref="IAuditEntity"/> or <see cref="ISoftDeleteEntity"/>
//    /// </summary>
//    /// <returns></returns>
//    public virtual void SetAuditableProperties()
//    {
//        foreach (var entry in ChangeTracker.Entries<IAuditEntity>().Where(entry => entry.State == EntityState.Added))
//        {
//            entry.Entity.CreatedAtUTC = DateTime.UtcNow;
//            entry.Entity.CreatedById = _userId ?? SystemId;
//        }

//        foreach (var entry in ChangeTracker.Entries<IAuditEntity>().Where(entry => entry.State == EntityState.Modified))
//        {
//            entry.Entity.UpdatedAtUTC = DateTime.UtcNow;
//            entry.Entity.UpdatedById = _userId ?? SystemId;
//        }

//        foreach (var entry in ChangeTracker.Entries<ISoftDeleteEntity>().Where(entry => entry.State == EntityState.Modified))
//        {
//            if (entry.Entity.IsDeleted)
//            {
//                entry.Entity.DeletedAtUTC = DateTime.UtcNow;
//                entry.Entity.DeletedById = _userId ?? SystemId;
//            }
//        }
//    }

//    private async Task PublishDomainEventsAsync()
//    {
//        var domainEvents = ChangeTracker
//            .Entries<IBaseEntity>()
//            .Select(entry => entry.Entity)
//            .SelectMany(entity =>
//            {
//                List<IDomainEvent> domainEvents = entity.DomainEvents;

//                entity.ClearDomainEvents();

//                return domainEvents;
//            })
//            .ToList();

//        foreach (IDomainEvent domainEvent in domainEvents)
//        {
//            await publisher.Publish(domainEvent);
//        }
//    }