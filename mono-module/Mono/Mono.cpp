#include "Mono.h"

namespace Mono {
	void InitMono() {
#ifdef _WINDOWS
		mono_set_dirs("C:\\Program Files\\Mono\\lib", "C:\\Program Files\\Mono\\etc");
#endif
		MainDomain = mono_jit_init("SharpOrange");
/*#ifdef _WINDOWS
		mono_domain_set_config(Domain, "C:\\Program Files\\Mono\\etc\\mono\\4.5", "machine.config");
#else
		mono_domain_set_config(Domain, "/etc/mono/4.5", "machine.config");
#endif*/
		//mono_config_parse(NULL);

		MonoAssembly* assembly = mono_domain_assembly_open(MainDomain, SharpOrangePath);
		if (!assembly) {
			Error("Assembly \"SharpOrange.dll\" failed to load!");
			return;
		}
		MonoImage* image = mono_assembly_get_image(assembly);
		MonoClass* mainclass = mono_class_from_name(image, "SharpOrange", "SharpOrange");
		MonoMethod* ctor = mono_class_get_method_from_name(mainclass, ".ctor", 0);
		MonoObject* obj = mono_object_new(MainDomain, mainclass);
		if (!Invoke(MainDomain, ctor, obj, NULL, false)) {
			Error("Failed to init SharpOrange!");
			return;
		}
		Method::LoadResource = mono_class_get_method_from_name(mainclass, "LoadResource", 1);

		MonoClass* eventclass = mono_class_from_name(image, "SharpOrange", "Event");
		Method::TriggerOnServerUnload = mono_class_get_method_from_name(eventclass, "TriggerOnServerUnload", 0);
		Method::TriggerOnTick = mono_class_get_method_from_name(eventclass, "TriggerOnTick", 0);
		Method::TriggerOnEvent = mono_class_get_method_from_name(eventclass, "TriggerOnEvent", 2);

		/*assembly = mono_domain_assembly_open(MainDomain, SharpOrangeSMPath);
		if (!assembly) {
			Error("Skipping load of Self-Managed API (\"SharpOrangeSM.dll\" failed to load)");
			return;
		}

		Print("Module sucessfully loaded!");*/
	}
	
	void LoadResource(char* name) {
		void* args[1]{ mono_string_new(MainDomain, name) };
		Invoke(MainDomain, Method::LoadResource, NULL, args, false);
	}

	void TriggerOnTick() {
		Invoke(MainDomain, Method::TriggerOnTick, NULL, NULL, true);
	}

	void TriggerOnEvent(const char* e, MValueList& mvlist) {
		if (!strcmp(e, "unload") || !strcmp(e, "ServerLoad")) return;
		if (!strcmp(e, "ServerUnload")) {
			Invoke(MainDomain, Method::TriggerOnServerUnload, NULL, NULL, true);
			return;
		}

		int size = mvlist.size();
		MonoArray* earray = mono_array_new(MainDomain, mono_get_array_class(), size);
		HandleEventArgs(MainDomain, earray, mvlist, size);
		void* args[2]{ mono_string_new(MainDomain, e), earray };
		Invoke(MainDomain, Method::TriggerOnEvent, nullptr, args, true);
	}

