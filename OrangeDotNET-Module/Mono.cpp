#include "Mono.h"
#include <iostream>

void MonoLoad() {
#ifdef _WINDOWS
	HMODULE hModule = GetModuleHandle(L"modules\\OrangeDotNET\\OrangeDotNET-Mono.dll"); // Does not work properly
	if (hModule == NULL) {
		std::cout << GetLastError();
	}
	HINSTANCE hDLL = LoadLibrary(L"modules\\OrangeDotNET\\OrangeDotNET-Mono.dll");

	MonoInitAPI = (APIINIT)GetProcAddress(hModule, "MonoInitAPI");
	MonoInit = (MONOINIT)GetProcAddress(hModule, "MonoInit");
#endif
}