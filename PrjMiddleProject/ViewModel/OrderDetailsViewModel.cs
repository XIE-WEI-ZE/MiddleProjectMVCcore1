using PrjMiddleProject.Models;
using System;
using System.Collections.Generic;

namespace PrjMiddleProject.ViewModels
{
    public class OrderDetailsViewModel
    {
        // 主表資料：訂單基本資訊
        public ShopOrder Order { get; set; }

        // 明細資料：訂單商品清單
        public List<ShopOrderDetail> Details { get; set; }

        // 延伸顯示：會員名稱 / 員工名稱（若日後關聯到會員表與員工表）
        public string? MemberName { get; set; }
        public string? EmployeeName { get; set; }

        // 顯示格式化時間
        public string OrderTimeString => Order.OrderTime.ToString("yyyy-MM-dd HH:mm");

        // 計算總筆數（例如明細幾項）
        public int ItemCount => Details?.Count ?? 0;

        // 付款與出貨資訊
        public string PaymentSummary => $"{Order.PaymentMethod} / {Order.DeliveryMethod}";
    }
}
