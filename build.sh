#!/bin/bash

mkdir bin
cd bin
cmake -G "Unix Makefiles" ../mono-module/
make VERBOSE=1
msbuild ../SharpOrange/SharpOrange.csproj
cd ../
mkdir linux
cd linux
cp ../bin/mono-module.so .
mkdir mono-module
cd mono-module
cp ../bin/SharpOrange/SharpOrange.dll .
cp ../SharpOrange/Std-symbols.so .