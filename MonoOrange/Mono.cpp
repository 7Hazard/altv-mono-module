#include "Mono.h"

namespace Mono {
	void InitMono() {
#ifdef _WINDOWS
		mono_set_dirs("C:\\Program Files\\Mono\\lib", "C:\\Program Files\\Mono\\etc");
#endif
		Domain = mono_jit_init("SharpOrange");
#ifdef _WINDOWS
		mono_domain_set_config(Domain, "C:\\Program Files\\Mono\\etc\\mono\\4.5", "machine.config");
#endif
		Assembly = mono_domain_assembly_open(Domain, "modules/MonoOrange/SharpOrange.dll");
		if (!Assembly) {
			APIPrint("Assembly failed to load!");
			return;
		}
		Image = mono_assembly_get_image(Assembly);

		ServerClass = mono_class_from_name(Image, "SharpOrange", "Server");
		ServerObject = mono_object_new(Domain, ServerClass);
		EventClass = mono_class_from_name(Image, "SharpOrange", "Event");

		Method::ctor = mono_class_get_method_from_name(ServerClass, ".ctor", 1);
		Method::LoadResource = mono_class_get_method_from_name(ServerClass, "LoadResource", 1);
		Method::Tick = mono_class_get_method_from_name(EventClass, "Tick", 0);
		Method::ServerCommand = mono_class_get_method_from_name(EventClass, "ServerCommand", 1);
		Method::PlayerConnected = mono_class_get_method_from_name(EventClass, "PlayerConnected", 1);
		Method::PlayerDisconnected = mono_class_get_method_from_name(EventClass, "PlayerDisconnected", 2);
		Method::PlayerUpdated = mono_class_get_method_from_name(EventClass, "PlayerUpdated", 1);
		Method::KeyStateChanged = mono_class_get_method_from_name(EventClass, "KeyStateChanged", 3);
		Method::Event = mono_class_get_method_from_name(EventClass, "EEvent", 2);

		void* args[1]{ &API::instance };
		MonoObject* exc = NULL;
		mono_runtime_invoke(Method::ctor, ServerObject, args, &exc);
		CheckException(exc);
	}

	/* SharpOrange */
	void LoadResource(const char* resource) {
		void* args[1]{ mono_string_new(Domain, resource) };
		Invoke(Method::LoadResource, ServerObject, args, false);
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

	void Event(const char* e, std::vector<MValue>* vector) {
		if (!strcmp(e, "unload") || !strcmp(e, "ServerUnload")) return;
		MonoArray* earray = mono_array_new(Domain, EventClass, vector->size());
		HandleEventArgs(earray, vector);

		void* args[2]{ mono_string_new(Domain, e), earray };
		Invoke(Method::Event, NULL, args, true);
	}

	void HandleEventArgs(MonoArray* earray, std::vector<MValue>* vector) {
		for (int i = 0; i < vector->size(); i++) {
			MValue value = vector->at(i);
			switch (value.type)
			{
			case M_STRING: {
				mono_array_setref(earray, i, mono_string_new(Domain, value.getString()));
				break;
			}
			case M_INT: {
				int val = value.getInt();
				mono_array_setref(earray, i, mono_value_box(Domain, mono_get_int64_class(), &val));
				break;
			}
			case M_BOOL: {
				bool val = value.getBool();
				mono_array_setref(earray, i, mono_value_box(Domain, mono_get_boolean_class(), &val));
				break;
			}
			case M_ULONG: {
				unsigned long val = value.getULong();
				mono_array_setref(earray, i, mono_value_box(Domain, mono_get_uint64_class(), &val));
				break;
			}
			case M_DOUBLE: {
				double val = value.getDouble();
				mono_array_setref(earray, i, mono_value_box(Domain, mono_get_double_class(), &val));
				break;
			}
			case M_ARRAY:
				APIPrint("Arrays passed through events are not supported yet!");
				/*MonoArray* iarray = mono_array_new(Domain, mono_get_object_class(), value.getArray().ikeys.size());
				HandleEventArgs(iarray, vector);
				mono_array_set(earray, MonoArray*, i, iarray);*/
				break;
			default:
				break;
			}
		}
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

	void InvokeArray(MonoMethod* method, MonoObject* obj, MonoArray* array, bool threaded) {
		if (threaded) {
			mono_thread_attach(Domain);
		}
		MonoObject* exc = NULL;
		mono_runtime_invoke_array(method, obj, array, &exc);
		CheckException(exc);
	}
	
	void CheckException(MonoObject* exc) {
		if (exc != NULL) {
			MonoString* ex = mono_object_to_string(exc, &exc);
			std::string out = "SharpOrange threw an exception: \n" + (std::string)mono_string_to_utf8(ex);
			APIPrint(out);
			mono_free(exc);
		}
	}
}