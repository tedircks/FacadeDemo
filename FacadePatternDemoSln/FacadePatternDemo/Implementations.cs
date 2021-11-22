using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePatternDemo
{
    public class ProductPageFacade : IProductPageFacade
    {
        IInventoryService _inventoryService;
        IOrderService _orderService;
        IDeliveryService _deliveryService;
        IProductService _productService;
        IReviewService _reviewService;

        public ProductPageFacade(IInventoryService inventoryService,
                                 IOrderService orderService,
                                 IDeliveryService deliveryService,
                                 IProductService productService,
                                 IReviewService reviewService)
        {
            _inventoryService = inventoryService;
            _orderService = orderService;
            _deliveryService = deliveryService;
            _productService = productService;
            _reviewService = reviewService;
        }

        public void LoadProductForPage(int productId)
        {
            Console.WriteLine("Begin - LoadPage");
            _productService.LoadProduct(productId);
            _productService.GetImagesForProduct(productId);
            _productService.GetRecommendedProducts(productId);

            _reviewService.LoadReviews(productId);
            _inventoryService.IsProductInStock(productId);
            _deliveryService.GetDeliveryEstimate(productId);
            Console.WriteLine("End - LoadPage");
        }

        public void PlaceOrder(int productId, int quantity)
        {
            Console.WriteLine("Begin - PlaceOrder");
            _inventoryService.UpdateInventory(productId, -quantity);
            _orderService.PlaceOrder(productId, quantity);
            _deliveryService.Initiate(productId, quantity);
            Console.WriteLine("End - PlaceOrder");
        }
    }

    public class InventoryService : IInventoryService
    {
        public void IsProductInStock(int productId)
        {
            Console.WriteLine($"Checking if product id {productId} is in stock");
        }

        public void UpdateInventory(int productId, int updateBy)
        {
            Console.WriteLine($"Updating product id {productId} inventory by {updateBy}");
        }
    }

    public class OrderService : IOrderService
    {
        public void PlaceOrder(int productId, int quantity)
        {
            Console.WriteLine($"Initiating order of {quantity} products with id {productId}");
        }
    }

    public class DeliveryService : IDeliveryService
    {
        public void GetDeliveryEstimate(int productId)
        {
            Console.WriteLine($"Fetching delivery estimate for product id {productId}");
        }

        public void Initiate(int productId, int quantity)
        {
            Console.WriteLine($"Initiating delivery for {quantity} products with id {productId}");
        }
    }

    public class ProductService : IProductService
    {
        public void GetImagesForProduct(int productId)
        {
            Console.WriteLine($"Loading images for product id {productId}");
        }

        public void GetRecommendedProducts(int productId)
        {
            Console.WriteLine($"Fetching recommended products based on product id {productId}");
        }

        public void LoadProduct(int productId)
        {
            Console.WriteLine($"Loading product id {productId}");
        }
    }

    public class ReviewService : IReviewService
    {
        public void LoadReviews(int productId)
        {
            Console.WriteLine($"Fetching reviews for product id {productId}");
        }
    }
}
