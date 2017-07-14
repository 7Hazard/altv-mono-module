#include "../stdafx.h"

struct Vector3 {
	float x, y, z;
};

struct CString {
	const char* string;
	int maxlength;
};

extern "C" {
	/// Server
	EXPORT void Print(const char* msg) {
		API::instance->Print(msg);
	}

	/// Player
	EXPORT void KickPlayer(unsigned int playerid, const char* reason) {
		if (reason == nullptr) {
			API::instance->KickPlayer(playerid);
		}
		API::instance->KickPlayer(playerid, reason);
	}
	EXPORT void GetPlayerName(unsigned int playerid, char* sb) {
		std::string name = API::instance->GetPlayerName(playerid);
		strcpy(sb, name.c_str());
	}
	EXPORT void SetPlayerName(unsigned int playerid, const char* name) {
		API::instance->SetPlayerName(playerid, name);
	}
	EXPORT Vector3 GetPlayerPosition(unsigned int playerid) {
		CVector3 vector = API::instance->GetPlayerPosition(playerid);
		Vector3 pos{ vector.fX, vector.fZ, vector.fZ };
		return pos;
	}
	EXPORT void SetPlayerPosition(unsigned int playerid, float x, float y, float z) {
		API::instance->SetPlayerPosition(playerid, x, y, z);
	}
}

std::wstring s2ws(std::string str) {
	return std::wstring(str.begin(), str.end());
}