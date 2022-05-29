
# <p align="center"><img src="https://user-images.githubusercontent.com/42378704/170884149-7e2f5c9f-91c8-488b-9fa3-b5beaa521a70.png" alt="Logo" width="128" align="center"/> <br/> DON'T YOU LECTURE ME WITH YOUR THIRTY DOLLAR LIBRARY</p>
DON'T YOU LECTURE ME WITH YOUR THIRTY DOLLAR LIBRARY, or ThirtyDollarLib for short, is a library that helps construct and parse 🗿 files, or better known as [Thirty Dollar Website](https://gdcolon.com/🗿) sequencer files.

## READ!! Info regarding ItemType
When programming the sounds, you might not be able to distinguish the control items and the actual sounds.
To distinguish the 2, here is a list of control items to help out:
<details>
  <summary>List</summary>
  Speed,
  Volume,
  Stop,
  LoopMany,
  Loop,
  LoopTarget,
  Cut,
  Combine,
  Jump,
  Target,
  Flash,
  StartPos,
  Pause
</details>

## Okay how do I use this crap
If you wanna generate a sequence, here's a quick guide to get started:
```cs
using ThirtyDollarLib;

List<Item> items = new()
{
  new Item(ItemType.Speed, 2000, ControlModifier.Set)
};

for (int i = 0; i < 20; i++) items.Add(new Item(ItemType.Boom, i));

Sequence seq = new Sequence(items);
string converted = seq.ToString();

// do stuff with your sequence file, like writing it to a file
```

You can also parse a compiled sequence back into a Sequence object like so:
```cs
using ThirtyDollarLib;

string compiled = File.ReadAllText("sequence.🗿"); // you can load the string in any way you'd like, we're only using files as an example
Sequence seq = Sequence.Parse();

// do stuff with your new Sequence, like appending data
```

## Contribution stuff
If you wanna contribute to the docs, or the crappy codebase, do so with a pull request \
That's pretty much all
