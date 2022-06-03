using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtyDollarLib
{
    /// <summary>
    /// An item that represents a sound placed in a Sequence.
    /// </summary>
    public class Item
    {
        public ItemType Type { get; set; }
        public float Pitch { get; set; }
        public ControlModifier Modifier { get; set; }
        public int? RepeatCount { get; set; }

        public Item(ItemType type)
        {
            Type = type;
            Pitch = 0;
            Modifier = ControlModifier.None;
            RepeatCount = null;
        }

        public Item(ItemType type, float pitch) : this(type)
        {
            Pitch = pitch;
            Modifier = ControlModifier.None;
            RepeatCount = null;
        }

        public Item(ItemType type, float pitch, ControlModifier modifier) : this(type, pitch)
        {
            Modifier = modifier;
            RepeatCount = null;
        }

        public Item(ItemType type, float pitch, ControlModifier modifier, int? repeatCount) : this(type, pitch, modifier)
        {
            RepeatCount = repeatCount;
        }
    }
}
