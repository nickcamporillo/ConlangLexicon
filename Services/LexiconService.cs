using IModels;
using IRepository;
using IServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services
{
    public class LexiconService<T> : BaseService<T>, ILexiconService<T> where T:class,new()
    {
        public event EventHandler RollingBackTransaction;

        //IUnitOfWork is passed in by the ServiceFacttory
        public LexiconService(IUnitOfWork uow)
            : base(uow)
        {
        }
        public override void Add(T entity)
        {
            base.Add(entity);
        }

        public void Dispose()
        {
            _uow = null;
        }

        public override IList<T> FindAll()
        {
            return base.FindAll().ToList();
        }

        public override IList<TInterface> FindAllOf<TInterface>()
        {
            return _uow.GetRepository<T>().FindAll().OfType<TInterface>().ToList();
        }

        public override T FindItem(Expression<Func<T, bool>> predicate)
        {
            return base.FindItem(predicate);
        }

        public override IList<T> FindItems(Expression<Func<T, bool>> predicate)
        {
            return base.FindItems(predicate);
        }

        public override IList<TInterface> FindItemsOf<TInterface>(Expression<Func<T, bool>> predicate)
        {
            return this.FindItems(predicate).OfType<TInterface>().ToList();
        }

        public override void Remove(T entity)
        {
            base.Remove(entity);
        }

        public override void RollBack()
        {
            base.RollBack();
            RollingBackTransaction?.Invoke(this, new EventArgs());
        }

        public override void SaveAndCommit()
        {
            _uow.SaveChanges();
        }

        public IModel GetFirstItem()
        {
            var item = (FindAll() as IList<LexiconRaw>).OrderBy(c => c.Entry).FirstOrDefault();

            return item;
        }

        public object GetSortedItems()
        {
            //I can't cast directly; I have to use LINQ
            //to get the IList of the ILexiconSummary
            IList<ILexiconSummary> items =
                (from item in FindAll() as IList<LexiconRaw>
                 orderby item.Entry, item.Meaning
                 select new LexiconRaw
                 {
                     Id = item.Id,
                     Entry = item.Entry,
                     Meaning = item.Meaning,
                     SecondaryMeanings = item.SecondaryMeanings,
                     Gender = item.Gender,
                     NounIncorporatedForm = item.NounIncorporatedForm,
                     Pos = item.Pos,
                     Dialect = item.Dialect,
                     EntryDate = item.EntryDate
                 } as ILexiconSummary)
                 .ToList();

            return items;
        }

        public object SearchByEntry(string searchString, SearchStartPoint searchStartPoint)
        {
            var list = new List<ILexiconSummary>();

            if (searchStartPoint == SearchStartPoint.BeginningOfWord)
            {
                list = (GetSortedItems() as IList<ILexiconSummary>)
                        .Where(c => !string.IsNullOrWhiteSpace(c.Entry) &&
                               c.Entry
                               .ToLower()
                               .StartsWith(searchString.ToLower())
                        ).ToList();
            }
            else
            {
                list = (GetSortedItems() as IList<ILexiconSummary>)
                        .Where(c => !string.IsNullOrWhiteSpace(c.Entry) &&
                               c.Entry
                               .ToLower()
                               .Contains(searchString.ToLower())
                        ).ToList();
            }
            return list;
        }
        public object SearchByMeaning(string searchString, SearchStartPoint searchStartPoint)
        {
            var list = new List<ILexiconSummary>();

            if (searchStartPoint == SearchStartPoint.BeginningOfWord)
            {
                list = (GetSortedItems() as IList<ILexiconSummary>)
                        .Where(c => !string.IsNullOrWhiteSpace(c.Entry) &&
                               c.Meaning
                               .ToLower()
                               .StartsWith(searchString.ToLower())
                        ).ToList();
            }
            else
            {
                list = (GetSortedItems() as IList<ILexiconSummary>)
                        .Where(c => !string.IsNullOrWhiteSpace(c.Entry) &&
                               c.Meaning
                               .ToLower()
                               .Contains(searchString.ToLower())
                        ).ToList();
            }
            return list;
        }
        

        //public IList<IDataServicesInvoker> AddTargetInvoker<T>(IEnumerationDetail registryItem,  GetDataFromLambda<T> queryByLambda, Func<T, bool> predicate)
        //{
        //    if (this.SafeToRegister(registryItem))
        //    {
        //        _invokerRegistry.Add(new DataserviceGetDataInvoker<T>(registryItem, queryByLambda, predicate));
        //    }
        //    return _invokerRegistry;
        //}

        //private bool SafeToRegister(IEnumerationDetail registryItem)
        //{
        //    bool retVal = false;

        //    if (this.RegisteredEnumerationIds.Contains(registryItem.Id) == false)
        //    {
        //        this.RegisteredEnumerationIds.Add(registryItem.Id);
        //        retVal = true;
        //    }            

        //    return retVal;
        //}

        //public void ClearInvokerList()
        //{
        //    this.RegisteredEnumerationIds.Clear();
        //    _invokerRegistry.Clear();
        //}

        //public object yep(IEnumerationDetail registryItem, IEnumerationDetail selectedEnumDetail)
        //{
        //    if (_invokerRegistry == null)
        //    {
        //        _invokerRegistry = new List<IDataServicesInvoker>();
        //        return null;
        //    }

        //    IDataServicesInvoker selectAll = null;
        //    IDataServicesInvoker selectSubset = null;
        //    IList<IDataServicesInvoker> dataResultInvokers = new List<IDataServicesInvoker>();

        //    object resultSet = null;

        //    dataResultInvokers = _invokerRegistry.ToList();

        //    foreach (IDataServicesInvoker invoker in dataResultInvokers)
        //    {
        //        if (invoker != null && invoker.EnumerationDetail != null)
        //        {
        //            invoker.Execute(selectedEnumDetail);
        //            resultSet = invoker.DataResultSet;
        //            if (resultSet != null)
        //            {
        //                return resultSet;
        //            }
        //        }
        //    }

        //    return resultSet;
        //}
    }
}




