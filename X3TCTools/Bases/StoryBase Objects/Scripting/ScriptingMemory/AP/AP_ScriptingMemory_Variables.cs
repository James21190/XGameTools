namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP
{
    public enum AP_Sun_Variables
    {
        PositionData,
        CurrentSectorScriptingObjectID,

        SubType = 7,
    }

    public enum AP_Planet_Variables
    {
        PositionData,
        CurrentSectorScriptingObjectID,

        SubType = 6,
    }
    public enum AP_Gate_Variables
    {
        PositionData,
        CurrentSectorScriptingObjectID,

        Dest_Sector_X = 8,
        Dest_Sector_Y,

        DestSectorDataScriptingObjectID = 11,
    }
    public enum AP_Sector_Variables
    {
        Sector_X,
        Sector_Y,
        OwningRaceDataScriptingObjectID,

        ShipScriptingObjectIDHashTable = 3,
        PlanetScriptingObjectIDHashTable,
        SunScriptingObjectIDHashTable,
        DockScriptingObjectIDHashTable,
        FactoryScriptingObjectIDHashTable,
        AsteroidScriptingObjectIDHashTable,

        GateScriptingObjectIDHashTable = 10,
        GateScriptingObjectIDArray,

        DebrisScriptingObjectIDHashTable = 14,

        BackgroundID = 29,
    }
    public enum AP_Ship_Variables
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

        SubType = 14,

        CustomShipName = 18,

        Hull = 20,

        WeaponArray = 23,

        ShieldStrength = 26,
        InstalledShieldArray,

        Cargo = 35,

        OwningRaceDataScriptingObjectID = 41,

        CurrentCargoVolume = 72,
    }

    public enum AP_Station_Variables
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

        MainType = 12,
        SubType,

        OwningRaceDataScriptingObjectID = 15,

        CargoHashTable = 20,
    }

    public enum AP_Ware_Variables
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

    public enum AP_PositionData_Variables
    {
        Position_X,
        Position_Y,
        Position_Z,
        Rotation_Alpha,
        Rotation_Beta,
        Rotation_Gamma,
    }

    public enum AP_RaceData_Variables
    {
        RaceID,
        ASectorScriptingObjectID,
        OwnedSectorScriptingObjectIDHashTable,
        RaceRelationsArray,
        OwnedShipScriptingObjectIDHashTable,
        OwnedMilitaryShipScriptingObjectIDHashTable,
        OwnedShipyardsScriptingObjectIDHashTable,
        OwnedStationScriptingObjectIDHashTable,

    }

    public enum AP_RaceData_Player_Variables
    {
        CreditBalance,

        RaceRelationsArray = 2,
        CurrentSectorScriptingObjectID,
        PreviousSectorScriptingObjectID,
        CurrentSectorX,
        CurrentSectorY,

        RaceDataWithSectorScriptingObjectIDHashTable = 14,
        RaceDataScriptingObjectIDHashTable,

        OwnedShipScriptingObjectIDHashTable = 19,

        OwnedStationScriptingObjectIDHashTable = 23,
    }
}
