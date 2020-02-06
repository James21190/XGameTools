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
            Projectile,
            Sector,
            Type_2,
            Sun,
            Planet,
            Dock,
            Factory,
            Ship,
            Weapon,
            Shield,
            Missile,
            Ware_Energy,
            Type_12,
            Type_13,
            Type_14,
            Type_15,
            Type_16,
            Asteroid_1,
            Gate,
            Type_19,
            Miscellaneous,
            Type_21,
            Type_22,
            Asteroid_2 = 28
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

        }
        // Type 4
        public const int PLANET_SUB_TYPE_COUNT = 147;
        public enum Planet_Sub_Type
        {

        }
        // Type 5
        public const int DOCK_SUB_TYPE_COUNT = 46;
        public enum Dock_Sub_Type
        {
            Free_Argon_Trading_Station,
            Split_Trading_Port,
            Paranid_Trading_Dock,
            Royal_Boron_Trading_Station,
            Trading_Station,
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
            Military_Base_1,
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
            Teladi_Weapon_Component_Factory = 10,
            Argon_Crystal_Fab,
            Boron_Crystal_Fab,
            Paranid_Crystal_Fab,
            Crystal_Fab_2,
            Teladi_Crystal_Fab,
            Argon_Quantum_Tube_Fab,
            Quantum_Tube_Fab_1 = 19,
            Teladi_Quantum_Tube_Fab,
            Boron_Chip_Plant = 22,
            Chip_Plant_2 = 24,
            Chip_Plant_3,
            Argon_Computer_Plant,
            Boron_Computer_Plant,
            Wheat_Farm_1 = 143,
            Wheat_Farm_2,
            Cattle_Ranch,
            Bio_Gass_Factory = 150,
            Scruffin_Farm = 152,
            Chelt_Space_Aquarium_1,
            Chelt_Space_Aquarium_2,
            Soyfarm_1,
            Soyfarm_2,
            Snail_Ranch,
            Flower_Farm_1 = 159,
            Flower_Farm_2,
            Teladianium_Foundry_1,
            Teladianium_Foundry_2,
            Dream_Farm,
            Stott_Mixery = 171,
            Boron_Silicon_Mine_M = 215,
            Boron_Silicon_Mine_L,
            Complex_Hub = 227,
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
            Terran_Matter_Anti_Matter_Mine_Fab = 352,
            Terran_Ghoul_Missile_Manufacturing_Plant = 356,
            Teladi_Energy_Bolt_Chaingun_Ammunition_Forge = 363,
            Argon_Heavy_Weapons_Complex = 384,
            Terran_Solar_Power_Plant_1,
            Terran_Solar_Power_Plant_2,
            Terran_Solar_Power_Plant_3,
            Terran_Mining_Outpost_2 = 395,
            Argon_Drone_Production_Facility = 402,
            Boron_Drone_Production_Facility,
            Teladi_Drone_Production_Facility = 405,
            Boron_Recon_Drone_Construction_Facility = 362,
            Boron_Tomahawk_Missile_Manufacturing_Plant = 366,
            Crystal_Fab_5 = 435,
            Crystal_Fab_4 = 438
        }
        // Type 7
        public const int SHIP_SUB_TYPE_COUNT = 373;
        public enum Ship_Sub_Type
        {
            Argon_Mammoth,
            Argon_Mercury_1,
            Argon_Mercury_2,
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
            Argon_Buster_4,
            Argon_Elite,
            Argon_Discoverer_1,
            Argon_Discoverer_2,
            Argon_Discoverer_3,
            Argon_Discoverer_4,
            Argon_Centaur,
            Argon_Heavy_Centaur,
            Argon_Gladiator = 30,
            Small_Orbital_Weapons_Platform = 38,
            Medium_Orbital_Weapons_Platform,
            Large_Orbital_Weapons_Platform,
            Split_Elephant,
            Split_Caiman_1,
            Split_Caiman_2,
            Split_Caiman_3,
            Split_Caiman_7,
            Split_Caiman_4,
            Split_Caiman_5,
            Split_Caiman_6,
            Split_Iguana_1,
            Split_Iquana_2,
            Split_Boa,
            Split_Raptor,
            Split_Python,
            Split_Mamba_1,
            Split_Mamba_2,
            Split_Mamba_3,
            Split_Chimera = 58,
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
            Split_Viper = 72,
            Paranid_Hercules,
            Paranid_Demeter_1,
            Paranid_Demeter_2,
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
            Paranid_Hades = 103,
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
            Boron_Skate = 121,
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
            Boron_Thresher = 133,
            Teladi_Albatross = 136,
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
            Teladi_Buzzard_2 = 155,
            Teladi_Buzzard_3,
            Teladi_Kite_1,
            Teladi_Harrier_1,
            Teladi_Harrier_2,
            Teladi_Harrier_3,
            Teladi_Harrier_4,
            Teladi_Kestrel,
            Teladi_Osprey,
            Teladi_Peregrine = 167,
            Xenon_J,
            Xenon_K,
            Xenon_L,
            Xenon_LX,
            Xenon_M,
            Xenon_N,
            Xenon_PX = 175,
            Xenon_Q,
            Pirate_Falcon = 179,
            Pirate_Nova_1,
            Pirate_Nova_2,
            Pirate_Kea = 184,
            Pirate_Buster = 186,
            Pirate_Buzzard,
            Pirate_Elete = 191,
            Pirate_Harrier,
            Pirate_Centaur = 197,
            Pirate_Carrack = 199,
            ATF_Odin,
            ATF_Tyre,
            ATF_Thor,
            ATF_Fenrir,
            ATF_Mjollnir,
            ATF_Valkyrie,
            ATF_Vali = 207,
            ATF_Aegir,
            ATF_Skirnir,
            Terran_Baldric = 212,
            Terran_Scabbard,
            Terran_Tokyo,
            Terran_Osaka,
            Terran_Scimitar,
            Terran_Cutlass,
            Terran_Sabre,
            Terran_Rapier,
            Terran_Katana = 221,
            Terran_Yokohama,
            Terran_Clamore,
            Terran_Spitfyre,
            Terran_Springblossom,
            Terran_CPU_Deca = 226,
            Yaki_Susanowa = 229,
            Yaki_Fujin = 238,
            Khaak_Carrier = 241,
            Khaak_Destroyer,
            Khaak_Fighter,
            Khaak_Interceptor,
            Khaak_Scout,
            Khaak_Corvette,
            Khaak_Guardian,
            Gonor_Aran = 250,
            Gonor_Ranger,
            OTAS_Boreas = 252,
            OTAS_Solano = 256,
            OTAS_Zephyrus,
            Khaak_Cluster = 266,
            Navigation_Relay_Satellite = 270,
            Fighter_Drone = 272,
            Lazertower = 273,
            Gonor_UFO,
            Spaceflies,
            Advanced_Satellite = 278,
            Freight_Drone = 294,
            Argon_Griffon,
            Split_Panther,
            Paranid_Agamemnon,
            Pirate_Brigantine = 301,
            Yaki_Akuma = 305,
            OTAS_Mistral_1 = 309,
            OTAS_Mistral_2,
            Matter_Anti_Matter_Mine = 319,
            Terran_Atmospheric_Lifter = 326,
            Terran_Mobile_Mining_Base_Ship,
            Paranid_Hyperion,
            Argon_Discoverer_Advanced = 335,
            Teladi_Kite_2 = 354,
            Xperimental_Shuttle = 372
        }
        // Type 8
        public const int WEAPON_SUB_TYPE_COUNT = 35;
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
            Starburst_Shockwave_Cannon = 19,
            Photon_Pulse_Cannon,
            Ion_Cannon,
            Incendiary_Bomb_Launcher = 23,
            Point_Singularity_Projector,
            Plasma_Beam_Cannon,
            Alpha_Kyon_Emitter = 32,
            Beta_Kyon_Emitter,
            Gamma_Kyon_Emitter,
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
            Wasp = 1,
            Sting = 6,
            Needle,
            Thorn,
            Hurricane = 12,
            Tornado = 14,
            Hammerhead = 20,
            Rapier,
            Firelance,
            Windstalker = 24,
            Banshee,
            Shadow = 33,
        }
        // Type 11
        // Type 12
        // Type 13
        // Type 14
        // Type 15
        // Type 16
        // Type 17
        // Type 18
        public const int GATE_SUB_TYPE_COUNT = 4;
        public enum Gate_Sub_Type
        {
            North,
            South,
            West,
            East
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
            Undefined_4,
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
                case Main_Type.Projectile: // 0
                case Main_Type.Weapon: // 8
                    return ((Weapon_Sub_Type)SubType).ToString();
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
                case Main_Type.Gate: // 18
                    return ((Gate_Sub_Type)SubType).ToString();
                default:
                    return SubType.ToString();
            }
        }

        public static int GetMaxSubType(Main_Type main_Type)
        {
            switch(main_Type)
            {
                case Main_Type.Projectile: // 0
                case Main_Type.Weapon: // 8
                    return WEAPON_SUB_TYPE_COUNT;
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
                case Main_Type.Gate: // 18
                    return GATE_SUB_TYPE_COUNT;
                default: throw new NotImplementedException();
            }
        }
    }
}
