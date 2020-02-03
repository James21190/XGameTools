#pragma once
#include "SectorObject.h"
namespace X3TC {
	namespace SectorObjects {

		class SectorObjectManager {
		public:
			int Unknown_1;
			int Unknown_2;
			SectorObject* pFirstSectorObject;
			int null_value;
			SectorObject* pLastSectorObject;
			int pObjectHashTable;
			int Unknown_3;
			int Unknown_4;
			int Unknown_5;
			int Unknown_6;
			int Unknown_7;
			int Unknown_8;
			int Unknown_9;
			int Unknown_10;
			SectorObject* pPlayerShip;
			int Unknown_11;
			int Unknown_12;
			int Unknown_13;
			int Unknown_14;
			int Unknown_15;
			int Unknown_16;
			int Unknown_17;
			int Unknown_18;
			int Unknown_19;
			int FunctionIndex;
			int Unknown_20;

			static SectorObjectManager* GetSectorObjectManager() { return *((SectorObjectManager**)0x00604640); }
		};
	}
}