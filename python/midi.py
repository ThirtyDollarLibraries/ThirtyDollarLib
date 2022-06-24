#
import mido
thirty_dollar_instruments = "_pause|boom|bruh|bong|💀|👏|🐶|👽|🔔|💢|💨|🚫|📲|🌄|🏏|🤬|🚨|buzzer|❗|🦀|e|eight|🍕|🦢|gun|hitmarker|👌|whatsapp|gnome|💿|🎉|🎻|pan|slip|whipcrack|explosion|oof|subaluwa|necoarc|yoda|hehehehaw|granddad|morshu|stopposting|21|op|SLAM|americano|smw_coin|smw_1up|smw_spinjump|smw_stomp2|smw_kick|smw_stomp|yahoo|sm64_hurt|bup|thwomp|sm64_painting|smm_scream|mariopaint_mario|mariopaint_luigi|smw_yoshi|mariopaint_star|mariopaint_flower|mariopaint_gameboy|mariopaint_dog|mariopaint_cat|mariopaint_swan|mariopaint_baby|mariopaint_plane|mariopaint_car|shaker|🥁|hammer|🪘|sidestick|ride2|buttonpop|skipshot|otto_on|otto_off|otto_happy|otto_stress|tab_sounds|tab_rows|tab_actions|tab_decorations|tab_rooms|preecho|tonk|rdmistake|samurai|adofaikick|midspin|adofaicymbal|cowbell|karateman_throw|karateman_offbeat|karateman_hit|karateman_bulb|ook|choruskid|builttoscale|perfectfail|🌟|hoenn|🎺|fnf_left|fnf_down|fnf_up|fnf_right|fnf_death|megalovania|🦴|undertale_encounter|undertale_hit|undertale_crack|toby|gaster|gdcrash|gdcrash_orbs|gd_coin|gd_orbs|gd_diamonds|bwomp|isaac_hurt|isaac_dead|isaac_mantle|terraria_star|terraria_pot|terraria_reforge|BABA|YOU|DEFEAT|celeste_dash|celeste_death|celeste_spring|celeste_diamond|ultrainstinct|flipnote|amongus|amongdrip|amogus|noteblock_harp|noteblock_bass|noteblock_snare|noteblock_click|noteblock_bell|noteblock_chime|noteblock_banjo|noteblock_pling|noteblock_xylophone|noteblock_bit|minecraft_explosion|minecraft_bell".split("|")
class LambdaGetitem:
    def __init__(self,f):
        self.f = f
    def __getitem__(self,i):
        return self.f(i)
import random
thirty_dollar_tonal_instruments = "bong|🔔|🚫|🤬|buzzer|🦢|gnome|morshu|stopposting|op|americano|bup|mariopaint_mario|mariopaint_luigi|mariopaint_star|mariopaint_flower|mariopaint_gameboy|mariopaint_dog|mariopaint_cat|mariopaint_swan|mariopaint_baby|mariopaint_plane|mariopaint_car|tab_sounds|tonk|samurai|cowbell|ook|choruskid|builttoscale|hoenn|🎺|fnf_left|fnf_down|fnf_up|fnf_right|🦴|bwomp|YOU|ultrainstinct|amongdrip|noteblock_harp|noteblock_bass|noteblock_bell|noteblock_chime|noteblock_banjo|noteblock_pling|noteblock_xylophone|noteblock_bit|minecraft_bell".split("|")
thirty_dollar_samenotes = "mariopaint_mario|mariopaint_luigi|mariopaint_star|mariopaint_flower|mariopaint_gameboy|mariopaint_dog|mariopaint_cat|mariopaint_swan|mariopaint_baby|mariopaint_plane|mariopaint_car|cowbell|ook|choruskid|hoenn|🎺|fnf_left|fnf_down|fnf_up|fnf_right|bwomp|noteblock_harp|noteblock_bass|noteblock_bell|noteblock_chime|noteblock_banjo|noteblock_pling|noteblock_xylophone|noteblock_bit|minecraft_bell".split("|")
rand_inst = LambdaGetitem(lambda n:random.choice(thirty_dollar_samenotes))
arrows = LambdaGetitem(lambda n:("fnf_"+["left","down","up","right"][n%4],(n==1)*12+n))

#percussion channel
#midi channel 10 (9 in 0-based ids)  is percussion
# note assignments can be found here: https://musescore.org/sites/musescore.org/files/General%20MIDI%20Standard%20Percussion%20Set%20Key%20Map.pdf
percussion_map = {36:"boom", #todo: fill this dict out
                  }
percussion = LambdaGetitem(lambda n: (percussion_map[n],0) if n in percussion_map else ("_pause",0))

