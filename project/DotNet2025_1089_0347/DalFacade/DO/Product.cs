namespace DO
{
    public record Product
        (
        string? Name,
        Categories? Category,
        double? Price,
        int? AmountInStock,
        int Id=0)
    {
        public Product() : this(null,null,0,0)
        {

        }
    }
}
