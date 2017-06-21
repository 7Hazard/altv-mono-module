#include "Mono.h"
#include <iostream>;

namespace Mono {
	void InitMono() {
#ifdef _WINDOWS
		mono_set_dirs("C:\\Program Files\\Mono\\lib", "C:\\Program Files\\Mono\\etc");
#endif
		Domain = mono_jit_init("SharpOrange");
		Assembly = mono_domain_assembly_open(Domain, "modules/MonoOrange/SharpOrange.dll");
		if (!Assembly) {
			APIPrint("Assembly failed to load!");
			return;
		}
		Image = mono_assembly_get_image(Assembly);

		MainClass = mono_class_from_name(Image, "SharpOrange", "SharpOrange");
		MainObject = mono_object_new(Domain, MainClass);
		EventClass = mono_class_from_name(Image, "SharpOrange", "Event");

		Method::ctor = mono_class_get_method_from_name(MainClass, ".ctor", 1);
		Method::LoadResource = mono_class_get_method_from_name(MainClass, "LoadResource", 1);
		Method::Tick = mono_class_get_method_from_name(EventClass, "Tick", 0);
		Method::ServerCommand = mono_class_get_method_from_name(EventClass, "ServerCommand", 1);
		Method::PlayerConnected = mono_class_get_method_from_name(EventClass, "PlayerConnected", 1);
		Method::PlayerDisconnected = mono_class_get_method_from_name(EventClass, "PlayerDisconnected", 2);
		Method::PlayerUpdated = mono_class_get_method_from_name(EventClass, "PlayerUpdated", 1);
		Method::KeyStateChanged = mono_class_get_method_from_name(EventClass, "KeyStateChanged", 3);
		Method::Event = mono_class_get_method_from_name(EventClass, "EEvent", 2);

		void* args[1]{ &API::instance };
		MonoObject* exc = NULL;
		mono_runtime_invoke(Method::ctor, MainObject, args, &exc);
		CheckException(exc);
	}

	/* SharpOrange */
	void LoadResource(const char* resource) {
		void* args[1]{ mono_string_new(Domain, resource) };
		Invoke(Method::LoadResource, MainObject, args, false);
	}

	/* Events */
	void Tick() {
		Invoke(Method::Tick, NULL, NULL, true);
	}

	void ServerCommand(const char* command) {
		void* args[1]{ mono_string_new(Domain, command) };
		Invoke(Method::ServerCommand, NULL, args, true);
	}
	
	void PlayerConnected(long playerid) {
		void* args[1]{ &playerid };
		Invoke(Method::PlayerConnected, NULL, args, true);
	}

	void PlayerDisconnected(long playerid, int reason) {
		void* args[2]{ &playerid, &reason };
		Invoke(Method::PlayerDisconnected, NULL, args, true);
	}

	void PlayerUpdated(long playerid) {
		void* args[1]{ &playerid };
		Invoke(Method::PlayerUpdated, NULL, args, true);
	}

	void KeyStateChanged(long playerid, int keycode, bool isUp) {
		void* args[3]{ &playerid, &keycode, &isUp };
		Invoke(Method::KeyStateChanged, NULL, args, true);
	}

	void Event(const char* e, std::vector<MValue>* vector) { // NOT FUNCTIONAL (call commented in MonoOrange.cpp)
		void* args[2]{ mono_string_new(Domain, e), &vector->at(0) };
		Invoke(Method::Event, NULL, args, true);
	}

	/* Mono */
	void Invoke(MonoMethod* method, MonoObject* obj, void** args, bool threaded) {
		if (threaded) {
			mono_thread_attach(Domain);
		}
		MonoObject* exc = NULL;
		mono_runtime_invoke(method, obj, args, &exc);
		CheckException(exc);
	}
	
	void CheckException(MonoObject* exc) {
		if (exc != NULL) {
			MonoString* ex = mono_object_to_string(exc, &exc);
			APIPrint("SharpOrange threw an exception: ");
			APIPrint(mono_string_to_utf8(ex));
			mono_free(exc);
		}
	}
}