//private string CreateSqlInsert()
//{
//    string sqlInsert = string.Empty;

//    string substring1 = "'LanguageId','Entry','IPA','Meaning','SecondaryMeanings','Synonyms','Dialect','Register','Gender','NounIncorporatedForm','Pos','PosSubtype','Domain','Etymology','GrammaticalNotes','AdditionalNotes','AlternateForms','EntryDate','DeactivatedDate'";
//    string substring2 = "{0},N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}',N'{16}',N'{17}',N'{18}'";
//    List<string> items = new List<string>();

//    items.Add(LanguageId.ToString());

//    Entry = (string.IsNullOrEmpty(Entry) ? "" :  Entry);            
//    IPA = (string.IsNullOrEmpty(IPA) ? "" : IPA);             
//    Meaning = (string.IsNullOrEmpty(Meaning) ? "" : Meaning);            
//    SecondaryMeanings = (string.IsNullOrEmpty(SecondaryMeanings) ? "" : SecondaryMeanings);            
//    Synonyms = (string.IsNullOrEmpty(Synonyms) ? "" :  Synonyms);       

//    Dialect = (string.IsNullOrEmpty(Dialect) ? "" : Dialect);            
//    Register = (string.IsNullOrEmpty(Register) ? "" : Register);

//    Gender = (string.IsNullOrEmpty(Gender) ? "" : Gender);            
//    NounIncorporatedForm = (string.IsNullOrEmpty(NounIncorporatedForm) ? "" : NounIncorporatedForm);            
//    Pos = (string.IsNullOrEmpty(Pos) ? "" : Pos);            
//    PosSubtype = (string.IsNullOrEmpty(PosSubtype) ? "" : PosSubtype);            
//    Domain = (string.IsNullOrEmpty(Domain) ? "" : Domain);

//    Etymology = (string.IsNullOrEmpty(Etymology) ? "" : Etymology);            
//    GrammaticalNotes = (string.IsNullOrEmpty(GrammaticalNotes) ? "" :GrammaticalNotes);            
//    AdditionalNotes = (string.IsNullOrEmpty(AdditionalNotes) ? "" : AdditionalNotes);            
//    AlternateForms = (string.IsNullOrEmpty(AlternateForms) ? "" : AlternateForms);

//    EntryDate = (string.IsNullOrEmpty(EntryDate) ? "" : EntryDate);             
//    DeactivatedDate = (string.IsNullOrEmpty(DeactivatedDate) ? "" : DeactivatedDate);	

//    items.Add(Entry);
//    items.Add(IPA);
//    items.Add(Meaning);
//    items.Add(SecondaryMeanings);
//    items.Add(Synonyms);

//    items.Add(Dialect);
//    items.Add(Register);

//    items.Add(Gender);
//    items.Add(NounIncorporatedForm);
//    items.Add(Pos);
//    items.Add(PosSubtype);
//    items.Add(Domain);

//    items.Add(Etymology);
//    items.Add(GrammaticalNotes);
//    items.Add(AdditionalNotes);
//    items.Add(AlternateForms);
//    items.Add(EntryDate);
//    items.Add(DeactivatedDate);

//    sqlInsert = string.Format("INSERT INTO LexiconRaw (" + substring1 + ") VALUES (" + substring2 + ")", items.ToArray());

//    return sqlInsert;
//}