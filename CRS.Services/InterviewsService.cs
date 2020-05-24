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
    public class InterviewsService : BaseService
    {
        public InterviewsService(IUnitOfWork uow)
            :base(uow)
        {

        }

        public IList<Interviews> GetAllInterviews()
        {
            return base.FindAll<Interviews>();
        }

        public void AddInterview(Interviews interview)
        {
            base.Add<Interviews>(interview);
        }
    }
}
