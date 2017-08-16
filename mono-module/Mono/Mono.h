#pragma once

#include "../mono-module.h"
#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/threads.h>
#include <mono/metadata/mono-config.h>
//#include <mono/metadata/exception.h>

namespace Method {
	static MonoMethod* ctor;
	static MonoMethod* LoadResource;
	static MonoMethod* TriggerOnServerUnload;
	static MonoMethod* TriggerOnTick;
	static MonoMethod* TriggerOnEvent;
}

namespace Mono {
#ifdef _WINDOWS
	static char* ConfigPath = "C:\\Program Files\\Mono\\etc\\mono\\4.5\\machine.config";
#else
	static char* ConfigPath = "/etc/mono/4.5/machine.config";
#endif

	static const char* SharpOrangePath = "modules/mono-module/SharpOrange.dll";

	static std::map<const char*, MonoDomain*> Domains;

	static MonoDomain* Domain;
	static MonoThread* Thread;
	static MonoAssembly* Assembly;
	static MonoImage* Image;

	static MonoClass* MainClass;
	static MonoObject* MainObject;
	static MonoClass* EventClass;

	void InitMono();
	void Invoke(MonoDomain* domain, MonoMethod* method, MonoObject* obj, void** args, bool threaded);
	bool HasException(MonoObject* exception);
	void LoopDomains(std::function<void(MonoDomain*)> function);

	void LoadResource(char* name);
	bool UnloadResource(char* name);
	void TriggerOnTick();
	void TriggerOnEvent(const char* e, MValueList& mvlist);

	void HandleEventArgs(MonoDomain* domain, MonoArray* earray, MValueList& args, int size);
}