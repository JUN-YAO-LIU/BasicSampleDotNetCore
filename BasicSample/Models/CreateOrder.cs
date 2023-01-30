﻿using System.ComponentModel.DataAnnotations;

namespace BasicSample.Models
{
    public class CreateOrder
    {
        public int Id { get; set; }

        /// <summary>
        /// 訂單名稱
        /// </summary>
        public string? OrderName { get; set; }

        /// <summary>
        /// 信箱
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 產品連結
        /// </summary>
        public string? OrderUrl { get; set; } = string.Empty;

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// 訂單日期
        /// </summary>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// 費用
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 商店名稱
        /// </summary>
        public string? Store { get; set; } = string.Empty;

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remark { get; set; } = string.Empty;

        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool Delete { get; set; }
    }
}