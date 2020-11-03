// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"

#include "discord/discord.h"

#include "DiscordMain.h"

using namespace discord;

void Inject() {
    // Injects code into the main game loop to call the Tick function.
}

void Tick() {
    // Code that will be executed every tick;
}

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
        Inject();
        break;
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

