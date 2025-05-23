using Core.Model;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Services;

[Route("api/payment")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] Payment payment)
    {
        var createdPayment = await _paymentService.CreatePaymentAsync(payment);
        if (createdPayment == null)
        {
            return BadRequest("Ödeme oluşturulamadı.");
        }

        return CreatedAtAction(nameof(GetPaymentById), new { id = createdPayment.PaymentId }, createdPayment);
    }




    [HttpGet("{id}")]
    public async Task<IActionResult> GetPaymentById(int id)
    {
        var payment = await _paymentService.GetPaymentByOrderIdAsync(id);
        if (payment == null)
        {
            return NotFound();
        }
        return Ok(payment);
    }
}
