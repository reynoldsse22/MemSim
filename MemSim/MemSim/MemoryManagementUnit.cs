using MemSim;
using System;
using System.IO;

namespace MemSim
{
    internal class MemoryManagementUnit
    {
        public static Configurations config;
        public static int VIRTpageNumber;
        public static int TLBtag;
        public static int TLBindex;
        public static int PTindex;
        public static int pageOffset;
        public static int DCtag;
        public static int DCindex;
        public static int DCoffset;
        public static int L2tag;
        public static int L2Index;
        public static int L2Offset;
        public static int TLBhit, TLBmiss, PThit, PTmiss, DChit, DCmiss, L2hit, L2miss,
            reads, writes, MMrefs, DiskRefs, PTrefs, MemRefLength;
        public static int IndexBits;
        public void RunProgram(ref Configurations configuration, ref string inputString, ref string statsOutput, ref string memOutput)
        {
            resetVariables();
            statsOutput = string.Empty;
            memOutput= string.Empty;
            config = configuration;
            //Will hold the addresses from the inputted files
            string[] addressLines;
            string[] address;
            DataCache dc = new DataCache("L1", config);
            DataCache l2 = new DataCache("L2", config);
            DTLB tlb = new DTLB(config); 
            PageTable pt = new PageTable(config);
            CacheHit dCache = new CacheHit();
            CacheHit l2Cache = new CacheHit();
            TlbHit Dtlb = new TlbHit();
            int finalAddress;

            int physicalPageNum = 0;
            string TLBresult = "MISS", PTresult, DCresult = "MISS", L2result = "MISS";
            addressLines = inputString.Split('\n');
            //statsOutput += DisplayConfigSettings();

            address = addressLines[0].Split(':');       // calculate the bits in a memory reference
            MemRefLength = address[1].Length * 4;

            if (config.VirtAddressing) { memOutput += "Virtual  Virt.  Page "; } else { memOutput += "Physical Phys.  Page "; }
            if (config.TLB_Exists) { memOutput += "TLB    TLB TLB  "; }
            if (config.VirtAddressing) { memOutput += "PT   Phys        DC  DC  "; } else { memOutput += "       DC  DC  "; }
            if (config.L2Cache_Exists) { memOutput += "        L2  L2\n"; } else { memOutput += "\n"; }
            memOutput += "Address  Page # Off ";
            if (config.TLB_Exists) { memOutput += " Tag    Ind Res."; }
            if (config.VirtAddressing) { memOutput += " Res. Pg #"; }
            memOutput += " DC Tag Ind Res.";
            if (config.L2Cache_Exists) { memOutput += " L2 Tag Ind Res.\n"; } else { memOutput += "\n"; }
            memOutput += "-------- ------ ----";
            if (config.TLB_Exists) { memOutput += " ------ --- ----"; }
            if (config.VirtAddressing) { memOutput += " ---- ---- ------ --- ----"; } else { memOutput += " ------ --- ----"; }
            if (config.L2Cache_Exists) { memOutput += " ------ --- ----\n"; } else { memOutput += "\n"; }

            //runs through each address and sends it through TLB, Page Table, and Cache
            for (int x = 0; x < addressLines.Length; x++)
            {
                //Resets L2 Variables
                if(config.L2Cache_Exists)
                    l2Cache = CacheHit.BYPASS;

                address = addressLines[x].Split(':');
                PTresult = "";

                //address[0] is the read or write char
                address[1] = CheckMemoryReference(address[1]);      // removes, adds, or leaves the same
                IsolateVPNAndOffset(address[1]);

                if (config.VirtAddressing)
                {
                    //TLB checks to see if the physical address exists
                    //if statement here to see if tlb is disabled or not
                    if (config.TLB_Exists)
                    {
                        Dtlb = tlb.updateTLB(VIRTpageNumber);

                        switch (Dtlb)
                        {
                            case TlbHit.HIT:
                                TLBhit++;
                                physicalPageNum = tlb.returnPPN();
                                //TLB HIT, Skip PageTable
                                goto Skip;

                            case TlbHit.CONF:
                                TLBmiss++;
                                //TLB MISS, Access PageTable
                                break;

                            case TlbHit.MISS:
                                TLBmiss++;
                                //TLB MISS, Access PageTable
                                break;
                        }
                    }

                    //PageTable finds the physical address for the virtual address

                    //PT HIT, return the physical page number
                    PTrefs++;
                    if (pt.PFNPresentAndValid(VIRTpageNumber))
                    {
                        PThit++;
                        PTresult = "HIT";
                        physicalPageNum = pt.GetPFN(VIRTpageNumber);
                    }
                    else     //PT MISS, Update the PT, return physical page number
                    {
                        PTmiss++;
                        PTresult = "MISS";
                        physicalPageNum = pt.GetPFN(VIRTpageNumber);
                    }
                    if (config.TLB_Exists)
                        tlb.updateTlbTag(physicalPageNum);
                    Skip:
                    // build new virt address with PFN + offset
                    finalAddress = (physicalPageNum << IndexBits) + pageOffset;

                    //TLB Update if it exists
                    if (config.TLB_Exists)
                    {
                        TLBresult = Dtlb.ToString();
                        TLBindex = tlb.index;
                        TLBtag = tlb.tag;
                    }
                }
                else
                {
                    finalAddress = Convert.ToInt32(address[1], 16);
                }

                // REPLACED CARLOS' physAddress WITH virtAddress
                // need to differentiate with the two based on config settings

                //Access the Data Cache with the physical address
                if (address[0] == "R")
                {
                    reads++;
                    dCache = dc.updateReadCache(finalAddress);
                    switch (dCache)
                    {
                        case CacheHit.HIT:
                            DChit++;
                            //DC READ HIT, bypass the L2 cache
                            break;
                        case CacheHit.CONF:
                            DCmiss++;
                            //DC WRITE CONF Write-Back, Update L2 Cache with the address that is being overwritten
                            if (config.L2Cache_Exists)
                                l2Cache = l2.updateReadCache(finalAddress);
                            break;
                        case CacheHit.MISS:
                            DCmiss++;
                            //DC READ CONF/MISS, Pass address to the L2 cache to see if it hits or misses
                            if (config.L2Cache_Exists)
                                l2Cache = l2.updateReadCache(finalAddress);
                            break;

                    }
                    DCresult = dCache.ToString();
                    DCindex = dc.index;
                    DCtag = dc.tag;

                    //Updates variables for the console
                    if (config.L2Cache_Exists)
                        L2result = l2MemoryReference(l2, l2Cache);
                }
                else
                {
                    writes++;
                    dCache = dc.updateWriteCache(finalAddress);
                    switch (dCache)
                    {
                        case CacheHit.HIT:
                            DChit++;
                            //DC WRITE HIT Write-Back, Update DC Cache
                            if (!config.DC_Writethrough_NoAllocate)
                            {

                            }
                            else
                            {
                                //DC WRITE HIT/CONF Write-Through, Update DC and L2 Cache
                                if (config.L2Cache_Exists)
                                    l2Cache = l2.updateWriteCache(finalAddress);
                            }

                            break;
                        case CacheHit.CONF:
                            DCmiss++;
                            //DC WRITE CONF Write-Back, Update L2 Cache with the address that is being overwritten
                            if (!config.DC_Writethrough_NoAllocate)
                            {
                                if (dc.dirtyBits[dc.lastIndex])
                                {
                                    if (config.L2Cache_Exists)
                                        l2Cache = l2.updateWriteCache(dc.lastAddress);
                                    dc.dirtyBits[dc.lastIndex] = false;
                                }
                                else
                                {
                                    if (config.L2Cache_Exists)
                                        l2Cache = l2.updateWriteCache(finalAddress);
                                }

                            }
                            else
                            {
                                if (config.L2Cache_Exists)
                                    l2Cache = l2.updateWriteCache(finalAddress);
                            }
                            break;
                        case CacheHit.MISS:
                            DCmiss++;
                            //DC MISS Write-Back, Update DC and L2 Cache
                            if (config.L2Cache_Exists)
                                l2Cache = l2.updateWriteCache(finalAddress);
                            break;

                    }
                    DCresult = dCache.ToString();
                    DCindex = dc.index;
                    DCtag = dc.tag;

                    //Gets the variables to print out to the console
                    if(config.L2Cache_Exists)
                        L2result = l2MemoryReference(l2, l2Cache);
                }


                //Create output


                string output = String.Format("{0,8} {1,6} {2,4} ", address[1].PadLeft(8, '0'), VIRTpageNumber.ToString("X").PadLeft(6), pageOffset.ToString("X").PadLeft(4));
                if (config.TLB_Exists) { output += String.Format("{0,6} {1,3} {2,4} ", TLBtag, TLBindex, TLBresult); }
                if (config.VirtAddressing) { output += String.Format("{0,4} {1,4} ", PTresult, physicalPageNum); }
                output += String.Format("{0,6} {1,3} {2,4} ",  DCtag.ToString("X"), DCindex, DCresult);
                if (config.L2Cache_Exists) { output += String.Format("{0,6} {1,3} {2,4}\n", L2tag, L2Index, L2result); } else { output += "\n"; }
                memOutput += output;
            }

            if(config.TLB_Exists)
            {
                tlb.findTLBVariables(12);
                TlbHit t = tlb.findInTlb();
            }

            statsOutput += DisplayFinalStats();

        }
        //Gets the L2 reference
        private static string l2MemoryReference(DataCache l2, CacheHit l2Cache)
        {
            string L2result = l2Cache.ToString();
            L2Index = l2.index % l2.indexSize;
            L2tag = l2.tag;
            switch (l2Cache)
            {
                case CacheHit.HIT:
                    L2hit++;
                    break;
                case CacheHit.CONF:
                case CacheHit.MISS:
                    MMrefs++;
                    DiskRefs++;
                    L2miss++;
                    break;
                default:
                    L2result = "";
                    L2Index = 0;
                    L2tag = 0;
                    break;
            }

            return L2result;
        }

