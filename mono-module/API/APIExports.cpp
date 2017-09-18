#include "APIExports.h"

extern "C" {
	// Mono
	/*EXPORT void LoadResource(char* resource) {
		Mono::LoadResource(resource);
	}
	EXPORT void UnloadResource(char* resource) {
		Mono::UnloadResource(resource);
	}*/

	// Server/Console
	EXPORT void Print(const char* msg) {
		API::instance->Print(msg);
	}
	EXPORT long Hash(const char* msg) {
		return API::instance->Hash(msg);
	}
	EXPORT void Shutdown() {
		Error("Shutting down the server programmatically is not implemented yet.");
	}
	EXPORT void ServerEvent(const char* e, EValue* args, int size) {
		MValueList values = GetMValueList(args, size);
		API::instance->ServerEvent(e, values);
	}

	// Clients/Players
	EXPORT void ClientEvent(long playerid, const char* e, EValue* args, int size) {
		MValueList values = GetMValueList(args, size);
		API::instance->ClientEvent(e, values, playerid);
	}
	EXPORT void KickPlayer(long playerid, const char* reason) {
		if (reason == nullptr) {
			API::instance->KickPlayer(playerid);
		}
		API::instance->KickPlayer(playerid, reason);
	}
	EXPORT Vector3 GetPlayerPosition(long playerid) {
		CVector3 vector = API::instance->GetPlayerPosition(playerid);
		Vector3 pos{ vector.fX, vector.fY, vector.fZ };
		return pos;
	}
	EXPORT void SetPlayerPosition(long playerid, float x, float y, float z) {
		API::instance->SetPlayerPosition(playerid, x, y, z);
	}
	EXPORT bool IsPlayerInRange(long playerid, float x, float y, float z, float range) {
		return API::instance->IsPlayerInRange(playerid, x, y, z, range);
	}
	EXPORT bool SetPlayerHeading(long playerid, float angle) {
		return API::instance->SetPlayerHeading(playerid, angle);
	}
	EXPORT float GetPlayerHeading(long playerid) {
		return API::instance->GetPlayerHeading(playerid);
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
	EXPORT bool GivePlayerMoney(long playerid, long money) {
		return API::instance->GivePlayerMoney(playerid, money);
	}
	EXPORT bool SetPlayerMoney(long playerid, long money) {
		return API::instance->SetPlayerMoney(playerid, money);
	}
	EXPORT bool ResetPlayerMoney(long playerid) {
		return API::instance->ResetPlayerMoney(playerid);
	}
	EXPORT long GetPlayerMoney(long playerid) {
		return API::instance->GetPlayerMoney(playerid);
	}
	EXPORT bool SetPlayerModel(long playerid, long model) {
		return API::instance->SetPlayerModel(playerid, model);
	}
	EXPORT long GetPlayerModel(long playerid) {
		return API::instance->GetPlayerModel(playerid);
	}
	EXPORT void SetPlayerName(long playerid, const char* name) {
		API::instance->SetPlayerName(playerid, name);
	}
	EXPORT void GetPlayerName(long playerid, char* sb) {
		std::string name = API::instance->GetPlayerName(playerid);
		Print(name);
		strcpy(sb, name.c_str());
	}
	EXPORT bool SetPlayerHealth(long playerid, float health) {
		return API::instance->SetPlayerHealth(playerid, health);
	}
	EXPORT float GetPlayerHealth(long playerid) {
		return API::instance->GetPlayerHealth(playerid);
	}
	EXPORT bool SetPlayerArmor(long playerid, float armor) {
		return API::instance->SetPlayerArmor(playerid, armor);
	}
	EXPORT unsigned int GetPlayerColor(long playerid) {
		return API::instance->GetPlayerColor(playerid);
	}
	EXPORT void SendMessageToAll(const char* message) {
		API::instance->SendMessageToAll(message);
	}
	EXPORT bool SendMessageToPlayer(long playerid, const char * message) {
		return API::instance->SendMessageToPlayer(playerid, message);
	}
	EXPORT bool SetPlayerIntoVehicle(long playerid, unsigned long vehicle, char seat) {
		return API::instance->SetPlayerIntoVehicle(playerid, vehicle, seat);
	}
	EXPORT void DisablePlayerHud(long playerid, bool disabled) {
		API::instance->DisablePlayerHud(playerid, disabled);
	}
	EXPORT unsigned long GetPlayerGUID(long playerid) {
		return API::instance->GetPlayerGUID(playerid);
	}
	EXPORT bool SetPlayerWorld(long playerid, unsigned short world) {
		return API::instance->SetPlayerWorld(playerid, world);
	}
	EXPORT unsigned short GetPlayerWorld(long playerid) {
		return API::instance->GetPlayerWorld(playerid);
	}
	EXPORT bool SetPlayerSyncedData(unsigned int playerid, const char* key, EValue* value) {
		return API::instance->SetPlayerSyncedData(playerid, key, EToMValue(*value));
	}
	EXPORT EValue GetPlayerSyncedData(unsigned int playerid, const char* key) {
		return MToEValue(API::instance->GetPlayerSyncedData(playerid, key));
	}

	// Vehicles
	EXPORT unsigned long CreateVehicle(long vehicle, float x, float y, float z, float heading) {
		return API::instance->CreateVehicle(vehicle, x, y, z, heading);
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
	EXPORT bool SetVehicleTiresBulletproof(unsigned long guid, bool bulletproof) {
		return API::instance->SetVehicleTiresBulletproof(guid, bulletproof);
	}
	EXPORT bool GetVehicleTiresBulletproof(unsigned long guid) {
		return API::instance->GetVehicleTiresBulletproof(guid);
	}
	EXPORT bool HasVehicleCustomColors(unsigned long guid) {
		bool colors[2];
		API::instance->HasVehicleCustomColors(guid, &colors[0], &colors[1]);
		return colors;
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

	// Markers
	EXPORT unsigned long CreateMarkerForAll(float x, float y, float z, float height, float radius) {
		return API::instance->CreateMarkerForAll(x, y, z, height, radius);
	}
	EXPORT unsigned long CreateMarkerForPlayer(long playerid, float x, float y, float z, float height, float radius) {
		return API::instance->CreateMarkerForPlayer(playerid, x, y, z, height, radius);
	}
	EXPORT void DeleteMarker(unsigned long guid) {
		API::instance->DeleteMarker(guid);
	}

	// Notifications
	EXPORT bool SendNotification(long playerid, const char * msg) {
		return API::instance->SendNotification(playerid, msg);
	}
	EXPORT bool SetInfoMsg(long playerid, const char * msg) {
		return API::instance->SetInfoMsg(playerid, msg);
	}
	EXPORT bool UnsetInfoMsg(long playerid) {
		return API::instance->UnsetInfoMsg(playerid);
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

std::shared_ptr<MValue> EToMValue(EValue& value) {
	switch (value.type)
	{
	case M_STRING: {
		return MValue::CreateString(value.string_val);
	}
	case M_INT: {
		return MValue::CreateInt(value.int_val);
	}
	case M_BOOL: {
		return MValue::CreateBool(value.bool_val);
	}
	case M_UINT: {
		return MValue::CreateUInt(value.uint_val);
	}
	case M_DOUBLE: {
		return MValue::CreateDouble(value.double_val);
	}
	default:
		return MValue::CreateNil();
	}
}

EValue MToEValue(std::shared_ptr<MValue> value) {
	EValue evalue;
	switch (value->getType())
	{
	case M_STRING: {
		const std::string& val = value->getString();
		evalue.string_val = val.c_str();
		break;
	}
	case M_INT: {
		evalue.int_val = value->getInt();
		break;
	}
	case M_BOOL: {
		evalue.bool_val = value->getBool();
		break;
	}
	case M_UINT: {
		evalue.uint_val = value->getUInt();
		break;
	}
	case M_DOUBLE: {
		evalue.double_val = value->getDouble();
		break;
	}
	default:
		break;
	}
	return evalue;
}