#pragma once

#define WIN32_LEAN_AND_MEAN

//#include <iostream>
//#include <thread>

#ifdef _WINDOWS
#include <string>
#else
#include <string.h>
#endif

#include "Export.h"
#include "mono-module.h"
#include "API/API.h"
#include "Mono/Mono.h"