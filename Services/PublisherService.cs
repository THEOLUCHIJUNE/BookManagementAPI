using System;
using BookManagementAPI.Interface;
using BookManagementAPI.Models;
using System.Collections.Generic;
using System.Linq;
using BookManagementAPI.DatabaseContext;

namespace BookManagementAPI.Service
{
    public class PublisherService : IPublisherService
    {
        private readonly ApplicationDbContext _context;
        public PublisherService(
            ApplicationDbContext context
        )

        {
            _context = context;
        }

        public List<Publisher> GetAllPublishers()
        {
            return _context.Publishers.ToList();
        }
        public Publisher GetOnePublisher(int id)
        {
            return _context.Publishers.FirstOrDefault(PID => PID.Id == id);
        }
        public Publisher AddPublisher(Publisher model)
        {
            if(model is null) throw new ArgumentNullException(message: "Publisher cannot be null", null);

            var publisher = new Publisher
            {
                Id = model.Id,
                Name = model.Name,
                State = model.State,
                Gender = model.Gender

            };

            _context.Publishers.Add(publisher);
            _context.SaveChanges();

            return publisher;
                
        }

        public Publisher UpdatePutPublisher(int id, Publisher model)
        {
            var publisher = GetOnePublisher(id);
            

            if (publisher is null) throw new ArgumentOutOfRangeException(message: "Publisher cannot be null", null);
            
            
            publisher.Name = model.Name;
            publisher.State = model.State;
            publisher.Gender = model.Gender;
            

            _context.Publishers.Update(publisher);
            _context.SaveChanges();

            return publisher;
                
        }

        public Publisher UpdatePatchPublisher(int id, Publisher model)
        {
            var publisher = GetOnePublisher(id);

            if (publisher is null) throw new ArgumentOutOfRangeException(message: "No publisher with this Id found", null);

            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                publisher.Name = model.Name;
            }
            if (!string.IsNullOrWhiteSpace(model.State))
            {
                publisher.State = model.State;
            }
            if (!string.IsNullOrWhiteSpace(model.Gender))
            {
                publisher.Gender = model.Gender;
            }

            _context.Publishers.Update(publisher);
            _context.SaveChanges();

            return publisher;
                
        }
                
        
    }
}