using Microsoft.EntityFrameworkCore;
using StockProgram_Domain.Models;
using StockProgram_Domain.Repositories.CommentRepository;
using StockProgram_Infrastructure.Data;

namespace StockProgram.Repositories.CommentRepository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CommentRepository(ApplicationDBContext dBContext) {
            _dbContext = dBContext;
        }

        public async Task<bool> CreateNewComment(Comment comment)
        {
            bool result = false;
            try
            {
                _dbContext.Comments.Add(comment);
                await _dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result; 
        }

        public async Task<bool> DeleteComment(int id)
        {
            bool result = false;
            try
            {
                var comment = await _dbContext.Comments.FirstOrDefaultAsync(s => s.Id == id);
                if (comment != null) {
                    _dbContext.Comments.Remove(comment);
                    await _dbContext.SaveChangesAsync();
                    result = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _dbContext.Comments.ToListAsync();
        }

        public async Task<Comment?> GetCommentById(int id)
        {
            return await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateComment(Comment comment)
        {
            bool result = false;
            try
            {
                _dbContext.Comments.Update(comment);
                await _dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
