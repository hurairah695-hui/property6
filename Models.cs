namespace PropDeal;

// One row per account. Holds the sign-in details only.
public class Login
{
    public int Id { get; set; }
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public string Role { get; set; } = "buyer";          // buyer | seller | admin
    public DateTime CreatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }
}

// Profile tables: one row per account, linked to Logins by LoginId.
public class Buyer
{
    public int Id { get; set; }
    public int LoginId { get; set; }
    public Login Login { get; set; }
    public string FullName { get; set; } = "";
    public int? Age { get; set; }
    public string Phone { get; set; }
    public string City { get; set; }
    public string About { get; set; }
    public long? BudgetMax { get; set; }
    public string PreferredType { get; set; }
}

public class Seller
{
    public int Id { get; set; }
    public int LoginId { get; set; }
    public Login Login { get; set; }
    public string FullName { get; set; } = "";
    public int? Age { get; set; }
    public string Phone { get; set; }
    public string City { get; set; }
    public string About { get; set; }
    public string AgencyName { get; set; }
    public int? ExperienceYears { get; set; }
}

public class Admin
{
    public int Id { get; set; }
    public int LoginId { get; set; }
    public Login Login { get; set; }
    public string FullName { get; set; } = "";
    public int? Age { get; set; }
    public string Phone { get; set; }
    public string City { get; set; }
    public string About { get; set; }
}

public class Property
{
    public int Id { get; set; }                           // assigned by the app (the 28 sample listings use 1..28)
    public int SellerLoginId { get; set; }
    public string Title { get; set; } = "";
    public string PropertyType { get; set; } = "house";   // house | apartment | shop | plot
    public string ListingMode { get; set; } = "sale";     // sale | rent
    public long Price { get; set; }                       // PKR, or monthly rent
    public bool? IsNegotiable { get; set; }
    public int? MinRentalMonths { get; set; }
    public string City { get; set; } = "";
    public string Locality { get; set; }
    public string AreaSize { get; set; }
    public int? Bedrooms { get; set; }
    public int? Bathrooms { get; set; }
    public string ShortDescription { get; set; } = "";
    public string FullDescription { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<PropertyImage> Images { get; set; } = new();
    public List<PropertyFeature> Features { get; set; } = new();
}

public class PropertyImage
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public string ImageUrl { get; set; } = "";            // web address or data: URL
    public int SortOrder { get; set; }
}

public class PropertyFeature
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public string Feature { get; set; } = "";
}

public class Favorite
{
    public int LoginId { get; set; }
    public int PropertyId { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class Meeting
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public int BuyerLoginId { get; set; }
    public int SellerLoginId { get; set; }
    public DateTime MeetingDate { get; set; }
    public string MeetingTime { get; set; } = "";
    public string Note { get; set; }
    public int? RentalMonths { get; set; }
    public string Status { get; set; } = "pending";       // pending | confirmed | declined
    public DateTime CreatedAt { get; set; }
}

public class Deal
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public int DiscountPercent { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime EndsAt { get; set; }
    public bool IsActive { get; set; }
}

public class DealProperty
{
    public int DealId { get; set; }
    public int PropertyId { get; set; }
}

public class Announcement
{
    public int Id { get; set; }
    public string Message { get; set; } = "";
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }
}
