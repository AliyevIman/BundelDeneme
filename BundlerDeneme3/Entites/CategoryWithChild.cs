namespace BundlerDeneme3.Entites
{
    public class CategoryWithChild
    {
        public int id { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public int ParentCategoryId { get; set; }
        //public virtual Category? ParentCategory { get; set; }
    }
}
