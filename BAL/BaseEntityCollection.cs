using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL
{
    /// <summary>
    /// Provides a base class for entity collection
    /// </summary>
    public abstract partial class BaseEntityCollection<T> : List<T> where T : BaseEntity, new()
    {

    }
}
