namespace Pronia_Project.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string SecondImageUrl { get; set; }



        //Foreign Key
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
