using ProjectAnimalCatalog.Data;
using ProjectAnimalCatalog.Models;
using ProjectAnimalCatalog.Repositories;
using System.Linq;

namespace ProjectAnimalCatalog.Repositories
{
    public class CommentRep : ICommentRep
    {
        #region Dependency Injection
        private readonly ASPNETCOREPROJECTContext _context;
        public CommentRep(ASPNETCOREPROJECTContext context)
        {
            _context = context;
        }
        #endregion
        #region New Comment
        public void NewComment(Comment comment)
        {
            if (_context.Comments.Any() != true)
            {
                comment.CommentId = 1;
                _context.Comments.Add(comment);
                _context.SaveChanges();
            }
            else
            {
                comment.CommentId = _context.Comments.Max(comment => comment.CommentId) + 1;
                _context.Comments.Add(comment);
                _context.SaveChanges();
            }
        }
        #endregion
    }
}
