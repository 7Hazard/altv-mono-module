#pragma once

#include "../mono-module.h"
#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/threads.h>
#include <mono/metadata/mono-config.h>
//#include <mono/metadata/exception.h>

namespace Method {
	// Managed API
	static MonoMethod* TriggerOnServerUnload;
	static MonoMethod* TriggerOnTick;
	static MonoMethod* TriggerOnEvent;

	// Self-Managed API
	static MonoMethod* TriggerOnServerUnloadSM;
	static MonoMethod* TriggerOnTickSM;
	static MonoMethod* TriggerOnEventSM;
}

namespace Mono {
#ifdef _WINDOWS
	static char* ConfigPath = "C:\\Program Files\\Mono\\etc\\mono\\4.5\\machine.config";
#else
	static char* ConfigPath = "/etc/mono/4.5/machine.config";
#endif

	// Domains
	static std::map<const char*, MonoDomain*> Domains;
	static MonoDomain* Domain;
	void LoopDomains(std::function<void(const char* name, MonoDomain*)> function);
	bool DomainIsSM(const char* name);

	// Managed API
	static const char* SharpOrangePath = "modules/mono-module/SharpOrange.dll";
	static MonoAssembly* Assembly;
	static MonoImage* Image;
	static MonoClass* MainClass;
	static MonoObject* MainObject;
	static MonoClass* EventClass;

	// Self-Managed API
	static const char* SharpOrangeSMPath = "modules/mono-module/SharpOrangeSM.dll";
	static MonoAssembly* AssemblySM;
	static MonoImage* ImageSM;
	static MonoClass* MainClassSM;
	static MonoObject* MainObjectSM;
	static MonoClass* EventClassSM;

	// Mono
	void InitMono();
	void Invoke(MonoDomain* domain, MonoMethod* method, MonoObject* obj, void** args, bool threaded);
	bool HasException(MonoObject* exception);

	// API Methods
	void LoadResource(const char* name);
	bool UnloadResource(char* name);
	void TriggerOnTick();
	void TriggerOnEvent(const char* e, MValueList& mvlist);
	void HandleEventArgs(MonoDomain* domain, MonoArray* earray, MValueList& args, int size);
}