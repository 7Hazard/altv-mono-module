#include "Mono.h"

namespace Mono {
	void InitMono() {
#ifdef _WINDOWS
		mono_set_dirs("C:\\Program Files\\Mono\\lib", "C:\\Program Files\\Mono\\etc");
#endif
		Domain = mono_jit_init("SharpOrange");
/*#ifdef _WINDOWS
		mono_domain_set_config(Domain, "C:\\Program Files\\Mono\\etc\\mono\\4.5", "machine.config");
#else
		mono_domain_set_config(Domain, "/etc/mono/4.5", "machine.config");
#endif*/
		mono_config_parse(NULL);

		Assembly = mono_domain_assembly_open(Domain, SharpOrangePath);
		if (!Assembly) {
			APIPrint("SharpOrange assembly failed to load!");
			return;
		}

		APIPrint("Module sucessfully loaded!");

		Image = mono_assembly_get_image(Assembly);
		EventClass = mono_class_from_name(Image, "SharpOrange", "Event");
		Method::TriggerOnServerUnload = mono_class_get_method_from_name(EventClass, "TriggerOnServerUnload", 0);
		Method::TriggerOnTick = mono_class_get_method_from_name(EventClass, "TriggerOnTick", 0);
		Method::TriggerOnEvent = mono_class_get_method_from_name(EventClass, "TriggerOnEvent", 2);
	}
	
	// SharpOrange
	void LoadResource(char* name) {
		std::string str_name = name;

		if (Domains.count(name) != 0) {
			APIPrint("Reloading resource \""+ str_name +"\"");
			if (!UnloadResource(name)) APIPrint("Failed to reload resource \"" + str_name + "\"");
		} else APIPrint("Loading resource \"" + str_name + "\"");

		MonoDomain* domain = mono_domain_create_appdomain(name, NULL);
		std::string path = "resources/"+ str_name + "/" + str_name +".dll";

		MonoAssembly* assembly = mono_domain_assembly_open(domain, path.c_str());
		MonoImage* image = mono_assembly_get_image(assembly);
		MonoClass* mainclass = mono_class_from_name(image, name, name);
		MonoObject* mainobject = mono_object_new(domain, mainclass);
		MonoMethod* ctor = mono_class_get_method_from_name(mainclass, ".ctor", 0);
		Invoke(domain, ctor, mainobject, NULL, true);
		
		Domains.insert(std::pair<const char*, MonoDomain*>(name, domain));
	}

	bool UnloadResource(char* name) {
		MonoObject* exc = NULL;
		MonoDomain* domain = Domains.find(name)->second;
		mono_domain_try_unload(domain, &exc);
		std::string str_name = name;
		if (HasException(exc)) {
			APIPrint("ERROR - Failed to unload resource \"" + str_name + "\"");
			return false;
		}
		Domains.erase(name);
		return true;
	}

	// Events
	void TriggerOnTick() {
		LoopDomains([](MonoDomain* d) {
			Invoke(d, Method::TriggerOnTick, NULL, NULL, true);
		});
	}

	void TriggerOnEvent(const char* e, MValueList& mvlist) {
		if (!strcmp(e, "unload") || !strcmp(e, "ServerLoad")) return;
		if (!strcmp(e, "ServerUnload")) {
			LoopDomains([](MonoDomain* d) {
				Invoke(d, Method::TriggerOnServerUnload, NULL, NULL, true);
			});
			return;
		}
		
		LoopDomains([&](MonoDomain* d) {
			int size = mvlist.size();
			MonoArray* earray = mono_array_new(d, EventClass, size);
			HandleEventArgs(d, earray, mvlist, size);
			void* args[2]{ mono_string_new(d, e), earray };
			Invoke(d, Method::TriggerOnEvent, NULL, args, true);
		});
	}

	void HandleEventArgs(MonoDomain* domain, MonoArray* earray, MValueList& args, int size)
	{
		std::vector<void*> values(size);
		for (int i = 0; i < size; i++) {
			std::shared_ptr<MValue> value = args.at(i);
			switch (value->getType())
			{
			case M_STRING: {
				const std::string& str = value->getString();
				mono_array_setref(earray, i, mono_string_new(domain, str.c_str()));
				break;
			}
			case M_INT: {
				int val = value->getInt();
				mono_array_setref(earray, i, mono_value_box(domain, mono_get_int64_class(), &val));
				break;
			}
			case M_BOOL: {
				bool val = value->getBool();
				mono_array_setref(earray, i, mono_value_box(domain, mono_get_boolean_class(), &val));
				break;
			}
			case M_UINT: {
				unsigned int val = value->getUInt();
				mono_array_setref(earray, i, mono_value_box(domain, mono_get_uint32_class(), &val));
				break;
			}
			case M_DOUBLE: {
				double val = value->getDouble();
				mono_array_setref(earray, i, mono_value_box(domain, mono_get_double_class(), &val));
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
	}

	// Mono
	void Invoke(MonoDomain* domain, MonoMethod* method, MonoObject* obj, void** args, bool threaded) {
		if (threaded) {
			mono_thread_attach(domain);
		}
		MonoObject* exc = NULL;
		mono_runtime_invoke(method, obj, args, &exc);
		HasException(exc);
	}

	bool HasException(MonoObject* exc) {
		if (exc != NULL) {
			MonoString* ex = mono_object_to_string(exc, &exc);
			std::string out = "SharpOrange threw an exception: \n" + (std::string)mono_string_to_utf8(ex);
			APIPrint(out);
			mono_free(exc);
			return true;
		}
		return false;
	}

	void LoopDomains(std::function<void(MonoDomain*)> function) {
		for each (auto pair in Domains)
		{
			mono_thread_attach(pair.second);
			function(pair.second);
		}
	}
}