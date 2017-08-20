#include "mono-module.h"

API * API::instance = nullptr;

extern "C"
{
	EXPORT bool Validate(API * api)
	{
		API::Set(api);
		return true;
	}

	EXPORT void OnModuleInit()
	{
		Mono::InitMono();
	}

	EXPORT const char* OnResourceTypeRegister()
	{
		return ".NET";
	}

	EXPORT bool OnResourceLoad(char* resource)
	{
		Mono::LoadResource(resource);
		return true;
	}

	EXPORT bool OnTick()
	{
		Mono::TriggerOnTick();
		return true;
	}

	EXPORT bool OnEvent(const char* e, MValueList& args)
	{
		Mono::TriggerOnEvent(e, args);
		return true;
	}
}

void Print(std::string msg) {
	std::string out = "[Mono] " + msg;
	API::instance->Print(out.c_str());
}

void Error(std::string msg) {
	std::string out = "[Mono] ERROR - " + msg;
	API::instance->Print(out.c_str());
}