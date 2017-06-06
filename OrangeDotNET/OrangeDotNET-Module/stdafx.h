#pragma once

#define WIN32_LEAN_AND_MEAN

#ifdef _WINDOWS
#include <windows.h>
#include <string>
#else
#include <cstring>
#include <string.h>
#include <dlfnc.h>
#endif

#include <sstream>
#include <vector>
#include <map>
#include <iostream>
#include <xmmintrin.h>
#include <cmath>

#include "API.h"