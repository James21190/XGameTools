namespace X3Tools.Bases.Story.Scripting.ScriptingMemory
{
    public enum TC_Sun_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the ScriptingObject that the ship is currently in.
        /// </summary>
        CurrentSectorScriptingObjectID,
        /// <summary>
        /// The ID of the ScriptingObject that the ship was in previously in.
        /// </summary>
        PreviousSectorScriptingObjectID,
    }

    public enum TC_Planet_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the ScriptingObject that the ship is currently in.
        /// </summary>
        CurrentSectorScriptingObjectID,
        /// <summary>
        /// The ID of the ScriptingObject that the ship was in previously in.
        /// </summary>
        PreviousSectorScriptingObjectID,
    }
    public enum TC_Gate_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the ScriptingObject that the ship is currently in.
        /// </summary>
        CurrentSectorScriptingObjectID,
        /// <summary>
        /// The ID of the ScriptingObject that the ship was in previously in.
        /// </summary>
        PreviousSectorScriptingObjectID,

        Dest_Sector_X = 7,
        Dest_Sector_Y
    }
    public enum TC_Sector_Variables
    {
        Sector_X,
        Sector_Y,
        SectorDataScriptingObjectID,

        ShipScriptingObjectIDHashTable = 3,

        DockScriptingObjectIDHashTable = 6,
        FactoryScriptingObjectIDHashTable,

        BackgroundID = 29,

        BackgroundMusicID = 32, 

        Population = 39,
    }
    public enum TC_Ship_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the ScriptingObject that the ship is currently in.
        /// </summary>
        CurrentSectorScriptingObjectID,
        /// <summary>
        /// The ID of the ScriptingObject that the ship was in previously in.
        /// </summary>
        PreviousSectorScriptingObjectID,

        SubType = 12,

        CustomShipName = 16,

        Hull = 18,

        WeaponArray = 21,

        ShieldArray = 25,

        Hue = 28,
        Saturation,

        Cargo = 33,

        JobID = 35,

        OwningRaceDataScriptingObjectID = 38,

        AdditionalMaxCargoUnits = 69,
        CurrentCargoUnits,
        MaximumLaserEnergy,
        MaximumShield
    }

    public enum TC_Station_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the ScriptingObject that the ship is currently in.
        /// </summary>
        CurrentSectorScriptingObjectID,
        /// <summary>
        /// The ID of the ScriptingObject that the ship was in previously in.
        /// </summary>
        PreviousSectorScriptingObjectID,

        MainType = 10,
        SubType,

        OwningRaceDataScriptingObjectID = 13,

        CargoHashTable = 18,

        Credits = 28,

        CustomName = 46,
    }


    // Inherits Station
    public enum TC_Headquarters_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the ScriptingObject that the ship is currently in.
        /// </summary>
        CurrentSectorScriptingObjectID,
        /// <summary>
        /// The ID of the ScriptingObject that the ship was in previously in.
        /// </summary>
        PreviousSectorScriptingObjectID,

        MainType = 10,
        SubType,

        OwningRaceDataScriptingObjectID = 13,

        CargoHashTable = 18,

        Credits = 28,

        CustomName = 46,

        AvailableBlueprintHashTable = 55,
    }

    public enum TC_Ware_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the ScriptingObject that the ship is currently in.
        /// </summary>
        CurrentSectorScriptingObjectID,
        /// <summary>
        /// The ID of the ScriptingObject that the ship was in previously in.
        /// </summary>
        PreviousSectorScriptingObjectID,

        Amount = 6,
        MainType,
        SubType
    }

    public enum TC_PositionData_Variables
    {
        Position_X,
        Position_Y,
        Position_Z,
        Rotation_Alpha,
        Rotation_Beta,
        Rotation_Gamma,
    }

    public enum TC_SectorData_Variables
    {
        OwnerRace,
        SectorScriptingObjectID,
    }
    public enum TC_RaceData_Variables
    {
        RaceID,
        ASectorScriptingObjectID,

        RaceRelationsArray = 3,
        OwnedShipScriptingObjectIDHashTable,

        OwnedStationScriptingObjectIDHashTable = 7,
    }

    public enum TC_RaceData_Player_Variables
    {
        CreditBalance,
        RaceRelationsArray,
        CurrentSectorScriptingObjectID,
        PreviousSectorScriptingObjectID,
        CurrentSectorX,
        CurrentSectorY,

        SecondsElapsed = 7,

        RaceDataWithSectorScriptingObjectIDHashTable = 13,
        RaceDataScriptingObjectIDHashTable,

        TradeRank = 16,
        FightRank,

        OwnedShipScriptingObjectIDHashTable = 18,

        OwnedStationScriptingObjectIDHashTable = 22,

        TimeOfLastInput = 30,
    }
}
