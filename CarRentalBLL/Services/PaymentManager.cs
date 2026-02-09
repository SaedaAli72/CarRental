using CarRentalBLL.Services.Interface;
using CarRentalDAL.Entities;
using CarRentalDAL.Enums;
using CarRentalDAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Services
{
    public class PaymentManager : IPaymentManager
    {
        private readonly IUnitOfWork _unitOfWork;


        // الـ Constructor
        public PaymentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // إنشاء Payment جديد
        public Payment CreatePayment(Payment payment)
        {
            _unitOfWork.payments.Add(payment);
            _unitOfWork.Save();

            return payment;
        }

        // جلب Payment بالـ ID
        public Payment GetPaymentById(Guid id)
        {
            return _unitOfWork.payments.GetById(p=>p.Id==id);
        }

        // تحديث Payment
        public Payment UpdatePayment(Payment payment)
        {
            _unitOfWork.payments.Update(payment);
            _unitOfWork.Save();

            return payment;
        }

        // جلب كل الـ Payments الخاصة بـ Rental معين
        public List<Payment> GetPaymentsByRentalId(Guid rentalId)
        {
            return _unitOfWork.payments.GetAll()
                .Where(p => p.RentalId == rentalId)
                .OrderByDescending(p => p.PaymentDate)
                .ToList();
        }
    }
}
