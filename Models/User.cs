using System.ComponentModel.DataAnnotations.Schema;
using basic_api.Constants;

namespace basic_api.Models
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("phone")]
        public string? Phone { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("password")]
        public string? Password { get; set; } = string.Empty;

        [Column("username")]
        public string Username { get; set; } = string.Empty;

        [Column("google_uid")]
        public string? GoogleUID { get; set; } = string.Empty;

        [Column("is_rent")]
        public bool IsRent { get; set; } = false;

        [Column("is_active")]
        public bool IsActive { get; set; } = false;

        [Column("is_verify")]
        public bool IsVerify { get; set; } = false;

        [Column("image_url")]
        public string? ImageURL { get; set; } = string.Empty;

        [Column("role")]
        public string Role { get; set; } = Roles.User;

        [Column("driving_license")]
        public string? DrivingLicense { get; set; } = string.Empty;

        [Column("verify_code")]
        public string? VerifyCode { get; set; } = string.Empty;

        [Column("verify_code_expires")]
        public DateTime? VerifyCodeExpires { get; set; }

        [Column("cars_rented")]
        public int CarRented { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Order> Orders { get; set; } = [];

        public ICollection<Punishment> Punishments { get; set; } = [];
    }
}
=======
﻿using System.ComponentModel.DataAnnotations.Schema;
using basic_api.Constants;

namespace basic_api.Models
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("phone")]
        public string? Phone { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("password")]
        public string? Password { get; set; } = string.Empty;

        [Column("username")]
        public string Username { get; set; } = string.Empty;

        [Column("google_uid")]
        public string? GoogleUID { get; set; } = string.Empty;

        [Column("is_rent")]
        public bool IsRent { get; set; } = false;

        [Column("is_active")]
        public bool IsActive { get; set; } = false;

        [Column("is_verify")]
        public bool IsVerify { get; set; } = false;

        [Column("image_url")]
        public string? ImageURL { get; set; } = string.Empty;

        [Column("role")]
        public string Role { get; set; } = Roles.User;

        [Column("driving_license")]
        public string? DrivingLicense { get; set; } = string.Empty;

        [Column("verify_code")]
        public string? VerifyCode { get; set; } = string.Empty;

        [Column("verify_code_expires")]
        public DateTime? VerifyCodeExpires { get; set; }

        [Column("cars_rented")]
        public int CarRented { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Order> Orders { get; set; } = [];

        public ICollection<Punishment> Punishments { get; set; } = [];
    }
}
>>>>>>> 90ce7f10766621f0afaee5aee687c9b45c201bb1
