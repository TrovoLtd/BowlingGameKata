# Setting up a Python Virtual Environment

When coding in Python, it's good practice to keep the core Python Interpreter as isolated as possible from _any_ dependencies (i.e. third-party libraries) that each Python application you are working with depends upon.

Let's unpack this statement a little:

- The fundamental software used whenever you run a piece of Python code is called the __Interpreter__, and you can (and usually should) have multiple Interpreter versions on your development machine at any given time. 
- New versions of The Interpreter are released regularly. There's one official Feature Release per year, but there might also be ad-hoc ones if vulnerabilities are found. You should always migrate applications away from Interpreters that are no longer supported, and you might need to update any applications you have to a newer version of the Interpreter at any point in time.
- Different applications are likely to depend upon different libraries. If these libraries are installed directly as Modules for whichever Interpreter you are using when you're creating the application, then they won't be available to that application when you switch to a newer interpreter. 
- Also, each Interpreter version can only work with one version of a dependency at a time, so if your application A needs V1 of a dependency, but your application B needs V2, you won't be able to use the same Interpreter for both apps if you've installed the dependency at the Interpreter level. 
- Similarly, if you install _all_ the dependencies for _all_ the applications you produce in one central location, it soon becomes very hard to keep track of which app needs which library, and each Interpreter version you are maintaining ends up with a massive list of Modules to manage.

It's much more efficient to let an application's dependencies live _with the application_, and not with the Interpreter that the application was built with. Keep your applications and their dependencies isolated from your Interpreters, and keep each Interpreter nice and clean. Of course, there's nothing stopping you from polluting your Interpreter right away, though, as the Python ecosystem makes it very easy to do so. Therefore, _resist the temptation to just start installing Python Modules in a big hurry to get stuff working_. Take a deep breath and plan what you're going to do a little, instead.

Fortunately there is a suite of tools to help manage dependencies at the application level, and also to keep the separation between your applications and the underlying set of Interpreters. The core tool for maintaining that separation is called a __Virtual Environment__.

## Creating a Virtual Environment

The Python Interpreter ships with all the scripts required to create Virtual Environments. All you need to do is decide which folder you want to make your working folder for the Virtual Environment, and then execute the Virtual Environment creation script in that folder.

__Note__: I'm working on Windows (what can I say, I was a C# guy for years) - so the instructions below are for that OS. 

I'm making the _py-src_ directory in this repo the working directory for all the Python code, so that's where I'm going to create my Virtual Environment. That said, you won't be any the wiser that I have done, because I've added some instructions to my [.gitignore](../.gitignore) file to prevent me from committing the files that are created when I do so. So you're just going to have to trust that I opened a Terminal window in this directory and entered the following command:

```

```
