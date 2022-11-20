namespace MemSim
{
    internal class PageTableEntry
    {
        public int PFN;                     // page frame number
        public bool ValidBit;               // is translation in PTE valid
        public int ProtectionBits;          // read, write, etc
        public bool DirtyBit;               // page modified since load

        /// <summary>Creates a new Page table entry, with the PFN set to -1.</summary>
        public PageTableEntry()
        {
            this.PFN = -1;
            this.ValidBit = false;
            this.ProtectionBits = 0;
            this.DirtyBit = false;
        }
    }
}
