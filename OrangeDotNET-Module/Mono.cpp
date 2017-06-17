#include "Mono.h"

void InitMono() {
#ifdef _WINDOWS
	mono_set_dirs("C:\\Program Files\\Mono\\lib", "C:\\Program Files\\Mono\\etc");
#endif
	exc = NULL;
	Domain = mono_jit_init("SharpOrange");
	Thread = mono_thread_attach(Domain);
	Assembly = mono_domain_assembly_open(Domain, "modules/OrangeDotNET/SharpOrange.dll");
	if (!Assembly) {
		APIPrint("Assembly failed to load!");
		return;
	}
	Image = mono_assembly_get_image(Assembly);

	MainClass = mono_class_from_name(Image, "SharpOrange", "SharpOrange");
	MainInstance = mono_object_new(Domain, MainClass);
	MainCtor = mono_class_get_method_from_name(MainClass, ".ctor", 1);
	
	void* args[1];
	args[0] = &API::instance;
	MonoObject *result = mono_runtime_invoke(MainCtor, MainInstance, args, &exc);
	if (exc != NULL) {
		MonoString* ex = mono_object_to_string(exc, &exc);
		APIPrint("SharpOrange threw an exception: ");
		APIPrint(mono_string_to_utf8(ex));
		mono_free(exc);
	}
}

MonoMethod* GetMethod(MonoClass* monoclass, const char* descstring, bool includenamespace) {
	MonoMethodDesc *desc = mono_method_desc_new(descstring, includenamespace);
	MonoMethod *method = mono_method_desc_search_in_class(desc, monoclass);
	mono_method_desc_free(desc);
	return method;
}

static const char* ReadConfig() {
	std::ifstream configfile;
	configfile.open("modules/OrangeDotNET/OrangeDotNET.conf");
	std::string output;
	if (configfile.is_open()) {
		while (!configfile.eof()) {
			std::getline(configfile, output);
		}
	}
	configfile.close();
	return output.c_str();
}