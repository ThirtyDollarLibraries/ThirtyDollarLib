namespace ThirtyDollarLib
{
    internal class ItemConverter
    {
        public static string ConvertItem(ItemType item)
        {
            string referenceSeq = "!speed|!volume|!stop|!loopmany|!loop|!looptarget|!cut|!combine|!jump|!target|!flash|!startpos|_pause|boom|bruh|bong|💀|👏|🐶|👽|🔔|💢|💨|🚫|🌄@0|🏏|🤬|🚨|buzzer|❗|🦀|e|eight|🍕|🦢|gun|hitmarker|👌|whatsapp|gnome|💿|🎉|🎻|pan|slip|whipcrack|explosion|oof|subaluwa|necoarc|yoda|hehehehaw|granddad|morshu|stopposting|21|op|SLAM|americano|smw_coin|smw_1up|smw_spinjump|smw_stomp2|smw_kick|smw_stomp|yahoo|sm64_hurt|bup|thwomp|sm64_painting|smm_scream|mariopaint_mario|mariopaint_luigi|smw_yoshi|mariopaint_star|mariopaint_flower|mariopaint_gameboy|mariopaint_dog|mariopaint_cat|mariopaint_swan|mariopaint_baby|mariopaint_plane|mariopaint_car|shaker|🥁|hammer|🪘|sidestick|ride2|buttonpop|skipshot|otto_on|otto_off|otto_happy|otto_stress|tab_sounds|tab_rows|tab_actions|tab_decorations|tab_rooms|preecho|tonk|rdmistake|samurai|adofaikick|midspin|adofaicymbal|cowbell|karateman_throw|karateman_offbeat|karateman_hit|karateman_bulb|ook|choruskid|builttoscale|perfectfail|🌟|hoenn|🎺|fnf_left|fnf_down|fnf_up|fnf_right|fnf_death|megalovania|🦴|undertale_encounter|undertale_hit|undertale_crack|toby|gaster|gdcrash|gdcrash_orbs|gd_coin|gd_orbs|gd_diamonds|bwomp|isaac_hurt|isaac_dead|isaac_mantle|terraria_star|terraria_pot|terraria_reforge|BABA|YOU|DEFEAT|celeste_dash|celeste_death|celeste_spring|celeste_diamond|ultrainstinct|flipnote|amongus|amongdrip|amogus|noteblock_harp|noteblock_bass|noteblock_snare|noteblock_click|noteblock_bell|noteblock_chime|noteblock_banjo|noteblock_pling|noteblock_xylophone|noteblock_bit|minecraft_explosion|minecraft_bell";
            string[] instruments = referenceSeq.Split('|');

            return instruments[(int)item];
        }

        public static ItemType FromItem(string item)
        {
            string referenceSeq = "!speed|!volume|!stop|!loopmany|!loop|!looptarget|!cut|!combine|!jump|!target|!flash|!startpos|_pause|boom|bruh|bong|💀|👏|🐶|👽|🔔|💢|💨|🚫|🌄@0|🏏|🤬|🚨|buzzer|❗|🦀|e|eight|🍕|🦢|gun|hitmarker|👌|whatsapp|gnome|💿|🎉|🎻|pan|slip|whipcrack|explosion|oof|subaluwa|necoarc|yoda|hehehehaw|granddad|morshu|stopposting|21|op|SLAM|americano|smw_coin|smw_1up|smw_spinjump|smw_stomp2|smw_kick|smw_stomp|yahoo|sm64_hurt|bup|thwomp|sm64_painting|smm_scream|mariopaint_mario|mariopaint_luigi|smw_yoshi|mariopaint_star|mariopaint_flower|mariopaint_gameboy|mariopaint_dog|mariopaint_cat|mariopaint_swan|mariopaint_baby|mariopaint_plane|mariopaint_car|shaker|🥁|hammer|🪘|sidestick|ride2|buttonpop|skipshot|otto_on|otto_off|otto_happy|otto_stress|tab_sounds|tab_rows|tab_actions|tab_decorations|tab_rooms|preecho|tonk|rdmistake|samurai|adofaikick|midspin|adofaicymbal|cowbell|karateman_throw|karateman_offbeat|karateman_hit|karateman_bulb|ook|choruskid|builttoscale|perfectfail|🌟|hoenn|🎺|fnf_left|fnf_down|fnf_up|fnf_right|fnf_death|megalovania|🦴|undertale_encounter|undertale_hit|undertale_crack|toby|gaster|gdcrash|gdcrash_orbs|gd_coin|gd_orbs|gd_diamonds|bwomp|isaac_hurt|isaac_dead|isaac_mantle|terraria_star|terraria_pot|terraria_reforge|BABA|YOU|DEFEAT|celeste_dash|celeste_death|celeste_spring|celeste_diamond|ultrainstinct|flipnote|amongus|amongdrip|amogus|noteblock_harp|noteblock_bass|noteblock_snare|noteblock_click|noteblock_bell|noteblock_chime|noteblock_banjo|noteblock_pling|noteblock_xylophone|noteblock_bit|minecraft_explosion|minecraft_bell";
            string[] instruments = referenceSeq.Split('|');

            return (ItemType)instruments.ToList().FindIndex(i => i == item);
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