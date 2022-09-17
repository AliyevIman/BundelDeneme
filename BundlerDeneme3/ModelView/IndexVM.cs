using BundlerDeneme3.Entites;
using BundlerDeneme3.Entites.DTO;

namespace BundlerDeneme3.ModelView
{
    public class IndexVM
    {
        public List<CategoryWithChilderen> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<CategoryWithChild> Children { get; set; }   
    }
}
