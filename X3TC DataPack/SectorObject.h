#pragma once
#include "SectorObjectManager.h"
#include "Vector3.h"
#include "DynamicValue.h"

namespace X3TC {
	namespace SectorObjects {

		class SectorObject {
		public:
			int Unknown_1;
			int Unknown_2;
			int ObjectID;
			char* pDefaultName;
			int Speed;
			int TargetSpeed;
			Vector3 EulerRotationCopy;
			Vector3 LocalEulerRotationDelta;
			int Unknown_3;
			int Unknown_4;
			int Unknown_5;
			int RaceID;
			int InteractionFlags;
			int Unknown_6;
			short MainType;
			short SubType;
			int Unknown_7;
			void* pMeta;
			SectorObject* pParent;
			int Unknown_9;
			int Unknown_10;
			Vector3 PositionStrafeDelta;
			int Unknown_11;
			void* pData;
			int Unknown_12;
			int Unknown_13;
			int Unknown_14;
			int Unknown_15;
			short Unknown_16;
			short Unknown_17;
			int Unknown_18;
			DynamicValue dynamicValue;
			char Unknown_19;
			char Unknown_20;
			char Unknown_21;
			int EventObjectID;
			int Unknown_22;
			short Unknown_23;
			short Unknown_24;
			int Unknown_25;
			int Unkown_26;
			int AbsTime;
			int Unkown_27;
			int null_value;
			int Unkown_28;

		};
	}
}