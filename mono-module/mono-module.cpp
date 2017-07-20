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
		//Sleep(3000);
		Mono::InitMono();
	}

	EXPORT const char* OnResourceTypeRegister()
	{
		return ".NET";
	}

	EXPORT bool OnResourceLoad(const char* resource)
	{
		Mono::LoadResource(resource);
		return true;
	}

	EXPORT bool OnTick()
	{
		Mono::TriggerOnTick();
		return true;
	}

	EXPORT bool OnPlayerConnect(unsigned int playerid)
	{
		return true;
	}

	/*EXPORT char* OnHTTPRequest(const char* method, const char* url, const char* query, std::string body)
	{
		return ;
	}*/

	EXPORT bool OnServerCommand(std::string& command)
	{
		Mono::TriggerOnServerCommand(command.c_str());
		return true;
	}

	EXPORT bool OnPlayerUpdate(unsigned int playerid)
	{
		Mono::TriggerOnPlayerUpdate(playerid);
		return true;
	}

	EXPORT bool OnKeyStateChanged(unsigned int playerid, int keycode, bool isUp)
	{
		Mono::TriggerOnKeyStateChanged(playerid, keycode, isUp);
		return true;
	}

	EXPORT void OnEvent(const char* e, MValueList& args)
	{
		Mono::TriggerOnEvent(e, args);
		return;
	}
}

void APIPrint(std::string msg) {
	std::string out = "[Mono] " + msg;
	API::instance->Print(out.c_str());
}