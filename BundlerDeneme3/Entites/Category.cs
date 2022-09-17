using BundlerDeneme3.Entites;

namespace BundlerDeneme3
{
    public class Category
    {
        public int Id { get; set; }
        public string  Name { get; set; }=null!;
        public string PhotoUrl { get; set; } = null!;
        public string Title { get; set; }   
        //public bool IsParent { get; set; }  
        public virtual List<CategoryWithChild>? CategoryWithChild { get; set; }
    }
}