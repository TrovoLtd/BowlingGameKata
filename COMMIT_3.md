# Commit 3

## Testing a spare

This is the first big refactor where some of the trickier aspects of the [Ten Pin Bowling scoring system](INITIAL_DESIGN.md) start to get added.

Remember, though, this isn't about writing the perfect bowling scoring code, it's about following the process as quickly as you can, to gain the muscle memory of writing in a test-first, red / green / refactor style using C# and Visual Studio.

So when the code in this Commit goes wrong a couple of times, work through it: it's teaching you to refactor when you code for real.

Indeed if you learn to work through the wrong without thinking about it, it's not only teaching you, it's getting you *in the habit* of doing it, which is even better.

## Begin

1. Add a test for a spare.

```csharp
[Test]
public void TestOneSpare()
{
    _game.Roll(5);
    _game.Roll(5); // << Spare – Ugly comment in test
    _game.Roll(3);
    
	RollMany(17, 0);

    Assert.AreEqual(16, _game.score);
}
```

2. **CTRL+R, A** 

<span style="color:red">**TESTS FAIL Red** (TestOneSpare fails – Expected 16, Actual 13).</span>

3. Start writing the code to pass the test. This is where we start to discover where the design is wrong...

```csharp
public class Game
{
    public int score { get; set; } // << Score doesn’t calculate score...

    public void Roll(int pins) // << Roll calculates score...
    {
        score += pins;
    }
}
```

The Roll() method calculates the score, when the name implies that it doesn't. The Score property implies this more, when it doesn't actually calculate anything. 

*The responsibilities of this class are misplaced, currently*.

To keep the codebase "in the Green" for as long as possible, the TestSpare class needs to be taken back out of the codebase temporarily while the BowlingGame class is refactored to a better design.

4. Comment out TestOneSpare - select the code, then **CTRL K, C**

```csharp
//[Test]
//public void TestOneSpare()
//{
//    _game.Roll(5);
//    _game.Roll(5); // << Spare
//    _game.Roll(3);
//    
//	  RollMany(17, 0);
//    
//    Assert.AreEqual(16, _game.score);
//}
```

5. **CTRL + R, A** 

<span style="color:green">**TESTS PASS GREEN**</span>

6. Refactor the Game class to start to iron some of the problems out…

```csharp
public class Game
{
    private int[] _rolls; // << Data structure for holding rolls
    private int _currentRoll; // << Tracks the current roll
    private int _score; // << Holds current score

    public Game()
    {
        _rolls = new int[21];
    }

    public void Roll(int pins) // << Now adds pins hit to _rolls 
    {
        _score += pins;
        _rolls[_currentRoll++] = pins;
    }
    
    public int Score() // << Generates final score by summing_rolls
    {
        int score = 0;
        for (int i = 0; i < _rolls.Length; i++)
        {
            score += _rolls[i];
        }
        return score;
    }
}
```

7. **CTRL + Shift + B** – build fails - 'Score' now a method, not a property, so tests won't build.

```csharp
[Test]
public void TestGutterGame()
{
    _rollMany(20, 0);
    Assert.AreEqual(0, _game.Score()); // << Score now a method
}
```

8. **CRTL + R, A** 

<span style="color:green">**TESTS PASS GREEN**</span>

9. Issue - the class-wide _score variable isn’t actually used anywhere, so can be refactored out.

```csharp
public class Game
{

    private int[] _rolls;
	//<< _score has gone from here
    private int _currentRoll;

    // ...

    public void Roll(int pins) 
    {
	    // << _score gone from here
      	_rolls[_currentRoll++] = pins;
    }
    
    //...
```

10. **CTRL + R, A** 

<span style="color:green">**TESTS PASS GREEN**</span>

11. Uncomment TestOneSpare (Select the code, then **CTRL + K, CTRL U**). Refactor to call Score() method.

<span style="color:red">**TESTS FAIL Red** (TestOneSpare fails – Expected 16, Actual 13).</span>

12. Now add initial attempt to pass the test. You can use **CTRL + K, CTRL + S** to *surround with* an if statement here:

```csharp
public int Score()
{
    int score = 0;
    
    for (int i = 0; i < _rolls.Length; i++)
    {
        if(_rolls[i] + _rolls[i+1] == 10) // << Spare
        {
            score += _rolls[i + 2]; // << Wrong for several reasons
        }
        score += _rolls[i];
    }
    return score;
}
```

