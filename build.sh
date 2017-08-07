#!/bin/bash

mkdir bin
cd bin
cmake -G "Unix Makefiles" ../mono-module/
make VERBOSE=1
msbuild ../SharpOrange/SharpOrange.csproj /p:Configuration=Release
cd ../
mkdir build
cd build
cp ../bin/libmono-module.so .
mkdir mono-module
cd mono-module
cp ../../bin/SharpOrange.dll .