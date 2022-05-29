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

        public Item(ItemType type)
        {
            Type = type;
            Pitch = 0;
            Modifier = ControlModifier.None;
        }

        public Item(ItemType type, float pitch)
        {
            Type = type;
            Pitch = pitch;
            Modifier = ControlModifier.None;
        }

        public Item(ItemType type, float pitch, ControlModifier modifier)
        {
            Type = type;
            Pitch = pitch;
            Modifier = modifier;
        }
    }
}
