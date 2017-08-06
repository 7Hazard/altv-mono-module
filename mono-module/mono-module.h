#pragma once

#define WIN32_LEAN_AND_MEAN

#include <string.h>

#include "API/API.h"
#include "Mono.h"

#ifdef _WINDOWS
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
char *_strdup(const char *str);
#endif

void APIPrint(std::string msg);
