# The Bowling Game Kata in Python

This Python port of [Uncle Bob's Bowling Game Kata](http://www.butunclebob.com/ArticleS.UncleBob.TheBowlingGameKata) is a little bit different to [my C# / Visual Studio 2019 Port](../README.md). That version assumed that the coder would have access to Visual Studio and pretty much be able to code in C# straight out of the box, with all of Visual Studio's built in Unit Testing tools to hand. 

But Python is an entirely different beast. It's been a much more open eco-system from the moment it was first produced, and there are thousands of different ways of working with it. This means it's both very easy to get up and running with Python, and very easy to _get in a really horrible mess with it_, very quickly. So I also want to use this port as an opportunity to explore some of the stuff I've learned about how to use Python in a neat and tidy fashion, and in ways that encourage using it collaboratively in a team.

Pretty much everything I've learned about setting up Python neatly and professionally, in ways that help manage a Python codebase and allow team members to collaborate productively, comes from [Claudio Jolowicz's](https://github.com/cjolowicz/) book [Hypermodern Python Tooling](https://learning.oreilly.com/library/view/hypermodern-python-tooling/9781098139575/), which I encourage anyone who is working seriously with Python to read. This little repo here merely scratches the surface just enough to get a nice clean port of the Bowling Kata together. When I decided that I was definitely going to get into Python, the career engineer in me started crying out for a good source of information about how to do so while staying sane, and Claudio's book has provided that source.

Claudio also provides a [Cookie Cutter Python Project](https://github.com/cjolowicz/cookiecutter-hypermodern-python) which is a fantastic shortcut to all the best practice I discuss here and a gigantic heap more. 

## The Python Commits Branch

Like my [C# Visual Studio Port](../README.md), I'll commit all the Python changes for the Kata onto a separate branch of this repo (which I'll refer to as ThePyCommits), though I'll keep all the documentation about what I'm doing on this main branch too. So the process of setting up a Python [Virtual Environment](VENV.md), Build and Project, and getting it ready to run Unit Tests in, will all be documented on the Main Branch. 

## Why keep my Python code neat, tidy and manageable?

If Python is so easy to get working with, why not just dive in and get going? Well, if we're going to be _professional_ about using Python, we need to assume a few things:

1. Other people will have to work with the code, either while we're around or maybe we're on leave / have left for pastures new. Allowing your team members to pick your work up and get running with it without having to spend an age setting everything up is what responsible engineers do.
2. There will be money riding on this code, so we need to try and keep mistakes to a minimum.
3. If it's in a full production environment in a commercial organisation, the code and application could provide an attack surface for malicious activity. 

This last issue in particular means it's important to produce code that can be updated and re-released quickly should any of the libraries it depends upon have a vulnerability. And like most modern languages - Python is _all about the dependencies_. Unless we can manage those libraries, update them quickly, and be sure any code we have produced that depends upon them still works, then we're potentially dangling our employers' posteriors over the parapet for bad guys to launch arrows at.

## Setting up a Python Virtual Environment

The first step towards neat and tidy Python application code is to [Setup a Python Virtual Environment](VENV.md). 

## Towards Unit Testing

The underlying goal of this exercise is to embed Unit Testing in our Python application, however. Until we're at a point where we can quickly and easily tell if upgrades to the underlying Interpreter or any of the dependencies our app uses have broken anything, we're in trouble, and that's what Unit Testing and TDD give us. Which is the point of the Kata, after all. (I.e.: making TDD a fundamental habit so we never write any code that we can't manage change around).