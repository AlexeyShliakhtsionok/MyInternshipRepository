using Business_Logic_Layer.DBO.Clients;
using Business_Logic_Layer.DBO.Feedbacks;
using Business_Logic_Layer.DBO.Orders;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IClientServices
    {
        public IEnumerable<ClientsInformationViewModel> GetAllClients();
        public ClientViewModel GetClientById(int id);
        public ClientToFeedbackCreationViewModel GetClientByEmail(string email);
        public void CreateClient(ClientViewModel client);
        public void UpdateClient(ClientViewModel client);
        public void DeleteClient(int id);
        public IEnumerable<ClientViewModel> GetAllClientsWithFeedbacks();
        public IEnumerable<ClientViewModel> GetAllClientsWithOrders();

        // Additional methods
        public SelectList GetClientsSelectList();
        public IEnumerable<FeedbackViewModel> GetAllClientFeedbacks(int id);
        public IEnumerable<OrderViewModel> GetAllClientOrders(int id);
    }
}
