using FlightsApp.Airports;
using FlightsApp.Flights;
using FlightsApp.Passengers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace FlightsApp.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class FlightsAppDbContext :
    AbpDbContext<FlightsAppDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public DbSet<Airport> Airports { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Flight> Flights { get; set; }

    public FlightsAppDbContext(DbContextOptions<FlightsAppDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.Entity<Airport>(b =>
        {
           b.ToTable(FlightsAppConsts.DbTablePrefix + "Airports", FlightsAppConsts.DbSchema);
           b.ConfigureByConvention(); //auto configure for the base class props
           b.HasMany(airport => airport.Departures).WithOne(flight => flight.Origin);
           b.HasMany(airport => airport.Arrivals).WithOne(flight => flight.Destination);
        });

        builder.Entity<Passenger>(b =>
        {
           b.ToTable(FlightsAppConsts.DbTablePrefix + "Passengers", FlightsAppConsts.DbSchema);
           b.ConfigureByConvention(); //auto configure for the base class props

        });

        builder.Entity<Flight>(b =>
        {
           b.ToTable(FlightsAppConsts.DbTablePrefix + "Flights", FlightsAppConsts.DbSchema);
           b.ConfigureByConvention(); //auto configure for the base class props
           b.HasOne(flight => flight.Origin).WithMany(airport => airport.Departures).HasForeignKey(flight => flight.OriginId).OnDelete(DeleteBehavior.Cascade);
           b.HasOne(flight => flight.Destination).WithMany(airport => airport.Arrivals).HasForeignKey(flight => flight.DestinationId).OnDelete(DeleteBehavior.Cascade);
        });
    }
}
