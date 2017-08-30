#pragma once
#include <string>
#include <map>
#include <vector>
#include <memory>
#include "CVector3.h"

enum {
	M_NIL,
	M_BOOL,
	M_INT,
	M_UINT,
	M_DOUBLE,
	M_STRING,
	M_DICT
};

class MValue
{
	struct MDict {
		std::map<int, std::shared_ptr<MValue>> int_keys;
		std::map<std::string, std::shared_ptr<MValue>> string_keys;
	};

public:
	MValue() {
		type = M_NIL;
	};

	MValue(bool _val) {
		type = M_BOOL;
		bool_val = _val;
	};

	MValue(int _val) {
		type = M_INT;
		int_val = _val;
	};

	MValue(unsigned int _val) {
		type = M_UINT;
		uint_val = _val;
	};

	MValue(double _val) {
		type = M_DOUBLE;
		double_val = _val;
	};

	MValue(const char* _val) {
		type = M_STRING;
		string_val = strdup(_val);
	};

	MValue(unsigned long _val) {
		type = M_UINT;
		uint_val = _val;
	};

	~MValue() {
		switch (type)
		{
		case M_STRING:
			free(string_val);
			break;
		case M_DICT:
			delete dict_val;
			break;
		default:
			break;
		}
	};

	static std::shared_ptr<MValue> CreateNil() {
		MValue *val = new MValue;
		return std::shared_ptr<MValue>(val);
	};

	static std::shared_ptr<MValue> CreateBool(bool _val) {
		MValue *val = new MValue;
		val->type = M_BOOL;
		val->bool_val = _val;
		return std::shared_ptr<MValue>(val);
	};

	static std::shared_ptr<MValue> CreateInt(int _val) {
		MValue *val = new MValue;
		val->type = M_INT;
		val->int_val = _val;
		return std::shared_ptr<MValue>(val);
	};

	static std::shared_ptr<MValue> CreateUInt(unsigned int _val) {
		MValue *val = new MValue;
		val->type = M_UINT;
		val->uint_val = _val;
		return std::shared_ptr<MValue>(val);
	};

	static std::shared_ptr<MValue> CreateDouble(double _val) {
		MValue *val = new MValue;
		val->type = M_DOUBLE;
		val->double_val = _val;
		return std::shared_ptr<MValue>(val);
	};

	static std::shared_ptr<MValue> CreateString(const char* _val) {
		MValue *val = new MValue;
		val->type = M_STRING;
		val->string_val = strdup(_val);
		return std::shared_ptr<MValue>(val);
	};

	static std::shared_ptr<MValue> CreateDict() {
		MValue *val = new MValue;
		val->type = M_DICT;
		val->dict_val = new MDict();
		return std::shared_ptr<MValue>(val);
	};

	bool IsNil() { return type == M_NIL; };
	bool IsBool() { return type == M_BOOL; };
	bool IsInt() { return type == M_INT; };
	bool IsUInt() { return type == M_UINT; };
	bool IsDouble() { return type == M_DOUBLE; };
	bool IsString() { return type == M_STRING; };
	bool IsDict() { return type == M_DICT; };

	bool getBool() {
		switch (type) {
		case M_NIL:
			return 0;
		case M_BOOL:
			return bool_val != 0;
		case M_INT:
			return int_val != 0;
		case M_UINT:
			return uint_val != 0;
		case M_DOUBLE:
			return double_val != 0;
		case M_STRING:
			return 1;
		case M_DICT:
			return 1;
		}
	};

	int getInt() {
		switch (type) {
		case M_NIL:
			return 0;
		case M_BOOL:
			return bool_val;
		case M_INT:
			return int_val;
		case M_UINT:
			return uint_val;
		case M_DOUBLE:
			return double_val;
		case M_STRING:
			return std::stoi(string_val);
		case M_DICT:
			return 0;
		}
	};

	unsigned int getUInt() {
		switch (type) {
		case M_NIL:
			return 0;
		case M_BOOL:
			return bool_val;
		case M_INT:
			return int_val;
		case M_UINT:
			return uint_val;
		case M_DOUBLE:
			return double_val;
		case M_STRING:
			return std::stoi(string_val);
		case M_DICT:
			return 0;
		}
	};

	double getDouble() {
		switch (type) {
		case M_NIL:
			return 0;
		case M_BOOL:
			return bool_val;
		case M_INT:
			return int_val;
		case M_UINT:
			return uint_val;
		case M_DOUBLE:
			return double_val;
		case M_STRING:
			return std::stod(string_val);
		case M_DICT:
			return 0;
		}
	};

