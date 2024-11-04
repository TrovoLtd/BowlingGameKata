# Using a Python Installer

Installers are a different class of tools that increase engineer productivity when using Python.

They allow standalone Python tools to be installed onto the engineer's system in a way that makes them constantly available on the Command Line. However, the Installer also ensures that these tools are placed in isolated [Virtual Environments](VENV.md), so that their dependencies can also be managed separately from the dependencies of other, similar tools. In this way, clashes between dependency versions from one tool to the next can be avoided, and tool updates etc can be managed safe in the knowledge that you're not going to break anything else.

An engineer would often maintain a standard set of productivity tools in this way (e.g. project management tools, unit testing frameworks, code coverage analysers, linters etc).
