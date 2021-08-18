# Commit 1

## The Gutter Game Test

Remember, the point of the Kata is to follow the process as mapped out. Don't attempt to rewrite the code to 'something better'. This is a test of your coding speed in a red / green / refactor style, using Visual Studio and its many shortcuts. It's not about C#.

*Minor deviations to process to shave time off completing the Kata (suggesting more useful VS shortcuts for example) will gladly be considered. Feel free to submit a PR in that case.*

Start from scratch each time, and don't deviate from the process too much, but instead learn it and aim to complete it as quickly as possible. Think of it as being like Speedrunning a video game level (see [Games Done Quick](https://www.twitch.tv/gamesdonequick), for example). 

Once you’re getting familiar with all the moves, you can use the summary I’ve made after the final test to help get your speed up.

## Begin

1. Open Visual Studio and create a New > Project **(CTRL / Shift + N)**. 
2. Create an empty Visual Studio Solution called Bowling Kata. 
3. In Solution Explorer, right-click on the Solution and add a new Unit Test Project called *BowlingGame.Tests.Unit*.
4. Right-click on the Solution once more and create a new Class Library Project called *Bowling Game*.
5. Add a Reference to BowlingGame in the Unit Test project you created first.
6. Right-click on the default UnitTest.cs file in the Unit Test project and rename it *BowlingGameTests.cs*.
7. Build the Solution by running all the tests **(CTRL + R, then A)**. 

<span style="color:green">**TESTS PASS GREEN**</span>

There will be one passing test (the empty TestMethod1 test created in the default UnitTest.cs file).

## First Test

```csharp

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame; // << Add using statement to the BowlingGame project
namespace BowlingGame.Tests.Unit
{
    [TestClass]
    public class BowlingGameTests
    {
        [TestMethod]
        public void TestGutterGame() // << Change test name
        {
            Game game = new Game(); // << Won’t build as Game class doesn’t exist 
        }
    }
}
```

8. **Shift / CTRL + B**: fails to build as no class called Game.
9. Move the curseor over Game initialisation statement and press **CTRL + .** . Select Generate New Type. Select Project BowlingGame, Create New File. 
10. Delete Class1.cs from BowlingGame project.
11. **Shift / CTRL + B**: succeeds.
12. Run all tests - **CTRL + R, then A** 

<span style="color:green">**TESTS PASS GREEN**</span>

```csharp
[TestMethod]
public void TestGutterGame()
{
    Game game = new Game();
    for(int i = 0; i < 20; i++)
    {
        game.Roll(0); // << Add call to roll method to the test.
    }
}
```

13. Move cursor into Roll and **CTRL + .**. Select Generate method Game.Roll > Preview Changes > Apply
14. **Shift + CTRL + B**: succeeds.
15. Run all tests: **CTRL + R, then A**.

<span style="color:red">**TESTS FAIL Red** (System.NotImplementedException).</span>

```csharp
[TestMethod]
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

16. Move cursor into score. **CTRL + .**, then add property Game.Score > Preview Changes > Apply
17. **Shift + CTRL + B**: succeeds.
18. Run all tests **CTRL + R, then A**. 

<span style="color:red">**TESTS FAIL Red** (System.NotImplementedException).</span>

19. Edit Game class

```csharp
namespace BowlingGame
{
    public class Game
    {
        public int score { get; set; }

        public void roll(int pins) // << Change parameter name
        {
            throw new NotImplementedException(); << Delete
        }
    }
}
```

19. **CTRL + R, then A** 

<span style="color:green">**TESTS PASS GREEN**</span>

## How is this working?

Zero is the default value for a non-nullable int in C#, so you can return it without setting a value. 

So the bare minimum to pass the Gutter Game Test (where the score is zero) is to just not set the value.

20. Commit your work so far.


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