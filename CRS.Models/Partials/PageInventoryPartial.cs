using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.App_Level;

namespace CRS.Models
{
    //[CBorillo] Notice I'm using explicit implementation of interface member.  This is bc
    //in this partial class, the corresponding PageInventory class is already declared,
    //as an implicit declaration, but it als returns a nullable values.  The explicit
    //implementation you see below allows me to get around the naming collision.
    //Read http://stackoverflow.com/questions/143405/c-sharp-interfaces-implicit-implementation-versus-explicit-implementation
    //for a better understanding.  One positive is that the explicit version enforces
    //"program to the interface, not the implementation".  This is desired if you want
    //to decouple code - see also http://www.artima.com/lejava/articles/designprinciples.html
    public partial class PageInventory: IPageInventoryShared
    {
        int IPageInventoryShared.PageType 
        {
            get 
            {
                return (this._PageType.HasValue ? this._PageType.Value : 0);
            }
            set 
            {
                this._PageType = value;
            } 
        }
    }
}
