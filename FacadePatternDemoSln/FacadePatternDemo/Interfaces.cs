namespace FacadePatternDemo
{
    public interface IProductPageFacade
    {
        void LoadPage(int productId);
        void PlaceOrder(int productId, int quantity);
    }

    public interface IInventoryService
    {
        void IsProductInStock(int productId);
        void UpdateInventory(int productId, int updateBy);
    }

    public interface IOrderService
    {
        void PlaceOrder(int productId, int quantity);
    }

    public interface IDeliveryService
    {
        void GetDeliveryEstimate(int productId);
        void Initiate(int productId, int quantity);
    }

    public interface IProductService
    {
        void LoadProduct(int productId);
        void GetImagesForProduct(int productId);
        void GetRecommendedProducts(int productId);
    }

    public interface IReviewService
    {
        void LoadReviews(int productId);
    }
}
