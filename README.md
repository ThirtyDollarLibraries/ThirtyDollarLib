
# <p align="center"><img src="https://user-images.githubusercontent.com/42378704/170884149-7e2f5c9f-91c8-488b-9fa3-b5beaa521a70.png" alt="Logo" width="128" align="center"/> <br/>![GitHub issues](https://img.shields.io/github/issues/4techguns/ThirtyDollarLib) ![GitHub](https://img.shields.io/github/license/4techguns/ThirtyDollarLib) ![Nuget](https://img.shields.io/nuget/dt/ThirtyDollarLib)<br/> DON'T YOU LECTURE ME WITH YOUR THIRTY DOLLAR LIBRARY</p>
DON'T YOU LECTURE ME WITH YOUR THIRTY DOLLAR LIBRARY, or ThirtyDollarLib for short, is a .NET library that helps construct and parse 🗿 files, or better known as [Thirty Dollar Website](https://thirtydollar.website) sequencer files.

## READ!! Info regarding ItemType
When programming the sounds, you might not be able to distinguish the control items and the actual sounds.
To distinguish the 2, here is a list of control items to help out:
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

## Installation
Like almost any other .NET library out there, the library is provided through NuGet.
Installing this library should be pretty straightforward:
### Visual Studio (GUI)
Right-click on your project node in the Solution Explorer, then click Manage NuGet Packages, or click Project > Manage NuGet Packages. \
Then, type ThirtyDollarLib into the search box, click on the package, then click Install.
Now you're ready to use the library!
### Visual Studio (Package Manager Console)
Bring up the Package Manager Console by going to View > Other Windows > Package Manager Console. Then type `Install-Package ThirtyDollarLib`
### `dotnet` CLI
`cd` into your project folder, then type `dotnet add package ThirtyDollarLib`.

## Usage
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
Sequence seq = Sequence.Parse(compiled);

// do stuff with your new Sequence, like appending data
```

## Contribution stuff
If you wanna contribute to the docs, or the crappy codebase, do so with a pull request \
That's pretty much all
