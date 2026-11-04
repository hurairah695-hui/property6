using Microsoft.EntityFrameworkCore;

namespace PropDeal;

public class AppDb : DbContext
{
    public AppDb(DbContextOptions<AppDb> options) : base(options) { }

    public DbSet<Login> Logins => Set<Login>();
    public DbSet<Buyer> Buyers => Set<Buyer>();
    public DbSet<Seller> Sellers => Set<Seller>();
    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<Property> Properties => Set<Property>();
    public DbSet<PropertyImage> PropertyImages => Set<PropertyImage>();
    public DbSet<PropertyFeature> PropertyFeatures => Set<PropertyFeature>();
    public DbSet<Favorite> Favorites => Set<Favorite>();
    public DbSet<Meeting> Meetings => Set<Meeting>();
    public DbSet<Deal> Deals => Set<Deal>();
    public DbSet<DealProperty> DealProperties => Set<DealProperty>();
    public DbSet<Announcement> Announcements => Set<Announcement>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Login>(e =>
        {
            e.ToTable("Logins");
            e.Property(x => x.Email).HasMaxLength(150).IsRequired();
            e.Property(x => x.PasswordHash).HasMaxLength(200).IsRequired();
            e.Property(x => x.Role).HasMaxLength(10).IsRequired();
            e.HasIndex(x => x.Email).IsUnique();
        });

        b.Entity<Buyer>(e =>
        {
            e.ToTable("Buyers");
            e.Property(x => x.FullName).HasMaxLength(50).IsRequired();
            e.Property(x => x.Phone).HasMaxLength(20);
            e.Property(x => x.City).HasMaxLength(80);
            e.Property(x => x.About).HasMaxLength(300);
            e.Property(x => x.PreferredType).HasMaxLength(12);
            e.HasOne(x => x.Login).WithOne().HasForeignKey<Buyer>(x => x.LoginId).OnDelete(DeleteBehavior.Cascade);
        });

        b.Entity<Seller>(e =>
        {
            e.ToTable("Sellers");
            e.Property(x => x.FullName).HasMaxLength(50).IsRequired();
            e.Property(x => x.Phone).HasMaxLength(20);
            e.Property(x => x.City).HasMaxLength(80);
            e.Property(x => x.About).HasMaxLength(300);
            e.Property(x => x.AgencyName).HasMaxLength(80);
            e.HasOne(x => x.Login).WithOne().HasForeignKey<Seller>(x => x.LoginId).OnDelete(DeleteBehavior.Cascade);
        });

        b.Entity<Admin>(e =>
        {
            e.ToTable("Admins");
            e.Property(x => x.FullName).HasMaxLength(50).IsRequired();
            e.Property(x => x.Phone).HasMaxLength(20);
            e.Property(x => x.City).HasMaxLength(80);
            e.Property(x => x.About).HasMaxLength(300);
            e.HasOne(x => x.Login).WithOne().HasForeignKey<Admin>(x => x.LoginId).OnDelete(DeleteBehavior.Cascade);
        });

        b.Entity<Property>(e =>
        {
            e.ToTable("Properties");
            e.Property(x => x.Id).ValueGeneratedNever();
            e.Property(x => x.Title).HasMaxLength(150).IsRequired();
            e.Property(x => x.PropertyType).HasMaxLength(12).IsRequired();
            e.Property(x => x.ListingMode).HasMaxLength(6).IsRequired();
            e.Property(x => x.City).HasMaxLength(80).IsRequired();
            e.Property(x => x.Locality).HasMaxLength(80);
            e.Property(x => x.AreaSize).HasMaxLength(40);
            e.Property(x => x.ShortDescription).HasMaxLength(160).IsRequired();
            e.HasOne<Login>().WithMany().HasForeignKey(x => x.SellerLoginId).OnDelete(DeleteBehavior.NoAction);
            e.HasMany(x => x.Images).WithOne().HasForeignKey(i => i.PropertyId).OnDelete(DeleteBehavior.Cascade);
            e.HasMany(x => x.Features).WithOne().HasForeignKey(f => f.PropertyId).OnDelete(DeleteBehavior.Cascade);
            e.HasIndex(x => new { x.PropertyType, x.ListingMode, x.City });
        });

        b.Entity<PropertyImage>(e =>
        {
            e.ToTable("PropertyImages");
            e.Property(x => x.ImageUrl).IsRequired();
        });

        b.Entity<PropertyFeature>(e =>
        {
            e.ToTable("PropertyFeatures");
            e.Property(x => x.Feature).HasMaxLength(80).IsRequired();
        });

        b.Entity<Favorite>(e =>
        {
            e.ToTable("Favorites");
            e.HasKey(x => new { x.LoginId, x.PropertyId });
            e.HasOne<Login>().WithMany().HasForeignKey(x => x.LoginId).OnDelete(DeleteBehavior.NoAction);
            e.HasOne<Property>().WithMany().HasForeignKey(x => x.PropertyId).OnDelete(DeleteBehavior.NoAction);
        });

        b.Entity<Meeting>(e =>
        {
            e.ToTable("Meetings");
            e.Property(x => x.MeetingDate).HasColumnType("date");
            e.Property(x => x.MeetingTime).HasMaxLength(10).IsRequired();
            e.Property(x => x.Note).HasMaxLength(300);
            e.Property(x => x.Status).HasMaxLength(10).IsRequired();
            e.HasOne<Property>().WithMany().HasForeignKey(x => x.PropertyId).OnDelete(DeleteBehavior.NoAction);
            e.HasOne<Login>().WithMany().HasForeignKey(x => x.BuyerLoginId).OnDelete(DeleteBehavior.NoAction);
            e.HasOne<Login>().WithMany().HasForeignKey(x => x.SellerLoginId).OnDelete(DeleteBehavior.NoAction);
            e.HasIndex(x => new { x.BuyerLoginId, x.Status });
            e.HasIndex(x => new { x.SellerLoginId, x.Status });
        });

        b.Entity<Deal>(e =>
        {
            e.ToTable("Deals");
            e.Property(x => x.Title).HasMaxLength(100).IsRequired();
        });

        b.Entity<DealProperty>(e =>
        {
            e.ToTable("DealProperties");
            e.HasKey(x => new { x.DealId, x.PropertyId });
            e.HasOne<Deal>().WithMany().HasForeignKey(x => x.DealId).OnDelete(DeleteBehavior.Cascade);
            e.HasOne<Property>().WithMany().HasForeignKey(x => x.PropertyId).OnDelete(DeleteBehavior.NoAction);
        });

        b.Entity<Announcement>(e =>
        {
            e.ToTable("Announcements");
            e.Property(x => x.Message).HasMaxLength(160).IsRequired();
        });
    }
}
