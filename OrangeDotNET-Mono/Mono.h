#pragma once

#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/debug-helpers.h>
#include <mono/metadata/threads.h>
#include <mono/utils/mono-logger.h>

#include <fstream>
#include "API.h"

#ifdef _WINDOWS
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
char *_strdup(const char *str) {
	size_t len = std::strlen(str);
	char *x = (char *)malloc(len + 1); /* 1 for the null terminator */
	if (!x) return NULL; /* malloc could not allocate memory */
	std::memcpy(x, str, len + 1); /* copy the string into the new buffer */
	return x;
}
#endif

API* API::instance = nullptr;
static MonoDomain* Domain;
static MonoThread* Thread;
static MonoAssembly* Assembly;
static MonoImage* Image;
static MonoClass* MainClass;

extern "C" {
	EXPORT bool MonoInitAPI(API* api);
	EXPORT bool MonoInit();
}
const char* ReadConfig();

MonoMethod* GetMethod(MonoClass* monoclass, const char* descstring, bool includenamespace);