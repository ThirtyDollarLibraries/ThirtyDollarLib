using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtyDollarLib
{
    /// <summary>
    /// A collection of <see cref="Item"/>s that can be converted into or parsed from a compatible Thirty Dollar Website file format.
    /// </summary>
    public class Sequence
    {
        private readonly string? _sequenceStr;
        public List<Item> Items { get; set; } = new List<Item>();
        public Sequence() { }
        public Sequence(string seq)
        {
            _sequenceStr = seq;
        }
        public Sequence(params Item[] items)
        {
            Items = items.ToList();
        }
        public Sequence(List<Item> items)
        {
            Items = items;
        }

        /// <summary>
        /// Converts the Sequence into a valid sequence string.
        /// </summary>
        /// <returns>The sequence string</returns>
        public override string ToString()
        {
            if (_sequenceStr != null) return _sequenceStr;
            else return string.Join('|', 
                Items.Select(i => 
                    $"{ItemConverter.ConvertItem(i.Type)}{((i.RepeatCount != null) ? $"={i.RepeatCount}" : "")}@{i.Pitch}{ItemConverter.GetModifier(i.Modifier)}"
                )
            );
        }

        /// <summary>
        /// Converts a <see cref="string"/> containing sequence data into a brand-new Sequence class
        /// </summary>
        /// <param name="sequenceString">The sequence data</param>
        /// <returns>A new <see cref="Sequence"/> constructed from the data</returns>
        public static Sequence Parse(string sequenceString)
        {
            List<Item> items = new();
            List<string> rawItems = sequenceString.Split('|').ToList();

            for (int i = 0; i < rawItems.Count; i++)
            {
                string[] splitted = rawItems[i].Split('@');

                if (splitted.Length == 0) items.Add(new Item(ItemConverter.FromItem(rawItems[i])));
                else if (splitted.Length == 2) items.Add(new Item(ItemConverter.FromItem(splitted[0]), int.Parse(splitted[1])));
                else if (splitted.Length == 3) items.Add(new Item(ItemConverter.FromItem(splitted[0]), int.Parse(splitted[1]), ItemConverter.FromStringModifier(splitted[2])));

            }

            return new Sequence(items);
        }
    }
}
