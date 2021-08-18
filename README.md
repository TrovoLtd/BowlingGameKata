# Uncle Bob's Bowling Game Coding Kata

## Ported to C# and Visual Studio

One way of keeping Test-Driven-Development, code design and refactoring skills sharp is to follow [Uncle Bob Martin's bowling game kata](http://www.butunclebob.com/ArticleS.UncleBob.TheBowlingGameKata). 

The original version was written for Java / JUnit and put into a PowerPoint deck, so I've ported it to Visual Studio. Even though the original has been there for a long time (in Internet years), we can't rely on it always being there (though it has been [sucked into the Internet Archive](https://web.archive.org/web/20180201183323/http://www.butunclebob.com/ArticleS.UncleBob.TheBowlingGameKata), where it might last a little bit longer).

## What is the Bowling Game kata?

The point of the kata is to *get developers into the habit of red / green / refactor Test-Driven-Development*. 

It's not a coding test as such – you're not supposed to get precious with it, redesign it or come up with fancy ways of doing it better. You are just supposed to follow it as quickly as you can. 

Furthermore, you are supposed to *practice* it, so you commit it to memory, and then to "muscle memory" – so you end up doing it without thinking. The first few times you do it, it takes way over an hour. However, once you're in the realms of doing it without thinking, it should take minutes.

Also (and this is the point) – once you can do it in a few minutes, then you'll truly be in the habit of writing code Test First, and refactoring it as you go along. This is a hard habit to get into, but you're a much better developer once you're there.

## Why bowling?

The genius of the kata is that it has ten-pin bowling as its topic. Ten-pin bowling is, on the surface, one of the simplest possible games – you're simply knocking pins down with a ball, and getting a point for each one, right? 

However – there are a few serious complexities lurking in the scoring system – and in this respect it's very much like every "simple" app or system you'd ever be asked to code in real life. It looks simple, but you don't have to go too far into it before it'll tie you up in knots.

This makes it a great choice for illustrating how to refactor your way from the simplest possible starting point towards a much more complex outcome, while keeping the code "in the green" (i.e. with all tests passing) for the maximum amount of time. 

That is the essence of the kata.

## Structure of the C# / VS port

My port of the Bowling Game Kata is broken down into the following sections, which largely follow the original:

* [Introduction](README.md) <-- You are here
* [Initial Design](INITIAL_DESIGN.md) - an overview of how you *might* design the scoring system for a game of bowling... :) 
* [Commit 1](COMMIT_1.md) - how to get to the first commit point
* [Commit 2](COMMIT_2.md) - getting to the second commit point
* [Commit 3](COMMIT_3.md) - etc etc etc
* [Commit 4](COMMIT_4.md) - etc etc
* [Commit 5](COMMIT_5.md) - etc

There's also a Visual Studio Commits branch, with the five commits posted to it, so you can see the state the code should be in at the end of each part of the Kata.

