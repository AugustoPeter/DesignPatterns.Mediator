using DesignPatterns.Mediator.Domain.DomainObjects;

namespace DesignPatterns.Mediator.Domain.Operations.Entities;

public class OperationEntity : Entity<Guid>
{
    public OperationEntity() : base(default) { }

    public OperationEntity(Guid id) : base (id) { }

    public OperationEntity(string asset, string assetCode, string institution, decimal value, int quantity) : base (default)
    {
        Asset = asset;
        AssetCode = assetCode;
        Institution = institution;
        Value = value;
        Quantity = quantity;
    }

    public string Asset { get; set; }
    public string AssetCode { get; set; }
    public string Institution { get; set; }
    public Guid ClientId { get; set; }
    public decimal Value { get; set; }
    public int Quantity { get; set; }
    public DateTime OperationDate { get; set; }

    public void UpdateValues(string? asset, string? assetCode, string? institution, decimal value, int quantity)
    {
        if (!string.IsNullOrEmpty(asset))
            Asset = asset;

        if (!string.IsNullOrEmpty(assetCode))
            AssetCode = assetCode;

        if (!string.IsNullOrEmpty(institution))
            Institution = institution;

        if(value > 0) 
            Value = value;

        if(quantity > 0)
            Quantity = quantity;
    }

}
