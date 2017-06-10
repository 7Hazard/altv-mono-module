#pragma once
#include "API.h"


#ifdef _WINDOWS
typedef void(*APIINIT)(API* api);
typedef void(*MONOINIT)();

static APIINIT MonoInitAPI;
static MONOINIT MonoInit;
#endif

void MonoLoad();