@echo off

echo %CD%
set moduledir = %CD%
echo %moduledir%
set bdir = mono-module-%~1%-win
echo %bdir%

if exist "C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\Common7\Tools\VsDevCmd.bat" (
  call "C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\Common7\Tools\VsDevCmd.bat"
) else (
	if exist "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd.bat" (
		call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd.bat"
	) else (
		if exist "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\Tools\VsDevCmd.bat" (
			call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\Tools\VsDevCmd.bat"
		) else (
			echo Script not found Visual Studio 2017 VsDevCmd.bat
			goto END
		)
	)
)

echo %cd%

echo. & echo BUILDING mono-module
msbuild mono-module\mono-module.vcxproj /p:Configuration=Release;Platform=x64 /p:OutputPath=..\bin\
echo. & echo BUILDING SharpOrange
msbuild SharpOrange\SharpOrange.csproj /p:Configuration=Release;Platform="Any CPU"; /p:PreBuildEvent= /p:PostBuildEvent= /p:OutputPath=..\bin\
mkdir build
cd build
mkdir %bdir%
cd %bdir%
mkdir mono-module
cd mono-module
cd ..\..\..\

echo. & echo COPYING MODULE DLLS
copy bin\mono-module.dll modules\mono-module.dll
copy bin\SharpOrange.dll modules\mono-module\SharpOrange.dll
copy mono-module\mono-2.0-sgen.dll %bdir%\modules\mono-module\bin\mono-2.0-sgen.dll

copy SharpOrange\client-script-loader %bdir%\resources\client-script-loader
:END