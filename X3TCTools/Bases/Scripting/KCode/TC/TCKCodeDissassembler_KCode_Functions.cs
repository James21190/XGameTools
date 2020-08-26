namespace X3TCTools.Bases.Scripting.KCode.TC
{
    public partial class TCKCodeDissassembler
    {
        public enum TCKCodeFunctionOffsets
        {
            Sector = 535865,

            Ship_Standby = 231642,
            Ship_Idling = 709975,
            Ship_Dock_At = 708487,
            Ship_Fly_To_Sector = 727950,
            Ship_Follow = 712208,
            Ship_Fly_To_Position = 710825,
            Ship_Jump_To_Sector = 731276,
            Ship_Jump_And_Dock = 731127,

            Turret_Attack = 228424,
            Turret_Defend_Ship = 228424,

            Ware = 564055,
        }

        public override string GetFunctionName(int functionStartInstructionAddress)
        {
            if (((TCKCodeFunctionOffsets)functionStartInstructionAddress).ToString() == functionStartInstructionAddress.ToString())
            {
                return "Unknown function " + functionStartInstructionAddress.ToString();
            }

            return ((TCKCodeFunctionOffsets)functionStartInstructionAddress).ToString();
        }
    }
}
