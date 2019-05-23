namespace InterviewDemo
{
    public class ShippingBox
    {
        public double Width;
        public double Height;
        public double Length;
        public double Volume => Width * Height * Length;
        public double Weight;
        public string ProductDescription;
        public double ProductCost;
        public ProductCategory ProductCategory;
    }
}
