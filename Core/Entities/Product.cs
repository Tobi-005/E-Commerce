namespace Core.Entities
{
    public class Product : BaseEntity
    {
        // [Key]  // This is the attribute to say the below is Primary key if other than 'Id' is used!
        // public int TheId {get;set;}
        public string  Name {get;set;}

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public ProductType ProductType{ get; set; }

        public int ProductTypeId { get; set; }

        public ProductBrand ProductBrand{ get; set; }

        public int ProductBrandId { get; set; }

        // private string car;
        // public string Car {
        //     get { return car;
        //     }
        //     set {car=value;}
        // }


    }
}