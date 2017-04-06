//+-------------------------------------------------------------------------------+
//| Copyright (c) 2003 Liping Dai. All rights reserved.                           |
//| Web: www.lipingshare.com                                                      |
//| Email: lipingshare@yahoo.com                                                  |
//|                                                                               |
//| Copyright and Permission Details:                                             |
//| =================================                                             |
//| Permission is hereby granted, free of charge, to any person obtaining a copy  |
//| of this software and associated documentation files (the "Software"), to deal |
//| in the Software without restriction, including without limitation the rights  |
//| to use, copy, modify, merge, publish, distribute, and/or sell copies of the   |
//| Software, subject to the following conditions:                                |
//|                                                                               |
//| 1. Redistributions of source code must retain the above copyright notice, this|
//| list of conditions and the following disclaimer.                              |
//|                                                                               |
//| 2. Redistributions in binary form must reproduce the above copyright notice,  |
//| this list of conditions and the following disclaimer in the documentation     |
//| and/or other materials provided with the distribution.                        |
//|                                                                               |
//| THE SOFTWARE PRODUCT IS PROVIDED “AS IS” WITHOUT WARRANTY OF ANY KIND,        |
//| EITHER EXPRESS OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED         |
//| WARRANTIES OF TITLE, NON-INFRINGEMENT, MERCHANTABILITY AND FITNESS FOR        |
//| A PARTICULAR PURPOSE.                                                         |
//+-------------------------------------------------------------------------------+

using System;
using System.IO;
using System.Windows.Forms;

namespace LipingShare.LCLib.Asn1Processor
{
	/// <summary>
	/// Maintaining ASN.1 DER encoded clipboard data.
	/// </summary>
    [Serializable]
    public class Asn1ClipboardData : Object
	{
        /// <summary>
        /// constructor.
        /// </summary>
        public Asn1ClipboardData()
        {
        }

        /// <summary>
        /// ASN.1 clipboard data format name.
        /// </summary>
        private static string asn1FormatName = "Asn1NodeDataFormat";

        /// <summary>
        /// Copy Asn1Node data into clipboard as Asn1NodeDataFormat and Text format.
        /// </summary>
        /// <param name="node">Asn1Node</param>
        public static void Copy(Asn1Node node)
        {
            DataFormats.Format asn1Format = DataFormats.GetFormat(asn1FormatName);
			MemoryStream ms = new MemoryStream();
			node.SaveData(ms);
			ms.Position = 0;
			byte[] ndata = new byte[ms.Length];
			ms.Read(ndata, 0, (int)ms.Length);
			ms.Close();
            DataObject aDataObj = new DataObject();
            aDataObj.SetData(asn1FormatName, ndata);
            aDataObj.SetData(
                DataFormats.Text, 
                Asn1Util.FormatString(Asn1Util.ToHexString(ndata), 32, 2));
            Clipboard.SetDataObject(aDataObj, true);
        }

        /// <summary>
        /// Paste clipboard data as an Asn1Node. It try to get data from 
        /// Asn1NodeDataFormat first, then try Text data format.
        /// </summary>
        /// <returns>Asn1Node</returns>
        public static Asn1Node Paste()
        {
            DataFormats.Format asn1Format = DataFormats.GetFormat(asn1FormatName);
            Asn1Node retval = new Asn1Node();
            IDataObject aRetrieveObj = Clipboard.GetDataObject();
            byte[] aData = (byte[]) aRetrieveObj.GetData(asn1FormatName);
            if (aData != null)
            {
                MemoryStream ms = new MemoryStream(aData);
                ms.Position = 0;
                retval.LoadData(ms);
            }
            else
            {
                string dataStr = (string) aRetrieveObj.GetData(DataFormats.Text);
                Asn1Node tmpNode = new Asn1Node();
                if (Asn1Util.IsAsn1EncodedHexStr(dataStr))
                {
                    byte[] data = Asn1Util.HexStrToBytes(dataStr);
                    retval.LoadData(data);
                }
            }
            return retval;
        }

        /// <summary>
        /// Check if there is ASN.1 DER encoded data in the clipboard.
        /// </summary>
        /// <returns>true:Yes; false:No</returns>
        public static bool IsDataReady()
        {
            bool retval = false;
            try
            {
                IDataObject aRetrieveObj = Clipboard.GetDataObject();
                byte[] aData = (byte[]) aRetrieveObj.GetData(asn1FormatName);
                if (aData != null)
                    retval = true;
                else
                {
                    string dataStr = (string) aRetrieveObj.GetData(DataFormats.Text);
                    if (Asn1Util.IsAsn1EncodedHexStr(dataStr))
                        retval = true;
                }
            }
            catch
            {
                retval = false;
            }
            return retval;
        }

	}
}
