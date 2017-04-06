using System;

namespace LCLib.Asn1Processor
{
	/// <summary>
	/// Summary description for BinaryDump.
	/// </summary>
    public class BinaryDump
    {
        private byte[] data = null;
        private int offsetWidth = 3;
        private int dataWidth = 16;

        public byte[] Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public int OffsetWidth
        {
            get
            {
                return offsetWidth;
            }
            set
            {
                offsetWidth = value;
            }
        }

        public int DataWidth
        {
            get
            {
                return dataWidth;
            }
            set
            {
                dataWidth = value;
            }
        }
        

        public BinaryDump()
		{
		}

        public static string Dump(byte[] data, int offsetWidth, int dataWidth)
        {
            string retval = "";
            int line = 0, offset = 0;
            for (offset = 0; offset<data.Length; offset++)
            {

            }
            return retval;
        }

	}
}
