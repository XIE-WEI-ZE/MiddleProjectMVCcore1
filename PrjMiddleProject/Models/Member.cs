using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string? Idnumber { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public DateOnly? BirthDate { get; set; }

    public decimal? Height { get; set; }

    public decimal? Weight { get; set; }

    public string? Mobility { get; set; }

    public string? MedicalHistory { get; set; }

    public DateOnly? MoveInDate { get; set; }

    public string? DietaryHabit { get; set; }

    public bool? ResidesInCareHome { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? PasswordSalt { get; set; }

    public byte[]? ProfilePicture { get; set; }

    public string? Email { get; set; }

    public DateOnly? MoveOutDate { get; set; }

    public string? LoginProvider { get; set; }

    public string? ExternalId { get; set; }

    public string? Photo { get; set; }

    public string? City { get; set; }

    public string? District { get; set; }

    public string? RoadAddress { get; set; }

    public bool? IsTempPassword { get; set; }

    public string? Role { get; set; }

    public string? Account { get; set; }

    public virtual ICollection<RoomTable> RoomTables { get; set; } = new List<RoomTable>();

    public virtual ICollection<ShopOrder> ShopOrders { get; set; } = new List<ShopOrder>();

    public virtual ICollection<TSearchLog> TSearchLogs { get; set; } = new List<TSearchLog>();
}