	// Domains
	/*DomainAssembly::DomainAssembly(std::string name, std::string path) {
		char* cname = (char*)name.c_str();
		Domain = mono_domain_create_appdomain(cname, NULL);

		Assembly = mono_domain_assembly_open(Domain, path.c_str());
		if (Assembly == nullptr) return;

		if (DomainIsSM(cname)) APIAssembly = mono_domain_assembly_open(Domain, SharpOrangeSMPath);
		else APIAssembly = mono_domain_assembly_open(Domain, SharpOrangePath);
		Image = mono_assembly_get_image(APIAssembly);

		MonoImage* image = mono_assembly_get_image(Assembly);
		MainClass = mono_class_from_name(image, name.c_str(), name.c_str());
		if (MainClass == nullptr) return;
		MonoObject* mainobject = mono_object_new(Domain, MainClass);
		MonoMethod* ctor = mono_class_get_method_from_name(MainClass, ".ctor", 0);
		Invoke(Domain, ctor, mainobject, NULL, true);

		EventClass = mono_class_from_name(Image, "SharpOrange", "Event");
		TriggerOnServerUnload = mono_class_get_method_from_name(EventClass, "TriggerOnServerUnload", 0);
		TriggerOnTick = mono_class_get_method_from_name(EventClass, "TriggerOnTick", 0);
		TriggerOnEvent = mono_class_get_method_from_name(EventClass, "TriggerOnEvent", 2);
	}

	void LoadResource(char* cname) {
		const std::string name(cname);

		if (Domains.count(cname) == 1) {
			Print("Reloading resource \""+ name +"\"");
			if (!UnloadResource(cname)) {
				Error("Failed to reload resource \"" + name + "\"!");
				return;
			}
		} 
		else if (DomainIsSM(cname)) Print("Loading self-managed resource \"" + name + "\"");
		else Print("Loading resource \"" + name + "\"");

		DomainAssembly da = DomainAssembly(name, "resources/" + name + "/" + name + ".dll");
		if (da.Assembly == nullptr) {
			Error("Failed to load resource \"" + name + "\"! Resource assembly failed to load!");
			return;
		}
		else if (da.MainClass == nullptr) {
			Error("Failed to get resource constructor of \"" + name + "." + name + "\"!");
			return;
		}

		if (name == "")

		Domains.insert(std::pair<const std::string, DomainAssembly>(name, da));
	}

	bool UnloadResource(char* name) {
		MonoObject* exc = NULL;
		MonoDomain* domain = Domains.find(name)->second.Domain;
		mono_domain_try_unload(domain, &exc);
		if (HasException(exc)) {
			std::string str_name = name;
			Error("Failed to unload resource \"" + str_name + "\"");
			return false;
		}
		Domains.erase(name);
		return true;
	}

	bool DomainIsSM(const char* name) {
		const char* str = strrchr(name, 'S');
		if (str != nullptr && !strcmp(str, "SM")) {
			return true;
		}
		return false;
	}

	void LoopDomains(std::function<void(const char*, DomainAssembly)> function) {
		for each (auto pair in Domains)
		{
			mono_thread_attach(pair.second.Domain);
			function(pair.first.c_str(), pair.second);
		}
	}
	

	// Events
	void TriggerOnTick() {
		LoopDomains([](const char* n, DomainAssembly da) {
			Invoke(da.Domain, da.TriggerOnTick, NULL, NULL, true);
		});
	}

	void TriggerOnEvent(const char* e, MValueList& mvlist) {
		if (!strcmp(e, "unload") || !strcmp(e, "ServerLoad")) return;
		if (!strcmp(e, "ServerUnload")) {
			LoopDomains([](const char* n, DomainAssembly da) {
				Invoke(da.Domain, da.TriggerOnServerUnload, NULL, NULL, true);
			});
			return;
		}
		
		LoopDomains([&](const char* n, DomainAssembly da) {
			int size = mvlist.size();
			MonoArray* earray = mono_array_new(da.Domain, mono_get_array_class(), size);
			HandleEventArgs(da.Domain, earray, mvlist, size);
			void* args[2]{ mono_string_new(da.Domain, e), earray };

			Invoke(da.Domain, da.TriggerOnEvent, nullptr, args, true);
		});
	}*/

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
				Error("Dictionaries in events are not supported yet by the Mono Module!");
				values[i] = NULL;
				break;
			}
		}
	}

	// Mono
	bool Invoke(MonoDomain* domain, MonoMethod* method, MonoObject* obj, void** args, bool threaded) {
		if (threaded) {
			mono_thread_attach(domain);
		}
		MonoObject* exc = NULL;
		mono_runtime_invoke(method, obj, args, &exc);
		if (HasException(exc)) return false;
		else return true;
	}

	bool HasException(MonoObject* exc) {
		if (exc != NULL) {
			MonoString* ex = mono_object_to_string(exc, &exc);
			std::string out = "SharpOrange threw an exception: \n" + (std::string)mono_string_to_utf8(ex);
			Error(out);
			mono_free(exc);
			return true;
		}
		return false;
	}
}