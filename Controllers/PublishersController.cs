using System;
using System.Collections.Generic;
using BookManagementAPI.Interface;
using BookManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementAPI.Controllers
{
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _repo;

        public PublisherController(
            IPublisherService repo
        )
        {
            _repo = repo;
        }

        [HttpGet("/publisher")]
        public ActionResult<IEnumerable<Publisher>> Get()
        {
            var publishers = _repo.GetAllPublishers();
            return Ok(publishers);
        }

        [HttpGet("/publisher/{id}")]
        public ActionResult<Publisher> Get(int id)
        {
            var publisher = _repo.GetOnePublisher(id);
            return Ok(publisher);
        }

        [HttpPost("/publisher")]
        public ActionResult<Publisher> Post(Publisher model)
        {
            try
            {
                var publisher = _repo.AddPublisher(model);
                return new CreatedResult("/publisher/", new {Id = publisher.Id, message="Publisher Added Successfully"});
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message});
            }
        }

        [HttpPatch("/publisher/{id}")]
        public ActionResult<Publisher> Patch(int id, Publisher model)
        {
            try
            {
                var publisher = _repo.UpdatePatchPublisher(id, model);
                return new OkObjectResult(new { message = "Publisher Detail Updated successfully", id});
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

        [HttpPut("/publisher/{id}")]
        public ActionResult<Publisher> Put(int id, Publisher model)
        {
            try
            {
                var publisher = _repo.UpdatePutPublisher(id, model);
                return new OkObjectResult(new {message = "Publisher Details Updated successfully", id });
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

    }
}