using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CRS.Models;
using CRS.Models.DTOs;
using IT.IRepository;

namespace CRS.Services
{
    public class CommentsService : BaseService
    {

        public CommentsService(IUnitOfWork uow, int accessCode)
            :base(uow, accessCode)
        {
        }

        public IList<Comments> GetAllComments()
        {
            return base.FindAll<Comments>();
        }

        public void AddComment(Comments comment)
        {
            base.Add<Comments>(comment);
        }
    }
}
