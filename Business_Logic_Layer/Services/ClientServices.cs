using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Business_Logic_Layer.Utilities;
using Data_Access_Layer.Entities;
using Data_Access_Layer.RepositoryWithUOW;

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
            Client clientEntity = GenericAutoMapper<ClientModel, Client>.Map(client);
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
            var clients =  _UnitOfWork.Client.GetAll();
            IEnumerable<ClientModel> clientsModel = GenericAutoMapper<Client, ClientModel>.MapEnumerable(clients);
            return clientsModel;
        }

        public ClientModel GetClientById(int id)
        {
            var client =  _UnitOfWork.Client.GetById(id);
            ClientModel clientModel = GenericAutoMapper<Client, ClientModel>.Map(client);
            return clientModel;
        }

        public void UpdateClient()
        {
            _UnitOfWork.Complete();
            throw new NotImplementedException();
        }

        // Additional methods -----------------------------------------------

        public IEnumerable<FeedbackModel> GetAllClientFeedbacks(int id)
        {
            var feedbacks = _UnitOfWork.Feedback.GetAll().Where(c => c.Client.ClientId == id);
            IEnumerable<FeedbackModel> feedbackModels = GenericAutoMapper<Feedback, FeedbackModel>.MapEnumerable(feedbacks);
            return feedbackModels;
        }

        public IEnumerable<OrderModel> GetAllClientOrders(int id)
        {
            var orders = _UnitOfWork.Order.GetAll().Where(o => o.Client.ClientId == id);
            IEnumerable<OrderModel> orderModels = GenericAutoMapper<Order, OrderModel>.MapEnumerable(orders);
            return orderModels;
        }

    }
}
