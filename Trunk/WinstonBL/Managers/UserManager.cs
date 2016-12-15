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
    public class UserManager : IUserManager
    {
        private readonly IUoW _uow;

        public UserManager(IUoW uow)
        {
            _uow = uow;
        }

        public IResponse<NoValue> AddUser(UserCreateModel createModel, string userId)
        {
            Logger.Message($"Adduser({createModel.Username}, {userId})");

            var result = new Response<NoValue>();
            try
            {
                var user = new User
                {
                    Username = createModel.Username,
                    FirstName = createModel.FirstName,
                    LastName = createModel.LastName,
                    Email = createModel.Email,
                    City = createModel.City,
                    Street = createModel.Street,
                    StreetNumber = createModel.StreetNumber,
                    AdressInfo = createModel.AdressInfo,
                    Password = createModel.Password,
                    ZipCode = createModel.ZipCode,
                    CreatedDate = DateTime.UtcNow,
                    DateOfBirth = createModel.DateOfBirth,
                    Gender = (int)createModel.Gender,
                    PointBalance = 0
                };

                _uow.Users.Add(user);
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

        public IResponse<UserCreateModel> NewUserModel()
        {

            Logger.Message("GetNewUserModel");

            try
            {
                var result = new UserCreateModel();
                return new Response<UserCreateModel>()
                {
                    Value = result,
                    Status = Status.Success
                };
            }
            catch (Exception ex)
            {
                Logger.ErrorWithException(ex);

                return new Response<UserCreateModel>()
                {
                    Message = Message.SomethingWrongError,
                    Status = Status.Error
                };
            }

        }

        public List<UserViewModel> GetUsers()
        {
            Logger.Message($"GetUsers");

            try
            {
                var users = _uow.Users.GetAll();

                var result = users.Select(u => new UserViewModel
                {
                    UserID = u.UserID,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    AdressInfo = u.AdressInfo,
                    City = u.City,
                    CreatedDate = u.CreatedDate,
                    DateOfBirth = u.DateOfBirth,
                    Email = u.Email,
                    PointBalance = u.PointBalance,
                    Street = u.Street,
                    StreetNumber = u.StreetNumber,
                    Username = u.Username,
                    ZipCode = u.ZipCode,
                    Gender = (Gender)u.Gender

                }).ToList();

                return result;

            }
            catch (Exception ex)
            {
                Logger.ErrorWithException(ex);
                return null;
            }

        }

        public IResponse<UserViewModel> GetUser(long id)
        {
            Logger.Message($"GetUser({id})");

            var result = new Response<UserViewModel>();
            try
            {
                var user = _uow.Users.Get(id);
                UserViewModel model = new UserViewModel
                {
                    UserID = user.UserID,
                    Username = user.Username,
                    Password = user.Password,
                    Gender = (Gender)user.Gender,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ZipCode = user.ZipCode,
                    City = user.City,
                    Street = user.Street,
                    StreetNumber = user.StreetNumber,
                    AdressInfo = user.AdressInfo,
                    Email = user.Email,
                    DateOfBirth = user.DateOfBirth,
                    PointBalance = user.PointBalance,
                    CreatedDate = user.CreatedDate
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

        public IResponse<List<UserVoucherViewModel>> GetUserVouchers(long id)
        {
            Logger.Message($"GetUserVouchers({id})");

            var result = new Response<List<UserVoucherViewModel>>();
            try
            {
                var userVouchers = _uow.UserVouchers
                    .GetAll()
                    .Where(w => w.UserID == id)
                    .Select(u => new UserVoucherViewModel
                    {
                        UserVoucherID = u.UserVoucherID,
                        Code = u.Code,
                        OfferID = u.OfferID,
                        OfferTitle = u.Voucher.Offer.Title,
                        VoucherID = u.VoucherID,
                        UserID = u.UserID,
                        ValidFrom = u.ValidFrom,
                        ValidTo = u.ValidTo,
                        RedeemDate = u.RedeemDate,
                        Valid = u.Valid,
                        PointCost = u.Voucher.PointCost
                    }).ToList();

                result.Value = userVouchers;
            }
            catch (Exception ex)
            {
                result.Message = Message.SomethingWrongError;
                result.Status = Status.Error;
                Logger.ErrorWithException(ex);
            }
            return result;
        }

        public UserDetailsModel GetDetails(long id)
        {
            Logger.Message($"GetDetails({id})");

            return new UserDetailsModel()
            {
                UserDetails = GetUser(id),
                UserVouchers = GetUserVouchers(id),
                Vouchers = GetVouchers(id)
            };
        }

        public IResponse<List<VoucherViewModel>> GetVouchers(long id)
        {
            Logger.Message($"GetVouchers({id})");
            var result = new Response<List<VoucherViewModel>>();

            try
            {
                var user = _uow.Users.Get(id);
                var vouchers = _uow.Vouchers.GetAll()
                    .Where(w => (w.Offer.UserSegment.Gender == user.Gender || w.Offer.UserSegment.Gender == (int)Gender.All) &&
                        (w.Offer.UserSegment.ZipCode == user.ZipCode || w.Offer.UserSegment.ZipCode == null) &&
                        ((w.Offer.UserSegment.DateOfBirthFrom <= user.DateOfBirth && w.Offer.UserSegment.DateOfBirthTo >= user.DateOfBirth) ||
                         (w.Offer.UserSegment.DateOfBirthFrom == null && w.Offer.UserSegment.DateOfBirthTo >= user.DateOfBirth) ||
                         (w.Offer.UserSegment.DateOfBirthFrom <= user.DateOfBirth && w.Offer.UserSegment.DateOfBirthTo == null) ||
                         (w.Offer.UserSegment.DateOfBirthFrom == null && w.Offer.UserSegment.DateOfBirthTo == null)) &&
                         (w.Offer.DateFrom.Date <= DateTime.Today && w.Offer.DateTo.Date >= DateTime.Today));

                var voucher = vouchers.Select(u => new VoucherViewModel
                {
                    VoucherID = u.VoucherID,
                    OfferID = u.OfferID,
                    Name = u.Name,
                    Amount = u.Amount,
                    CalculationType = (CalculationType)u.CalculationType,
                    Code = u.Code,
                    CreatedDate = u.CreatedDate,
                    Description = u.Description,
                    ExpirationDate = u.ExpirationDate,
                    Images = u.Images,
                    OfferName = u.Offer.Title,
                    PointCost = u.PointCost,
                    Type = (VoucherType)u.Type,
                    Assigned = u.UserVoucher.Any(),

                }).ToList();

                result.Value = voucher;
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

        public IResponse<NoValue> AddUserVoucher(UserVoucherCreateModel model)
        {
            Logger.Message($"AddUserVoucher(UserID: {model.UserID}, VoucherID: {model.VoucherID}, OfferID: {model.OfferID})");

            var result = new Response<NoValue>();
            var voucher = _uow.Vouchers.Get(model.VoucherID);
            var user = _uow.Users.Get(model.UserID);

            if (voucher.PointCost > user.PointBalance)
            {
                result.Message = Message.NotEnoughtPoints;
                result.Status = Status.Error;
                Logger.Error(Message.NotEnoughtPoints);
            }
            else
            {
                try
                {
                    var date = DateTime.Compare(voucher.ExpirationDate, voucher.Offer.DateTo);

                    var userVoucher = new UserVoucher
                    {
                        Code = user.UserID + DateTime.Now.ToString("yyyyMMddHHmmss") + voucher.Code,
                        OfferID = model.OfferID,
                        VoucherID = model.VoucherID,
                        UserID = model.UserID,
                        ValidFrom = voucher.Offer.DateFrom,
                        ValidTo = (date < 1) ? voucher.ExpirationDate : voucher.Offer.DateTo,
                        RedeemDate = DateTime.UtcNow,
                        Valid = true
                    };

                    _uow.UserVouchers.Add(userVoucher);
                    user.PointBalance = user.PointBalance - voucher.PointCost;
                    _uow.Complete();
                    result.Status = Status.Success;
                }
                catch (Exception ex)
                {
                    result.Message = Message.SomethingWrongError;
                    result.Status = Status.Error;
                    Logger.ErrorWithException(ex);
                }
            }
            return result;
        }

        public IResponse<NoValue> AddPointBalance(long id, string code)
        {
            Logger.Message($"AddPointBalance({id})");

            var result = new Response<NoValue>();
            try
            {
                var user = _uow.Users.Get(id);
                int points = code.Length * 5;

                user.PointBalance = user.PointBalance + points;
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