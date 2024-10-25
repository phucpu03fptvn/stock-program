using StockProgram_Domain.Models;

namespace StockProgram_Domain.Repositories.CommentRepository
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllComments();

        Task<Comment?> GetCommentById(int id);

        Task<bool> CreateNewComment(Comment comment);

        Task<bool> DeleteComment(int id); 

        Task<bool> UpdateComment(Comment comment);
    }
}
