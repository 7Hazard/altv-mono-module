#pragma once

#include "API.h"
#include "OrangeDotNET.h"
#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/debug-helpers.h>
#include <mono/metadata/threads.h>
#include <mono/utils/mono-logger.h>
#include <fstream>

static MonoDomain* Domain;
static MonoThread* Thread;
static MonoAssembly* Assembly;
static MonoImage* Image;
static MonoObject* exc;
static MonoClass* MainClass;
static MonoObject* MainInstance;
static MonoMethod *MainCtor;

void InitMono();
MonoMethod* GetMethod(MonoClass* monoclass, const char* descstring, bool includenamespace);
static const char* ReadConfig();