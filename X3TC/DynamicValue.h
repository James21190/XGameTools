#pragma once

namespace X3TC {
	namespace StoryBase {
		typedef enum DynamicValue_Type {
			Int = 1,
			MODValue = 2,
			Null = 0,
			pEventObject = 10,
			pScriptTaskObject = 9,
			pStoryBase_15fc_Object = 8,
			pTextObject = 11
		} DynamicValue_Type;

		struct DynamicValue {
			enum DynamicValue_Type Flag;
			unsigned int Value;
		};
	}
}