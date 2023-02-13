using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace BasicSample.Models
{
    public class TestDataTypeHtmlHelper
    {
        public string TestString { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        public string TestPassword { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        public string ColName { get; set; }

        [DataType(DataType.Date)]
        public string ColName1 { get; set; }

        [DataType(DataType.DateTime)]
        public string ColName2 { get; set; }

        [DataType(DataType.Currency)]
        public string ColName3 { get; set; }

        [DataType(DataType.MultilineText)]
        public string ColName4 { get; set; }

        [DataType(DataType.Url)]
        public string ColName5 { get; set; }
    }
}