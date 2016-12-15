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
    public class UserSegmentManager : IUserSegmentManager
    {
        private readonly IUoW _uow;
        public UserSegmentManager(IUoW uow)
        {
            _uow = uow;
        }

        public IResponse<NoValue> AddUserSegment(UserSegmentCreateModel createModel)
        {
            Logger.Message($"AddUserSegment({createModel.Name})");

            var result = new Response<NoValue>();
            try
            {

                var userSegment = new UserSegment
                {
                    Name = createModel.Name,
                    ZipCode = createModel.ZipCode,
                    DateOfBirthFrom = createModel.DateOfBirthFrom,
                    DateOfBirthTo = createModel.DateOfBirthTo,
                    Gender = (int)createModel.Gender
                };

                _uow.UserSegments.Add(userSegment);
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

        public IResponse<NoValue> DeleteUserSegment(long id)
        {
            Logger.Message($"DeleteUserSegment({id})");

            var result = new Response<NoValue>();
            try
            {
                var userSegment = _uow.UserSegments.Get(id);

                if (userSegment.Offer.Any())
                {
                    result.Message = Message.SegmentInUse;
                    result.Status = Status.Error;
                }
                else
                {
                    _uow.UserSegments.Remove(userSegment);
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

        public IResponse<UserSegmentCreateModel> GetUserSegment(long id)
        {
            Logger.Message($"GetUserSegment({id})");

            var result = new Response<UserSegmentCreateModel>();
            try
            {

                var userSegment = _uow.UserSegments.Get(id);

                var model = new UserSegmentCreateModel
                {
                    UserSegmentID = userSegment.UserSegmentID,
                    Gender = (Gender)userSegment.Gender,
                    Name = userSegment.Name,
                    ZipCode = userSegment.ZipCode,
                    DateOfBirthFrom = userSegment.DateOfBirthFrom,
                    DateOfBirthTo = userSegment.DateOfBirthTo
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

        public List<UserSegmentViewModel> GetUserSegments()
        {
            Logger.Message($"GetUserSegments");

            try
            {
                var userSegments = _uow.UserSegments.GetAll();

                var result = userSegments.Select(u => new UserSegmentViewModel
                {
                    UserSegmentID = u.UserSegmentID,
                    Name = u.Name,
                    DateOfBirthFrom = u.DateOfBirthFrom,
                    DateOfBirthTo = u.DateOfBirthTo,
                    ZipCode = u.ZipCode,
                    Gender = (Gender)u.Gender,
                    Assigned = u.Offer.Any()

                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                Logger.ErrorWithException(ex);
                return null;
            }
        }

        public IResponse<UserSegmentCreateModel> NewUserSegmentModel()
        {
            Logger.Message("NewUserSegmentModel");

            try
            {
                var result = new UserSegmentCreateModel();
                return new Response<UserSegmentCreateModel>()
                {
                    Value = result,
                    Status = Status.Success
                };
            }
            catch (Exception ex)
            {
                Logger.ErrorWithException(ex);

                return new Response<UserSegmentCreateModel>()
                {
                    Message = Message.SomethingWrongError,
                    Status = Status.Error
                };
            }
        }

        public IResponse<NoValue> UpdateUserSegment(UserSegmentCreateModel model)
        {
            Logger.Message($"UpdateUserSegment({model.UserSegmentID})");

            var result = new Response<NoValue>();
            try
            {
                var userSegment = _uow.UserSegments.Get(model.UserSegmentID);

                userSegment.Name = model.Name;
                userSegment.ZipCode = model.ZipCode;
                userSegment.Gender = (int)model.Gender;
                userSegment.DateOfBirthFrom = model.DateOfBirthFrom;
                userSegment.DateOfBirthTo = model.DateOfBirthTo;

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
