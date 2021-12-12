﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;

namespace Lexicon.Legacy2019.Repositories
{
    //[CBorillo] By inheriting from ObjectContext and implementing IContext, I don't have to inherit from project-specific "DataModel.edmx" anymore
    public class EfContext : ObjectContext, IContext  
    {
        #region contructor
        /// <summary>
        /// DO NOT USE THIS CONSTRUCTOR!!!! Use Second constructor instead and instantiate in the factory "ContextFactory"!!!!
        /// That's why I made this constructor private, to prevent usage from the outside!   :-)
        /// </summary>
        private EfContext()
            : base("")
        {
            throw new Exception("Don't use this constructor!!!!");
            //base.SavingChanges += new EventHandler(EfContext_SavingChanges);
        }

        /// <summary>
        /// This should be used by only one class: the ContextFactory class.
        /// </summary>
        /// <param name="connectionString"></param>
        public EfContext(string connectionString)
            : base(connectionString)
        {
            base.SavingChanges += new EventHandler(EfContext_SavingChanges);
        }

        #endregion

        #region public
        public new int SaveChanges()
        {
            IEnumerable<ObjectStateEntry> changes =
               this.ObjectStateManager.GetObjectStateEntries(EntityState.Modified);

            return base.SaveChanges();           
        }
        #endregion

        #region private
        private void EfContext_SavingChanges(object sender, EventArgs e)
        {
            IEnumerable<ObjectStateEntry> changes =
               this.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted | EntityState.Modified);
        }

        #endregion
    }
}