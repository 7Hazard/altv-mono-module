#pragma once

#define WIN32_LEAN_AND_MEAN

#include <string>
#include <functional>

#include "API/API.h"
#include "Mono/Mono.h"

#ifdef _WINDOWS
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
char *_strdup(const char *str);
#endif

void Print(std::string msg);
void Error(std::string msg);