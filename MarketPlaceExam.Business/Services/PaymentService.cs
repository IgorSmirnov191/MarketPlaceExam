using AutoMapper;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Business.Services
{
    public class PaymentService : IPaymentService
    {
        // Dependencies
        private IPaymentRepo _repo;

        public PaymentService(IPaymentRepo repo)
        {
            _repo = repo;
        }

        // TODO: Perform mappings using Automapper instead of manually.
        // TODO: CRUD.
        public async Task AddPayment(PaymentModel payment)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentModel, Payment>());
            var mapper = new Mapper(config);
            var paymentEntity = mapper.Map<PaymentModel, Payment>(payment);
            await _repo.AddPayment(paymentEntity);
        }

        public async Task<PaymentModel> GetPayment(int id)
        {
            Payment paymentEntity = await _repo.GetPayment(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Payment, PaymentModel>());
            var mapper = new Mapper(config);
            var model = mapper.Map<Payment, PaymentModel>(paymentEntity);
            return model;
        }
        public async Task UpdatePayment(PaymentModel payment)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentModel, Payment>());
            var mapper = new Mapper(config);
            var paymentEntity = mapper.Map<PaymentModel, Payment>(payment);
            await _repo.UpdatePayment(paymentEntity);
        }

        public async Task DeletePayment(int id)
        {
            await _repo.DeletePayment(id);
        }
    }
}
