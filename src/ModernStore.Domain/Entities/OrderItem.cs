using FluentValidator.Validation;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class OrderItem : Entity
    {
        protected OrderItem() { }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = Product.Price;

            AddNotifications(new ValidationContract()
                .IsGreaterThan(Quantity, 1, "Quantity", "Quantity bigger than one")
                .IsGreaterThan(Product.QuantityOnHand, Quantity + 1, "Quantity", $"We don't have enough {product.Title}(s) in stock.")
            );
            
            Product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public decimal Total() => Price * Quantity;
    }
}
