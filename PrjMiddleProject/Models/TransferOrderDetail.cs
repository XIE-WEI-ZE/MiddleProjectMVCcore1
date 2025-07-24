using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class TransferOrderDetail
{
    public int TransferOrderId { get; set; }

    public int StoreProductId { get; set; }

    public decimal QuantityOfTransfer { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public virtual TransferOrder TransferOrder { get; set; } = null!;
}
