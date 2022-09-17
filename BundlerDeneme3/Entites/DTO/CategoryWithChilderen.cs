namespace BundlerDeneme3.Entites.DTO
{
    public class CategoryWithChilderen
    {
        public CategoryWithChilderen()
        {
            Childeren = new List<Category>();
        }
        public int CatgoryId { get; set; }
        public string CatgoryName { get; set; }
        public IEnumerable<Category> Childeren { get; set; }
    }
}
