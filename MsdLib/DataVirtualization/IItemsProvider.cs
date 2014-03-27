using System;
using System.Collections.Generic;

namespace MsdLib.CSharp.DataVirtualization
{
    /// <summary>
    /// Represents a provider of collection details.
    /// </summary>
    /// <typeparam name="T">The type of items in the collection.</typeparam>
    public interface IItemsProvider<T> : ICloneable 
    {
        
        /// <summary>
        /// Fetches the total number of items available.
        /// </summary>
        /// <returns></returns>
        int FetchCount();

        /// <summary>
        /// Fetches a range of items.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The number of items to fetch.</param>
        /// <returns></returns>
        IList<T> FetchRange(int startIndex, int count);

        

        //DataVirtualization.test.Loading BeforeLoad { get; set; }
        //DataVirtualization.test.Loaded AfterLoad { get; set; }
    }
}
