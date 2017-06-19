#include "Mono.h"

namespace Mono {
	void InitMono() {
#ifdef _WINDOWS
		mono_set_dirs("C:\\Program Files\\Mono\\lib", "C:\\Program Files\\Mono\\etc");
#endif
		Domain = mono_jit_init("SharpOrange");
		Thread = mono_thread_attach(Domain);
		Assembly = mono_domain_assembly_open(Domain, "modules/MonoOrange/SharpOrange.dll");
		if (!Mono::Assembly) {
			APIPrint("Assembly failed to load!");
			return;
		}
		Image = mono_assembly_get_image(Assembly);

		MainClass = mono_class_from_name(Image, "SharpOrange", "SharpOrange");
		MainInstance = mono_object_new(Domain, MainClass);
		MonoMethod* Method = mono_class_get_method_from_name(Mono::MainClass, ".ctor", 1);

		MonoObject* exc = NULL;
		void* args[1];
		args[0] = &API::instance;
		mono_runtime_invoke(Method, MainInstance, args, &exc);
		CheckException(exc);
	}

	void LoadResource(const char* resource) {
		MonoMethod* Method = mono_class_get_method_from_name(MainClass, "LoadResource", 1);

		
		MonoObject* exc = NULL;
		void* args[1];
		args[0] = mono_string_new(Domain, resource);
		mono_runtime_invoke(Method, MainInstance, args, &exc);
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