using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yookassa.Application.CQRS.Command.PostCreatePaymentCommand;
using Yookassa.Application.Interface;

namespace ConsoleApp1
{
    public class Test
    {
        

       
       
        public async void Create()
        {
            CreatePayment createPayment = new CreatePayment();


            bool test = true;
            var content = await createPayment.CreatePaymentAsync("350", "RUB", "Покупка газеты", test, "google.ru", "666");
            
        }
    }
}
