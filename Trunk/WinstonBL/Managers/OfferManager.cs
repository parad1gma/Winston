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
    public class OfferManager : IOfferManager
    {
        private readonly IUoW _uow;

        public OfferManager(IUoW uow)
        {
            _uow = uow;
        }

        public IResponse<NoValue> AddOffer(OfferCreateModel model)
        {
            Logger.Message($"AddOffer({model.Title})");

            var result = new Response<NoValue>();
            try
            {
                var offer = new Offer
                {
                    Title = model.Title,
                    DateFrom = model.DateFrom,
                    DateTo = model.DateTo,
                    UserSegmentID = model.UserSegment,
                    Messages = model.Messages,
                    Active = true,
                };

                _uow.Offers.Add(offer);
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

        public List<OfferViewModel> GetOffers()
        {
            Logger.Message("GetOffers");

            var offers = _uow.Offers.GetAll();

            var result = offers.Select(o => new OfferViewModel
            {
                OfferID = o.OfferID,
                Title = o.Title,
                DateFrom = o.DateFrom,
                DateTo = o.DateTo,
                UserSegment = o.UserSegmentID,
                UserSegmentName = o.UserSegment.Name,
                Messages = o.Messages,
                Active = o.Active
            }).ToList();

            return result;
        }

        public IResponse<OfferViewModel> GetOffer(long id)
        {
            Logger.Message($"GetOffer({id})");

            var result = new Response<OfferViewModel>();
            try
            {
                var offer = _uow.Offers.Get(id);
                OfferViewModel model = new OfferViewModel
                {
                    OfferID = offer.OfferID,
                    Title = offer.Title,
                    DateFrom = offer.DateFrom,
                    DateTo = offer.DateTo,
                    UserSegment = offer.UserSegmentID,
                    Messages = offer.Messages,
                    Active = offer.Active
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

        public IResponse<OfferCreateModel> NewOfferModel()
        {
            Logger.Message("NewOfferModel");

            OfferCreateModel model = new OfferCreateModel()
            {
                UserSegmentList = _uow.UserSegments
                .GetAll()
                .Select(v => new Item
                {
                    Id = v.UserSegmentID,
                    Value = v.Name
                })
                .ToList()
            };

            return new Response<OfferCreateModel>()
            {
                Value = model,
                Status = Status.Success
            };
        }

        public IResponse<NoValue> UpdateOffer(OfferCreateModel model)
        {
            Logger.Message($"UpdateOffer({model.OfferID})");

            var result = new Response<NoValue>();
            try
            {
                var offer = _uow.Offers.Get(model.OfferID);

                offer.Title = model.Title;
                offer.DateFrom = model.DateFrom;
                offer.DateTo = model.DateTo;
                offer.UserSegmentID = model.UserSegment;
                offer.Messages = model.Messages;
                offer.Active = model.Active;

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

        public IResponse<NoValue> DeleteOffer(long id)
        {
            Logger.Message($"DeleteOffer({id})");

            var result = new Response<NoValue>();
            try
            {
                var offer = _uow.Offers.Get(id);

                offer.Active = false;

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

        public IResponse<OfferCreateModel> EditOffer(int id)
        {
            Logger.Message($"EditOffer({id})");

            var result = new Response<OfferCreateModel>();
            try
            {
                var offer = _uow.Offers.Get(id);
                OfferCreateModel model = new OfferCreateModel
                {
                    OfferID = offer.OfferID,
                    Title = offer.Title,
                    DateFrom = offer.DateFrom,
                    DateTo = offer.DateTo,
                    UserSegment = offer.UserSegmentID,
                    Messages = offer.Messages,
                    Active = offer.Active,

                    UserSegmentList = _uow.UserSegments
                    .GetAll()
                    .Select(us => new Item
                    {
                        Id = us.UserSegmentID,
                        Value = us.Name
                    })
                    .ToList()
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