# GeonBit.UI.Documentation

Documentation is built using Sandcastle.  

Updating the documentation is currently a manual process:

- Install Sandcastle and Visual Studio 2019 project extensions by following the procedure at https://github.com/EWSoftware/SHFB
- Open the solution file in this directory and click Build.  Output goes to a subdirectory called Help
- Get the wiki repo and delete all .md files
- Copy the .md files from the Help output directory to the wiki repo
- Commit and push
