#!/bin/bash

# Handle building setup
mkdir bin
cd bin
cmake -G "Unix Makefiles" ../mono-module/
make VERBOSE=1
msbuild ../SharpOrange/SharpOrange.csproj /p:Configuration=Release
cd ../
mkdir build
cd build
mkdir mono-module-"$1"-linux
cd mono-module-"$1"-linux

# Handle dependent resources
mkdir resources
cp -r ../../SharpOrange/client-script-loader resources/

# Handle module files
mkdir modules
cp ../../bin/libmono-module.so modules/
mkdir modules/mono-module
cp ../../bin/SharpOrange.dll modules/mono-module/

# Zip the module
cd ../
zip -r mono-module-"$1"-linux.zip mono-module-"$1"-linux