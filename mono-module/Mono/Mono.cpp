#include "Mono.h"

namespace Mono {
	void InitMono() {
#ifdef _WINDOWS
		mono_set_dirs("C:\\Program Files\\Mono\\lib", "C:\\Program Files\\Mono\\etc");
#endif
		Domain = mono_jit_init("SharpOrange");
#ifdef _WINDOWS
		mono_domain_set_config(Domain, "C:\\Program Files\\Mono\\etc\\mono\\4.5", "machine.config");
#else
		mono_domain_set_config(Domain, "/etc/mono/4.5", "machine.config");
#endif
		Assembly = mono_domain_assembly_open(Domain, "modules/mono-module/SharpOrange.dll");
		if (!Assembly) {
			APIPrint("SharpOrange assembly failed to load!");
			return;
		}
		Image = mono_assembly_get_image(Assembly);

		MainClass = mono_class_from_name(Image, "SharpOrange", "SharpOrange");
		ServerObject = mono_object_new(Domain, MainClass);
		EventClass = mono_class_from_name(Image, "SharpOrange", "Event");

		Method::ctor = mono_class_get_method_from_name(MainClass, ".ctor", 0);
		/*Method::LoadResource = mono_class_get_method_from_name(MainClass, "LoadResource", 1);
		Method::TriggerOnServerUnload = mono_class_get_method_from_name(EventClass, "TriggerOnServerUnload", 0);
		Method::TriggerOnTick = mono_class_get_method_from_name(EventClass, "TriggerOnTick", 0);
		Method::TriggerOnServerCommand = mono_class_get_method_from_name(EventClass, "TriggerOnServerCommand", 1);
		Method::TriggerOnPlayerUpdate = mono_class_get_method_from_name(EventClass, "TriggerOnPlayerUpdate", 1);
		Method::TriggerOnEvent = mono_class_get_method_from_name(EventClass, "TriggerOnEvent", 2);*/

		MonoObject* exc = NULL;
		mono_runtime_invoke(Method::ctor, ServerObject, NULL, &exc);
		CheckException(exc);
	}
	/*
	// SharpOrange
	void LoadResource(const char* resource) {
		void* args[1]{ mono_string_new(Domain, resource) };
		Invoke(Method::LoadResource, ServerObject, args, false);
	}

	// Events
	void TriggerOnTick() {
		Invoke(Method::TriggerOnTick, NULL, NULL, true);
	}

	void TriggerOnServerCommand(const char* command) {
		void* args[1]{ mono_string_new(Domain, command) };
		Invoke(Method::TriggerOnServerCommand, NULL, args, true);
	}

	void TriggerOnPlayerUpdate(long playerid) {
		void* args[1]{ &playerid };
		Invoke(Method::TriggerOnPlayerUpdate, NULL, args, true);
	}

	void TriggerOnEvent(const char* e, MValueList& mvlist) {
		if (!strcmp(e, "unload")) return;
		if (!strcmp(e, "ServerUnload")) {
			Invoke(Method::TriggerOnServerUnload, NULL, NULL, true);
			return;
		}
		int size = mvlist.size();
		MonoArray* earray = mono_array_new(Domain, EventClass, size);
		HandleEventArgs(earray, mvlist, size);

		void* args[2]{ mono_string_new(Domain, e), earray };
		Invoke(Method::TriggerOnEvent, NULL, args, true);
	}

	void HandleEventArgs(MonoArray* earray, MValueList& args, int size)
	{
		std::vector<void*> values(size);
		for (int i = 0; i < size; i++) {
			std::shared_ptr<MValue> value = args.at(i);
			switch (value->getType())
			{
			case M_STRING: {
				std::string& str = value->getString();
				mono_array_setref(earray, i, mono_string_new(Domain, str.c_str()));
				break;
			}
			case M_INT: {
				int val = value->getInt();
				mono_array_setref(earray, i, mono_value_box(Domain, mono_get_int64_class(), &val));
				break;
			}
			case M_BOOL: {
				bool val = value->getBool();
				mono_array_setref(earray, i, mono_value_box(Domain, mono_get_boolean_class(), &val));
				break;
			}
			case M_UINT: {
				unsigned int val = value->getUInt();
				mono_array_setref(earray, i, mono_value_box(Domain, mono_get_uint32_class(), &val));
				break;
			}
			case M_DOUBLE: {
				double val = value->getDouble();
				mono_array_setref(earray, i, mono_value_box(Domain, mono_get_double_class(), &val));
				break;
			}
			case M_DICT:
				//auto int_keys = value->getIntDict();
				//auto string_keys = value->getStringDict();
				APIPrint("Warning: Dictionaries in events are not supported yet by the Mono Module!");
				values[i] = NULL;
				break;
			}
		}
	}*/

	// Mono
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
			std::string out = "SharpOrange threw an exception: \n" + (std::string)mono_string_to_utf8(ex);
			APIPrint(out);
			mono_free(exc);
		}
	}
}