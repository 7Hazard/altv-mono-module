@echo off

if exist "C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\Common7\Tools\VsDevCmd.bat" (
  call "C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\Common7\Tools\VsDevCmd.bat"
) else (
  if exist "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd.bat" (
    call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd.bat"
  ) else (
    echo Script not found Visual Studio 2017 VsDevCmd.bat
    goto END
  )
)

msbuild mono-module\mono-module.vcxproj /p:Configuration=Release;Platform=x64 /p:OutputPath=..\bin\
msbuild SharpOrange\SharpOrange.csproj /p:Configuration=Release;Platform="Any CPU";AllowUnsafeBlocks=true;SkipBuildPackage=false;RestorePackages=false /p:PreBuildEvent= /p:PostBuildEvent= /p:OutputPath=..\bin\
mkdir build
copy mono-module\bin\mono-module.dll build\mono-module.dll
copy mono-module\mono-2.0-sgen.dll build\mono-module\bin\mono-2.0-sgen.dll
copy bin\SharpOrange.dll build\mono-module\SharpOrange.dll
:END