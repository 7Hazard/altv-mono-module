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

msbuild MonoOrange\MonoOrange.vcxproj /p:Configuration=Release;Platform=x64 /p:OutputPath=..\modules\
msbuild SharpOrange\SharpOrange.csproj /p:Configuration=Release;Platform="Any CPU" /p:OutputPath=..\modules\MonoModule\
copy SharpOrange\Std-symbols.dll modules\MonoOrange\Std-symbols.dll

:END