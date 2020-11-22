namespace X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory
{
    public enum TC_Sun_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the EventObject that the ship is currently in.
        /// </summary>
        CurrentSectorEventObjectID,
        /// <summary>
        /// The ID of the EventObject that the ship was in previously in.
        /// </summary>
        PreviousSectorEventObjectID,
    }

    public enum TC_Planet_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the EventObject that the ship is currently in.
        /// </summary>
        CurrentSectorEventObjectID,
        /// <summary>
        /// The ID of the EventObject that the ship was in previously in.
        /// </summary>
        PreviousSectorEventObjectID,
    }
    public enum TC_Gate_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the EventObject that the ship is currently in.
        /// </summary>
        CurrentSectorEventObjectID,
        /// <summary>
        /// The ID of the EventObject that the ship was in previously in.
        /// </summary>
        PreviousSectorEventObjectID,

        Dest_Sector_X = 8,
        Dest_Sector_Y
    }
    public enum TC_Sector_Variables
    {
        Sector_X,
        Sector_Y,
        SectorDataEventObjectID,

        ShipEventObjectIDHashTable = 3,

        DockEventObjectIDHashTable = 6,
        FactoryEventObjectIDHashTable,

        BackgroundID = 29,
    }
    public enum TC_Ship_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the EventObject that the ship is currently in.
        /// </summary>
        CurrentSectorEventObjectID,
        /// <summary>
        /// The ID of the EventObject that the ship was in previously in.
        /// </summary>
        PreviousSectorEventObjectID,

        SubType = 12,

        CustomShipName = 16,

        Hull = 18,

        WeaponArray = 21,

        ShieldArray = 25,

        Hue = 28,
        Saturation,

        Cargo = 33,

        JobID = 35,

        OwningRaceDataEventObjectID = 38,

        AdditionalMaxCargoUnits = 69,
        CurrentCargoUnits,
        MaximumLaserEnergy,
        MaximumShield
    }

    public enum TC_Station_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the EventObject that the ship is currently in.
        /// </summary>
        CurrentSectorEventObjectID,
        /// <summary>
        /// The ID of the EventObject that the ship was in previously in.
        /// </summary>
        PreviousSectorEventObjectID,

        MainType = 10,
        SubType,

        OwningRaceDataEventObjectID = 13,

        CargoHashTable = 18,

        Credits = 28,

        CustomName = 46,
    }


    // Inherits Station
    public enum TC_Headquarters_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the EventObject that the ship is currently in.
        /// </summary>
        CurrentSectorEventObjectID,
        /// <summary>
        /// The ID of the EventObject that the ship was in previously in.
        /// </summary>
        PreviousSectorEventObjectID,

        MainType = 10,
        SubType,

        OwningRaceDataEventObjectID = 13,

        CargoHashTable = 18,

        Credits = 28,

        CustomName = 46,

        AvailableBlueprintHashTable = 55,
    }

    public enum TC_Ware_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the EventObject that the ship is currently in.
        /// </summary>
        CurrentSectorEventObjectID,
        /// <summary>
        /// The ID of the EventObject that the ship was in previously in.
        /// </summary>
        PreviousSectorEventObjectID,

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
        SectorEventObjectID,
    }
    public enum TC_RaceData_Variables
    {
        RaceID,
        ASectorEventObjectID,

        RaceRelationsArray = 3,
        OwnedShipEventObjectIDHashTable,

        OwnedStationEventObjectIDHashTable = 7,
    }

    public enum TC_RaceData_Player_Variables
    {
        CreditBalance,
        RaceRelationsArray,
        CurrentSectorEventObjectID,
        PreviousSectorEventObjectID,
        CurrentSectorX,
        CurrentSectorY,

        RaceDataWithSectorEventObjectIDHashTable = 13,
        RaceDataEventObjectIDHashTable,

        OwnedShipEventObjectIDHashTable = 18,

        OwnedStationEventObjectIDHashTable = 22,
    }
}
