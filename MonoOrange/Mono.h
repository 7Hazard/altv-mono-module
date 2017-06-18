#pragma once

#include "API.h"
#include "MonoOrange.h"
#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/debug-helpers.h>
#include <mono/metadata/threads.h>
#include <mono/utils/mono-logger.h>
#include <fstream>

namespace Mono {
	static MonoDomain* Domain;
	static MonoThread* Thread;
	static MonoAssembly* Assembly;
	static MonoImage* Image;
	static MonoClass* MainClass;
	static MonoObject* MainInstance;

	void InitMono();
	void LoadResource(const char*);
	void CheckException(MonoObject*);
	const char* ReadConfig();
}