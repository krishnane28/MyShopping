using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShopping.App_Code
{
    public class GenericFactory<T, I> where T : I
    {
        public static I CreateInstance()
        {
            return (I)Activator.CreateInstance(typeof(T));
        }
    }
}