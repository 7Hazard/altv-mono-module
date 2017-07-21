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
	EXPORT void ClientEvent(long guid, const char* e, EValue* args, int size) {
		MValueList& values = GetMValueList(args, size);
		APIPrint(values.at(0)->getString());
		API::instance->ClientEvent(e, values, guid);
	}

	// Players
	EXPORT void KickPlayer(long guid, const char* reason) {
		if (reason == nullptr) {
			API::instance->KickPlayer(guid);
		}
		API::instance->KickPlayer(guid, reason);
	}
	EXPORT void GetPlayerName(long guid, char* sb) {
		std::string name = API::instance->GetPlayerName(guid);
		strcpy(sb, name.c_str());
	}
	EXPORT void SetPlayerName(long guid, const char* name) {
		API::instance->SetPlayerName(guid, name);
	}
	EXPORT Vector3 GetPlayerPosition(long guid) {
		CVector3 vector = API::instance->GetPlayerPosition(guid);
		Vector3 pos{ vector.fX, vector.fY, vector.fZ };
		return pos;
	}
	EXPORT void SetPlayerPosition(long guid, float x, float y, float z) {
		API::instance->SetPlayerPosition(guid, x, y, z);
	}
	EXPORT bool SetPlayerModel(long guid, long model) {
		return API::instance->SetPlayerModel(guid, model);
	}
	EXPORT long GetPlayerModel(long guid) {
		return API::instance->GetPlayerModel(guid);
	}
	EXPORT bool RemovePlayerWeapons(long guid) {
		return API::instance->RemovePlayerWeapons(guid);
	}
	EXPORT bool GivePlayerWeapon(long guid, long weapon, long ammo) {
		return API::instance->GivePlayerWeapon(guid, weapon, ammo);
	}
	EXPORT bool GivePlayerAmmo(long guid, long weapon, long ammo) {
		return API::instance->GivePlayerAmmo(guid, weapon, ammo);
	}

	// Vehicles
	EXPORT unsigned long CreateVehicle(long vehicle, float x, float y, float z) {
		return API::instance->CreateVehicle(vehicle, x, y, z, 0);
	}
	EXPORT bool DeleteVehicle(unsigned long guid) {
		return API::instance->DeleteVehicle(guid);
	}
	EXPORT bool SetVehiclePosition(unsigned long guid, float x, float y, float z) {
		return API::instance->SetVehiclePosition(guid, x, y, z);
	}
	EXPORT Vector3 GetVehiclePosition(unsigned long guid) {
		CVector3 vector = API::instance->GetVehiclePosition(guid);
		Vector3 pos{ vector.fX, vector.fY, vector.fZ };
		return pos;
	}
	EXPORT bool SetVehicleRotation(unsigned long guid, float rx, float ry, float rz) {
		return API::instance->SetVehicleRotation(guid, rx, ry, rz);
	}
	EXPORT Vector3 GetVehicleRotation(unsigned long guid) {
		CVector3 vector = API::instance->GetVehicleRotation(guid);
		Vector3 rot{ vector.fX, vector.fY, vector.fZ };
		return rot;
	}
	EXPORT bool SetVehiclePrimaryColor(unsigned long guid, unsigned char r, unsigned char g, unsigned char b) {
		return API::instance->SetVehicleCustomPrimaryColor(guid, r, g, b);
	}
	EXPORT RGB GetVehiclePrimaryColor(unsigned long guid) {
		RGB rgb;
		API::instance->GetVehicleCustomPrimaryColor(guid, &rgb.r, &rgb.g, &rgb.b);
		return rgb;
	}
	EXPORT bool SetVehicleSecondaryColor(unsigned long guid, unsigned char r, unsigned char g, unsigned char b) {
		return API::instance->SetVehicleCustomSecondaryColor(guid, r, g, b);
	}
	EXPORT RGB GetVehicleSecondaryColor(unsigned long guid, unsigned char *rColor, unsigned char *gColor, unsigned char *bColor) {
		RGB rgb;
		API::instance->GetVehicleCustomPrimaryColor(guid, &rgb.r, &rgb.g, &rgb.b);
		return rgb;
	}
	EXPORT bool SetVehicleEngineStatus(unsigned long guid, bool status, bool locked) {
		return API::instance->SetVehicleEngineStatus(guid, status, locked);
	}
	EXPORT bool GetVehicleEngineStatus(unsigned long guid) {
		return API::instance->GetVehicleEngineStatus(guid);
	}
	EXPORT bool SetVehicleLocked(unsigned long guid, bool locked) {
		return API::instance->SetVehicleLocked(guid, locked);
	}
	EXPORT bool IsVehicleLocked(unsigned long guid) {
		return API::instance->IsVehicleLocked(guid);
	}
	EXPORT bool SetVehicleBodyHealth(unsigned long guid, float health) {
		return API::instance->SetVehicleBodyHealth(guid, health);
	}
	EXPORT bool SetVehicleEngineHealth(unsigned long guid, float health) {
		return API::instance->SetVehicleEngineHealth(guid, health);
	}
	EXPORT bool SetVehicleTankHealth(unsigned long guid, float health) {
		return API::instance->SetVehicleTankHealth(guid, health);
	}
	EXPORT VehicleHealth GetVehicleHealth(unsigned long guid) {
		VehicleHealth healths;
		API::instance->GetVehicleHealth(guid, &healths.body, &healths.engine, &healths.tank);
		return healths;
	}
	EXPORT bool SetVehicleNumberPlate(unsigned long guid, const char *text) {
		return API::instance->SetVehicleNumberPlate(guid, text);
	}
	EXPORT const char* GetVehicleNumberPlate(unsigned long guid) {
		std::string plate = API::instance->GetVehicleNumberPlate(guid);
		return plate.c_str();
	}
	EXPORT bool SetVehicleNumberPlateStyle(unsigned long guid, unsigned char style) {
		return API::instance->SetVehicleNumberPlateStyle(guid, style);
	}
	EXPORT unsigned char GetVehicleNumberPlateStyle(unsigned long guid) {
		unsigned char byte;
		API::instance->GetVehicleNumberPlateStyle(guid, &byte);
		return byte;
	}
	EXPORT bool SetVehicleSirenState(unsigned long guid, bool state) {
		return API::instance->SetVehicleSirenState(guid, state);
	}
	EXPORT bool GetVehicleSirenState(unsigned long guid) {
		return API::instance->GetVehicleSirenState(guid);
	}
	EXPORT bool SetVehicleWheelColor(unsigned long guid, unsigned char color) {
		return API::instance->SetVehicleWheelColor(guid, color);
	}
	EXPORT unsigned char GetVehicleWheelColor(unsigned long guid) {
		unsigned char byte;
		API::instance->GetVehicleWheelColor(guid, &byte);
		return byte;
	}
	EXPORT bool SetVehicleWheelType(unsigned long guid, unsigned char type) {
		return API::instance->SetVehicleWheelType(guid, type);
	}
	EXPORT unsigned char GetVehicleWheelType(unsigned long guid) {
		unsigned char byte;
		API::instance->GetVehicleWheelType(guid, &byte);
		return byte;
	}
	EXPORT bool SetVehicleLights(unsigned long guid, unsigned char LightState) {
		return API::instance->SetVehicleLights(guid, LightState);
	}
	EXPORT bool GetVehicleLights(unsigned long guid) {
		unsigned char byte;
		API::instance->GetVehicleWheelType(guid, &byte);
		return byte;
	}
	EXPORT unsigned int GetVehicleDriver(unsigned long guid) {
		return API::instance->GetVehicleDriver(guid);
	}
	EXPORT unsigned int* GetVehiclePassengers(unsigned long guid) {
		std::vector<unsigned int> pass = API::instance->GetVehiclePassengers(guid);
		return pass.data();
	}

	// Objects
	EXPORT unsigned long CreateObject(long model, float x, float y, float z, float rx, float ry, float rz) {
		return API::instance->CreateObject(model, x, y, z, rx, ry, rz);
	}
	EXPORT bool DeleteObject(unsigned long guid) {
		return API::instance->DeleteObject(guid);
	}
	EXPORT unsigned long Create3DText(const char* text, float x, float y, float z, int color, int outColor, float fontSize) {
		return API::instance->Create3DText(text, x, y, z, color, outColor, fontSize);
	}
	EXPORT unsigned long Create3DTextForPlayer(long guid, const char* text, float x, float y, float z, int color, int outColor, float fontSize) {
		return API::instance->Create3DTextForPlayer(guid, text, x, y, z, color, outColor);
	}
	EXPORT bool Attach3DTextToPlayer(unsigned long guid, long player, float x, float y, float z) {
		return API::instance->Attach3DTextToPlayer(guid, player, x, y, z);
	}
	EXPORT bool Attach3DTextToVehicle(unsigned long guid, unsigned long vehicle, float x, float y, float z) {
		return API::instance->Attach3DTextToVehicle(guid, vehicle, x, y, z);
	}
	EXPORT bool Delete3DText(unsigned long guid) {
		return API::instance->Delete3DText(guid);
	}
	EXPORT bool CreatePickup(int type, float x, float y, float z, float scale) {
		return API::instance->CreatePickup(type, x, y, z, scale);
	}

	// Blips
	EXPORT unsigned long CreateBlipForAll(const char* name, float x, float y, float z, float scale, int color, int sprite) {
		return API::instance->CreateBlipForAll(name, x, y, z, scale, color, sprite);
	}
	EXPORT unsigned long CreateBlipForPlayer(long guid, const char* name, float x, float y, float z, float scale, int color, int sprite) {
		return API::instance->CreateBlipForPlayer(guid, name, x, y, z, scale, color, sprite);
	}
	EXPORT void DeleteBlip(unsigned long guid) {
		API::instance->DeleteBlip(guid);
	}
	EXPORT void SetBlipColor(unsigned long guid, int color) {
		API::instance->SetBlipColor(guid, color);
	}
	EXPORT void SetBlipScale(unsigned long guid, float scale) {
		API::instance->SetBlipScale(guid, scale);
	}
	EXPORT void SetBlipRoute(unsigned long guid, bool route) {
		API::instance->SetBlipRoute(guid, route);
	}
	EXPORT void SetBlipSprite(unsigned long guid, int sprite) {
		API::instance->SetBlipSprite(guid, sprite);
	}
	EXPORT void SetBlipName(unsigned long guid, const char* name) {
		API::instance->SetBlipName(guid, name);
	}
	EXPORT void SetBlipAsShortRange(unsigned long guid, bool _short) {
		API::instance->SetBlipAsShortRange(guid, _short);
	}
	EXPORT void AttachBlipToPlayer(unsigned long guid, long player) {
		API::instance->AttachBlipToPlayer(guid, player);
	}
	EXPORT void AttachBlipToVehicle(unsigned long guid, unsigned long vehicle) {
		API::instance->AttachBlipToVehicle(guid, vehicle);
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