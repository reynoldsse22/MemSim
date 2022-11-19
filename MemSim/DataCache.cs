using System;

namespace MemSim
{
    internal class DataCache
    {
        Configurations config;
        //Used to check if the tags are the same from addresses
        public int[] tagIndexCache;
        public bool[] dirtyBits;
        public LRU[] lru;

        //Sets up the association for the cache
        private int association = 1;
        private int memoryKicked = 0;
        private Random rand;

        public int tag, index, offset, cacheLines, address;

        public int lastAddress { get; set; }
        public int lastIndex { get; set; }

        //Allows for configuration
        public int offsetBitAmount { get; set; }
        public int indexBitAmount { get; set; }
        public int indexSize { get; set; }
        //Number of words allowed in the cache
        public int numberOfBytes { get; set; }

        public int offsetMask;
        public int indexMask;

        /**
	    * Method Name: DataCache <br>
	    * Method Purpose: Class constructor
	    * 
	    * <hr>
	    * Date created: 4/19/21 <br>
	    * @author Samuel Reynolds
	    */
        public DataCache(string cacheType, Configurations configurations)
        {
            config = configurations;
            tag = 0;
            index = 0;
            offset = 0;
            //association = config.associativity;

            rand = new Random();
            switch (cacheType)
            {
                case "L1":
                    //Finds how many bits will be allowed in the offset
                    offsetBitAmount = config.DC_OffsetBits;
                    //Finds how many bits will be in the index
                    indexSize = config.DC_NumOfSets;

                    association = config.DC_SetSize;
                    indexBitAmount = config.DC_IndexBits;
                    break;
                case "L2":
                    //Finds how many bits will be allowed in the offset
                    offsetBitAmount = config.L2_OffsetBits;
                    //Finds how many bits will be in the index
                    indexSize = config.L2_NumOfSets;

                    association = config.L2_SetSize;
                    indexBitAmount = config.L2_IndexBits;
                    break;
            }

            cacheLines = indexSize * association;

            numberOfBytes = (int)Math.Pow(2, offsetBitAmount) + 2;
            //This should be configurable in the future to allow 2/4 way association
            offsetMask = (int)Math.Pow(2, offsetBitAmount) - 1;
            indexMask = (int)Math.Pow(2, indexBitAmount) - 1;

            tagIndexCache = new int[cacheLines];
            dirtyBits = new bool[cacheLines];
            lru = new LRU[indexSize];
            //Setting up the cache to hold memory
            for (int x = 0; x < tagIndexCache.Length; x++)
            {
                tagIndexCache[x] = -1;
                dirtyBits[x] = false;
            }
            for (int x = 0; x < indexSize; x++)
            {
                lru[x] = new LRU();
            }
        }

        /// <summary>Updates the TLB.</summary>
        /// <param name="address">The address.</param>
        /// <param name="memory">The main memory.</param>
        ///   <para>
        /// The cache.
        /// </para>
        /// </param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void updateCacheTag()
        {
            tagIndexCache[index + indexSize * memoryKicked] = tag;
            lru[index % indexSize].ComputeAddress(address);
        }


        /// <summary>Updates the cache with write instructions.</summary>
        /// <param name="result">The result.</param>
        public CacheHit updateWriteCache(int addressUp)
        {
            findCacheVariables(addressUp);
            CacheHit ch = findInstructionInCache();
            if (ch == CacheHit.HIT)
            {
                dirtyBits[index] = true;
            }
            updateCacheTag();

            return ch;
        }

        /// <summary>Updates the cache with read instructions.</summary>
        /// <param name="result">The result.</param>
        public CacheHit updateReadCache(int addressUp)
        {
            findCacheVariables(addressUp);
            CacheHit ch = findInstructionInCache();
            updateCacheTag();

            return ch;
        }
        /// <summary>
        ///   <para>
        /// Finds the cache variables in order to check if the address is in the cache.
        /// </para>
        /// </summary>
        /// <param name="inst">The instruction.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="index">The index.</param>
        /// <param name="tag">The tag.</param>
        public void findCacheVariables(int inst)
        {
            address = inst;
            offset = inst & offsetMask;
            inst = inst >> offsetBitAmount;
            index = inst & indexMask;
            inst = inst >> indexBitAmount;
            tag = inst;
        }

        /// <summary>Finds whether the instruction hit or missed in the cache.</summary>
        /// <param name="instruction">The instruction.</param>
        public CacheHit findInstructionInCache()
        {
            //finds the offset for the types of association

            for (int x = index; x < tagIndexCache.Length; x = x + indexSize)
            {
                if (tagIndexCache[x] == -1)
                {
                    index = x;
                    memoryKicked = 0;
                    return CacheHit.MISS;
                }
                else if (tagIndexCache[x] != tag)
                {

                }
                else
                {
                    index = x;
                    memoryKicked = 0;
                    lru[index % indexSize].ComputeAddress(address);
                    return CacheHit.HIT;
                }
            }
            findLRU();
            return CacheHit.CONF;
        }

        /// <summary>Clears the cache.</summary>
        public void clearCache()
        {
            for (int x = 0; x < tagIndexCache.Length; x++)
            {
                tagIndexCache[x] = 0;
            }
            memoryKicked = 0;
        }

        /// <summary>Finds the random offset for the eviction policy.</summary>
        public void findRandomOffset()
        {
            switch (association)
            {
                case 1:
                    memoryKicked = 0;
                    break;
                case 2:
                case 4:
                    memoryKicked = rand.Next(association);
                    break;
            }
        }

        public void findLRU()
        {
            if (association == 1)
            {
                memoryKicked = 0;
                lastAddress = lru[index].GetLRU();
            }
            else
            {
                lastAddress = lru[index % indexSize].GetLRU();
                int lastTag = lastAddress >> (indexBitAmount + offsetBitAmount);

                for (int x = 0; x < association; x++)
                {
                    if (tagIndexCache[index + indexSize * x] == lastTag)
                    {
                        memoryKicked = x;
                        lastIndex = index + indexSize * x;
                    }
                }
            }
        }
    }

}
