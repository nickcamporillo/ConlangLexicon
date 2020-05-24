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
    public class InterviewFeedbacksService : BaseService
    {

        public InterviewFeedbacksService(IUnitOfWork uow)
            :base(uow)
        {
        }

        public IList<InterviewFeedback> GetAllInterviewFeedbacks()
        {
            return base.FindAll<InterviewFeedback>();
        }

        public void AddApplicant(InterviewFeedback feedback)
        {
            base.Add<InterviewFeedback>(feedback);
        }
    }
}
