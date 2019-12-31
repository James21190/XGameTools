using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X2Tools.X2.SectorObjects
{
    public partial class SectorObject
    {
        public static int ToFullType(Main_Type MainType, int SubType)
        {
            return (((int)MainType) << 16 | SubType);
        }

        public static void FromFullType(int FullType, out Main_Type MainType, out int SubType)
        {
            MainType = (Main_Type)(FullType >> 16);
            SubType = FullType & 0x0000ffff;
        }
        /// <summary>
        /// The number of MainTypes recognised
        /// </summary>
        public const int MAIN_TYPE_COUNT = 23;
        public enum Main_Type
        {
            Projectile,
            Sector,
            Type_2,
            Sun,
            Planet,
            Dock,
            Factory,
            Ship,
            ShipGun,
            Shield,
            Missile,
            Ware_Energy,
            Ware_Mission,
            Ware_Agriculture,
            Ware_Processed,
            Ware_Ores,
            Ware_Technology,
            Asteroid,
            Gate,
            Type_19,
            Miscellaneous,
            Nebula,
            Station_Internal
        }


        #region Sub Types
        // Type 0(Projectile) and 8(ShipGun)
        public const int WEAPON_SUBTYPE_COUNT = 22;
        public enum Weapon_Sub_Type
        {
            Alpha_Impuse_Ray_Emitter,
            Beta_Impuse_Ray_Emitter,
            Gamma_Impuse_Ray_Emitter,
            Alpha_Particle_Accelerator_Cannon,
            Beta_Particle_Accelerator_Cannon,
            Gamma_Particle_Accelerator_Cannon,
            Alpha_High_Energy_Plasma_Thrower,
            Beta_High_Energy_Plasma_Thrower,
            Gamma_High_Energy_Plasma_Thrower,
            Alpha_Phased_Shockwave_Generator,
            Beta_Phasted_Shockwave_Generator,
            Gamma_Phased_Shockwave_Generator,
            Mobile_Drilling_System,
            Alpha_Kyon_Emitter,
            Beta_Kyon_Emitter,
            Gamma_Kyon_Emitter,
            Mass_Driver,
            Ion_Disruptor,
            Alpha_Photon_Pulse_Cannon,
            Beta_Photon_Pulse_Cannon,
            Gamma_Photon_Pulse_Cannon,
            Lastertower_Weapon
        }

        // Type 1
        public const int SECTOR_SUBTYPE_COUNT = 5;
        public enum Sector_Sub_Type
        {
            Space = 0,
            Station = 4
        }

        // Type 2
        public const int TYPE_2_SUBTYPE_COUNT = 0;
        public enum Type_2_Sub_Type
        {

        }

        // Type 3
        public const int SUN_SUBTYPE_COUNT = 9;
        public enum Sun_Sub_Type
        {
            White_1,
            Red_1,
            Red_2,
            Yellow,
            White_2,
            Green_1,
            Red_3,
            Orange = 7,
            Green_2 = 8
        }

        // Type 4
        public const int PLANET_SUBTYPE_COUNT = 20;
        public enum Planet_Sub_Type
        {
            Class_B = 1,
            Class_D = 3,
            Class_E = 4,
            Class_G_1,
            Class_G_2,
            Class_H,
            Class_I,
            Class_K,
            Class_L,
            Class_M,
            Class_N_1,
            Class_N_2,
            Class_N_3 = 19
        }

        // Type 5
        public const int DOCK_SUBTYPE_COUNT = 17;
        public enum Dock_Sub_Type
        {
            Free_Argon_Trading_Station,
            Split_Trading_Port,
            Paranid_Trading_Dock,
            Royal_Boron_Trading_Station,
            Teladi_Trading_Station,
            Xenon_Station_1,
            Argon_Equipment_Dock,
            Split_Equipment_Dock,
            Paranid_Equipment_Dock,
            Boron_Equipment_Dock,
            Teladi_Space_Equipment_Dock,
            Xenon_Station_2,
            Gonor_Temple = 13,
            Pirate_Base,
            Khaak_Station = 16,

        }

        // Type 6
        public const int FACTORY_SUBTYPE_COUNT = 242;
        public enum Factory_Sub_Type
        {
            Split_Split_Shipyard = 1,
            Teladi_Teladi_Shipyard = 4,
            Argon_Quantum_Tube_Fab = 7,
            Split_Weapon_Component_Factory = 10,
            Split_Crystal_Fab,
            Split_Quantum_Tube_Fab,
            Split_Chip_Plant,
            Split_Computer_Plant,
            Boron_Weapon_Component_Factory,
            Teladi_Crystal_Fab = 26,
            Teladi_Quantum_Tube_Fab,
            Split_Shield_Prod_Facility_25MW = 36,
            Teladi_Shield_Prod_Facility_1MW = 46,
            Teladi_Shield_Prod_Facility_5MW = 47,
            Split_Silkworm_Missile_Factory = 58,
            Boron_Mosquito_Missile_Factory = 65,
            Teladi_Mosquito_Missile_Factory = 70,
            Teladi_Silkworm_Missile_Factory = 73,
            Split_Beta_IRE_Forge = 85,
            Split_Gamma_PAC_Forge = 89,
            Split_Beta_HEPT_Forge = 91,
            Boron_Alpha_IRE_Forge = 102,
            Boron_Beta_IRE_Forge = 103,
            Boron_Alpha_PAC_Forge = 105,
            Teladi_Alpha_IRE_Forge = 111,
            Argon_Ore_Mine = 120,
            Split_Ore_Mine,
            Boron_Ore_Mine = 123,
            Teladi_Ore_Mine = 124,
            Argon_Silicon_Mine = 125,
            Split_Silicon_Mine = 126,
            Boron_Silicon_Mine = 128,
            Teladi_Silicon_Mine = 129,
            Argon_Solar_Power_Plant = 130,
            Split_Solar_Power_Plant = 131,
            Boron_Solar_Power_Plant = 133,
            Teladi_Solar_Power_Plant,
            Argon_Wheat_Farm,
            Argon_Cattle_Ranch,
            Boron_Plankton_Farm,
            Boron_Bio_Gas_Factory,
            Split_Scriffin_Farm,
            Split_Chelt_Space_Aquarium,
            Paranid_Soyfarm,
            Paranid_Snail_Ranch,
            Teladi_Flower_Farm,
            Teladi_Teladianium_Foundry,
            Teladi_Dream_Farm,
            Argon_Rimes_Fact,
            Argon_Cahoona_Bakery,
            Boron_Stott_Mixery = 149,
            Boron_BoFu_Chemical_Lab = 150,
            Split_Massom_Mill,
            Split_Raster_Refinery,
            Paranid_Soyery = 154,
            Teladi_Sun_Oil_Refinery = 155,
            Teladi_Bliss_Place,
            Argon_Satellite_Factory = 159,
            Teladi_SQUASH_Mine_Factory = 168,
            Argon_Lasertower_Factory = 169,
            Teladi_Lasertower_Factory = 173,
            Split_Drown_Factory = 175,
            Teladi_Drone_Factory = 178,
            Split_Split_Dockyard = 180,
            Boron_Royal_Boron_Drydock = 182,
            Teladi_Teladi_Showroom,
            Split_Gamma_PPC_Forge = 189,
            Boron_Beta_PPC_Forge = 194,
            Teladi_Alpha_PSG_Forge = 211,
            Split_Mass_Driver_Forge = 215,
            Split_Ammunition_Factory = 230,
            Split_Advanced_Satellite_Factory = 235
        }

        // Type 7
        public const int SHIP_SUBTYPE_COUNT = 114;
        public enum Ship_Sub_Type
        {
            Argon_Mammoth,
            Argon_Mercury,
            Argon_Colossus,
            Argon_Titan,
            UnnamedObject,
            Argon_Buster,
            Argon_Discoverer,
            Xenon_I,
            Xenon_H,
            Xenon_Mothership,
            Xenon_J,
            Xenon_K,
            Xenon_L,
            Xenon_M,
            Xenon_N,
            Split_Elephant,
            Split_Raptor = 0x11,
            Split_Mamba = 0x13,
            Split_Scorpion,
            Paranid_Hercules = 0x16,
            Paranid_Demeter,
            Paranid_Zeus,
            Paranid_Odysseus,
            Paranid_Perseus,
            Paranid_Pegasus = 0x1c,
            Boron_Orca,
            Boron_Dolphin,
            Boron_Shark,
            Boron_Ray,
            Boron_Octopus = 0x23,
            Teladi_Albatross,
            Teladi_Vulture,
            Teladi_Condor,
            Teladi_Phoenix,
            Teladi_Falcon,
            Pirate_Ship1 = 0x2b,
            Pirate_Ship2,
            Pirate_Ship3,
            Pirate_Ship4,
            Pirate_Ship5,
            Pirate_Ship6,
            XperementalShuttle,
            SpaceSuit,
            Gonor_Ship = 0x34,
            DataStorageDevice,
            Drone1 = 0x38,
            Drone2,
            Drone3,
            Drone4,
            Pirate_Orinoco = 0x3d,
            Pirate_Bayamon,
            Pirate_Mandalay,
            NavigationRelaySatellite,
            SQUASHMine,
            FighterDrone,
            Lasertower,
            UnknownObject,
            Spaceflies = 0x46,
            Khaak_Fighter,
            Khaak_Interceptor,
            Khaak_Scout,
            Khaak_Carrier,
            Khaak_Destroyer,
            Argon_Centaur,
            Argon_Nova,
            Argon_Express = 0x4f,
            Teladi_Osprey,
            Teladi_Buzzard,
            Teladi_Harrier,
            Teladi_Toucan,
            Split_Dragon,
            Split_Jaguar,
            Split_Caiman,
            Split_Iguana,
            Boron_Hydra,
            Boron_Barracuda,
            Boron_Mako,
            Boron_Manta,
            Paranid_Nemesis,
            Paranid_Pericles,
            Paranid_Hermes = 0x5f,
            CameraDrone = 0x63,
            AdvancedSatellite,
            Khaak_Cluster1 = 0x67,
            Khaak_Cluster2,
            Khaak_Cluster3,
            Khaak_Cluster4,
            NavigationalBeacon,
            Khaak_Mothership = 0x6f
        }

        // Type 9
        public const int SHIELD_SUBTYPE_COUNT = 4;
        public enum Shield_Sub_Type
        {
            Shield_1MW,
            Shield_5MW,
            Shield_25MW,
            Shield_125MW
        }

        // Type 10
        public const int MISSILE_SUBTYPE_COUNT = 8;
        public enum Missile_Sub_Type
        {
            Mosquito,
            Thorn = 7
        }

        // Type 11
        public const int WARE_ENERGY_SUBTYPE_COUNT = 1;
        public enum Ware_Energy_Sub_Type
        {
            Energy_Cells
        }

        // Type 12
        public const int WARE_MISSION_SUBTYPE_COUNT = 25;
        public enum Ware_Mission_Sub_Type
        {
            Water,
            Artifacts,
            Artificial_Fertilizer,
            Biological_Micro_Organisms,
            Cartography_Chips,
            Construction_Equipment,
            Engine_Components,
            Entertainment_Chips,
            Food_Rations,
            Hand_Weapons,
            Luxury_Foodstuffs,
            Medical_Equipment,
            Mining_Equipment,
            Nividium,
            Radioactive_Waste,
            Teladianium_Panelling,
            Weapon_Interface_Chips,
            Narcotics,
            Super_Slave_Chips,
            Spacefly_Eggs,
            Pirate_Sidearms,
            Hackerchips,
            Military_Personnel,
            Passengers,
            Very_Important_Passengers

        }

        // Type 13
        public const int TYPE_13_SUBTYPE_COUNT = 11;
        public enum Ware_Agriculture_Sub_Type
        {
            Delaxian_Wheat,
            Argnu_Beef,
            Plankton,
            BoGas,
            Scruffin_Fruits,
            Chelt_Meat,
            Soja_Beans,
            Maja_Snails,
            Sunrise_Flowers,
            Teladianium,
            Swamp_Plant
        }

        // Type 14
        public const int WARE_PROCESSED_SUBTYPE_COUNT = 11;
        public enum Ware_Processed_Sub_Type
        {
            Cloth_Rimes,
            Meatsteak_Cahoonas,
            Space_Fuel,
            Stott_Spices,
            BoFu,
            Massom_Powder,
            Raster_Oil,
            Majaglit,
            Soja_Husk,
            Nostrop_Oil,
            Space_Weed
        }

        // Type 15
        public const int WARE_ORES_SUBTYPE_COUNT = 3;
        public enum Ware_Ores_Sub_Type
        {
            Ore,
            Silicon_Wafers,
            Nividium
        }

        // Type 16
        public const int WARE_TECHNOLOGY_SUBTYPE_COUNT = 80;
        public enum Ware_Technology_Sub_Type
        {
            Warheads,
            Crystals,
            Quantum_Tubes,
            Microchips,
            Computer_Components,
            Spaceflies,
            Slaves,
            Navigation_Relay_Satelite,
            SQUASH_Mine,
            Lasertower,
            Fighter_Drone,
            Salvage_Insurance,
            Mineral_Scanner,
            Freight_Scanner,
            Trading_System_Extension,
            Cargo_Bay_Extension = 16,
            Engine_Tuning,
            Rudder_Optimisation,
            Docking_Computer,
            Motion_Analysis_Relay_System,
            Video_Enhancement_Goggles = 22,
            Singularity_Engine_Time_Accelerator,
            SETA_Boost_Extension,
            Ecliptic_Projector,
            Argon_Law_Enforcement_License,
            Boron_Law_Enforcement_License,
            Split_Police_License,
            Paranid_Police_License,
            Teladi_Company_Security_License,
            Data_Storage_Device,
            Best_Buys_Locator,
            Best_Selling_Price_Locator,
            Transporter_Device,
            Jumpdrive,
            Cargo_Lifesupport_System = 39,
            Boost_Extension,
            Strafe_Drive_Extension,
            Camera_Drone = 43,
            Advanced_Satelite,
            Ore_Collector,
            Camouflage_Device,
            Spacefly_Collector = 49,
            Mass_Driver_Ammunition,
            Duplex_Scanner,
            Triplex_Scanner,
            Navigation_Command_Software_MK1,
            Trade_Command_Software_MK1,
            Trade_Command_Software_MK2,
            Fight_Command_Software_MK1,
            Fight_Command_Software_MK2,
            Special_Command_Software_MK1,
            Commodity_Logistics_Software_MK1 = 65,
            Adv_Trade_Command_Software_MK1,
            Fusion_Injector = 68,
            Trade_Command_Software_MK3 = 71,
            AEGIS_Weapon_System = 76,

        }

        // Type 17
        public const int ASTEROID_SUBTYPE_COUNT = 3;
        public enum Asteroid_Sub_Type
        {

        }

        // Type 18
        public const int GATE_SUBTYPE_COUNT = 4;
        public enum Gate_Sub_Type
        {
            North,
            South,
            West,
            East
        }

        // Type 19
        public const int TYPE_19_SUBTYPE_COUNT = 0;
        public enum Type_19_Sub_Type
        {

        }

        // Type 20
        public const int MISCELLANEOUS_SUBTYPE_COUNT = 62;
        public enum Miscellaneous_Sub_Type
        {
            Kessler_Ring,
            Kessler_Ring_Narrow,
            Xenon_Capital_Front,
            Asteroid_Ore_Collectable,
            Asteroid_Silicon_Collectable,
            Pannel_3_Sides_1,
            Frame,
            Panel_3_Sides_2,
            Station_Construction_1 = 9,
            Pannel_1_Sides,
            Universe_Map,
            Drill,
            Nacelle_1 = 25,
            Nacelle_2 = 26,
            Gate_Debris = 27
        }

        // Type 21
        public const int NEBULA_SUBTYPE_COUNT = 126;
        public enum Nebula_Sub_Type
        {
            Blue_Cloud = 57,
            Gray_Cloud_1 = 100,
            Gray_Cloud_2,
            Cyan_Cloud = 105
        }

        // Type 22
        public const int STATION_INTERNAL_SUBTYPE_COUNT = 38;
        public enum Station_Internal_Sub_Type
        {
            Free_Argon_Trading_Station,
            Argon_Cahoona_Bakery = 22,
            Argon_Solar_Power_Plant = 37
        }


        #endregion
    }
}
