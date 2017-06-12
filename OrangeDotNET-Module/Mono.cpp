#include "Mono.h"

void MonoLoad() {
#ifdef _WINDOWS
	SetDllDirectory(L"modules/OrangeDotNET/");
	HINSTANCE hDLL = LoadLibrary(L"modules/OrangeDotNET/OrangeDotNET-Mono.dll");
	if (hDLL == NULL) {
		APIPrint("Could not load the Mono Runtime!");
	}

	MonoInitAPI = (APIINIT)GetProcAddress(hDLL, "MonoInitAPI");
	MonoInit = (MONOINIT)GetProcAddress(hDLL, "MonoInit");
#endif
}