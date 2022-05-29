namespace ThirtyDollarLib
{
    internal class ItemConverter
    {
        public static string ConvertItem(ItemType item)
        {
            // colon why did you add so much sounds i had to type for hours straight
            return item switch
            {
                // controls
                ItemType.Speed => "!speed",
                ItemType.Volume => "!volume",
                ItemType.Stop => "!stop",
                ItemType.LoopMany => "!loopmany",
                ItemType.LoopTarget => "!looptarget",
                ItemType.Loop => "!loop",
                ItemType.Cut => "!cut",
                ItemType.Combine => "!combine",
                ItemType.Jump => "!jump",
                ItemType.Target => "!target",
                ItemType.Flash => "!flash",
                ItemType.StartPos => "!startpos",
                ItemType.Pause => "_pause",
                // sounds
                ItemType.Boom => "boom",
                ItemType.Bruh => "bruh",
                ItemType.TacoBell => "bong",
                ItemType.Skull => "💀",
                ItemType.Clap => "👏",
                ItemType.WhatTheDogDoin => "🐶",
                ItemType.BogosBinted => "👽",
                ItemType.NotificationBell => "🔔",
                ItemType.Boing => "💢",
                ItemType.Fard => "💨",
                ItemType.WindowsXPError => "🚫",
                ItemType.SamsungAlarm => "🌄",
                ItemType.Bonk => "🏏",
                _ => "unknown"
            };
        }

        public static ItemType FromItem(string item)
        {
            return item switch
            {
                // controls
                "!speed" => ItemType.Speed,
                "!volume" => ItemType.Volume,
                "!stop" => ItemType.Stop,
                "!loopmany" => ItemType.LoopMany,
                "!looptarget" => ItemType.LoopTarget,
                "!loop" => ItemType.Loop,
                "!cut" => ItemType.Cut,
                "!combine" => ItemType.Combine,
                "!jump" => ItemType.Jump,
                "!target" => ItemType.Target,
                "!flash" => ItemType.Flash,
                "!startpos" => ItemType.StartPos,
                "_pause" => ItemType.Pause,
                _ => ItemType.Boom
            };
        }

        public static string GetModifier(ControlModifier mod)
        {
            return mod switch
            {
                ControlModifier.Add => "@+",
                ControlModifier.Multiply => "@x",
                _ => string.Empty
            };
        }

        public static ControlModifier FromStringModifier(string mod)
        {
            return mod switch
            {
                "+" => ControlModifier.Add,
                "x" => ControlModifier.Multiply,
                _ => ControlModifier.None
            };
        }
    }
}