using StockProgram.Services.CommentService;
using StockProgram_Domain.Models;
using StockProgram_Domain.Repositories.CommentRepository;

namespace StockProgram_Application.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Task<bool> CreateNewComment(Comment comment)
        {
            return _commentRepository.CreateNewComment(comment);
        }

        public Task<bool> DeleteComment(int id)
        {
            return _commentRepository.DeleteComment(id);
        }

        public Task<Comment?> GetCommentById(int id)
        {
            return _commentRepository.GetCommentById(id);
        }

        public Task<List<Comment>> GetComments()
        {
            return _commentRepository.GetAllComments();
        }

        public Task<bool> UpdateComment(Comment comment)
        {
            return _commentRepository.UpdateComment(comment);
        }
    }
}
