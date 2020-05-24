using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IT.IRepository;

using CRS.App_Level;
using CRS.Models.Interfaces;
using CRS.Models.DTOs;
using LambdaRegistry = CRS.Models.LambdaRegistry;
using LambdaRegistryDetail = CRS.Models.LambdaRegistryDetail;

namespace CRS.Services
{
    public class LambdaRegistryService: BaseService
    {
        public LambdaRegistryService(IUnitOfWork uow, int accessCode)
            : base(uow, accessCode)
        {
            base.AccessCode = accessCode;
        }

        internal IList<ILambdaRegistry> GetAllRegisteredLambdaInfos()
        {
            IList<ILambdaRegistry> retVal = base.FindAll<LambdaRegistry>() as IList<ILambdaRegistry>;
            return retVal;
        }

        internal IList<ILambdaRegistryDetail> GetUsersLambdaInfo()
        {
            var lambdaRegistryDetails = base.FindAll<LambdaRegistryDetail>().Where(c=>c.LambdaRegistry.RoleId == base.AccessCode).ToList();
            List<ILambdaRegistryDetail> detailSubset = new List<ILambdaRegistryDetail>();
            detailSubset.AddRange(lambdaRegistryDetails);

            return detailSubset;
        }

        internal ILambdaRegistry GetLambdaInfoByEnumerationDetail(IEnumerationDetail detail)
        {
            return base.FindItem<ILambdaRegistry>(c => c.EnumerationDetailsId == detail.Id);
        }

        internal void AddLambdaInfo(ILambdaRegistry registeredLambda)
        {
            base.Add<ILambdaRegistry>(registeredLambda);
        }

    }
}
