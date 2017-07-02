#!/bin/bash

mkdir modules
cd modules
cmake -G "Unix Makefiles" ../MonoOrange/
make VERBOSE=1