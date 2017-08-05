#pragma once

#define WIN32_LEAN_AND_MEAN

#include <string.h>

#include "API/API.h"
#include "Mono/Mono.h"

#ifdef _WINDOWS
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
#include <cstring>
char *_strdup(const char *str) {
	size_t len = std::strlen(str);
	char *x = (char *)malloc(len + 1); /* 1 for the null terminator */
	if (!x) return NULL; /* malloc could not allocate memory */
	std::memcpy(x, str, len + 1); /* copy the string into the new buffer */
	return x;
}
#endif

void APIPrint(std::string msg);
