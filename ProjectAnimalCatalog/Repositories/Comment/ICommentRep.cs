using ProjectAnimalCatalog.Models;

namespace ProjectAnimalCatalog.Repositories
{
    public interface ICommentRep
    {
        #region Comment Repository Inteface
        public void NewComment(Comment comment);
        #endregion
    }
   
}
