REM Batch file that executes the vsvars32.bat file, to set up the system 
REM variables required for csc to work from the command line without having to
REM write the whole /path/to/csc, and be able to only need csc fileToCompile.cs.

REM For an explanation as to why these variables can't be permanently set, see
REM the README file in the top c# directory

call C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\Tools\vsvars32.bat