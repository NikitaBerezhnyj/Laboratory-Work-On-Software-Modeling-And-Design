namespace PW1.Models
{
    internal class Description : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ProductId { get; set; }

        public Description(string text, int productId)
        {
            Text = text;
            ProductId = productId;
        }

        public override string ToString()
        {
            return $"{Id} {Text} {ProductId}";
        }
    }
}
