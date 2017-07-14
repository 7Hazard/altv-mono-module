#pragma once

#define WIN32_LEAN_AND_MEAN

#ifdef _WINDOWS
#include <windows.h>
#else
#include <cstring>
#include <string.h>
#endif

#include <cmath>
#include <sstream>
#include <vector>
#include <map>
#include <xmmintrin.h>

#include "Export.h"
#include "mono-module.h"
#include "API/API.h"
#include "Mono/Mono.h"