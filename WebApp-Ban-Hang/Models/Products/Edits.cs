namespace WebApp_Ban_Hang.Models.Products
{
    public class Edits
    {
        public string Product_Line { get; set; }
        public string Product_Name { get; set; }
        public string Thumbnail { get; set; }
        public int Price { get; set; }
        public uint Discount { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Modified_At { get; set; }
        public DateTime Delete_At { get; set; }
        //public string Create_By { get; set; }
        public string BrandId { get; set; }
        public int CategoryID { get; set; }
    }
}
