using Microsoft.AspNetCore.Mvc;
using Softvision.ECommerceDemo.Api.Services;
using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.Dtos;

namespace Softvision.ECommerceDemo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task Put(UpdateOrderStatusDto dto)
    {
        await _orderService.UpdateOrderStatus(dto);
    }
}