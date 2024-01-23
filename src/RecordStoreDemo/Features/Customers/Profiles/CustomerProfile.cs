namespace RecordStoreDemo.Features.Customers.Profiles;
public class CustomerProfile : BaseEntity
{
    public CustomerProfile(string name, string contact)
    {
        SetDetails(name, contact);
        RewardsCard = new RewardsCard();
    }

    public string Name { get; private set; } = null!;
    public EmailAddress? EmailAddress { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; }

    private readonly List<SpecialOrder> _specialOrders = [];
    public virtual ICollection<SpecialOrder> SpecialOrders => _specialOrders.AsReadOnly();

    public Guid RewardsCardId { get; set; }
    public virtual RewardsCard RewardsCard { get; set; } = null!;

    public void AttachRewardsCard(string number)
    {
        RewardsCard.SetCardNumber(number);
    }
    public SpecialOrder AddSpecialOrder(Guid inventoryProductId)
    {
        var order = new SpecialOrder(Id, inventoryProductId);
        _specialOrders.Add(order);

        return order;
    }
    public string GetContact()
    {
        if (EmailAddress is null)
            return PhoneNumber!.Digits;

        return EmailAddress.Address;
    }
    public void SetDetails(string name, string contact)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(Name));

        if (contact.Contains('@'))
        {
            EmailAddress = new EmailAddress(contact);
        }
        else
        {
            PhoneNumber = new PhoneNumber(contact);
        }
    }

#nullable disable
    private CustomerProfile() { }
}
