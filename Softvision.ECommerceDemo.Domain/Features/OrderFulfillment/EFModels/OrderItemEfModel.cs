using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softvision.ECommerceDemo.Core.Features.OrderFulfillment.EFModels;

public class OrderItemEfModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public double DiscountAmount { get; set; }
    public ProductEfModel? Product { get; set; }
}
