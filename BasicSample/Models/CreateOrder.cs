namespace BasicSample.Models
{
    public class CreateOrder
    {
        public int Id { get; set; }

        public string OrderName { get; set; }

        public string Email { get; set; }

        public string Blog { get; set; }

        public DateTime BirthDay { get; set; }

        public DateTime? OrderDate { get; set; }

        public int Amount { get; set; }

        public string store { get; set; }

        // 備註
        public string Remark { get; set; }

        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool Delete { get; set; }
    }
}