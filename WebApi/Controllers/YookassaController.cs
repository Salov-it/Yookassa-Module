using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Yookassa.Application.CQRS.Command.PostCancellationPaymentCommand;
using Yookassa.Application.CQRS.Command.PostCreateCheckCommand;
using Yookassa.Application.CQRS.Command.PostCreatePaymentCommand;
using Yookassa.Application.CQRS.Command.PostRefundCommand;
using Yookassa.Application.CQRS.Command.PostWriteEverythingOffCommand;
using Yookassa.Application.CQRS.Command.PostWriteoffPartCommand;
using Yookassa.Domain.CancellationPayment;
using Yookassa.Domain.Check;
using Yookassa.Domain.CreatePayment;
using Yookassa.Domain.Refund;
using Yookassa.Domain.WriteEverythingOff;
using Yookassa.Domain.WriteoffPart;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YookassaController : ControllerBase
    {
        private readonly IMediator mediator;
        public YookassaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("CreatePayment")]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentModel.createPaymentModel 
            createPaymentModel)
        {
            var content = new PostCreatePaymentCommand
            {
              createPayment1 = createPaymentModel
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }

        [HttpPost("CreatePaymentCheck")]
        public async Task<IActionResult> CreatePaymentCheck([FromBody] CreatePaymentCheckModel createPaymentCheckModel)
        {
            var content = new PostCreatePaymentCheckCommand
            {
                createPaymentCheckModel = createPaymentCheckModel
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }

        [HttpPost("WriteoffPart")]
        public async Task<IActionResult> WriteoffPart([FromBody] WriteoffPartModel writeoffPartModel)
        {
            var content = new PostWriteoffPartCommand
            {
              writeoffPartModel = writeoffPartModel
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }

        [HttpPost("WriteEverythingOff")]
        public async Task<IActionResult> WriteEverythingOff([FromBody] WriteEverythingOffModel1 writeEverythingOffModel1 )
        {
            var content = new PostWriteEverythingOffCommand
            {
               writeEverythingOffModel1 = writeEverythingOffModel1
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }

        [HttpPost("Return")]
        public async Task<IActionResult> Return([FromBody] RefundModel refundModel)
        {
            var content = new PostRefundCommand
            {
               refundModel = refundModel
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }


        [HttpPost("Cancellation")]
        public async Task<IActionResult> Cancellation([FromBody] CancellationPaymentModel cancellationPaymentModel)
        {
            var content = new CancellationPaymentCommand
            {
              cancellationPaymentModel = cancellationPaymentModel
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }

        [HttpPost("CreateReceiptOnPayment")]
        public async Task<IActionResult> CreateReceiptOnPayment([FromBody] CheckPayment.PaymentRequestModel checkPayment)
        {
            var content = new PostCreateReceiptOnPaymentCommand
            {
                checkPayment = checkPayment
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }
    }

}
