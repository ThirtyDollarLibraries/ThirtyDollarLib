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
                    $"{ItemConverter.ConvertItem(i.Type)}@{i.Pitch}{ItemConverter.GetModifier(i.Modifier)}{((i.RepeatCount != null) ? $"={i.RepeatCount}" : "")}"
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
            Sequence seq = new Sequence(new List<Item>());
            string[] items = sequenceString.Split('|');

            foreach (string i in items)
            {
                string[] equals = i.Split('=');

                string[] sections;

                if (equals.Length > 0) sections = equals[0].Split('@');
                else sections = i.Split('@');

                switch (sections.Length)
                {
                    case 1:
                        seq.Items.Add(new Item(ItemConverter.FromItem(sections[0]), 0, ControlModifier.None, (equals.Length > 1) ? int.Parse(equals[1]) : null));
                        break;
                    case 2:
                        seq.Items.Add(new Item(ItemConverter.FromItem(sections[0]), float.Parse(sections[1]), ControlModifier.None, (equals.Length > 1) ? int.Parse(equals[1]) : null));
                        break;
                    case 3:
                        seq.Items.Add(new Item(ItemConverter.FromItem(sections[0]), float.Parse(sections[1]), ItemConverter.FromStringModifier(sections[2]), (equals.Length > 1) ? int.Parse(equals[1]) : null));
                        break;
                }
            }

            return seq;
        }
    }
}