        private static void writeCache()
        {
            throw new NotImplementedException();
        }

        private static void readCache()
        {
            throw new NotImplementedException();
        }

        public static string DisplayConfigSettings()
        {
            string statsString = "";
            if (config.TLB_Exists)
            {
                statsString+= "\nData TLB contains " + config.TLB_NumOfSets + " sets.";
                statsString += "\nEach set contains " + config.TLB_SetSize + " entries.";
                statsString += "\nNumber of bits used for the index is " + config.TLB_IndexBits ;
            }
            else
                statsString += "\nTLB does not exist.";
            statsString += "\nNumber of virtual pages is " +  config.PT_NumOfVP;
            statsString += "\nNumber of physical pages is " +  config.PT_NumOfPhyP;
            statsString += "\nEach page contains " + config.PT_PageSize + " bytes.";
            statsString += "\nNumber of bits used for the page table index is " +  config.PT_IndexBits;
            statsString += "\nNumber of bits used for the page offset " +  config.PT_OffsetBits;
            statsString += "\nD-cache contains "+ config.DC_NumOfSets + " sets";
            statsString += "\nEach set contains "+ config.DC_SetSize + " entries";
            statsString += "\nEach line is "+ config.DC_LineSize + " bytes";
            if (config.DC_Writethrough_NoAllocate)
                statsString += "\nThe cache uses a write-allocate and write-back policy.";
            else
                statsString += "\nThe cache uses a write-allocate and no write-back policy.";
            statsString += "\nNumber of bytes used for the index is " + config.DC_IndexBits;
            statsString += "\nNumber of bytes used for the offset is " + config.DC_OffsetBits;
            if(config.L2Cache_Exists)
            {
                statsString += "\nL2-cache contains "+ config.L2_NumOfSets + " sets";
                statsString += "\nEach set contains " + config.L2_SetSize + " entries";
                statsString += "\nEach line is " + config.L2_LineSize + " bytes";
                if (config.L2_Writethrough_NoAllocate)
                    statsString += "\nThe cache uses a write-allocate and write-back policy.";
                else
                    statsString += "\nThe cache uses a write-allocate and no write-back policy.";
                statsString += "\nNumber of bytes used for the index is " + config.L2_IndexBits;
                statsString += "\nNumber of bytes used for the offset is " +  config.L2_OffsetBits;
            }
            else
                statsString += "\nTLB does not exist.";

            if (config.VirtAddressing)
                statsString += "\nThe addresses read in are virtual addresses.";
            else
                statsString += "\nThe addresses read in are physical addresses.";

            return statsString;
        }
        //Prints out the final stats for the program
        public static string DisplayFinalStats()
        {
            string output = "Simulation Statistics:";
            output+= "\nDTLB Hits: " + TLBhit;
            output += "\nDTLB Misses: " + TLBmiss;
            output += "\nDTLB Hit Ratio: " + ((double)TLBhit / (TLBmiss + TLBhit)).ToString(".000");

            output += "\n\nPT Hits: " + PThit;
            output += "\nPT Faults: " + PTmiss;
            output += "\nPT Hit Ratio: " + ((double)PThit / (PTmiss + PThit)).ToString(".000");

            output += "\n\nDC Hits: " + DChit;
            output += "\nDC Misses: " + DCmiss;
            output += "\nDC Hit Ratio: " + ((double)DChit / (DCmiss + DChit)).ToString(".000");

            output += "\n\nL2 Hits: " + L2hit;
            output += "\nL2 Misses: " + L2miss;
            output += "\nL2 Hit ratio: " + ((double)L2hit / (L2miss + L2hit)).ToString(".000");

            output += "\n\nTotal Reads: " + reads;
            output += "\nTotal Writes: " + writes;
            output += "\nRatio of Reads: " + ((double)reads / (writes + reads)).ToString(".000");

            output += "\n\nMain Memory Refs: " + MMrefs;
            output += "\nPage Table Refs: " + PTrefs;
            output += "\nDisk Refs: " + DiskRefs;
            return output;
        }

