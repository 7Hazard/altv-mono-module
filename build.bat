@echo off

echo BUILDING mono-module-%~1-win

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

cd Repos\mono-module

echo. & echo BUILDING mono-module
msbuild mono-module\mono-module.vcxproj /p:Configuration=Release;Platform=x64 /p:OutDir="../bin/"
echo. & echo BUILDING SharpOrange
msbuild SharpOrange\SharpOrange.csproj /p:Configuration=Release /p:OutputPath="..\bin\mono-module"

echo. & echo SETTING UP BUILD STRUCTURE
mkdir build
cd build
mkdir mono-module-%~1-win
cd mono-module-%~1-win
mkdir modules
mkdir resources
cd modules
mkdir mono-module
cd mono-module
mkdir bin
cd ..\..\..\..\

echo. & echo COPYING MODULE DLLS
copy bin\mono-module.dll build\mono-module-%~1-win\modules\mono-module.dll
copy bin\mono-module\SharpOrange.dll build\mono-module-%~1-win\modules\mono-module\SharpOrange.dll
copy mono-module\mono-2.0-sgen.dll build\mono-module-%~1-win\modules\mono-module\bin\mono-2.0-sgen.dll

xcopy SharpOrange\client-script-loader build\mono-module-%~1-win\resources\client-script-loader\ /Y
:END