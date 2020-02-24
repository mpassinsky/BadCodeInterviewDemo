namespace InterviewDemo
{
    public class ProductBox
    {
        public int ProductId;
        public double Width;
        public double Height;
        public double Length;
        public double Volume => Width * Height * Length;
        public double Weight;
        public string ProductDescription;
        public decimal ProductCost;
        public ProductCategory ProductCategory;

        public override string ToString()
        {
            return $"{ProductId}_{ProductDescription}";
        }
    }
}
