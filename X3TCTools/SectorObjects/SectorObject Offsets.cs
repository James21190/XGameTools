using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.SectorObjects
{
    public partial class SectorObject
    {
        public enum Offsets
        {
            pNext = 0,
            pPrevious = 4,
            ObjectID = 8,
            pDefaultName = 12,
            Speed = 16,
            TargetSpeed = 20,
            EulerRotationCopy = 24,
            LocalEulerRotationDelta = 36,
            RaceID = 60,
            MainType = 72,
            SubType = 74,
            pMeta = 80,
            pParent = 84,
            PositionStrafeDelta = 96,
            pData = 112,
            Position_Copy = 192,
            Speed_Copy = 232,
            Hull = 236
        }
    }
}
