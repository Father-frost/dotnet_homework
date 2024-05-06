using EllipticCurve.Utils;
using HelpDesk_BLL.Contracts;
using HelpDesk_BLL.Contracts.Identity;
using HelpDesk_DAL;
using HelpDesk_DomainModel.Models.ECommerce;
using HelpDesk_DomainModel.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HelpDesk_BLL.Services.Identity
{
    internal class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public OrderService(
            IUnitOfWork unitOfWork,
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public Task<List<OrderBriefModel>> FetchOrders(long skip, long take, string? searchString, OrderStatusEnum? status)
        {
            var repo = _unitOfWork.GetRepository<Order>();

            var query = repo.AsReadOnlyQueryable();


            if (!string.IsNullOrEmpty(searchString))
            {
                query = from order in query
                        where order.User.Id == searchString
                        //|| order.EmployeeId == searchString
						select order;
            }

            if (status != null)
            {
                query = from order in query
                        where order.Status == status
                        select order;
            }

            var projectedQuery = from order in query
                                 select new OrderBriefModel
                                 {
                                     Id = order.Id,
                                     User = order.User,
                                     OrderText = order.OrderText,
                                     Date = order.Date,
                                     Status = order.Status,
                                     Address = order.Address,
                                     Phone = order.Phone,
                                     MinCost = order.MinCost,
                                     MaxCost = order.MaxCost,
                                 };

            return projectedQuery.Skip((int)skip).Take((int)take).ToListAsync();
        }      
        
        public Task<List<OrderBriefModel>> FetchOrdersForEmployee(long skip, long take, string? searchString, OrderStatusEnum? status)
        {
            var repo = _unitOfWork.GetRepository<Order>();

            var query = repo.AsReadOnlyQueryable();



                query = from order in query
                        where order.EmployeeId == 1
						select order;


            if (status != null)
            {
                query = from order in query
                        where order.Status == status
                        select order;
            }

            var projectedQuery = from order in query
                                 select new OrderBriefModel
                                 {
                                     Id = order.Id,
                                     User = order.User,
                                     OrderText = order.OrderText,
                                     Date = order.Date,
                                     Status = order.Status,
                                     Address = order.Address,
                                     Phone = order.Phone,
                                     MinCost = order.MinCost,
                                     MaxCost = order.MaxCost,
                                 };

            return projectedQuery.Skip((int)skip).Take((int)take).ToListAsync();
        }

        public async Task<Order> GetOrderById(long? orderId)
        {
            var repo = _unitOfWork.GetRepository<Order>();

            var order = repo.AsReadOnlyQueryable()
                .FirstOrDefault(ord => ord.Id == orderId);

            return order;
        }

        public async Task<Order> CreateOrder(OrderBriefModel order)
        {
            var repo = _unitOfWork.GetRepository<Order>();



            var newDbOrder = new Order
            {
                User = order.User,
                OrderText = order.OrderText,
                Date = order.Date,
                Status = order.Status,
                Address = order.Address,
                Phone = order.Phone,
                MinCost = order.MinCost,
                MaxCost = order.MaxCost,
            };

            var trackedOrder = repo.Create(newDbOrder);

            await _unitOfWork.SaveChangesAsync();

            return trackedOrder;
        }

        public async Task WriteOrder(OrderBriefModel orderToWrite)
        {
            var repo = _unitOfWork.GetRepository<Order>();

            var user = await _userService.GetUserById(orderToWrite.UserId);

			var newOrder = new Order
			{
                User = user,
				Date = orderToWrite.Date,
				OrderText = orderToWrite.OrderText,
				Status = orderToWrite.Status,
				Address = orderToWrite.Address,
				Phone = orderToWrite.Phone,
				MinCost = orderToWrite.MinCost,
				MaxCost = orderToWrite.MaxCost,
			};

			repo.InsertOrUpdate(
            order => order.Id == orderToWrite.Id,
            newOrder
            );

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteOrder(long orderId)
        {
            var repo = _unitOfWork.GetRepository<Order>();
            var trackedOrder = repo
                .AsQueryable()
                .First(ord => ord.Id == orderId);

            repo.Delete(trackedOrder);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
