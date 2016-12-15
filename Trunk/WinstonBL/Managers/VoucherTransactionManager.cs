using System;
using System.Linq;
using Winston.BL.Interfaces;
using Winston.Common;
using Winston.DAL;
using Winston.DAL.UoW;
using Winston.Models;

namespace Winston.BL.Managers
{
    public class VoucherTransactionManager : IVoucherTransactionManager
    {
        private readonly IUoW _uow;

        public VoucherTransactionManager(IUoW uow)
        {
            _uow = uow;
        }

        public IResponse<NoValue> AddVoucherTransaction(VoucherTransactionCreateModel model)
        {
            Logger.Message($"AddVoucherTransaction(KeyAccountID: {model.KeyAccountID}, UserVoucherID: {model.UserVoucherID}");

            var result = new Response<NoValue>();
            try
            {
                var userVoucher = _uow.UserVouchers.Get(model.UserVoucherID);

                var voucherTransaction = new VoucherTransaction
                {
                    UserVoucherID = model.UserVoucherID,
                    VoucherID = userVoucher.VoucherID,
                    UserID = userVoucher.UserID,
                    OfferID = userVoucher.OfferID,
                    KeyAccountID = model.KeyAccountID,
                    Amount = userVoucher.Voucher.Amount, // unclear purpose, require further clarification
                    TimeStamp = DateTime.UtcNow
                };

                _uow.VoucherTransactions.Add(voucherTransaction);
                userVoucher.Valid = false;
                _uow.Complete();
                result.Status = Status.Success;
            }
            catch (Exception ex)
            {
                result.Message = Message.SomethingWrongError;
                result.Status = Status.Error;
                Logger.ErrorWithException(ex);
            }

            return result;
        }

        public IResponse<VoucherTransactionCreateModel> NewVoucherTransactionModel(long id)
        {
            Logger.Message($"NewVoucherTransactionModel({id})");

            var userVouchers = _uow.UserVouchers.GetAll().Where(w => w.Valid && (w.Voucher.KeyAcountID == id || w.Voucher.KeyAcountID == null));

            var result = new VoucherTransactionCreateModel()
            {
                KeyAccountID = id,
                UserVoucherList = userVouchers.Select(s => new Item { Id = s.UserVoucherID, Value = s.Code }).ToList()
            };

            return new Response<VoucherTransactionCreateModel>()
            {
                Value = result,
                Status = Status.Success
            };
        }
    }
}
