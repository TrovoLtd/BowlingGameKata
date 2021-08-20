# Commit 1

## The Gutter Game Test

Remember, the point of the Kata is to follow the process as mapped out. Don't attempt to rewrite the code to 'something better'. This is a test of your coding speed in a red / green / refactor style, using Visual Studio and its many shortcuts. It's not about C#.

*Minor deviations to process to shave time off completing the Kata (suggesting more useful VS shortcuts for example) will gladly be considered. Feel free to submit a PR in that case.*

Start from scratch each time, and don't deviate from the process too much, but instead learn it and aim to complete it as quickly as possible. Think of it as being like Speedrunning a video game level (see [Games Done Quick](https://www.twitch.tv/gamesdonequick), for example). 

Once you're getting familiar with all the moves, you can use the summary I've made after the [final commit](COMMIT_5.md) to help get your speed up.

## Begin

1. Open Visual Studio and create a New > Project **(CTRL + Shift + N)**. 
2. Create an empty Visual Studio Solution called BowlingKata. 
3. Add another project using **CTRL + Shift + N**. Make it a C# NUnit Test Project called *BowlingGame.Tests.Unit*, and add it to the existing Solution. Give it a Target Framework of .Net Core 3.1. (See notes below).
4. Hit **CTRL + Shift + N** once more and create a new C# .Net Core Class Library Project called *BowlingGame*, also adding it to the existing Solution. Make this .Net 3.1 too.
5. Right-click on Dependencies under the Unit Test project you created first,select *Add a Project Reference* and add the BowlingGame project you just created.
6. Click on the default UnitTest1.cs file in the Unit Test project, press **F2** and rename it *BowlingGameTests.cs*.
7. Rename the test class *BowlingGameTests*, and Test 1 to be *TestGutterGame*.
8. Build the Solution by running all the tests **(CTRL + R, then A)**. 

<span style="color:green">**TESTS PASS GREEN**</span>

TestGutterGame in BowlingGameTests just has Assert.Pass in it for now.

9. Setup a Game class in TestGutterGame. Press **Shift / CTRL + B**, but the build fails as there's no class called Game yet.

## First Test

```csharp

using NUnit.Framework;

namespace BowlingGame.Tests.Unit
{
    public class BowlingGameTests
    {
        [SetUp]
        public void Setup()
        {
        }
		
        [Test]
        public void TestGutterGame() // << Change test name
        {
            Game game = new Game(); // << Won’t build as Game class doesn’t exist 
        }
    }
}
```

10. Move the cursor over Game initialisation statement and press **CTRL + .** . Select Generate New Type. Select Project BowlingGame, Create New File. 
11. Delete Class1.cs from BowlingGame project.
12. Run all tests - **CTRL + R, then A** 

<span style="color:green">**TESTS PASS GREEN**</span>

13. Write a call to a game.Roll(0) method. Move the cursor into Roll and **CTRL + .**. Select Generate method Game.Roll

```csharp
[Test]
public void TestGutterGame()
{
    Game game = new Game();

    game.Roll(0); // << Add call to roll method to the test.
}
```

14. Select the whole game.Roll(0); line, then press **CTRL + K, CTRL + S** and select *for* to surround it with a for loop to give us the 20 rolls of the Gutter Game

```csharp
[Test]
public void TestGutterGame()
{
    Game game = new Game();
	
    for(int i = 0; i < 20; i++) // << Surround with a for loop.
    {
        game.Roll(0); 
    }
}
```

14. Run all tests: **CTRL + R, then A**.

<span style="color:red">**TESTS FAIL Red** (System.NotImplementedException).</span>

15. Add an Assertion to the test calling a game.Score property.

```csharp
[Test]
public void TestGutterGame()
{
	Game game = new Game();

	for(int i = 0; i < 20; i++)
	{
	  game.Roll(0);
	}
       
	Assert.AreEqual(0, game.Score); // << Add assertion and call to .Score
}
```

16. Move cursor into score. **CTRL + .**, then add property Game.Score
17. Run all tests **CTRL + R, then A**. 

<span style="color:red">**TESTS FAIL Red** (System.NotImplementedException).</span>

18. Edit Game class as per the comments below.

```csharp
using System; // << You don't need this - CTRL R, CTRL G to remove it

namespace BowlingGame
{
    public class Game
    {
        public int score { get; set; } // << needs changing from double to int

        public void roll(int pins) // << Change parameter name
        {
            throw new NotImplementedException(); // << Delete
        }
    }
}
```

19. **CTRL + R, then A** 

<span style="color:green">**TESTS PASS GREEN**</span>

20. Commit your work so far with the message *Adds Gutter Game Test.*

## How is this working?

Zero is the default value for a non-nullable int in C#, so you can return it by default without setting a value. 

So the bare minimum to pass the Gutter Game Test (where the score is zero) is to just not set the value.

## Notes

It really doesn't matter too much what version of .Net you use, or if you use NUnit or MSTest, or whathaveyou. This really isn't about the code, it's about getting into the habit of the red / green / refactor TDD method.

So I just picked the most up-to-date setup as I could at time of writing. The underlying process ought to stay the same or very similar from dotnet version to dotnet version. That said, you may have to put the version you want to use on your machine before you can get going, of course.

Also, even though they aren't mentioned above yet, I've tried to add some keyboard shortcuts to make Git Commits quicker. You can do that under Tools > Options > Keyboard, then the Git commands all start Team.Git, but they aren't part of the standard set of VS shortcuts, while all the ones mentioned above are ... 

Oh, and it turns out you don't need to add a using statement for the BowlingGame to the tests in DotNet core... Who knew?

## Structure of the C# / VS port

My port of the Bowling Game Kata is broken down into the following sections, which largely follow the original:

* [Introduction](README.md) 
* [Initial Design](INITIAL_DESIGN.md)
* [Commit 1](COMMIT_1.md) <-- You are here 
* [Commit 2](COMMIT_2.md) 
* [Commit 3](COMMIT_3.md) 
* [Commit 4](COMMIT_4.md) 
* [Commit 5](COMMIT_5.md) 

There's also a Visual Studio Commits branch, with the five commits posted to it, so you can see the state the code should be in at the end of each part of the Kata.