13. **CTRL + R, A**

<span style="color:red">**TESTS FAIL Red** (They all fails with an IndexOutOfRangeException).</span>

The above solution is wrong for a couple of reasons. Firstly it checks i+1 at the end of the array and thus fails with an out of bounds exception. 

But it also takes any two rolls adding up to ten to be a spare, regardless of whether they happened in the same frame or not.

The solution is to walk through the game one Frame (i.e. two rolls) at a time.

13. Comment the failing test out again. (Select, then **CTRL + K + C**). Then refactor Score() to step through two rolls (i.e. one frame) at a time.

```csharp

public int Score()
{
    int score = 0;
    int i = 0;
    
    for (int frame = 0; frame < 10; frame++) // << Frame by frame
    {
        score += _rolls[i] + _rolls[i+1];
        i += 2;
    }
    return score;
}
```

14. **CTRL + R, A** 

<span style="color:green">**TESTS PASS GREEN**</span> - the first two tests are back green again, even though we've introduced frames into the design.

15. Uncomment TestSpare again (Select, then **CTRL K, CTRL U**)...
16. **CTRL + R, A** 

<span style="color:red">**TESTS FAIL Red** (TestOneSpare fails – Expected 16, Actual 13).</span>

17. But now when the code to calculate a spare is added, it should work because two rolls together are now a frame.

```csharp
public int Score()
{
    int score = 0;
    int i = 0;
    for (int frame = 0; frame < 10; frame++)
    {
        if(_rolls[i] + _rolls[i+1] == 10) // Spare
        {
            score += 10 + _rolls[i + 2];
        }
        else
        {
            score += _rolls[i] + _rolls[i + 1];
        }
        i += 2;
    }
    return score;
}
```

18. **CTRL + R, A**

<span style="color:green">**ALL THREE TESTS PASS GREEN**</span>

## Refactor the class

We can refactor the class to make it more readable / understandable. i is a bad name for the loop counting variable (it's the index of the current Frame). 

And the // Spare comment would be better handled in the code itself.

19. Rename the i variable declaration to frameIndex, then **CTRL + .** and select Rename i to frameIndex.
20. **CTRL + R, A** 

<span style="color:green">**TESTS PASS GREEN**</span>

21. Now refactor to handle spares more obviously (i.e. remove the comment and use readable code). You can use **CTRL + .** Extract Method here.

```csharp
public int Score()
{
    ...
    for (int frame = 0; frame < 10; frame++)
    {
        if(IsSpare(frameIndex)) // << Extract a helper method
        {
            score += 10 + _rolls[frameIndex + 2];
        }
        else
        {
            score += _rolls[frameIndex] + _rolls[frameIndex + 1];
        }
        frameIndex += 2;
    }
    return score;        
}

private bool IsSpare(int frameIndex) // << Helper calculates spare
{
	return (_rolls[frameIndex] + _rolls[frameIndex + 1]) == 10;
}
```

22. **CTRL + R, A** 

<span style="color:green">**TESTS PASS GREEN**</span>

## Refactor the test

23. There's a similar unnecessary comment about spares in the tests that can be handled better in code, too. Again, **CTRL + .** Extract Method is your friend:

```csharp
private void RollSpare() // << Extract a RollSpare helper method
{
    _game.roll(5);
    _game.roll(5);
}
...

[Test]
public void TestOneSpare()
{
    RollSpare(); // << Call it in the test
    _game.roll(3);
    _rollMany(17, 0);
    Assert.AreEqual(16, _game.score());
}
```

24. **CTRL + R, A** 

<span style="color:green">**TESTS PASS GREEN**</span>

25. Commit the code with the message: *Adds Test for a Spare.*

## Structure of the C# / VS port

My port of the Bowling Game Kata is broken down into the following sections, which largely follow the original:

* [Introduction](README.md) 
* [Initial Design](INITIAL_DESIGN.md)
* [Commit 1](COMMIT_1.md)
* [Commit 2](COMMIT_2.md)
* [Commit 3](COMMIT_3.md) <-- You are here   
* [Commit 4](COMMIT_4.md) 
* [Commit 5](COMMIT_5.md) 

There's also a Visual Studio Commits branch, with the five commits posted to it, so you can see the state the code should be in at the end of each part of the Kata.

