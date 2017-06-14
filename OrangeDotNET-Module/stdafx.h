#pragma once

#define WIN32_LEAN_AND_MEAN

#ifdef _WINDOWS
#include <windows.h>
#include <string>
#else
#include <cstring>
#include <string.h>
#endif

#include <sstream>
#include <vector>
#include <map>
#include <xmmintrin.h>

#include "API.h"
#include "OrangeDotNET.h"