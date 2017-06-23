#include "MonoOrange.h"

#ifdef _WINDOWS
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
char *_strdup(const char *str) {
	size_t len = std::strlen(str);
	char *x = (char *)malloc(len + 1); /* 1 for the null terminator */
	if (!x) return NULL; /* malloc could not allocate memory */
	std::memcpy(x, str, len + 1); /* copy the string into the new buffer */
	return x;
}
#endif

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
#ifdef _DEBUG
		Sleep(3000);
#endif // _DEBUG
		Mono::InitMono();
	}

	EXPORT const char* OnResourceTypeRegister()
	{
		return ".net";
	}

	EXPORT bool OnResourceLoad(const char* resource)
	{
		Mono::LoadResource(resource);
		return true;
	}

	EXPORT bool OnTick()
	{
		Mono::Tick();
		return true;
	}

	EXPORT bool OnPlayerConnect(long playerid)
	{
		Mono::PlayerConnected(playerid);
		return true;
	}

	/*EXPORT char* OnHTTPRequest(const char* method, const char* url, const char* query, std::string body)
	{
		return ;
	}*/

	EXPORT bool OnServerCommand(std::string command)
	{
		Mono::ServerCommand(command.c_str());
		return true;
	}

	EXPORT bool OnPlayerDisconnect(long playerid, int reason)
	{
		Mono::PlayerDisconnected(playerid, reason);
		return true;
	}

	EXPORT bool OnPlayerUpdate(long playerid)
	{
		Mono::PlayerUpdated(playerid);
		return true;
	}

	EXPORT bool OnKeyStateChanged(long playerid, int keycode, bool isUp)
	{
		Mono::KeyStateChanged(playerid, keycode, isUp);
		return true;
	}

	EXPORT void OnEvent(const char* e, std::vector<MValue>* args)
	{
		Mono::Event(e); //Mono::Event(e, args);
		return;
	}
}

void APIPrint(std::string msg) {
	std::string out = "[MonoOrange] " + msg;
	API::instance->Print(out.c_str());
}