	const std::map<int, std::shared_ptr<MValue>> &getIntDict()
	{
		if (type != M_DICT) throw std::runtime_error("Trying to get dict from non-dict type");
		return dict_val->int_keys;
	}

	const std::map<std::string, std::shared_ptr<MValue>> &getStringDict()
	{
		if (type != M_DICT) throw std::runtime_error("Trying to get dict from non-dict type");
		return dict_val->string_keys;
	}

	std::string getString() {
		switch (type) {
		case M_NIL:
			return "nil";
		case M_BOOL:
			return bool_val ? "true" : "false";
		case M_INT:
			return std::to_string(int_val);
		case M_UINT:
			return std::to_string(uint_val);
		case M_DOUBLE:
			return std::to_string(double_val);
		case M_STRING:
			return string_val;
		case M_DICT:
			return "[i'm a dict!]";
		}
	};

	int getType() { return type; };

	std::shared_ptr<MValue>& get(int&& _key) {
		if (type != M_DICT) throw std::runtime_error("Trying to us [] on non-dict type");
		return dict_val->int_keys[_key];
	};

	std::shared_ptr<MValue>& get(std::string&& _key) {
		if (type != M_DICT) throw std::runtime_error("Trying to us [] on non-dict type");
		return dict_val->string_keys[_key];
	};

	void push(int _key, std::shared_ptr<MValue> _val) {
		if (type != M_DICT) return;
		dict_val->int_keys[_key] = _val;
	}

	void push(std::string& _key, std::shared_ptr<MValue> _val) {
		if (type != M_DICT) return;
		dict_val->string_keys[_key] = _val;
	}

	std::shared_ptr<MValue>& operator[](int&& _key) {
		if (type != M_DICT) throw std::runtime_error("Trying to us [] on non-dict type");
		return dict_val->int_keys[_key];
	};

	std::shared_ptr<MValue>& operator[](std::string&& _key) {
		if (type != M_DICT) throw std::runtime_error("Trying to us [] on non-dict type");
		return dict_val->string_keys[_key];
	};

	std::shared_ptr<MValue>& operator[](const int& _key) {
		if (type != M_DICT) throw std::runtime_error("Trying to us [] on non-dict type");
		return dict_val->int_keys[_key];
	};

	std::shared_ptr<MValue>& operator[](const std::string& _key) {
		if (type != M_DICT) throw std::runtime_error("Trying to us [] on non-dict type");
		return dict_val->string_keys[_key];
	};

	size_t size() {
		if (type != M_DICT) return 0;
		return dict_val->int_keys.size() + dict_val->string_keys.size();
	}

private:
	int type;
	union {
		bool bool_val;
		int int_val;
		unsigned int uint_val;
		double double_val;
		char* string_val;
		MDict* dict_val;
	};
};

typedef std::vector<std::shared_ptr<MValue>> MValueList;

class APIBase {
public:
	virtual void LoadClientScript(std::string name, char* buffer, size_t size) = 0;
	virtual void ClientEvent(const char * name, MValueList& args, long playerid) = 0;
	virtual bool ServerEvent(std::string e, MValueList& args) = 0;
	//Player
	virtual bool PlayerExists(long playerid) = 0;
	virtual void KickPlayer(long playerid) = 0;
	virtual void KickPlayer(long playerid, const char * reason) = 0;
	virtual bool SetPlayerPosition(long playerid, float x, float y, float z) = 0;
	virtual CVector3 GetPlayerPosition(long playerid) = 0;
	virtual bool IsPlayerInRange(long playerid, float x, float y, float z, float range) = 0;
	virtual bool SetPlayerHeading(long playerid, float angle) = 0;
	virtual float GetPlayerHeading(long playerid) = 0;
	virtual bool RemovePlayerWeapons(long playerid) = 0;
	virtual bool GivePlayerWeapon(long playerid, long weapon, long ammo) = 0;
	virtual bool GivePlayerAmmo(long playerid, long weapon, long ammo) = 0;
	virtual bool GivePlayerMoney(long playerid, long money) = 0;
	virtual bool SetPlayerMoney(long playerid, long money) = 0;
	virtual bool ResetPlayerMoney(long playerid) = 0;
	virtual size_t GetPlayerMoney(long playerid) = 0;
	virtual bool SetPlayerModel(long playerid, long model) = 0;
	virtual long GetPlayerModel(long playerid) = 0;
	virtual bool SetPlayerWorld(long playerid, unsigned short world) = 0;
	virtual unsigned short GetPlayerWorld(long playerid) = 0;
	virtual bool SetPlayerName(long playerid, const char * name) = 0;
	virtual std::string GetPlayerName(long playerid) = 0;
	virtual bool SetPlayerHealth(long playerid, float health) = 0;
	virtual float GetPlayerHealth(long playerid) = 0;
	virtual bool SetPlayerArmor(long playerid, float armor) = 0;
	virtual float GetPlayerArmor(long playerid) = 0;
	virtual bool SetPlayerColor(long playerid, unsigned int color) = 0;
	virtual unsigned int GetPlayerColor(long playerid) = 0;
	virtual bool SendMessageToAll(const char* message) = 0;
	virtual bool SendMessageToPlayer(long playerid, const char* message) = 0;
	virtual bool SetPlayerIntoVehicle(long playerid, unsigned long vehicle, char seat) = 0;
	virtual void DisablePlayerHud(long playerid, bool toggle) = 0;
	virtual unsigned long GetPlayerGUID(long playerid) = 0;

