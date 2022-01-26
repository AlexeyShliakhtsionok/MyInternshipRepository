using Business_Logic_Layer.Models;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IClientServices
    {
        public IEnumerable<ClientModel> GetAllClients();
        public ClientModel GetClientById(int id);
        public void CreateClient(ClientModel client);
        public void UpdateClient();
        public void DeleteClient(int id);

        // Additional methods
        public IEnumerable<FeedbackModel> GetAllClientFeedbacks(int id);
        public IEnumerable<OrderModel> GetAllClientOrders(int id);

    }
}
