using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSim
{
    internal class Configurations
    {
        public int TLB_NumOfSets, TLB_SetSize, TLB_IndexBits;
        public int PT_NumOfVP, PT_NumOfPhyP, PT_PageSize, PT_IndexBits, PT_OffsetBits;
        public int DC_NumOfSets, DC_SetSize, DC_LineSize, DC_IndexBits, DC_OffsetBits;
        public bool DC_Writethrough_NoAllocate;
        public int L2_NumOfSets, L2_SetSize, L2_LineSize, L2_IndexBits, L2_OffsetBits;
        public bool L2_Writethrough_NoAllocate;
        public bool VirtAddressing, TLB_Exists, L2Cache_Exists;
        public Configurations()
        {
            TLB_NumOfSets = 2;
            TLB_SetSize = 1;

            PT_NumOfVP = 64;
            PT_NumOfPhyP = 4;
            PT_PageSize = 256;

            DC_NumOfSets = 4;
            DC_SetSize = 1;
            DC_LineSize = 16;
            DC_Writethrough_NoAllocate = false;

            L2_NumOfSets = 16;
            L2_SetSize = 4;
            L2_LineSize = 16;
            L2_Writethrough_NoAllocate = false;

            VirtAddressing = true;
            TLB_Exists = true;
            L2Cache_Exists = true;
            computeIndexandOffsets();
        }

        public void updateConfiguration()
        {
            computeIndexandOffsets();
        }
        private void computeIndexandOffsets()
        {
            TLB_IndexBits = (int)Math.Log(TLB_NumOfSets, 2);
            PT_IndexBits = (int)Math.Log(PT_NumOfVP, 2);
            PT_OffsetBits = (int)Math.Log(PT_PageSize, 2);
            DC_IndexBits = (int)Math.Log(DC_NumOfSets, 2);
            DC_OffsetBits = (int)Math.Log(DC_LineSize, 2);
            L2_IndexBits = (int)Math.Log(L2_NumOfSets, 2);
            L2_OffsetBits = (int)Math.Log(L2_LineSize, 2);
        }
    }
}
