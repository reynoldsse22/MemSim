using MemSim;
using System;
using System.IO;

namespace MemSim
{
    internal class MemoryManagementUnit
    {
        public static Configurations config;
        public static int VIRTpageNumber = 0;
        public static int TLBtag = 0;
        public static int TLBindex = 0;
        public static int PTindex = 0;
        public static int pageOffset = 0;
        public static int DCtag = 0;
        public static int DCindex = 0;
        public static int DCoffset = 0;
        public static int L2tag = 0;
        public static int L2Index = 0;
        public static int L2Offset = 0;
        public static int TLBhit, TLBmiss, PThit, PTmiss, DChit, DCmiss, L2hit, L2miss,
            reads, writes, MMrefs, DiskRefs, PTrefs, MemRefLength;
        public static int IndexBits;
        public void RunProgram(ref Configurations configuration, ref string inputString, ref string statsOutput, ref string memOutput)
        {
            config = configuration;
            //Will hold the addresses from the inputted files
            string[] addressLines;
            string[] address;
            string pageOffsetHex = "";
            DataCache dc = new DataCache("L1", config);
            DataCache l2 = new DataCache("L2", config);
            DTLB tlb = new DTLB(config); 
            PageTable pt = new PageTable(config);
            CacheHit dCache = new CacheHit();
            CacheHit l2Cache = new CacheHit();
            TlbHit Dtlb = new TlbHit();
            int[] test = new int[] { 12, 8, 1, 12, 4, 1, 1, 12, 0 };


            //IsolateOffset("EFA");


            //int that will hold the addresses int

            int virtAddress;
            int physAddress = 0;
            int physicalPageNum = 0;
            string TLBresult = "MISS", PTresult, DCresult = "MISS", L2result = "MISS";
            addressLines = inputString.Split('\n');
            //statsOutput += DisplayConfigSettings();

            address = addressLines[0].Split(':');       // calculate the bits in a memory reference
            MemRefLength = address[1].Length * 4;

            memOutput += "Virtual  Virt.  Page TLB    TLB TLB  PT   Phys        DC  DC          L2  L2\n";
            memOutput += "Address  Page # Off  Tag    Ind Res. Res. Pg # DC Tag Ind Res. L2 Tag Ind Res.\n";
            memOutput += "-------- ------ ---- ------ --- ---- ---- ---- ------ --- ---- ------ --- ----\n";

            //runs through each address and sends it through TLB, Page Table, and Cache
            for (int x = 0; x < addressLines.Length; x++)
            {
                //Resets L2 Variables
                l2Cache = CacheHit.BYPASS;
                address = addressLines[x].Split(':');
                PTresult = "";

                //address[0] is the read or write char

                address[1] = CheckMemoryReference(address[1]);      // removes, adds, or leaves the same
                IsolateVPNAndOffset(address[1]);



                //TLB checks to see if the physical address exists
                //if statement here to see if tlb is disabled or not
                if(config.TLB_Exists)
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
                if(config.TLB_Exists)
                    tlb.updateTlbTag(physicalPageNum);
            Skip:
                // build new virt address with PFN + offset
                virtAddress = (physicalPageNum << IndexBits) + pageOffset;

                //TLB Update if it exists
                if(config.TLB_Exists)
                {  
                    TLBresult = Dtlb.ToString();
                    TLBindex = tlb.index;
                    TLBtag = tlb.tag;
                }
                

                // REPLACED CARLOS' physAddress WITH virtAddress
                // need to differentiate with the two based on config settings

                //Access the Data Cache with the physical address
                if (address[0] == "R")
                {
                    reads++;
                    dCache = dc.updateReadCache(virtAddress);
                    switch (dCache)
                    {
                        case CacheHit.HIT:
                            DChit++;
                            //DC READ HIT, bypass the L2 cache
                            break;
                        case CacheHit.CONF:
                            DCmiss++;
                            //DC WRITE CONF Write-Back, Update L2 Cache with the address that is being overwritten
                            l2Cache = l2.updateReadCache(virtAddress);
                            break;
                        case CacheHit.MISS:
                            DCmiss++;
                            //DC READ CONF/MISS, Pass address to the L2 cache to see if it hits or misses
                            l2Cache = l2.updateReadCache(virtAddress);
                            break;

                    }
                    DCresult = dCache.ToString();
                    DCindex = dc.index;
                    DCtag = dc.tag;

                    //Updates variables for the console
                    L2result = l2MemoryReference(l2, l2Cache);
                }
                else
                {
                    writes++;
                    dCache = dc.updateWriteCache(virtAddress);
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
                                l2Cache = l2.updateWriteCache(virtAddress);
                            }

                            break;
                        case CacheHit.CONF:
                            DCmiss++;
                            //DC WRITE CONF Write-Back, Update L2 Cache with the address that is being overwritten
                            if (!config.DC_Writethrough_NoAllocate)
                            {
                                if (dc.dirtyBits[dc.lastIndex])
                                {
                                    l2Cache = l2.updateWriteCache(dc.lastAddress);
                                    dc.dirtyBits[dc.lastIndex] = false;
                                }
                                else
                                {
                                    l2Cache = l2.updateWriteCache(virtAddress);
                                }

                            }
                            else
                                l2Cache = l2.updateWriteCache(virtAddress);
                            break;
                        case CacheHit.MISS:
                            DCmiss++;
                            //DC MISS Write-Back, Update DC and L2 Cache
                            l2Cache = l2.updateWriteCache(virtAddress);
                            break;

                    }
                    DCresult = dCache.ToString();
                    DCindex = dc.index;
                    DCtag = dc.tag;

                    //Gets the variables to print out to the console
                    L2result = l2MemoryReference(l2, l2Cache);
                }

                string output = String.Format("{0,8} {1,6} {2,4} {3,6} {4,3} {5,4} {6,4} {7,4} {8,6} {9,3} {10,4} {11,6} {12,3} {13,4}\n",
                    address[1].PadLeft(8, '0'), VIRTpageNumber.ToString("X").PadLeft(6), pageOffset.ToString("X").PadLeft(4),
                    TLBtag, TLBindex, TLBresult, PTresult, physicalPageNum, DCtag.ToString("X"), DCindex,
                    DCresult, L2tag, L2Index, L2result);
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
            output += "\nDTLB Hit Ratio: " + (double)TLBhit / (TLBmiss + TLBhit);

            output += "\n\nPT Hits: " + PThit;
            output += "\nPT Faults: " + PTmiss;
            output += "\nPT Hit Ratio: " + (double)PThit / (PTmiss + PThit);

            output += "\n\nDC Hits: " + DChit;
            output += "\nDC Misses: " + DCmiss;
            output += "\nDC Hit Ratio: " + (double)DChit / (DCmiss + DChit);

            output += "\n\nL2 Hits: " + L2hit;
            output += "\nL2 Misses: " + L2miss;
            output += "\nL2 Hit ratio: " + (double)L2hit / (L2miss + L2hit);

            output += "\n\nTotal Reads: " + reads;
            output += "\nTotal Writes: " + writes;
            output += "\nRatio of Reads: " + (double)reads / (writes + reads);

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


    }
}