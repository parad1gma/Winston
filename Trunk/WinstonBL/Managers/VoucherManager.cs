using System;
using System.Collections.Generic;
using System.Linq;
using Winston.BL.Interfaces;
using Winston.Common;
using Winston.DAL;
using Winston.DAL.UoW;
using Winston.Models;

namespace Winston.BL.Managers
{
    public class VoucherManager : IVoucherManager
    {

        private readonly IUoW _uow;

        public VoucherManager(IUoW uow)
        {
            _uow = uow;
        }

        public IResponse<NoValue> AddVoucher(VoucherCreateModel createModel)
        {
            Logger.Message($"AddVoucher({createModel.Name}");

            var result = new Response<NoValue>();
            try
            {

                var voucher = new Voucher
                {
                    Name = createModel.Name,
                    Amount = createModel.Amount,
                    CalculationType = (int)createModel.CalculationType,
                    Type = (int)createModel.Type,
                    Code = createModel.Code,
                    CreatedDate = DateTime.UtcNow,
                    Description = createModel.Description,
                    ExpirationDate = createModel.ExpirationDate,
                    PointCost = createModel.PointCost,
                    Images = createModel.Images,
                    KeyAcountID = createModel.KeyAcountID,
                    OfferID = createModel.OfferID
                };

                _uow.Vouchers.Add(voucher);
                _uow.Complete();
                result.Status = Status.Success;

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("duplicate key"))
                {
                    result.Message = Message.UniqueName;
                }
                else
                {
                    result.Message = Message.SomethingWrongError;
                }

                result.Status = Status.Error;
                Logger.ErrorWithException(ex);
            }

            return result;
        }

        public IResponse<VoucherCreateModel> GetVoucher(long id)
        {
            Logger.Message($"Getuser({id})");

            var result = new Response<VoucherCreateModel>();
            try
            {

                var voucher = _uow.Vouchers.Get(id);

                var model = new VoucherCreateModel
                {

                    VoucherID = voucher.VoucherID,
                    Type = (VoucherType)voucher.Type,
                    PointCost = voucher.PointCost,
                    KeyAcountID = voucher.KeyAcountID,
                    Images = voucher.Images,
                    Amount = voucher.Amount,
                    CalculationType = (CalculationType)voucher.CalculationType,
                    Code = voucher.Code,
                    CreatedDate = voucher.CreatedDate,
                    Description = voucher.Description,
                    ExpirationDate = voucher.ExpirationDate,
                    Name = voucher.Name,
                    KeyAccounts = _uow.KeyAccounts.GetAll().Select(s => new Item { Id = s.KeyAccountID, Value = s.Name }).ToList(),
                    Offers = _uow.Offers.GetAll().Select(s => new Item { Id = s.OfferID, Value = s.Title }).ToList(),
                    OfferID = voucher.OfferID
                };
                result.Value = model;
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

        public List<VoucherViewModel> GetVouchers()
        {
            Logger.Message($"GetVouchers");

            try
            {
                var vouchers = _uow.Vouchers.GetAll();
                var keyAccounts = _uow.KeyAccounts.GetAll();
                var offers = _uow.Offers.GetAll();

                var result = vouchers.Select(u => new VoucherViewModel
                {
                    VoucherID = u.VoucherID,
                    Name = u.Name,
                    Amount = u.Amount,
                    CalculationType = (CalculationType)u.CalculationType,
                    Code = u.Code,
                    CreatedDate = u.CreatedDate,
                    Description = u.Description,
                    ExpirationDate = u.ExpirationDate,
                    Images = u.Images,
                    KeyAccountName = keyAccounts.Where(w => w.KeyAccountID == u.KeyAcountID).Select(s => s.Name).FirstOrDefault(),
                    OfferName = offers.Where(w => w.OfferID == u.OfferID).Select(s => s.Title).FirstOrDefault(),
                    PointCost = u.PointCost,
                    Type = (VoucherType)u.Type,
                    Assigned = u.UserVoucher.Any() || u.VoucherTransaction.Any()

                }).ToList();

                return result;

            }
            catch (Exception ex)
            {
                Logger.ErrorWithException(ex);
                return null;
            }
        }

        public IResponse<VoucherCreateModel> NewVoucherModel()
        {
            Logger.Message("NewVoucherModel");

            try
            {
                var keyAccounts = _uow.KeyAccounts.GetAll();
                var offers = _uow.Offers.GetAll();

                var result = new VoucherCreateModel()
                {

                    KeyAccounts = keyAccounts.Select(s => new Item() { Id = s.KeyAccountID, Value = s.Name }).ToList(),
                    Offers = offers.Select(s => new Item() { Id = s.OfferID, Value = s.Title }).ToList()
                };


                return new Response<VoucherCreateModel>()
                {
                    Value = result,
                    Status = Status.Success
                };
            }
            catch (Exception ex)
            {
                Logger.ErrorWithException(ex);

                return new Response<VoucherCreateModel>()
                {
                    Message = Message.SomethingWrongError,
                    Status = Status.Error
                };
            }
        }

        public IResponse<NoValue> DeleteVoucher(long id)
        {
            Logger.Message($"DeleteVoucher({id})");

            var result = new Response<NoValue>();
            try
            {
                var voucher = _uow.Vouchers.Get(id);

                if (voucher.UserVoucher.Any() || voucher.VoucherTransaction.Any())
                {
                    result.Message = Message.VoucherInUse;
                    result.Status = Status.Error;
                }
                else
                {
                    _uow.Vouchers.Remove(voucher);
                    _uow.Complete();
                    result.Status = Status.Success;
                }
            }
            catch (Exception ex)
            {
                result.Message = Message.SomethingWrongError;
                result.Status = Status.Error;
                Logger.ErrorWithException(ex);
            }

            return result;
        }

        public IResponse<NoValue> UpdateVaucher(VoucherCreateModel model)
        {
            Logger.Message($"UpdateOffer({model.VoucherID})");

            var result = new Response<NoValue>();
            try
            {
                var voucher = _uow.Vouchers.Get(model.VoucherID);

                voucher.Name = model.Name;
                voucher.PointCost = model.PointCost;
                voucher.Type = (int)model.Type;
                voucher.KeyAcountID = model.KeyAcountID;
                voucher.Images = model.Images;
                voucher.ExpirationDate = model.ExpirationDate;
                voucher.Code = model.Code;
                voucher.CalculationType = (int)model.CalculationType;
                voucher.Description = model.Description;
                voucher.PointCost = model.PointCost;
                voucher.OfferID = model.OfferID;
                voucher.Amount = model.Amount;

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
    }
}
