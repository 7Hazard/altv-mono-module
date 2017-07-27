#pragma once

#define WIN32_LEAN_AND_MEAN

//#include <iostream>
//#include <thread>
//#include <string>

#ifdef _WINDOWS

#else
#include <stdlib.h>
#include <cstring>
#endif

#include "Export.h"
#include "mono-module.h"
#include "API/API.h"
#include "Mono/Mono.h"