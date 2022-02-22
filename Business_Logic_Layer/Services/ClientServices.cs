using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Business_Logic_Layer.Utilities;
using Data_Access_Layer.Entities;
using Data_Access_Layer.RepositoryWithUOW;
using Microsoft.EntityFrameworkCore;

namespace Business_Logic_Layer.Services
{
    public class ClientServices : IClientServices
    {
        private readonly IUnitOfWork _UnitOfWork;

        public ClientServices(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public void CreateClient(ClientModel client)
        {
            Client clientEntity = AutoMappers<ClientModel, Client>.Map(client);
            _UnitOfWork.Client.Add(clientEntity);
            _UnitOfWork.Complete();
        }

        public void DeleteClient(int id)
        {
            var clientToDelete = _UnitOfWork.Client.GetById(id);
             _UnitOfWork.Client.Delete(clientToDelete);
            _UnitOfWork.Complete();
        }

        public IEnumerable<ClientModel> GetAllClients()
        {
            var clients =  _UnitOfWork.Client.GetAll()
                .Include(o => o.Orders)
                .Include(f => f.Feedbacks);
            IEnumerable<ClientModel> clientsModel = AutoMappers<Client, ClientModel>.MapIQueryable(clients);
            return clientsModel;
        }

        public ClientModel GetClientById(int id)
        {
            var client =  _UnitOfWork.Client.GetAll()
                .Include(o => o.Orders)
                .Include(f => f.Feedbacks)
                .FirstOrDefault(c => c.ClientId == id);
            ClientModel clientModel = AutoMappers<Client, ClientModel>.Map(client);
            return clientModel;
        }

        public ClientModel GetClientByEmail(string email)
        {
            var client = _UnitOfWork.Client.GetAll()
                .Include(o => o.Orders)
                .Include(f => f.Feedbacks)
                .FirstOrDefault(c => c.Email == email);
            ClientModel clientModel = AutoMappers<Client, ClientModel>.Map(client);
            return clientModel;
        }

        public void UpdateClient(ClientModel client)
        {
            var clientToUpdate = _UnitOfWork.Client.GetById(client.ClientId);
            clientToUpdate.FirstName = client.FirstName;
            clientToUpdate.LastName = client.LastName;
            clientToUpdate.PhoneNumber = client.PhoneNumber;
            clientToUpdate.Email = client.Email;
            _UnitOfWork.Complete();
        }

        // Additional methods -----------------------------------------------

        public IEnumerable<FeedbackModel> GetAllClientFeedbacks(int id)
        {
            var feedbacks = _UnitOfWork.Feedback.GetAll().Where(c => c.Client.ClientId == id);
            IEnumerable<FeedbackModel> feedbackModels = AutoMappers<Feedback, FeedbackModel>.MapIQueryable(feedbacks);
            return feedbackModels;
        }

        public IEnumerable<OrderModel> GetAllClientOrders(int id)
        {
            var orders = _UnitOfWork.Order.GetAll().Where(o => o.Client.ClientId == id);
            IEnumerable<OrderModel> orderModels = AutoMappers<Order, OrderModel>.MapIQueryable(orders);
            return orderModels;
        }
    }
}
