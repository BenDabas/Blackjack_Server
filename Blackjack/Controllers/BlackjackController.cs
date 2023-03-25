using Blackjack.Models;
using Blackjack.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Blackjack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlackjackController : ControllerBase
    {
        private readonly BlackjackService _blackjackService;

        public BlackjackController(BlackjackService blackjackService)
        {
            _blackjackService = blackjackService;
        }

        [HttpPost("start")]
        public ActionResult StartNewGame()
        {
            try
            {
                _blackjackService.StartNewGame();
                return Ok(_blackjackService.GetGame());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("hit")]
        public ActionResult<Game> PlayerHit()
        {
            try
            {
                _blackjackService.PlayerHits();
                return Ok(_blackjackService.GetGame());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("stand")]
        public ActionResult<Game> PlayerStand()
        {
            try
            {
                _blackjackService.PlayerStand();
                return Ok(_blackjackService.GetGame());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("end-game")]
        public ActionResult<Game> EndGame()
        {
            try
            {
                _blackjackService.EndGame();
                return Ok(_blackjackService.GetGame());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("dealer-play")]
        public ActionResult<Game> DealerPlay()
        {
            try
            {
                _blackjackService.DealerPlayes();
                return Ok(_blackjackService.GetGame());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("player-bust")]
        public ActionResult<Game> PlayerBust()
        {
            try
            {
                _blackjackService.PlayerBust();
                return Ok(_blackjackService.PlayerBust());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("calculate-player-hand")]
        public ActionResult<Game> CalculatePlayerHand()
        {
            try
            {                
                return Ok(_blackjackService.CalculatePlayerHand());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("calculate-dealer-hand")]
        public ActionResult<int> CalculateDealerHand()
        {
            try
            {                
                return Ok(_blackjackService.CalculateDealerHand());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
