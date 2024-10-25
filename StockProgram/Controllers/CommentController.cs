using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StockProgram.Services.CommentService;
using StockProgram_API.Dtos.Comment;
using StockProgram_API.Mappers;
using StockProgram_Domain.Models;

namespace StockProgram_API.Controllers
{
    [Route("api/v1/comment")]

    public class CommentController : Controller
    {
        private ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("/getAllComments")]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentService.GetComments();
            var commentsResult = comments.Select(s => s.ToCommentDTO()).ToList();
            return Ok(commentsResult);
        }

        [HttpGet("getComment/{id}")]
        public async Task<IActionResult> GetComment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comments = await _commentService.GetCommentById(id);
            if (comments == null)
            {
                return NotFound();
            }
            return Ok(comments.ToCommentDTO());
        }

        [HttpPost("")]
        [Authorize]
        public async Task<IActionResult> CreateNewComment([FromBody] CreateCommentDTO commentDTO)
        {
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }
            var commentModel = commentDTO.ToCommentCreateDTO();
            await _commentService.CreateNewComment(commentModel);
            return CreatedAtAction(nameof(GetComment), new {id = commentModel.Id}, commentModel);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateNewComment(int id, [FromBody] UpdateCommentDTO commentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commentModel = commentDTO.ToCommentUpdateDTO();
            if (commentModel == null)
            {
                NotFound();
            }

            commentModel.Title = commentDTO.Title;
            commentModel.Content = commentDTO.Content;
            commentModel.CreatedOn = commentDTO.CreatedOn;
            commentModel.StockId = commentDTO.StockId;

            var result = await _commentService.UpdateComment(commentModel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteComment(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commentModel = await _commentService.GetCommentById(id);
            if (commentModel == null)
            {
                NotFound();
            }
            await _commentService.DeleteComment(id);
            return Ok($"Delete successfully comment id: {id}!");
        }
    }
}
