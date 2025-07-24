using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class StoreProductsDate
{
    public int StoreProductId { get; set; }

    public DateOnly ExpiryDateArrivalDate { get; set; }

    public decimal RemainingStocks { get; set; }

    public bool StocksStatus { get; set; }
}
