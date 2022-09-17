namespace BundlerDeneme3.Entites.DTO
{
    public class CategoryDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public  bool IsFeatured { get; set; }
        public int? ParentCategoryId    { get; set; }

    }
}