#$30ws syntax: "|" separated things, where args are sep by "@", rle by '='
def to_thirtyDollarWebsite(midi,insts=["noteblock_harp"]*16,bases=[64]*16,vmap = lambda v: v/127,base_speed=200,percuss=percussion_map):
    if type(midi) is str:
        midi = mido.MidiFile(midi)
    msgs = (msg for msg in midi if not msg.is_meta)
    vals = {"control":[[0 for i in range(128)] for j in range(16)],"pitch":[0 for i in range(16)]}
    time_error = 0
    current_speed = base_speed #speed takes effect next, so have to hoist all the speeds up 1 note                                       
    pvol = 1
    yield f"!speed@{current_speed}" #ima do everything multiplicatively on later speeds to ease shenanigans                              
    pnote = None
    overflow = dict()
    for msg in msgs:
        time_error += msg.time #the time until the note starts, controled by the previous note's tempo                                   
        #do message                                                                                                                      
        if msg.type == "note_off":
            pass
        elif msg.type == "note_on":
            if msg.channel == 9 and percuss is not None:
                inst = percuss
            else:
                inst = insts[msg.channel%len(insts)]
            note = msg.note-bases[msg.channel%len(insts)]
            if type(inst) is not str:
                try:
                    inst = inst[note]
                except KeyError:
                    inst = "_pause"
                if type(inst) is tuple: #allow changing of note from inst funcs                                                          
                    inst,note = inst
            vol = vmap(msg.velocity)
            #bpm is clamped to [10,10000]                                                                                                
            bpe = min(10000,60/time_error) if time_error > 0 else 10000
            if time_error <= 0:
                if vol in overflow:
                    overflow[vol] += [(inst,note)]
                else:
                    time_error -= 60/10000
                    overflow[vol] = [(inst,note)]
            else:
                if len(overflow):
                    for vol in overflow:
                        if current_speed != 10000:
                            yield f"!speed@{10000/current_speed}@x"
                            current_speed = 10000
                        if pnote is not None:
                            yield pnote
                        pnote = "|!combine|".join(f"{inst_}@{note_}" for inst_,note_ in overflow[vol])
                        if pvol != vol:
                            yield f"!volume@{vol*100}"
                        elif pnote is not None:
                            pass#pnote_ = pnote+"|!combine|"+pnote_                                                                      
                        pvol = vol
                    overflow = dict()
                n = 1
                if bpe < 10:
                    n = math.ceil(10/bpe)
                    bpe *= n
                if bpe!=current_speed:
                    yield f"!speed@{bpe/current_speed}@x"
                    current_speed = bpe
                if n > 1:
                    yield f"!stop@{n}"
                if pnote is not None:
                    yield pnote
                pnote = f"{inst}@{note}"
                if pvol != vol:
                    yield f"!volume@{vol*100}"
                pvol = vol
                time_error -= n*60/bpe
        elif msg.type == "polytouch":
            pass
        elif msg.type == "control_change":
            vals["control"][msg.channel][msg.control] = msg.value
        elif msg.type == "program_change":
            pass
        elif msg.type == "aftertouch":
            pass
        elif msg.type == "pitchwheel":
            vals["pitch"][msg.channel] = msg.pitch
        elif msg.type == "sysex":
            pass
        elif msg.type == "quarter_frame":
            pass
        elif msg.type == "songpos":
            pass
        elif msg.type == "song_select":
            pass
    if pnote is not None:
        yield pnote




#use:
def write_30dw_song(midi,outname="foo",insts=["noteblock_harp"],bases=[64],suffix=".🗿",whomst=None,**ka):
    with open(outname+suffix,"w") as f:
        f.write("|".join(to_thirtyDollarWebsite(midi,insts,bases,**ka)))
        if whomst is not None:
            f.write(f"|{whomst}") #abuse of the format for lil eastereggs/signatures
    


    
#todo: automatic recognition of loops to make the output shorter
# (note: loops can't be nested normally)






#main stuff for cli execution
if __name__ == "__main__":
    import argparse
    parser = argparse.ArgumentParser(description='use this to thirty dollar some midis.')
    parser.add_argument('inp',metavar="input", type=str,
                        help='The input midi file.')
    parser.add_argument('-o', dest='out', type=str,
                        default=None,
                        help='Output file, ".🗿" may be omitted.')
    parser.add_argument('-s', dest='sign', type=str,
                        default=None,
                        help='Secret thing to append to the end. Leave blank to omit.')
    parser.add_argument('-n', dest='suffix', action='store_const',
                    const="", default=".🗿",
                    help='do not append ".🗿" to the filename.')
    parser.add_argument('-i', dest='inst', type=str,
                        default="noteblock_harp",
                        help='instrument.')
    args = parser.parse_args()
    if args.out is None:
        print("|".join(to_thirtyDollarWebsite(args.inp,insts=[args.inst]))+(f"|{args.sign}" if args.sign is not None else ""))
    else:
        write_30dw_song(args.inp,args.out,insts=[args.inst],suffix=args.suffix)
