﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicSample.DbAccess.Models
{
    public class AuthUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Account { get; set; } = string.Empty;

        public string Pwd { get; set; } = string.Empty;
        public string HttpMethod { get; set; } = string.Empty;
        public string FunctionPath { get; set; } = string.Empty;
        public bool Enabled { get; set; }
    }
}