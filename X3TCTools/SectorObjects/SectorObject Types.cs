using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.SectorObjects
{
    public partial class SectorObject
    {

        public const int MAIN_TYPE_COUNT = 32;
        public enum Main_Type : ushort
        {
            Bullet,
            Sector,
            Type_2,
            Sun,
            Planet,
            Dock,
            Factory,
            Ship,
            Laser,
            Shield,
            Missile,
            Ware_Energy,
            Type_12,
            Type_13,
            Ware_Bio,
            Type_15,
            Ware_Miscellaneous,
            Asteroid_1,
            Gate,
            Type_19,
            Miscellaneous,
            Type_21,
            Type_22,
            Asteroid_2 = 28,
            Station_Debris = 30,
        }

        public static int ToFullType(Main_Type MainType, int SubType)
        {
            return (((int)MainType) << 16 | SubType);
        }

        public static void FromFullType(int FullType, out Main_Type MainType, out int SubType)
        {
            MainType = (Main_Type)(FullType >> 16);
            SubType = FullType & 0x0000ffff;
        }

        #region Sub Types

        // Type 0
        // Type 1
        // Type 2
        // Type 3
        public const int SUN_SUB_TYPE_COUNT = 8;
        public enum Sun_Sub_Type
        {
            Red_1,
            Sol,
            White_1 = 4,
            Red_2 = 6,
            Yellow_1 = 7,
            Green_1,
        }
        // Type 4
        public const int PLANET_SUB_TYPE_COUNT = 147;
        public enum Planet_Sub_Type
        {
            Large_Habitable_1,
            Large_Desert_1 = 6,
            The_Moon_Close = 69,
            The_Moon_Far = 75,
            Small_Barren_Moon_1 = 74,
            Small_Barren_Moon_2 = 110,
            Saturn = 135,
            Saturn_Moon,
            Mercury = 137,
            Venus,
            Earth,
            Mars = 141,
            Jupiter,

            The_Hub_Planet = 146,
            Khaak_Home_Planet,
            Earth_With_Tourus
        }
        // Type 5
        public const int DOCK_SUB_TYPE_COUNT = 46;
        public enum Dock_Sub_Type
        {
            Free_Argon_Trading_Station,
            Split_Trading_Port,
            Paranid_Trading_Dock,
            Royal_Boron_Trading_Station,
            Teladi_Trading_Station,
            Xenon_Station,
            Argon_Equipment_Dock,
            Split_Equipment_Dock,
            Paranid_Equipment_Dock,
            Boron_Equipment_Dock,
            Teladi_Space_Equipment_Dock,

            Pirate_Base = 13,

            Boron_Military_Outpost = 16,
            Paranid_Military_Outpost,
            Split_Military_Outpost,

            Military_Outpost_3 = 19,

            Headquarters = 20,
            Goner_Temple,
            USC_Orbital_Supply_Base,
            USC_Orbital_Support_Station,
            USC_Orbital_Logistics_Dock,
            Terran_Military_Base,
            Orbital_Defence_Station_1,
            Orbital_Patrol_Base,
            Orbital_Defence_Station_2,
            Orbital_Defence_Station_3,
            Earth_Torus,
            Unknown_Aldrin_Base_1,
            Unknown_Aldrin_Base_2,
            Military_Base_2,
            Orbital_Defence_Station_4,
            Terracorp_HQ,
            OTAS_HQ,
            Jonferco_HQ,
            Putarch_HQ,
            NMMC_HQ,
            Dukes_Haven,
            Atreus_HQ,
            Strong_Arms_HQ,
            Xenon_Hub,

            Saturn_Research_Station = 45
        }
        // Type 6
        public const int FACTORY_SUB_TYPE_COUNT = 439;
        public enum Factory_Sub_Type
        {
            Federal_Argon_Shipyard,
            Split_Shipyard,
            Paranid_Shipyard,
            Royal_Boron_Shipyard,
            Teladi_Shipyard,

            Argon_Weapon_Component_Factory = 6,
            Boron_Weapon_Component_Factory,

            Split_Weapon_Component_Factory = 9,
            Teladi_Weapon_Component_Factory,
            Argon_Crystal_Fab,
            Boron_Crystal_Fab,
            Paranid_Crystal_Fab,
            Split_Crystal_Fab,
            Teladi_Crystal_Fab,
            Argon_Quantum_Tube_Fab,

            Quantum_Tube_Fab_1 = 19,
            Teladi_Quantum_Tube_Fab,

            Boron_Chip_Plant = 22,

            Teladi_Chip_Plant = 25,
            Argon_Computer_Plant,
            Boron_Computer_Plant,

            Teladi_Computer_Plant = 30,

            Paranid_Wasp_Missile_Factory = 36,

            Split_Silkworm_Missile_Factory = 42,

            Split_SQUASH_Mine_Factory = 44,
            Teladi_SQUASH_Mine_Factory,

            Argon_Drone_Factory = 49,
            Split_Drone_Factory = 51,

            Boron_Saterllite_Factory=54,

            Teladi_Saterllite_Factory = 56,
            Argon_Advanced_Saterllite_Factory,
            Paranid_Advanced_Satellite_Factory,
            Split_Advanced_Satellite_Factory,
            Argon_Impulse_Ray_Emitter_Forge,
            Boron_Impulse_Ray_Emitter_Forge,

            Argon_Light_Weapons_Complex = 70,

            Teladi_Gauss_Cannon_Forge = 79,

            Teladi_Flak_Artillery_Array_Forge = 89,
            
            Teladi_Heavy_Weapons_Complex = 91,

            Argon_Mass_Driver_Forge = 93,

            Split_Ammunition_Factory = 96,

            Boron_Concussion_Impulse_Generator_Forge=100,
            Split_Medium_Weapons_Complex,

            Paranid_Heavy_Weapons_Complex = 109,

            Boron_Medium_Weapons_Complex=114,

            Wheat_Farm_1 = 143,
            Wheat_Farm_2,
            Cattle_Ranch_M,
            Cattle_Ranch_L,
            Plankton_Farm_M,
            Plankton_Farm_L,
            Bio_Gass_Factory_M,
            Bio_Gass_Factory_L,
            Scruffin_Farm_M,
            Scruffin_Farm_L,
            Chelt_Space_Aquarium_M,
            Chelt_Space_Aquarium_L,
            Soyfarm_M,
            Soyfarm_L,
            Snail_Ranch_M,
            Snail_Rance_L,
            Flower_Farm_M,
            Flower_Farm_L,
            Teladianium_Foundry_M,
            Teladianium_Foundry_L,
            Dream_Farm,

            Rimes_Fact = 166,
            Cahoona_Bakery_M,
            Cahoona_Bakery_L,
            Space_Fuel_Distillery,

            Stott_Mixery_M = 171,
            Stott_Mixery_L,
            BoFu_Chemical_Lab_M,
            BoFu_Chemical_Lab_L,
            Massom_Mill,

            Rastar_Refinery_M = 177,
            Rastar_Refinery_L,
            Space_Jewellery_M,
            Space_Jewellery_L,

            Soyery_M = 181,
            Soyery_L,
            Sun_Oil_Refinery_M,
            Sun_Oil_Refinery_L,

            Bliss_Place = 186,

            Argon_Solar_Power_Plant = 189,
            Boron_Solar_Power_Plant_1,
            Boron_Solar_Power_Plant_2,
            Boron_Solar_Power_Plant_3,
            Paranid_Solar_Power_Plant_1,

            Paranid_Solar_Power_Plant_2 = 195,
            Split_Solar_Power_Plant_1,
            Split_Solar_Power_Plant_2,

            Teladi_Solar_Power_Plant_1 = 199,
            Teladi_Solar_Power_Plant_2,
            Teladi_Solar_Power_Plant_3,

            Argon_Ore_Mine_1 = 203,
            Argon_Ore_Mine_2,

            Boron_Ore_Mine_1 = 206,
            Boron_Ore_Mine_2,
            Paranid_Ore_Mine_1,
            Split_Ore_Mine_1 = 209,
            Split_Ore_Mine_2,

            Teladi_Ore_Mine_1 = 211,
            Teladi_Ore_Mine_2,
            Argon_Silicon_Mine_M,
            Argon_Silicon_Mine_L,
            Boron_Silicon_Mine_M,
            Boron_Silicon_Mine_L,
            Paranid_Silicon_Mine_M,
            Paranid_Silicon_Mine_L,
            Split_Silicon_Mine_1,
            Split_Silicon_Mine_2,

            Teladi_Silicon_Mine_1 = 221,
            Teladi_Silicon_Mine_2,

            Complex_Hub = 227,

            Teladi_Cyclone_Missile_Factory = 272,

            Split_Shipyard_Special = 305,

            Paranid_Shipyard_Special = 307,

            Royal_Boron_Shipyard_Special = 309,

            Teladi_Shipyard_Special = 311,

            Terran_Shipyard = 331,
            Terran_USC_Food_Supply_Factory_1,
            Terran_USC_Food_Supply_Factory_2,
            Terran_Food_Preparation_Facility_1,
            Terran_Food_Preparation_Facility_2,
            Terran_Mining_Outpost_1,
            Terran_Water_Purification_Plant,

            Terran_Matter_Anti_Matter_Launcher_Forge = 339,

            Terran_Hull_Plating_Production_Facility = 347,
            Pirate_Rehabilitation_Facility,

            Terran_Matter_Anti_Matter_Mine_Fab = 352,

            Terran_Phantom_Missile_Fabrication_Facility = 354,

            Terran_Ghoul_Missile_Manufacturing_Plant = 356,

            Boron_Recon_Drone_Construction_Facility = 362,
            Teladi_Energy_Bolt_Chaingun_Ammunition_Forge,
            Teladi_Gauss_Cannon_Ammunition_Forge,

            Boron_Tomahawk_Missile_Manufacturing_Plant = 366,

            Split_Tomahawk_Missile_Manufacturing_Plant = 368,

            Argon_Hammer_Torpedo_Fabrication_Facility = 370,
            Boron_Hammer_Torpedo_Fabrication_Facility,

            Argon_Flail_Missile_Production_Facility_1 = 375,

            Argon_Flail_Missile_Production_Facility_2 = 378,

            Pirate_Plasma_Burst_Generator_Forge = 381,
            Pirate_Incendiary_Bomb_Launcher_Forge = 382,

            Argon_Heavy_Weapons_Complex = 384,
            Terran_Solar_Power_Plant_1,
            Terran_Solar_Power_Plant_2,
            Terran_Solar_Power_Plant_3,

            Terran_Mining_Outpost_2 = 395,


            Argon_Drone_Production_Facility = 402,
            Boron_Drone_Production_Facility,

            Teladi_Drone_Production_Facility = 405,

            Crystal_Fab = 435,

            Teladi_Crystal_Fab_1 = 438
        }
        // Type 7
        public const int SHIP_SUB_TYPE_COUNT = 374;
        public enum Ship_Sub_Type
        {
            Argon_Mammoth,
            Argon_Mercury,
            Argon_Mercury_Tanker,
            Argon_Mercury_3,
            Argon_Mercury_4,
            Argon_Mercury_5,
            Argon_Mercury_6,
            Argon_Express_1,
            Argon_Express_2,
            Argon_Magnetar,
            Argon_Colossus,
            Argon_Titan,
            Argon_Nova_1,
            Argon_Nova_2,
            Argon_Nova_3,
            Argon_Nova_4,
            Argon_Eclipse,
            Argon_Buster_1,
            Argon_Buster_2,
            Argon_Buster_3,
            Argon_Buster_Sentiel,
            Argon_Elite,
            Argon_Discoverer_1,
            Argon_Discoverer_2,
            Argon_Discoverer_3,
            Argon_Discoverer_4,
            Argon_Centaur,
            Argon_Heavy_Centaur,
            Argon_Cerberus,
            Argon_Minotaur,
            Argon_Gladiator,
            Fighter_Drone_MKII,
            Undefined_Hauler_1,
            Undefined_Hauler_2,
            Undefined_Hauler_3,
            Undefined_Hauler_4,
            Undefined_Hauler_5,
            Undefined_Hauler_6,
            Small_Orbital_Weapons_Platform,
            Medium_Orbital_Weapons_Platform,
            Large_Orbital_Weapons_Platform,
            Split_Elephant,
            Split_Caiman,
            Split_Caiman_Tanker,
            Split_Caiman_Hauler,
            Split_Caiman_Tanker_XL,
            Split_Caiman_Super_Freighter,
            Split_Caiman_Super_Freighter_XL,
            Split_Caiman_Miner,
            Split_Iguana,
            Split_Iquana_Vanguard,
            Split_Boa,
            Split_Raptor,
            Split_Python,
            Split_Mamba,
            Split_Mamba_Raider,
            Split_Mamba_Vanguard,
            Split_Mamba_4,
            Split_Chimera,
            Split_Scorpion_1,
            Split_Scorpion_2,
            Split_Scorpion_3,
            Split_Scorpion_4,
            Split_Asp,
            Split_Jaguar_1,
            Split_Jaguar_2,
            Split_Jaguar_3,
            Split_Jaguar_4,
            Split_Dragon,
            Split_Heavy_Dragon,
            Split_Tiger,
            Split_Cobra,
            Split_Viper,
            Paranid_Hercules,
            Paranid_Demeter_1,
            Paranid_Demeter_Tanker,
            Paranid_Demeter_3,
            Paranid_Demeter_4,
            Paranid_Demeter_5,
            Paranid_Demeter_6,
            Paranid_Hermes_1,
            Paranid_Hermes_2,
            Paranid_Helios,
            Paranid_Zeus,
            Paranid_Odysseus,
            Paranid_Perseus_1,
            Paranid_Perseus_2,
            Paranid_Perseus_3,
            Paranid_Perseus_4,
            Paranid_Medusa,
            Paranid_Pericles_1,
            Paranid_Perecles_2,
            Paranid_Perecles_3,
            Paranid_Pereclese_4,
            Paranid_Theseus,
            Paranid_Pegasus_1,
            Paranid_Pegasus_2,
            Paranid_Pegasus_3,
            Paranid_Pegasus_4,
            Paranid_Nemesis,
            Paranid_Heavy_Nemesis,
            Paranid_Diamos,
            Paranid_Ares,
            Paranid_Hades,
            Boron_Orca,
            Boron_Dolphin_1,
            Boron_Dolphin_2,
            Boron_Dolphin_3,
            Boron_Dolphin_4,
            Boron_Dolphin_5,
            Boron_Dolphin_6,
            Boron_Angel,
            Boron_Manta_1,
            Boron_Manta_Hauler,
            Boron_Pleco,
            Boron_Shark,
            Boron_Ray,
            Boron_Barracuda_1,
            Boron_Barracuda_2,
            Boron_Barracuda_3,
            Boron_Barracuda_4,
            Boron_Skate,
            Boron_Mako_1,
            Boron_Mako_2,
            Boron_Mako_3,
            Boron_Mako_4,
            Boron_Pike,
            Boron_Octopus_1,
            Boron_Octopus_2,
            Boron_Octopus_3,
            Boron_Octopus_4,
            Boron_Hydra,
            Boron_Heavy_Hydra,
            Boron_Thresher,
            Boron_Kracken,
            Boron_Marlin_Hauler,
            Teladi_Albatross,
            Teladi_Vulture_1,
            Teladi_Vulture_2,
            Teladi_Vulture_3,
            Teladi_Vulture_4,
            Teladi_Vulture_5,
            Teladi_Vulture_6,
            Teladi_Toucan_1,
            Teladi_Toucan_2,
            Teladi_Pelican,
            Teladi_Condor,
            Teladi_Phoenix,
            Teladi_Falcon_1,
            Teladi_Falcon_2,
            Teladi_Falcon_3,
            Teladi_Falcon_4,
            Teladi_Kea,
            Teladi_Buzzard_1,
            Teladi_Buzzard_2,
            Teladi_Buzzard_3,
            Teladi_Buzzard_4,
            Teladi_Kite_1,
            Teladi_Harrier_1,
            Teladi_Harrier_Hauler,
            Teladi_Harrier_3,
            Teladi_Harrier_4,
            Teladi_Kestrel,
            Teladi_Osprey,
            Teladi_Heavy_Osprey,
            Teladi_Shrike,
            Teladi_Gannet,
            Teladi_Peregrine,
            Xenon_J,
            Xenon_K,
            Xenon_L,
            Xenon_LX,
            Xenon_M,
            Xenon_N,
            Xenon_P,
            Xenon_PX,
            Xenon_Q,
            Pirate_Caravel,
            Pirate_Ship,
            Pirate_Falcon,
            Pirate_Nova_Raider,
            Pirate_Nova_2,
            Pirate_Falcon_Vanguard,
            Pirate_Eclipse,
            Pirate_Kea,
            Pirate_Blastclaw,
            Pirate_Buster,
            Pirate_Buzzard,
            Pirate_Buster_Hauler,
            Pirate_Buzzard_Vanguard,
            Pirate_Scorpion,
            Pirate_Elite,
            Pirate_Harrier,
            Pirate_Harrier_Raider,
            Pirate_Harrier_Hauler,
            Pirate_Harrier_Vanguard,
            Pirate_Kestrel,
            Pirate_Centaur,
            Pirate_Osprey,
            Pirate_Carrack,
            ATF_Odin,
            ATF_Tyr,
            ATF_Thor,
            ATF_Fenrir,
            ATF_Mjollnir,
            ATF_Valkyrie,
            ATF_Vidar,
            ATF_Vali,
            ATF_Aegir,
            ATF_Skirnir,
            ATF_Woden,
            ATF_Valhalla,
            Terran_Baldric,
            Terran_Scabbard,
            Terran_Tokyo,
            Terran_Osaka,
            Terran_Scimitar,
            Terran_Cutlass,
            Terran_Sabre,
            Terran_Rapier,
            Terran_Keris,
            Terran_Katana,
            Terran_Yokohama,
            Terran_Clamore,
            Terran_Spitfyre,
            Terran_Springblossom,
            Terran_Deca,
            Terran_Deca_Cefa,
            Yaki_Chokaro,
            Yaki_Susanowa,
            Yaki_Susanowa_Raider,
            Yaki_Susanowa_3,
            Yaki_Tenjin,

            Yaki_Raijin_1 = 233,
            Yaki_Raijin_2,
            Yaki_Raijin_3,
            Yaki_Tonbo,
            Yaki_Fujin_1,
            Yaki_Fujin_2,

            Khaak_Carrier = 241,
            Khaak_Destroyer,
            Khaak_Fighter,
            Khaak_Interceptor,
            Khaak_Scout,
            Khaak_Corvette,
            Khaak_Guardian,
            Khaak_Hive_Queen,
            Gonor_Ozias,
            Gonor_Aran,
            Gonor_Ranger,
            OTAS_Boreas,
            OTAS_Venti,
            OTAS_Notus_Hauler,
            OTAS_Eurus,
            OTAS_Solano,
            OTAS_Zephyrus,
            OTAS_Skiron,
            OTAS_Astraeus_Hauler,
            OTAS_Aquilo,
            OTAS_Auster_Hauler,
            OTAS_Sirokos,

            Khaak_Cluster = 266,

            Navigation_Relay_Satellite = 270,
            SQUASH_Mine,
            Fighter_Drone,

            Lazertower = 273,
            Gonor_UFO,
            Spaceflies,
            Advanced_Satellite = 278,

            Navigational_Beacon = 280,

            Freight_Drone = 294,
            Argon_Griffon,
            Split_Panther,
            Paranid_Agamemnon,

            Pirage_Galleon = 300,
            Pirate_Brigantine,
            Yaki_Shuri,

            Yaki_Akuma = 305,

            OTAS_Mistral_1 = 309,
            OTAS_Mistral_2,
            Troop_Training_Ship_Hauler,
            Civilian_Vessel_Hauler_1,
            Civilian_Vessel_Hauler_2,
            Civilian_Vessel_Hauler_3,
            Starliner_Hauler,
            Mobile_Repair_Ship,
            Unknown_Biological_Entity_1,
            Unknown_Biological_Entity_2,
            Matter_Anti_Matter_Mine,

            Terran_Atmospheric_Lifter = 326,
            Terran_Mobile_Mining_Base_Ship,
            Paranid_Hyperion,
            Argon_Eclipse_Prototype,
            Argon_Nova_Prototype,
            Argon_Express_Advanced,
            Argon_Mercury_Enhanced,
            Argon_Mercury_Prototype,
            Argon_Heavy_Centaur_Prototype,
            Argon_Discoverer_Advanced,

            Teladi_Kea_Enhanced = 350,
            Teladi_Vulture_Prototype,

            Teladi_Kite_2 = 354,

            Jump_Beacon = 359,
            Message_Drone,
            Terran_Deca_Deaf,
            Terran_Deca_Fade,
            Terran_Freight_Drone_1,
            Terran_Freight_Drone_2,
            Terran_Freight_Drone_3,
            Small_Orbital_Weapons_Platform_2,
            Terran_Freight_Drone_4,
            Terran_Tourus_Lasertower,
            Terran_Lasertower,
            Terran_Baldric_Miner,
            Yaki_Chokaro_Advanced,
            Xperimental_Shuttle,
            Aamon_Prototype
        }
        // Type 8
        public const int WEAPON_SUB_TYPE_COUNT = 39;
        public enum Weapon_Sub_Type
        {
            Impulse_Ray_Emitter,
            Particle_Accelerator_Cannon,
            Mass_Driver,
            Phased_Repeater_Gun,
            Energy_Bolt_Chaingun,
            Fragmentation_Bomb_Launcher,
            High_Energy_Plasma_Thrower,
            Ion_Disruptor,
            Pulsed_Beam_Emitter,
            Plasma_Burst_Geerator,
            Electro_Magnetic_Plasma_Cannon,
            Concussion_Impuse_Generator,
            Ion_Pulse_Generator,
            Ion_Shard_Railgun,
            Matter_Anti_Matter_Launcher,
            Flak_Artillery_Array,
            Cluster_Flak_Array,
            Phased_Array_Laser_Cannon,
            Phased_Shockwave_Generator,
            Starburst_Shockwave_Cannon,
            Photon_Pulse_Cannon,
            Ion_Cannon,
            Gauss_Cannon,
            Incendiary_Bomb_Launcher,
            Point_Singularity_Projector,
            Plasma_Beam_Cannon,
            TriBeam_Cannon,
            Fusion_Beam_Cannon,
            Mobile_Mining_Drill,
            Tractor_Beam,
            SPARE_LASER_1,
            SPARE_LASER_2,
            Alpha_Kyon_Emitter,
            Beta_Kyon_Emitter,
            Gamma_Kyon_Emitter,
            Repair_Laser,
            Experimental_Electro_Magnetic_Plasma_Cannon,
            Prototype_Matter_Anti_Matter_Launcher,
            Prototype_Starburst_Shockwave_Cannon,
        }
        // Type 9
        public const int SHIELD_SUB_TYPE_COUNT = 6;
        public enum Shield_Sub_Type
        {
            Shield_1MJ,
            Shield_5MJ,
            Shield_25MJ,
            Shield_200MJ,
            Shield_1GJ,
            Shield_2GJ
        }
        // Type 10
        public const int MISSILE_SUB_TYPE_COUNT = 33;
        public enum Missile_Sub_Type
        {
            Mosquito,
            Wasp,
            Dragonfly,
            Silkworm,

            Disruptor = 5,
            Sting,
            Needle,
            Thorn,
            Firefly,

            Hurricane = 12,

            Tornado = 14,

            Aurora = 17,

            Beluga = 19,
            Hammerhead,
            Rapier,
            Firelance,

            Windstalker = 24,
            Banshee,
            Wraith,

            Shadow = 33,
        }
        // Type 11
        public const int WARE_ENERGY_SUB_TYPE_COUNT = 1;
        public enum Ware_Energy_Sub_Type
        {
            Energy_Cells
        }
        // Type 12
        // Type 13
        // Type 14
        public const int WARE_BIO_SUB_TYPE_COUNT = 11;
        public enum Ware_Bio_Sub_Type
        {
            Space_Weed = 10
        }
        // Type 15
        // Type 16
        public const int WARE_MMISCELLANEOUS_SUB_TYPE_COUNT = 110;
        public enum Ware_Miscellaneous_Sub_Type
        {
            Spaceflies = 5,
            Credits = 79,
            Energy_Bolt_Chaingun_Ammunition = 93,
            Keris = 109,
        }
        // Type 17
        // Type 18
        public const int GATE_SUB_TYPE_COUNT = 4;
        public enum Gate_Sub_Type
        {
            North_Gate,
            South_Gate,
            West_Gate,
            East_Gate,
            North_TransOrbital_Accelerator = 5,
            South_TransOrbital_Accelerator,
            West_TransOrbital_Accelerator,
            East_TransOrbital_Accelerator,
            Hub_Circle_1,
            Hub_Circle_2,
            Hub_Square_1,
            Hub_Square_2,
            Hub_Triangle_1,
            Hub_Triangle_2
        }
        // Type 19
        // Type 20
        public const int MISCELLANEOUS_SUB_TYPE_COUNT = 95;
        public enum Miscellaneous_Sub_Type
        {
            Station_Debris_1 = 38,
            Station_Debris_2 = 40,
            Station_Debris_3,
            Ship_Debris_1 = 43,
            Unknown_Object_1 = 45,
            Unknown_Object_2,
            Unknown_Object_3,
            Undefined_1 = 76,
            Undefined_2,
            Undefined_3,
            Advertisement_Ring_Solar_Power_Plant,
            Ship_Debris_2 = 93,
            Ship_Debris_3,
        }
        // Type 21
        // Type 22
        // Type 23
        // Type 24
        // Type 25
        // Type 26
        // Type 27
        // Type 28
        // Type 29
        // Type 30
        // Type 31
        #endregion

        /// <summary>
        /// Returns the object's subtype in as a string. Takes maintype into account.
        /// </summary>
        /// <returns></returns>
        public string GetSubTypeAsString()
        {
            return (GetSubTypeAsString(MainType, SubType));
        }

        public static string GetSubTypeAsString(Main_Type main_Type, int SubType)
        {
            switch (main_Type)
            {
                case Main_Type.Bullet: // 0
                case Main_Type.Laser: // 8
                    return ((Weapon_Sub_Type)SubType).ToString();
                case Main_Type.Sun: // 3
                    return ((Sun_Sub_Type)SubType).ToString();
                case Main_Type.Planet: // 4
                    return ((Planet_Sub_Type)SubType).ToString();
                case Main_Type.Dock: // 5
                    return ((Dock_Sub_Type)SubType).ToString();
                case Main_Type.Factory: // 6
                    return ((Factory_Sub_Type)SubType).ToString();
                case Main_Type.Ship: // 7
                    return ((Ship_Sub_Type)SubType).ToString();
                case Main_Type.Shield: // 9
                    return ((Shield_Sub_Type)SubType).ToString();
                case Main_Type.Missile: // 10
                    return ((Missile_Sub_Type)SubType).ToString();
                case Main_Type.Ware_Energy: // 11
                    return ((Ware_Energy_Sub_Type)SubType).ToString();
                case Main_Type.Ware_Bio: // 14
                    return ((Ware_Bio_Sub_Type)SubType).ToString();
                case Main_Type.Ware_Miscellaneous: // 16
                    return ((Ware_Miscellaneous_Sub_Type)SubType).ToString();
                case Main_Type.Gate: // 18
                    return ((Gate_Sub_Type)SubType).ToString();
                case Main_Type.Miscellaneous: // 20
                    return ((Miscellaneous_Sub_Type)SubType).ToString();
                default:
                    return SubType.ToString();
            }
        }

        public static int GetMaxSubType(Main_Type main_Type)
        {
            switch(main_Type)
            {
                case Main_Type.Bullet: // 0
                case Main_Type.Laser: // 8
                    return WEAPON_SUB_TYPE_COUNT;
                case Main_Type.Sun: // 3
                    return SUN_SUB_TYPE_COUNT;
                case Main_Type.Planet: // 4
                    return PLANET_SUB_TYPE_COUNT;
                case Main_Type.Dock: // 5
                    return DOCK_SUB_TYPE_COUNT;
                case Main_Type.Factory: // 6
                    return FACTORY_SUB_TYPE_COUNT;
                case Main_Type.Ship: // 7
                    return SHIP_SUB_TYPE_COUNT;
                case Main_Type.Shield: // 9
                    return SHIELD_SUB_TYPE_COUNT;
                case Main_Type.Missile: // 10
                    return MISSILE_SUB_TYPE_COUNT;
                case Main_Type.Ware_Bio: // 14
                    return WARE_BIO_SUB_TYPE_COUNT;
                case Main_Type.Ware_Miscellaneous: // 16
                    return WARE_MMISCELLANEOUS_SUB_TYPE_COUNT;
                case Main_Type.Gate: // 18
                    return GATE_SUB_TYPE_COUNT;
                case Main_Type.Miscellaneous: // 20
                    return MISCELLANEOUS_SUB_TYPE_COUNT;
                default: throw new NotImplementedException();
            }
        }
    }
}
