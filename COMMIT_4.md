# Commit 4

## Adding a strike

This is the fourth part of a series describing a straight port of [Uncle Bob's Bowling Game Kata](http://www.butunclebob.com/ArticleS.UncleBob.TheBowlingGameKata) from Java to C# .Net and Visual Studio. 

We've got as far as the fourth test, which helps us add functionality for rolling a strike.

## Add the test for a strike

```csharp
[TestMethod]
public void TestOneStrike()
{
    _game.Roll(10); // strike
    _game.Roll(3);
    _game.Roll(4);
    _rollMany(16, 0);
    
    Assert.AreEqual(24, _game.score());
}
```

1. **CTRL + R, A** 

<span style="color:red">**TESTS FAIL Red** (TestOneStrike fails – Expected 24, Actual 17).</span>

(Plus there’s an ugly comment once more)…

2. Now change Score() to pass the test.

```csharp
public int Score()
{
    int score = 0;
    int frameIndex = 0;
    for (int frame = 0; frame < 10; frame++)
    {
        if(_rolls[frameIndex] == 10) // strike – ugly comment
        {
            score += 10 + _rolls[frameIndex + 1]  + _rolls[frameIndex + 2];
            frameIndex++; // Move on one if there’s a strike
 	    }
        else if (_isSpare(frameIndex))
        {
            score += 10 + _rolls[frameIndex + 2];
            frameIndex += 2; // Moved here
        }
        else
        {
            score += _rolls[frameIndex] + _rolls[frameIndex + 1];
            frameIndex += 2; // Moved here
 	    }
    }

    return score;
}
```

3. **CTRL + R, A** 

<span style="color:green">**TESTS PASS GREEN**</span>

**Note** – have to move the code that moves the frameIndex into the if statements as the player moves straight into the next frame if they score a strike. (So when a roll is ten, the next frame starts with the next roll...)

## Refactoring the Game class

4. The following refactorings can be made to Game to make it more readable. First, extract a _strikeBonus helper method (**CTRL + . – Extract Method**)

```csharp
public int Score()
{
    int score = 0;
    int frameIndex = 0;
    
    for (int frame = 0; frame < 10; frame++)
    {
        if(_rolls[frameIndex] == 10) // strike
        {
            score += 10 + 
 	 	 	_strikeBonus(frameIndex); // < More readable
            frameIndex++;
 	    }
 	    else if (_isSpare(frameIndex))
        {
            ...
		}

    return score;
}

private int _strikeBonus(int frameIndex)
{
    return _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
}
```

5. **CTRL + R, A**

<span style="color:green">**TESTS PASS GREEN**</span>

_strikeBonus() hasn't broken anything...

6. Then do the same for _spareBonus().

```csharp
public int Score()
{
    int score = 0;
    int frameIndex = 0;
    
    for (int frame = 0; frame < 10; frame++)
    {
 		...
    }
 	else if (_isSpare(frameIndex))
    {
        score += 10 + _spareBonus(frameIndex);
    }
    
    return score;
}

...

private int _spareBonus(int frameIndex)
{
    return _rolls[frameIndex + 2];
}
```

7. Then extract the sum of balls in frame:

```csharp
public int Score()
{
    int score = 0;
    int frameIndex = 0;
    
    for (int frame = 0; frame < 10; frame++)
    {
 		...
 	    else
        {
             	    score += _sumOfBallsInFrame(frameIndex);
        }
    }
    
    return score;
}

...

private int _sumOfBallsInFrame(int frameIndex)
{
    return _rolls[frameIndex] + _rolls[frameIndex + 1];
}
```

8. Finally, extract a test for the _isStrike(frameIndex) condition:

```csharp
public int Score()
{
    int score = 0;
    int frameIndex = 0;
    
    for (int frame = 0; frame < 10; frame++)
    {
        if(_isStrike(frameIndex)) // strike
        {
            score += 10 + 
 	 	 	_strikeBonus(frameIndex); // < More readable
 	 	    frameIndex++;
 	    }
 	    else if (_isSpare(frameIndex))
        {
             ...
		}

        ...
    }

    return score;
}

private bool _isStrike(int frameIndex)
{
    return _rolls[frameIndex] == 10;
}
```

## Refactor the test class

9. Extract a _rollStrike() method  from the _game.roll(10) line in the TestStrike test using **CTRL + .** It should end up looking like this:

```csharp
private void _rollStrike()
{
    _game.roll(10);
}
```

## Structure of the C# / VS port

My port of the Bowling Game Kata is broken down into the following sections, which largely follow the original:

* [Introduction](README.md) 
* [Initial Design](INITIAL_DESIGN.md)
* [Commit 1](COMMIT_1.md)
* [Commit 2](COMMIT_2.md)
* [Commit 3](COMMIT_3.md)
* [Commit 4](COMMIT_4.md) <-- You are here    
* [Commit 5](COMMIT_5.md) 

There's also a Visual Studio Commits branch, with the five commits posted to it, so you can see the state the code should be in at the end of each part of the Kata.
