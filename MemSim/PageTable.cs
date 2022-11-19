using System;

namespace MemSim
{
    // set up as a linear PT
    // OSTEP Notes:
    // The simplest form is called a linear page table, which is just an array.
    // The OS indexes the array by the virtual page number(VPN), and looks up
    // the page-table entry(PTE) at that index in order to find the desired physical frame number(PFN)

    internal class PageTable
    {
        Configurations config;
        PageTableEntry[] PT;
        FrameTable FT;
        int Hits = 0;
        int Misses = 0;

        /// <summary>Creates page table and presets all of the pages options. Uses config settings to set the number of
        /// virtual and physical pages.</summary>
        public PageTable(Configurations configurations)
        {
            config = configurations;
            PT = new PageTableEntry[config.PT_NumOfVP];
            FT = new FrameTable(config.PT_NumOfVP);

            for (int i = 0; i < PT.Length; i++)  // create all pages, setting each to invalid
            {
                PT[i] = new PageTableEntry();
            }
        }

        /// <summary>Determines if the PFN at a given VPN is valid</summary>
        /// <returns>bool - true if valid, false if not</returns>
        public bool PFNPresentAndValid(long VPN)
        {
            if (PT[VPN].PFN != -1 && PT[VPN].ValidBit)
                return true;
            else
                return false;
        }

        /// <summary>Will return the PFN for a given VPN. If PFN at the VPN is empty or invalid, LRU algorithm is called 
        /// from Frame table class that get the next available PFN.</summary>
        /// <returns>Page Frame Number</returns>
        public int GetPFN(long VPN)
        {
            if (PT[VPN].PFN != -1 && PT[VPN].ValidBit)
            {
                FT.ReAdjustFrameTable(PT[VPN].PFN);
                Hits++;
                return PT[VPN].PFN;
            }
            else
            {
                Misses++;
                PT[VPN].PFN = FT.GetLRU();
                PT[VPN].ValidBit = true;

                InvalidateEntries(PT[VPN].PFN);
                PT[VPN].ValidBit = true;            // invalidate will mark all as false, so reset the current one back to true

                return PT[VPN].PFN;
            }

        }

        /// <summary>Takes given PFN integer and invalidates all instances of that PFN</summary>
        public void InvalidateEntries(int PFN)
        {
            foreach (var entry in PT)
            {
                if (entry.PFN == PFN)
                {
                    entry.ValidBit = false;
                }
            }
        }

    }
}