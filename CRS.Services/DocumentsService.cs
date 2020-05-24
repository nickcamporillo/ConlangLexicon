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
    public class DocumentsService : BaseService
    {
        public DocumentsService(IUnitOfWork uow)
            :base(uow)
        {
        }

        public IList<Documents> GetAllDocuments()
        {
            return base.FindAll<Documents>();
        }

        public void AddDocument(Documents comment)
        {
            base.Add<Documents>(comment);
        }
    }
}
