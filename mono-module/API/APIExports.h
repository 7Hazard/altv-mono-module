#pragma once

#include "../mono-module.h"
#include "../Export.h"

typedef struct {
	float x, y, z;
} Vector3;

typedef struct {
	float body, engine, tank;
} VehicleHealth;

typedef struct {
	unsigned char r, g, b;
} RGB;

typedef struct {
	int type;
	union {
		bool bool_val;
		int int_val;
		unsigned int uint_val;
		double double_val;
		const char* string_val;
		//MDict* dict_val;
	};
} EValue;

MValueList GetMValueList(EValue* args, int size);

std::shared_ptr<MValue> EToMValue(EValue& value);
EValue MToEValue(std::shared_ptr<MValue> value);