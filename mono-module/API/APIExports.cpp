#include "APIExports.h"

extern "C" {
	// Server/Console
	EXPORT void Print(const char* msg) {
		API::instance->Print(msg);
	}
	EXPORT long Hash(const char* msg) {
		return API::instance->Hash(msg);
	}
	EXPORT void Shutdown() {
		APIPrint("Shutting down the server programmatically is not implemented yet.");
	}
	EXPORT void ServerEvent(const char* e, EValue* args, int size) {
		MValueList& values = GetMValueList(args, size);
		APIPrint(values.at(0)->getString());
		API::instance->ServerEvent(e, values);
	}

	// Clients
	EXPORT void ClientEvent(long playerid, const char* e, EValue* args, int size) {
		MValueList& values = GetMValueList(args, size);
		APIPrint(values.at(0)->getString());
		API::instance->ClientEvent(e, values, playerid);
	}

	// Players
	EXPORT void KickPlayer(long playerid, const char* reason) {
		if (reason == nullptr) {
			API::instance->KickPlayer(playerid);
		}
		API::instance->KickPlayer(playerid, reason);
	}
	EXPORT void GetPlayerName(long playerid, char* sb) {
		std::string name = API::instance->GetPlayerName(playerid);
		strcpy(sb, name.c_str());
	}
	EXPORT void SetPlayerName(long playerid, const char* name) {
		API::instance->SetPlayerName(playerid, name);
	}
	EXPORT Vector3 GetPlayerPosition(long playerid) {
		CVector3 vector = API::instance->GetPlayerPosition(playerid);
		Vector3 pos{ vector.fX, vector.fY, vector.fZ };
		return pos;
	}
	EXPORT void SetPlayerPosition(long playerid, float x, float y, float z) {
		API::instance->SetPlayerPosition(playerid, x, y, z);
	}
	EXPORT bool SetPlayerModel(long playerid, long model) {
		return API::instance->SetPlayerModel(playerid, model);
	}
	EXPORT long GetPlayerModel(long playerid) {
		return API::instance->GetPlayerModel(playerid);
	}
	EXPORT bool RemovePlayerWeapons(long playerid) {
		return API::instance->RemovePlayerWeapons(playerid);
	}
	EXPORT bool GivePlayerWeapon(long playerid, long weapon, long ammo) {
		return API::instance->GivePlayerWeapon(playerid, weapon, ammo);
	}
	EXPORT bool GivePlayerAmmo(long playerid, long weapon, long ammo) {
		return API::instance->GivePlayerAmmo(playerid, weapon, ammo);
	}

	// Vehicles
	EXPORT unsigned long CreateVehicle(long vehicle, float x, float y, float z) {
		return API::instance->CreateVehicle(vehicle, x, y, z, 0);
	}
	EXPORT bool DeleteVehicle(unsigned long vehid) {
		return API::instance->DeleteVehicle(vehid);
	}
	EXPORT bool SetVehiclePosition(unsigned long vehid, float x, float y, float z) {
		return API::instance->SetVehiclePosition(vehid, x, y, z);
	}
	EXPORT Vector3 GetVehiclePosition(unsigned long vehid) {
		CVector3 vector = API::instance->GetVehiclePosition(vehid);
		Vector3 pos{ vector.fX, vector.fY, vector.fZ };
		return pos;
	}
	EXPORT bool SetVehicleRotation(unsigned long vehid, float rx, float ry, float rz) {
		return API::instance->SetVehicleRotation(vehid, rx, ry, rz);
	}
	EXPORT Vector3 GetVehicleRotation(unsigned long vehid) {
		CVector3 vector = API::instance->GetVehicleRotation(vehid);
		Vector3 rot{ vector.fX, vector.fY, vector.fZ };
		return rot;
	}
	EXPORT bool SetVehiclePrimaryColor(unsigned long vehid, unsigned char r, unsigned char g, unsigned char b) {
		return API::instance->SetVehicleCustomPrimaryColor(vehid, r, g, b);
	}
	EXPORT RGB GetVehiclePrimaryColor(unsigned long vehid) {
		RGB rgb;
		API::instance->GetVehicleCustomPrimaryColor(vehid, &rgb.r, &rgb.g, &rgb.b);
		return rgb;
	}
	EXPORT bool SetVehicleSecondaryColor(unsigned long vehid, unsigned char r, unsigned char g, unsigned char b) {
		return API::instance->SetVehicleCustomSecondaryColor(vehid, r, g, b);
	}
	EXPORT RGB GetVehicleSecondaryColor(unsigned long vehid, unsigned char *rColor, unsigned char *gColor, unsigned char *bColor) {
		RGB rgb;
		API::instance->GetVehicleCustomPrimaryColor(vehid, &rgb.r, &rgb.g, &rgb.b);
		return rgb;
	}
	EXPORT bool SetVehicleEngineStatus(unsigned long vehid, bool status, bool locked) {
		return API::instance->SetVehicleEngineStatus(vehid, status, locked);
	}
	EXPORT bool GetVehicleEngineStatus(unsigned long vehid) {
		return API::instance->GetVehicleEngineStatus(vehid);
	}
	EXPORT bool SetVehicleLocked(unsigned long vehid, bool locked) {
		return API::instance->SetVehicleLocked(vehid, locked);
	}
	EXPORT bool IsVehicleLocked(unsigned long vehid) {
		return API::instance->IsVehicleLocked(vehid);
	}
	EXPORT bool SetVehicleBodyHealth(unsigned long vehid, float health) {
		return API::instance->SetVehicleBodyHealth(vehid, health);
	}
	EXPORT bool SetVehicleEngineHealth(unsigned long vehid, float health) {
		return API::instance->SetVehicleEngineHealth(vehid, health);
	}
	EXPORT bool SetVehicleTankHealth(unsigned long vehid, float health) {
		return API::instance->SetVehicleTankHealth(vehid, health);
	}
	EXPORT VehicleHealth GetVehicleHealth(unsigned long vehid) {
		VehicleHealth healths;
		API::instance->GetVehicleHealth(vehid, &healths.body, &healths.engine, &healths.tank);
		return healths;
	}
}

MValueList GetMValueList(EValue* args, int size) {
	MValueList values;
	for (int i = 0; i < size; i++) {
		EValue value = args[i];
		switch (value.type)
		{
		case M_STRING: {
			values.push_back(MValue::CreateString(value.string_val));
			break;
		}
		case M_INT: {
			values.push_back(MValue::CreateInt(value.int_val));
			break;
		}
		case M_BOOL: {
			values.push_back(MValue::CreateBool(value.bool_val));
			break;
		}
		case M_UINT: {
			values.push_back(MValue::CreateUInt(value.uint_val));
			break;
		}
		case M_DOUBLE: {
			values.push_back(MValue::CreateDouble(value.double_val));
			break;
		}
		default:
			values.push_back(MValue::CreateNil());
		}
	}
	return values;
}