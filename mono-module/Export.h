#pragma once

#include "stdafx.h"

#ifdef _WINDOWS
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
char *_strdup(const char *str) {
	size_t len = strlen(str);
	char *x = (char *)malloc(len + 1); /* 1 for the null terminator */
	if (!x) return NULL; /* malloc could not allocate memory */
	memcpy(x, str, len + 1); /* copy the string into the new buffer */
	return x;
}
#endif