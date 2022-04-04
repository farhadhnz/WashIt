using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WashIt.API.DTOs;
using WashIt.API.Models;
using WashIt.API.Service;

namespace WashIt.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaitListController : ControllerBase
    {
        private readonly IWaitListService waitListService;
        private readonly IMapper mapper;

        public WaitListController(IWaitListService waitListService, IMapper mapper)
        {
            this.waitListService = waitListService;
            this.mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateWaitingListItem(WaitingListDto waitingListDto)
        {
            var waitListItem = mapper.Map<WaitingListItem>(waitingListDto);

            waitListService.CreateWaitingListItem(waitListItem);

            return Ok();
        }
    }
}