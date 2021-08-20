# Commit 5, and Summary

## The Perfect Game test

1. Add a final test for a perfect game. It *should* just pass with no changes required to the Game class.

```csharp
[TestMethod]
public void TestPerfectGame()
{
    _rollMany(12, 10);
    Assert.AreEqual(300, _game.score());
}
```

2. **CTRL + R, A** 

<span style="color:green">**TESTS PASS GREEN**</span> 

The Perfect Game test just passes.

## Summary of all Actions

Below is a summary of all actions in the Kata. Once you’re familiar with the Kata overall, you can use this summary to commit the Kata to memory and increase your speed.

### Commit 1 - setup and Gutter Game Test

1.	Open Visual Studio.
2.	Create an empty Solution called BowlingKata (CTRL + Shift + N).
3.	Add a Unit Test Project to the Solution.
4.	Add a Class Library to the Solution.
5.	Create a project reference from the Class Library to the Test Project.
6.	Rename the UnitTest.cs file and class.
7.	CTRL + R, A - Green.
8.	Change the test name to TestGutterGame.
9.	Write a call to a Game class in the test.
10.	CTRL + Shift + B – won’t build.
11.	CTRL + . over Game and generate new Game type in the BowlingGame project.
12.	Delete Class1.cs from BowlingGame.
13.	CTRL + R, A - Green.
14.	Write a call to a Roll method.
15.	CTRL+. over Roll method call and add Roll method.
16. Select the line that calls Roll and CTRL K, CTRL S - then surround with a for loop.
17.	Add assertion that calls Game.Score to test.
18.	CTRL+. over Score and add Score property.
19.	CTRL + R, A - Red.
20. Change Score property from double to int.
21.	Refactor roll parameter to pins.
22.	Delete Throw NotImplementedException.
23.	CTRL + R, A – Green.
24. Commit.

### Commit 2 - roll 20 1s

1.	Add a TestAllOnes test.
2.	CTRL + R, A - Red 
3.	Increment score with pins in roll() method
4.	CTRL + R, A – Green 
5.	Add roll management variables in TestGutterGame.
6.	CTRL + R, A – Green 
7.	Give Game fixture-wide scope in TestBowlingGame.
8.	Refactor tests to use fixture-wide Game instance.
9.	CTRL + R, A – Green 
10.	Add *RollMany()* helper method (**CTRL + .** over loop in TestGutterGame > Extract Method). Delete the local roll management variables and tidy up TestAllOnes to call RollMany(20, 1).
11.	CTRL + R, A – Green 
12.	Move *RollMany()* method above tests.
13.	CTRL + R, A – Green
14. Commit.

### Commit 3 - testing a spare

1.	Create a test for a spare.
2.	CTRL + R, A - Red 
3.	Comment the test out  (CTRL + K + C) while refactoring the Game class design.
4.	CTRL + R, A – Green 
5.	Add an array of ints - *_rolls* – with class scope to record rolls (instantiate in constructor).
6.	Create an int with class scope to record the *_currentRoll*.
7.	Create an int with class scope to hold the *_score*.
8.	Alter *_roll* to add to _score and put roll in *_rolls[_currentRoll++]*.
9.	Chane the Score property to a Score() method that calculates score using *_rolls[]*.
10.	CLTR+B – won’t build – refactor tests to call Score().
11.	CTRL + R, A – Green 
12.	Remove class-scoped *_score* variable – not needed.
13.	CTRL + R, A – Green
14.	Uncomment TestSpare (**CTRL + K, CTRL + U**).
15.	Change to call Score() method.
16.	Add initial spare code to Score() method using "if a set of two rolls == 10..." logic.
17.	CTRL + R, A – Red – now all tests fail with an IndexOutOfRangeException.
18.	Comment TestSpare out again (**CTRL + K, CTRL + C**).
19. Change Score() to use frames instead of sets of two rolls. (Take the if statement out temporarily).
20. CTRL + R, A – Green
21.	Re-add if / else statement code to cope with spare bonus.
22.	CTRL + R, A – Green
23.	Rename i to frameIndex.	
24.	CTRL + R, A – Green
25.	Extract *IsSpare()* helper. Select the spare condition and **CTRL +.** > Extract Method.
26.	CTRL + R, A – Green 
27.	Extract *TestIsSpare()* method (**CTRL +.** again).
28.	CTRL + R, A – Green 
29. Commit.

### Commit 4 - testing a strike

1.	Add the test for a strike.
2.	CTRL + R, A – Red
3.	Add code to handle a strike.
4.	CTRL + R, A – Green 
5.	Extract _strikeBonus() method (CTRL + .).
6.	CTRL + R, A – Green 
7.	Extract _spareBonus() method (CTRL + .)
8.	CTRL + R, A – Green 
9.	Extract _isStrike() method (CTRL + .)
10.	CTRL + R, A – Green
11.	Extract _rollStrike() method from TestStrike() in the tests.
12.	CTRL + R, A – Green

### Commit 5 - the Perfect Game test

1.	Add a TestPerfectGame() test.
2.	CTRL + R, A – Green

## Structure of the C# / VS port

My port of the Bowling Game Kata is broken down into the following sections, which largely follow the original:

* [Introduction](README.md) 
* [Initial Design](INITIAL_DESIGN.md)
* [Commit 1](COMMIT_1.md) 
* [Commit 2](COMMIT_2.md) 
* [Commit 3](COMMIT_3.md) 
* [Commit 4](COMMIT_4.md) 
* [Commit 5](COMMIT_5.md) <-- You are here 

There's also a Visual Studio Commits branch, with the five commits posted to it, so you can see the state the code should be in at the end of each part of the Kata.