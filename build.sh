#!/bin/bash

cd bin
cmake -G "Unix Makefiles" ../MonoOrange/
make VERBOSE=1
xbuild ../SharpOrange/SharpOrange.csproj
cd ../
mkdir linux
cd linux
cp ../bin/MonoOrange.so .
mkdir MonoOrange
cd MonoOrange
cp ../bin/SharpOrange.dll .
cp ../SharpOrange/Std-symbols.so .