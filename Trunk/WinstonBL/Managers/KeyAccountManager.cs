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
    public class KeyAccountManager : IKeyAccountManager
    {
        private readonly IUoW _uow;

        public KeyAccountManager(IUoW uow)
        {
            _uow = uow;
        }

        public IResponse<NoValue> AddKeyAccount(KeyAccountCreateModel createModel)
        {
            Logger.Message($"Adduser({createModel.Name}");

            var result = new Response<NoValue>();
            try
            {

                var keyAccount = new KeyAccount
                {
                    Name = createModel.Name,
                    Logo = createModel.Logo,

                };

                _uow.KeyAccounts.Add(keyAccount);
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

        public List<KeyAccountViewModel> GetKeyAccounts()
        {
            Logger.Message($"GetKeyAccounts");

            try
            {
                var keyAccounts = _uow.KeyAccounts.GetAll();

                var result = keyAccounts.Select(k => new KeyAccountViewModel
                {
                    KeyAccountID = k.KeyAccountID,
                    Logo = k.Logo,
                    Name = k.Name,
                    Assigned = k.Voucher.Any()
                }).ToList();

                return result;

            }
            catch (Exception ex)
            {
                Logger.ErrorWithException(ex);
                return null;
            }
        }

        public IResponse<KeyAccountCreateModel> NewKeyAccountModel()
        {
            Logger.Message("NewKeyAccountModel");

            try
            {
                var result = new KeyAccountCreateModel();
                return new Response<KeyAccountCreateModel>()
                {
                    Value = result,
                    Status = Status.Success
                };
            }
            catch (Exception ex)
            {
                Logger.ErrorWithException(ex);

                return new Response<KeyAccountCreateModel>()
                {
                    Message = Message.SomethingWrongError,
                    Status = Status.Error
                };
            }
        }

        public IResponse<NoValue> UpdateKeyAccount(KeyAccountCreateModel model)
        {
            Logger.Message($"UpdateKeyAccount({model.KeyAccountID})");

            var result = new Response<NoValue>();
            try
            {
                var keyAcounts = _uow.KeyAccounts.Get(model.KeyAccountID);

                keyAcounts.Name = model.Name;
                keyAcounts.Logo = model.Logo;


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

        public IResponse<NoValue> DeleteKeyAccount(long id)
        {
            Logger.Message($"DeleteKeyAccount({id})");

            var result = new Response<NoValue>();
            try
            {
                var keyAccount = _uow.KeyAccounts.Get(id);


                _uow.KeyAccounts.Remove(keyAccount);
                _uow.Complete();
                result.Status = Status.Success;
            }
            catch (Exception ex)
            {
                result.Message = Message.UsedRole;
                result.Status = Status.Error;
                Logger.ErrorWithException(ex);
            }

            return result;
        }

        public IResponse<KeyAccountCreateModel> GetKeyAccount(long id)
        {
            Logger.Message($"GetKeyAccount({id})");

            var result = new Response<KeyAccountCreateModel>();
            try
            {
                var keyAccount = _uow.KeyAccounts.Get(id);
                var model = new KeyAccountCreateModel
                {
                    KeyAccountID = keyAccount.KeyAccountID,
                    Name = keyAccount.Name,
                    Logo = keyAccount.Logo
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
    }




}
