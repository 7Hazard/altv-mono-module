#pragma once

#include "API.h"
#include "MonoOrange.h"
#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/threads.h>

namespace Method {
	static MonoMethod* ctor;
	static MonoMethod* LoadResource;
	static MonoMethod* Tick;
	static MonoMethod* ServerCommand;
	static MonoMethod* PlayerConnected;
	static MonoMethod* PlayerDisconnected;
	static MonoMethod* PlayerUpdated;
	static MonoMethod* KeyStateChanged;
	static MonoMethod* Event;
}

namespace Mono {
	static MonoDomain* Domain;
	static MonoThread* Thread;
	static MonoAssembly* Assembly;
	static MonoImage* Image;

	static MonoClass* ServerClass;
	static MonoObject* ServerObject;
	static MonoClass* EventClass;
	static MonoObject* EventObject;

	void InitMono();
	void Invoke(MonoMethod* method, MonoObject* obj, void** args, bool threaded);
	void InvokeArray(MonoMethod* method, MonoObject* obj, MonoArray* args, bool threaded);
	void CheckException(MonoObject* exception);

	void LoadResource(const char* resource);
	void Tick();
	void ServerCommand(const char* command);
	void PlayerConnected(long playerid);
	void PlayerDisconnected(long playerid, int reason);
	void PlayerUpdated(long playerid);
	void KeyStateChanged(long playerid, int keycode, bool isUp);
	void Event(const char* e, std::vector<MValue>* args);

	void HandleEventArgs(MonoArray* earray, std::vector<MValue>* args);
}