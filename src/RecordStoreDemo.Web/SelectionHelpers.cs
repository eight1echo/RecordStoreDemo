using RecordStoreDemo.Features.Webstore.Products;

namespace RecordStoreDemo.Web;

public static class SelectionHelpers
{
    public static bool IsGenreSelected(WebstoreProductModel product, string selectedGenre)
    {
        if (product.Genres.Contains(selectedGenre))
        {
            return true;
        }
        else return false;
    }

    public static bool IsStyleSelected(WebstoreProductModel product, string selectedStyle)
    {
        if (product.Styles.Contains(selectedStyle))
        {
            return true;
        }
        else return false;
    }

    public static bool IsTagSelected(WebstoreProductModel product, string selectedTag)
    {
        if (product.Tags.Contains(selectedTag))
        {
            return true;
        }
        else return false;
    }
}
