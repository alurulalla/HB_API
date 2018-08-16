using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using HummingBoxApp.API.Data;
using HummingBoxApp.API.Dtos;
using HummingBoxApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HummingBoxApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IHBRepository _repo;

        private readonly IMapper _mapper;
        public OrderController(IHBRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpPost("checkout")]
        public async Task<IActionResult> CheckOut([FromBody] OrderForCreationDto orderForCreation)
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var userFromRepo = await _repo.GetUser(orderForCreation.UserId);

            if (currentUserId != userFromRepo.Id)
                return Unauthorized();

            if (userFromRepo == null)
                return NotFound($"Could not find user with an ID of {orderForCreation.UserId}");

            var order = _mapper.Map<Order>(orderForCreation);
            _repo.Add(order);

            if(await _repo.SaveAll())
            {
                foreach (var item in orderForCreation.Items)
                {
                    var itemOrder = _mapper.Map<OrderDetail>(item);
                    itemOrder.OrderId = order.Id;
                    _repo.Add(itemOrder);
                    await _repo.SaveAll();
                }
                return Ok(order);
            }
                

            throw new Exception($"Failed while ordering your food");

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistory(int id)
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var userFromRepo = await _repo.GetUser(id);

            if(userFromRepo == null)
                return NotFound($"Could not find user with an ID of {id}");
            if(currentUserId != userFromRepo.Id)
                return Unauthorized();
            var historyData = _repo.GetUserHistory(id);

            return Ok(historyData.Result);
        }
    }
}