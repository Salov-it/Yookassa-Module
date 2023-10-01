using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Yookassa.Application.Configs;
using Yookassa.Application.CQRS.Command.PostCancellationPaymentCommand;
using Yookassa.Application.CQRS.Command.PostCreateCheckCommand;
using Yookassa.Application.CQRS.Command.PostCreatePaymentCommand;
using Yookassa.Application.CQRS.Command.PostRefundCommand;
using Yookassa.Application.CQRS.Command.PostWriteEverythingOffCommand;
using Yookassa.Application.CQRS.Command.PostWriteoffPartCommand;
using Yookassa.Application.Interface;

namespace Yookassa.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddYookassaApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            // services.AddScoped<>():
            services.AddScoped<ICreatePayment, CreatePayment>();
            services.AddScoped<IConfig, Config>();
            services.AddScoped<PostCreatePaymentCommand>();
            services.AddScoped<PostCreatePaymentHandle>();
            services.AddScoped<PostCreatePaymentCheckCommand>();
            services.AddScoped<PostCreatePaymentCheckHandle>();

            services.AddScoped<IWriteEverythingOff, WriteEverythingOff>();
            services.AddScoped<PostWriteEverythingOffCommand>();
            services.AddScoped<PostWriteEverythingOffHandle>();


            services.AddScoped<ICancellationPayment,CancellationPayment>();
            services.AddScoped<CancellationPaymentCommand>();
            services.AddScoped<CancellationPaymentHandler>();

            services.AddScoped<IRefund,Refund>();
            services.AddScoped<PostRefundCommand>();
            services.AddScoped<PostRefundHandler>();

            services.AddScoped<ICreateReceiptOnPayment,CreateReceiptOnPayment>();
            services.AddScoped<PostCreateReceiptOnPaymentCommand>();
            services.AddScoped<PostCreateReceiptOnPaymentHandler>();

            services.AddScoped<IWriteoffPart, WriteoffPart>();
            services.AddScoped<PostWriteoffPartCommand>();
            services.AddScoped<PostWriteoffPartHandle>();


            return services;
        }
    }
}
