#pragma once

#include "../stdafx.h"
#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/threads.h>

namespace Method {
	static MonoMethod* ctor;
	static MonoMethod* LoadResource;
	static MonoMethod* TriggerOnTick;
	static MonoMethod* TriggerOnServerCommand;
	static MonoMethod* TriggerOnPlayerDisconnect;
	static MonoMethod* TriggerOnPlayerUpdate;
	static MonoMethod* TriggerOnKeyStateChanged;
	static MonoMethod* TriggerOnEvent;
}

namespace Mono {
	static MonoDomain* Domain;
	static MonoThread* Thread;
	static MonoAssembly* Assembly;
	static MonoImage* Image;

	static MonoClass* MainClass;
	static MonoObject* ServerObject;
	static MonoClass* EventClass;

	void InitMono();
	void Invoke(MonoMethod* method, MonoObject* obj, void** args, bool threaded);
	void CheckException(MonoObject* exception);

	void LoadResource(const char* resource);
	void TriggerOnTick();
	void TriggerOnServerCommand(const char* command);
	void TriggerOnPlayerDisconnect(long playerid, int reason);
	void TriggerOnPlayerUpdate(long playerid);
	void TriggerOnKeyStateChanged(long playerid, int keycode, bool isUp);
	void TriggerOnEvent(const char* e, MValueList& mvlist);

	void HandleEventArgs(MonoArray* earray, MValueList& args, int size);
}