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
        private IMapper _mapper;
        public PaymentService(IPaymentRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task AddPayment(PaymentModel payment)
        {
            Payment paymentEntity = _mapper.Map<PaymentModel, Payment>(payment);
            await _repo.AddPayment(paymentEntity);
        }

        public async Task<PaymentModel> GetPayment(int id)
        {
            Payment paymentEntity = await _repo.GetPayment(id);
            PaymentModel model = _mapper.Map<Payment, PaymentModel>(paymentEntity);
            return model;
        }
        public async Task UpdatePayment(PaymentModel payment)
        {
            Payment paymentEntity = _mapper.Map<PaymentModel, Payment>(payment);
            await _repo.UpdatePayment(paymentEntity);
        }

        public async Task DeletePayment(int id)
        {
            await _repo.DeletePayment(id);
        }
    }
}
