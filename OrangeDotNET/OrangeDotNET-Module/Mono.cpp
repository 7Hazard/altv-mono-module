#include "Mono.h"

void InitMono() {
#ifdef _WINDOWS
	mono_set_dirs("C:\\Program Files\\Mono\\lib", "C:\\Program Files\\Mono\\etc");
#endif
	Domain = mono_jit_init("OrangeDotNET");
	Thread = mono_thread_attach(Domain);
	Assembly = mono_domain_assembly_open(Domain, "modules/OrangeDotNET.dll");
	if (!Assembly)
		API::Get().Print("OrangeDotNET Mono Assembly failed to load!");
	
	Image = mono_assembly_get_image(Assembly);
	MainClass = mono_class_from_name(Image, "OrangeDotNET", "Main");

	MonoMethod *InitMethod = GetMethod(MainClass, ":.ctor()", FALSE);
	MonoObject* exc = NULL;
	MonoObject *result = mono_runtime_invoke(InitMethod, NULL, NULL, &exc);
	if (exc != NULL) {
		MonoString* ex = mono_object_to_string(exc, &exc);
		API::instance->Print(mono_string_to_utf8(ex));
	}
	else {
		int int_result = *(int*)mono_object_unbox(result); // Tested throws NULL exception
		API::instance->Print("mono_runtime_invoke finished with code " + int_result);
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