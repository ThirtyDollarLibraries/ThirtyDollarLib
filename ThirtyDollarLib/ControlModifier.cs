using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtyDollarLib
{
    /// <summary>
    /// A modifier that can be appended into certain <see cref="ItemType"/>s.
    /// </summary>
    public enum ControlModifier
    {
        /// <summary>
        /// No modifier
        /// </summary>
        None,
        // Set is same as None since they are the same in a typical sequence file
        /// <summary>
        /// A modifier to set a value. This is identical to <see cref="ControlModifier.None"/> behind-the-scenes, and is just used to make code more readable
        /// </summary>
        Set,
        /// <summary>
        /// A modifer to add a value.
        /// </summary>
        Add,
        /// <summary>
        /// A modifier to multiply a value.
        /// </summary>
        Multiply
    }
}
