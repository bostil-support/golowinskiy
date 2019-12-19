namespace Golowinskiy_NewBostil.DAL.Entities
{
    public class AdditionalImage
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string ImageLink { get; set; }
    }
}
