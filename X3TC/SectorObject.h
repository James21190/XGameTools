#pragma once

#include "Vector3.h"
#include "UndefinedTypes.h"
#include "DynamicValue.h"

using namespace X3TC::Generics;
using namespace X3TC::StoryBase;

namespace X3TC {namespace Sector {

    typedef enum RaceID {
        None = 65535
    } RaceID;

    typedef enum MainType {
        Asteroid = 17,
        Background = 2,
        Bullet = 0,
        Camera = 19,
        Cockpit = 25,
        Debris = 28,
        Dock = 5,
        Factory = 6,
        FactoryWreck = 30,
        Gate = 18,
        Laser = 8,
        Missile = 10,
        NONE = 65535,
        Planet = 4,
        Sector = 1,
        Shield = 9,
        Ship = 7,
        ShipWreck = 31,
        Special = 20,
        Sun = 3,
        WareB = 13,
        WareE = 11,
        WareF = 14,
        WareM = 15,
        WareN = 12,
        WareT = 16,
        Wreck = 29
    } MainType;
	struct SectorObject {

	public:
        struct SectorObject* pNext;
        struct SectorObject* pPrevious;
        int ObjectID; /* The numeric ID of the ship. */
        char* pDefaultName; /* Pointer to the default name of the ship. */
        int Speed;
        int TargetSpeed;
        struct Vector3 EulerRotationCopy; /* A copy of the current rotation of the ship. */
        struct Vector3 LocalEulerRotationDelta; /* The current rotation change relative to the ship. */
        struct Vector3 AutopilotDeltaTarget;
        enum RaceID RaceID;
        undefined2 field_0x3e;
        undefined4 InteractionFlags;
        undefined4 field_0x44;
        enum MainType MainType;
        short SubType;
        undefined4 field_0x4c;
        void* pMeta;
        struct SectorObject* pParent;
        undefined4 field_0x58;
        undefined4 field_0x5c;
        struct Vector3 PositionStrafeDelta;
        undefined4 field_0x6c;
        struct RenderObject* pRenderObject;
        undefined4 field_0x74;
        undefined4 field_0x78;
        undefined4 field_0x7c;
        undefined4 field_0x80;
        undefined2 field_0x84;
        undefined2 field_0x86;
        undefined4 field_0x88;
        struct DynamicValue DynamicValue;
        undefined3 field_0x91;
        int EventObjectID;
        int ModelCollectionID;
        undefined2 field_0x9c;
        undefined2 field_0x9e;
        int Mass;
        undefined4 Size;
        int AbsTime;
        undefined* pFirstUnknownObject;
        undefined4 NULL_2;
        undefined* pLastUnknownObject;
        undefined4 field_0xb8;
        undefined4 field_0xbc;
        struct Vector3 Position_Copy;
        undefined4 field_0xcc;
        struct Vector3 EulerRotationCopy2;
        struct Vector3 LocalRotationDeltaCopy;
        int Speed_Copy;
        int Hull;
        struct SectorObject* field_0xf0;
        undefined4 field_0xf4;
        undefined4 field_0xf8;
        struct SectorObject* field_0xfc;
        undefined4 field_0x100;
        undefined4 field_0x104;
        undefined4 field_0x108;
        undefined4 field_0x10c;
        undefined4 field_0x110;
        undefined4 field_0x114;
        undefined4 field_0x118;
        undefined4 field_0x11c;
        undefined4 field_0x120;
        undefined4 field_0x124;
        undefined4 field_0x128;
        undefined4 field_0x12c;

#pragma region EXE functions
    private:
		typedef SectorObject* InitializeSectorObject(SectorObject* pThis, int FullType);
#pragma endregion

    public:
		SectorObject(int FullType) {
			((InitializeSectorObject*)0x004404f0)(this, FullType);
		}
	};

}}