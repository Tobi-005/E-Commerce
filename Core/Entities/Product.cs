
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Product
    {
        // [Key]  // This is the attribute to say the below is Primary key if other than 'Id' is used!
        // public int TheId {get;set;}


        public int Id {get;set;}

        public string  Name {get;set;}

        // private string car;
        // public string Car {
        //     get { return car;
        //     }
        //     set {car=value;}
        // }


    }
}