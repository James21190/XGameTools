#include"discord/discord.h"

#include "SectorObjectManager.h";

using namespace X3TC::SectorObjects;

discord::Core* core{};
discord::Result result;
void DiscordStart() 
{
	result = discord::Core::Create(672392852403126272, DiscordCreateFlags_Default, &core);
}

void DiscordTick()
{
    auto pSectorObjectManager = SectorObjectManager::GetSectorObjectManager();

    discord::Activity activity{};

    // Only update if ship changes
    if (pSectorObjectManager->pPlayerShip != nullptr) {
        char buffer[128];
        sprintf(buffer, "Commanding a %s class ship.", pSectorObjectManager->pPlayerShip->pDefaultName);
        activity.SetDetails(buffer);


        if (pSectorObjectManager->pPlayerShip->pParent != nullptr) {
            if (pSectorObjectManager->pPlayerShip->pParent->MainType == 1)
            {
                activity.SetState("Flying in space");
            }
            else {
                sprintf(buffer, "Docked at %s.", pSectorObjectManager->pPlayerShip->pParent->pDefaultName);
                activity.SetState(buffer);
            }
        }

        core->ActivityManager().UpdateActivity(activity, [](discord::Result result) {});
    }

    ::core->RunCallbacks();
}