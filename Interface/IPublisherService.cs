using System.Collections.Generic;
using BookManagementAPI.Models;

namespace BookManagementAPI.Interface
{
    public interface IPublisherService
    {
        List<Publisher> GetAllPublishers();

        Publisher GetOnePublisher(int id);

        Publisher AddPublisher(Publisher model);

        Publisher UpdatePutPublisher(int id, Publisher model);

        Publisher UpdatePatchPublisher(int id, Publisher model);
    }
}