# Bug report for System.Numerics.Vectors

## Issue description
The problem manifests in the `Vector3.Normalize` returning non-normalized vector when invoked on a vector of a non-zero length. 
The bug only happens in Release build. Reproducible on 64-bit version of Windows 7 or 10, targeting .NET v.4.6.1 using the v.4.4.0 of 
System.Numerics.Vectors NuGet package.

## Project description
The project contains minimal code necessary to reproduce the issue. It was extracted from a real-life application. Some parts of the reproduction code seem unrelevant, however removing them somehow hide the problem.

Current project uses XUnit framework and console test runner to reproduce the issue, however this is not essential. Originally it was discovered in WPF desktop application.



## Steps to reproduce
1. Open the solution with Visual Studio 2015.


2. Build both Debug and Release configurations.


3. Open command window in the root folder.

4. Execute 'RunDebug.bat'.
   
   Result (expected): test passes, length of the vector output to the console equals 1. ![Screenshot](/Images/DebugRun.png).
   
5. Execute 'RunRelease.bat'.

	Result (bug): test fails, length of the vector equals 0.03477052. ![Screenshot](/Images/ReleaseRun.png).
