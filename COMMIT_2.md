# Commit 2

## Test Rolling 20 1s

This is a port of [Uncle Bob's Bowling Game Kata](http://www.butunclebob.com/ArticleS.UncleBob.TheBowlingGameKata), ported to C# and Visual Studio.

Just to reiterate, the point of the Bowling Game Kata is to follow it closely, learn it and commit it to muscle memory like a [video game Speedrun](https://www.twitch.tv/gamesdonequick).

## Begin

1. Add a second ‘TestAllOnes’ test to the BowlingGamesTests fixture:

```csharp
[TestMethod] // << Add this new test method
public void TestAllOnes()
{
    Game game = new Game(); // << Game creation is replicated
    
    for (int i = 0; i < 20; i++) // << Roll loop is replicated
    {
      game.Roll(1);
    }

    Assert.AreEqual(20, game.Score);
}
```

2. **Shift / CTRL + B**: succeeds.

<span style="color:red">**TESTS FAIL Red** (TestAllOnes fails – expected 20, actual 0).</span>


3. In the Game class:

```csharp
public void roll(int pins)
{
    Score += pins; // << increment score
}
```

4. **CTRL + R, then A** 

<span style="color:green">**TESTS PASS GREEN**</span>

## Refactoring the tests

5. Add some variables to manage the rolling. There's a 'surround with' shortcut that will help add the for loop.

```csharp
[TestMethod]
public void TestGutterGame()
{
    Game game = new Game();
    int n = 20; // << rolling variables
    int pins = 0;

    for(int i = 0; i < n; i++) // << added to the loop controller
    {
        game.Roll(pins);
    }

    Assert.AreEqual(0, game.score);
}
```
6. Give Game fixture-wide scope:

```csharp
[TestClass]
public class BowlingGameTests
{
    private Game _game; // << Game class with global scope

    [TestInitialize] // << initialise it in a SetUp method
    public void SetUp()
    {
        _game = new Game();
    }
    
    [TestMethod]
    public void TestGutterGame() ...
```
	
7. **Ctrl + R, A** 

<span style="color:green">**TESTS PASS GREEN**</span>

8. Add a _rollMany() helper method:

```csharp
[TestMethod]
public void TestGutterGame()
{
    _rollMany(20, 0);

    Assert.AreEqual(0, _game.score);
}

private void _rollMany(int n, int pins)
{
    for(int i=0; i < n; i++)
    {
        _game.roll(pins);
    }
}
...
```

9. **Ctrl + R, A** – Green
10. Commit

## Structure of the C# / VS port

My port of the Bowling Game Kata is broken down into the following sections, which largely follow the original:

* [Introduction](README.md) 
* [Initial Design](INITIAL_DESIGN.md)
* [Commit 1](COMMIT_1.md)
* [Commit 2](COMMIT_2.md) <-- You are here  
* [Commit 3](COMMIT_3.md) 
* [Commit 4](COMMIT_4.md) 
* [Commit 5](COMMIT_5.md) 

There's also a Visual Studio Commits branch, with the five commits posted to it, so you can see the state the code should be in at the end of each part of the Kata.
