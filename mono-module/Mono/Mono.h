#pragma once

#include "../mono-module.h"
#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/threads.h>
#include <mono/metadata/mono-config.h>
//#include <mono/metadata/exception.h>

namespace Method {
	// Managed API
	static MonoMethod* LoadResource;
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

	/*// Domains
	struct DomainAssembly {
		std::string Name;
		std::string AssemblyPath;
		MonoDomain* Domain;
		MonoAssembly* Assembly;
		MonoAssembly* APIAssembly;
		MonoImage* Image;
		MonoClass* MainClass;
		MonoClass* EventClass;
		MonoMethod* TriggerOnServerUnload;
		MonoMethod* TriggerOnTick;
		MonoMethod* TriggerOnEvent;

		DomainAssembly(std::string name, std::string path);
	};*/

	static MonoDomain* MainDomain;
	/*static std::map<const std::string, DomainAssembly> Domains;
	void LoopDomains(std::function<void(const std::string, DomainAssembly)> function);*/

	// Managed API
	static const char* SharpOrangePath = "modules/mono-module/SharpOrange.dll";

	// Self-Managed API
	static const char* SharpOrangeSMPath = "modules/mono-module/SharpOrangeSM.dll";
	//bool DomainIsSM(const char* name);

	// Mono
	void InitMono();
	bool Invoke(MonoDomain* domain, MonoMethod* method, MonoObject* obj, void** args, bool threaded);
	bool HasException(MonoObject* exception);

	// API Methods
	void LoadResource(char* name);
	//bool UnloadResource(char* name);
	void TriggerOnTick();
	void TriggerOnEvent(const char* e, MValueList& mvlist);
	void HandleEventArgs(MonoDomain* domain, MonoArray* earray, MValueList& args, int size);
}