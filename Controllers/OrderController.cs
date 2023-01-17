using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers;

public class OrderController : Controller
{
    private Cart cart;
    private IOrderRepository repository;

    public OrderController(Cart cart, IOrderRepository repository)
    {
        this.cart = cart;
        this.repository = repository;
    }
    
    public ViewResult Checkout() => View(new Order());

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        if(cart.Lines.Count() == 0)
            ModelState.AddModelError("", "Sorry, your cart is empty!");

        if (ModelState.IsValid)
        {
            order.Lines = cart.Lines.ToArray();
            repository.SaveOrder(order);
            cart.Clear();
            return RedirectToPage("/Completed", new {orderId = order.OrderID});
        }
        else return View();
    }
}