using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PrjMiddleProject.Models;

public partial class ShopOrder
{
    [DisplayName("訂單編號")]
    public long OrderId { get; set; }
    [DisplayName("客戶編號")]
    public string? CustomerId { get; set; }
    [DisplayName("會員編號")]
    public int? MemberId { get; set; }
    [DisplayName("員工編號")]
    public string? EmployeeId { get; set; }
    [DisplayName("訂單時間")]
    public DateTime OrderTime { get; set; }
    [DisplayName("訂購人")]
    public string BuyerName { get; set; } = null!;
    [DisplayName("收件人")]
    public string ReceiverName { get; set; } = null!;
    [DisplayName("收件電話")]
    public string ReceiverPhone { get; set; } = null!;
    [DisplayName("付款方式")]
    public string PaymentMethod { get; set; } = null!;
    [DisplayName("配送方式")]
    public string DeliveryMethod { get; set; } = null!;
    [DisplayName("收貨地址")]
    public string DeliveryAddress { get; set; } = null!;
    [DisplayName("發票抬頭")]
    public string? InvoiceTitle { get; set; }
    [DisplayName("發票稅額")]
    public string? InvoiceTax { get; set; }
    [DisplayName("發票方式")]
    public string? InvoiceInMethod { get; set; }
    [DisplayName("備註")]
    public string? Note { get; set; }
    [DisplayName("總金額")]
    public int? TotalAmount { get; set; }

    public virtual Member? Member { get; set; }

    public virtual ICollection<ShopOrderDetail> ShopOrderDetails { get; set; } = new List<ShopOrderDetail>();
}
