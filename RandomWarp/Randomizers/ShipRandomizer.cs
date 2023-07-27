using System;
using System.Linq;

namespace Randomizer.Randomizers
{
    public static class ShipRandomizer
    {
        private static Random _Random;
        public static void RandomizeShipWeapons(int subType)
        {
            var shipData = Program.GameHook.GetTypeData_Ship(subType);
            var turretCount = shipData.TurretCount;
            for (int turretIndex = 0; turretIndex < turretCount; turretIndex++)
            {
                var turret = shipData.GetTurretData(turretIndex);
                var weaponBitfield = turret.WeaponCompatability;
                var numberOfCompatibleWeapons = weaponBitfield.CountOnes();

                // +- 2
                //numberOfCompatibleWeapons += _Random.Next(-2, 3);
                if (numberOfCompatibleWeapons < 0)
                    numberOfCompatibleWeapons = 0;
                if(numberOfCompatibleWeapons > 32)
                    numberOfCompatibleWeapons = 32;

                int[] indexes = new int[numberOfCompatibleWeapons];
                for (int i = 0; i < numberOfCompatibleWeapons; i++)
                    indexes[i] = -1;

                for (int w = 0; w < numberOfCompatibleWeapons;)
                {
                    var index = _Random.Next(32);
                    if (!indexes.Contains(index))
                    {
                        indexes[w] = index;
                        w++;
                    }
                }

                for (int i = 0; i < 32; i++)
                    weaponBitfield.SetBit(i, indexes.Contains(i));

                turret.WriteSafeToMemory();
            }
        }

        public static void RandomizeAllShipWeapons(int randomSeed)
        {
            _Random = new Random(randomSeed);
            for (int i = 0; i < Program.GameHook.GetTypeDataCount_Ship(); i++)
            {
                RandomizeShipWeapons(i);
            }
        }
    }
}