        /// <summary>Sets VPN value based on config settings and given memory reference</summary>
        public static void IsolateVPNAndOffset(string MemoryReference)
        {
            int VPNBits = config.PT_IndexBits;
            IndexBits = config.PT_OffsetBits;

            char[] MaskBuilder = new char[VPNBits + IndexBits];
            long memRef = Convert.ToInt64(MemoryReference, 16);

            for (int i = 0; i < VPNBits; i++)           // VPN Mask
            {
                MaskBuilder[i] = '1';
            }

            for (int i = 0; i < IndexBits; i++)
            {
                MaskBuilder[i + VPNBits] = '0';
            }

            string strMask = string.Concat(MaskBuilder);
            long Mask = Convert.ToInt64(strMask, 2);

            VIRTpageNumber = (int)(Mask & memRef) >> IndexBits;

            for (int i = 0; i < VPNBits; i++)           // Offset mask
            {
                MaskBuilder[i] = '0';
            }

            for (int i = 0; i < IndexBits; i++)
            {
                MaskBuilder[i + VPNBits] = '1';
            }

            strMask = string.Concat(MaskBuilder);
            Mask = Convert.ToInt64(strMask, 2);

            pageOffset = (int)Mask & (int)memRef;
        }

        /// <summary>Checks config settings and bit in given Memory Reference. If reference is too long, it will remove the leftmost 
        /// bits as needed. If reference is too short, it will pad with zeros.</summary>
        /// <returns>new Memory Reference, if changes were needed.</returns>
        public static string CheckMemoryReference(string MemoryReference)
        {
            int VPNBits = config.PT_IndexBits;
            int IndexBits = config.PT_OffsetBits;

            char[] RemoveExtraBitsMask;

            long memRef = Convert.ToInt64(MemoryReference, 16);

            if (MemRefLength > (VPNBits + IndexBits))
            {
                // create mask that only allows through the VPNBits + IndexBits least sig bits
                RemoveExtraBitsMask = new char[MemRefLength];
                for (int i = 0; i < MemRefLength; i++)
                {
                    if (i < MemRefLength - (VPNBits + IndexBits))
                        RemoveExtraBitsMask[i] = '0';
                    else
                        RemoveExtraBitsMask[i] = '1';
                }

                string removeBitsMask = string.Concat(RemoveExtraBitsMask);
                long RemoveBitsMask = Convert.ToInt64(removeBitsMask, 2);

                memRef &= RemoveBitsMask;
            }

            return memRef.ToString("X");
        }

        internal void resetVariables()
        {
            VIRTpageNumber = 0;
            TLBtag = 0;
            TLBindex = 0;
            PTindex = 0;
            pageOffset = 0;
            DCtag = 0;
            DCindex = 0;
            DCoffset = 0;
            L2tag = 0;
            L2Index = 0;
            L2Offset = 0;
            TLBhit = 0;
            TLBmiss = 0;
            PThit = 0;
            PTmiss = 0;
            DChit = 0;
            DCmiss = 0;
            L2hit = 0;
            L2miss = 0;
            reads = 0;
            writes = 0;
            MMrefs = 0;
            DiskRefs = 0;
            PTrefs = 0;
            MemRefLength = 0;
            IndexBits = 0;
        }
    }
}