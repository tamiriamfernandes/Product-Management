namespace ProductManagement.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; private set; }
        public DateTime DateFabrication { get; set; }
        public DateTime DateValidity { get; set; }
        public int IdProvider { get; set; }
        public string DescriptionProvider { get; set; }
        public string DocumentProvider { get; set; }

        public void ActiveProduct(bool active)
        {
            this.Active = active;
        }
    }
}
