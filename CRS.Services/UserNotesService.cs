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
    public class UserNotesService : BaseService
    {

        public UserNotesService(IUnitOfWork uow)
            :base(uow)
        {
        }

        public IList<UserNotes> GetAllUserNotes()
        {
            return base.FindAll<UserNotes>();
        }

        public void AddUserNote(UserNotes feedback)
        {
            base.Add<UserNotes>(feedback);
        }
    }
}