	//World
	virtual void Print(const char * message) = 0;
	virtual long Hash(const char * str) = 0;

	//TODO
	virtual bool VehicleExists(unsigned long guid) = 0;
	virtual unsigned long CreateVehicle(long hash, float x, float y, float z, float heading) = 0;
	virtual bool DeleteVehicle(unsigned long vehid) = 0;
	virtual bool SetVehiclePosition(unsigned long vehid, float x, float y, float z) = 0;
	virtual CVector3 GetVehiclePosition(unsigned long vehid) = 0;
	virtual bool SetVehicleRotation(unsigned long vehid, float rx, float ry, float rz) = 0;
	virtual CVector3 GetVehicleRotation(unsigned long vehid) = 0;
	virtual bool SetVehicleColors(unsigned long vehid, unsigned char Color1, unsigned char Color2) = 0;
	virtual bool GetVehicleColors(unsigned long vehid, unsigned char *Color1, unsigned char *Color2) = 0;
	virtual bool SetVehiclePrimaryColor(unsigned long guid, unsigned char Color) = 0;
	virtual bool GetVehiclePrimaryColor(unsigned long guid, unsigned char *Color) = 0;
	virtual bool SetVehicleSecondaryColor(unsigned long guid, unsigned char Color) = 0;
	virtual bool GetVehicleSecondaryColor(unsigned long guid, unsigned char *Color) = 0;
	virtual bool SetVehicleTiresBulletproof(unsigned long vehid, bool bulletproof) = 0;
	virtual bool GetVehicleTiresBulletproof(unsigned long vehid) = 0;
	virtual bool HasVehicleCustomColors(unsigned long guid, bool *PrimaryColor, bool *SecondaryColor) = 0;
	virtual bool SetVehicleCustomColors(unsigned long guid, unsigned char PrimaryColorR, unsigned char PrimaryColorG, unsigned char PrimaryColorB, unsigned char SecondaryColorR, unsigned char SecondaryColorG, unsigned char SecondaryColorB) = 0;
	virtual bool GetVehicleCustomColors(unsigned long guid, unsigned char *PrimaryColorR, unsigned char *PrimaryColorG, unsigned char *PrimaryColorB, unsigned char *SecondaryColorR, unsigned char *SecondaryColorG, unsigned char *SecondaryColorB) = 0;
	virtual bool SetVehicleCustomPrimaryColor(unsigned long vehid, unsigned char rColor, unsigned char gColor, unsigned char bColor) = 0;
	virtual bool GetVehicleCustomPrimaryColor(unsigned long vehid, unsigned char *rColor, unsigned char *gColor, unsigned char *bColor) = 0;
	virtual bool SetVehicleCustomSecondaryColor(unsigned long vehid, unsigned char rColor, unsigned char gColor, unsigned char bColor) = 0;
	virtual bool GetVehicleCustomSecondaryColor(unsigned long vehid, unsigned char *rColor, unsigned char *gColor, unsigned char *bColor) = 0;
	virtual bool SetVehicleEngineStatus(unsigned long vehid, bool status, bool locked) = 0;
	virtual bool GetVehicleEngineStatus(unsigned long vehid) = 0;
	virtual bool SetVehicleLocked(unsigned long vehid, bool locked) = 0;
	virtual bool IsVehicleLocked(unsigned long vehid) = 0;
	virtual bool SetVehicleBodyHealth(unsigned long vehid, float health) = 0;
	virtual bool SetVehicleEngineHealth(unsigned long vehid, float health) = 0;
	virtual bool SetVehicleTankHealth(unsigned long vehid, float health) = 0;
	virtual bool GetVehicleHealth(unsigned long vehid, float *body, float *engine, float *tank) = 0;
	virtual bool SetVehicleNumberPlate(unsigned long vehid, const char *text) = 0; //Not implemented
	virtual std::string GetVehicleNumberPlate(unsigned long vehid) = 0; //Not implemented
	virtual bool SetVehicleNumberPlateStyle(unsigned long vehid, unsigned char style) = 0;
	virtual bool GetVehicleNumberPlateStyle(unsigned long vehid, unsigned char *NumberPlateStyle) = 0;
	virtual bool SetVehicleSirenState(unsigned long vehid, bool state) = 0;
	virtual bool GetVehicleSirenState(unsigned long vehid) = 0;
	virtual bool SetVehicleWheelColor(unsigned long vehid, unsigned char color) = 0;
	virtual bool GetVehicleWheelColor(unsigned long vehid, unsigned char *WheelColor) = 0;
	virtual bool SetVehicleWheelType(unsigned long vehid, unsigned char type) = 0;
	virtual bool GetVehicleWheelType(unsigned long vehid, unsigned char *WheelType) = 0;
	virtual bool SetVehicleLights(unsigned long vehid, unsigned char LightState) = 0;
	virtual bool GetVehicleLights(unsigned long vehid, unsigned char *LightState) = 0;
	virtual int GetVehicleDriver(unsigned long vehid) = 0;
	virtual std::vector<unsigned int> GetVehiclePassengers(unsigned long vehid) = 0;

