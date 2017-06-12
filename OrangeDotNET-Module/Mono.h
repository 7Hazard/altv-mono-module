#pragma once
#include "API.h"
#include "OrangeDotNET.h"

#ifdef _WINDOWS
typedef bool(*APIINIT)(API* api);
typedef bool(*MONOINIT)(void);

static APIINIT MonoInitAPI;
static MONOINIT MonoInit;
#endif

void MonoLoad();