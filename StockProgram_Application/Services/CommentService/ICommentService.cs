using StockProgram_Domain.Models;

namespace StockProgram.Services.CommentService
{
    public interface ICommentService
    {
        Task<List<Comment>> GetComments();

        Task<Comment?> GetCommentById(int id);

        Task<bool> CreateNewComment(Comment comment);
        
        Task<bool> DeleteComment(int id);

        Task<bool> UpdateComment(Comment comment);  
    }
}