	virtual unsigned long CreateObject(long model, float x, float y, float z, float pitch, float yaw, float roll) = 0;
	virtual bool DeleteObject(unsigned long guid) = 0;

	virtual bool CreatePickup(int type, float x, float y, float z, float scale) = 0;

	virtual unsigned long CreateBlipForAll(std::string name, float x, float y, float z, float scale, int color, int sprite) = 0;
	virtual unsigned long CreateBlipForPlayer(long playerid, std::string name, float x, float y, float z, float scale, int color, int sprite) = 0;
	virtual void DeleteBlip(unsigned long guid) = 0;
	virtual void SetBlipColor(unsigned long guid, int color) = 0;
	virtual void SetBlipScale(unsigned long guid, float scale) = 0;
	virtual void SetBlipRoute(unsigned long guid, bool route) = 0;
	virtual void SetBlipSprite(unsigned long guid, int sprite) = 0;
	virtual void SetBlipName(unsigned long guid, std::string name) = 0;
	virtual void SetBlipAsShortRange(unsigned long guid, bool _short) = 0;
	virtual void AttachBlipToPlayer(unsigned long _guid, long player) = 0;
	virtual void AttachBlipToVehicle(unsigned long _guid, unsigned long vehicle) = 0;

	virtual unsigned long CreateMarkerForAll(float x, float y, float z, float height, float radius) = 0;
	virtual unsigned long CreateMarkerForPlayer(long playerid, float x, float y, float z, float height, float radius) = 0;
	virtual void DeleteMarker(unsigned long guid) = 0;

	virtual bool SendNotification(long playerid, const char * msg) = 0;
	virtual bool SetInfoMsg(long playerid, const char * msg) = 0;
	virtual bool UnsetInfoMsg(long playerid) = 0;

	virtual unsigned long Create3DText(const char * text, float x, float y, float z, int color, int outColor, float fontSize) = 0;
	virtual unsigned long Create3DTextForPlayer(unsigned long player, const char * text, float x, float y, float z, int color, int outColor) = 0;
	virtual bool Attach3DTextToVehicle(unsigned long textId, unsigned long vehicle, float oX, float oY, float oZ) = 0;
	virtual bool Attach3DTextToPlayer(unsigned long textId, unsigned long player, float oX, float oY, float oZ) = 0;
	virtual bool Set3DTextContent(unsigned long textId, const char * text) = 0;
	virtual bool Delete3DText(unsigned long textId) = 0;

	//UNSORTED

	virtual bool SetPlayerSyncedData(unsigned int playerid, const char* key, const std::shared_ptr<MValue> &val) = 0;
	virtual std::shared_ptr<MValue> GetPlayerSyncedData(unsigned int playerid, const char* key) = 0;
	virtual unsigned short GetPlayerPing(uint32_t playerid) = 0;
};

#ifndef GTA_ORANGE_SERVER
class API : public APIBase
{
public:
	static API * instance;
	static void Set(API * api) { instance = api; }
	static API& Get() { return *instance; }
};
#endif
