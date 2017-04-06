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

namespace LipingShare.LCLib.Asn1Processor
{
	/// <summary>
	/// Describes Asn1Processor version and copyright related information.
	/// <code>
	/// Update Info
	/// ============
    /// 
    /// 03/17/2007: (V2007.03.17 - 1.0.18)
    /// 1. Build by VS2005 
    /// 2. Screen positoin changes for supporting dual screens.
    /// 
	/// 07/03/2005: (V2005.07.03 - 1.0.17)
	/// 1. A bug is fixed in the node text viewer to let the saved parameters take effect.
	/// 
	/// 06/28/2005: (V2005.06.28 - 1.0.16)
	/// 1. OID table uniqueness checking and sorting when the OID text file is first used.
    /// 2. Removed unnecessary references from Asn1Parser and Asn1Node class;
    /// for example "using System.Windows.Forms;"
    /// for example the last editor winddow position, size, hex viewer state, and text viewer state.
    /// 3. Added the application friendly name in the registry to have better "open with" support.
    /// 4. Added Asn1Editor.Configuration class to save some screen related information.
    /// 5. Zero length bit-string decoding bug fix. -- Thanks to Gustaf Björklund for fixing the bug.
	/// 
    /// 04/04/2005: (V2005.04.02 - 1.0.12)
    /// 1. Bug fix to show the opening file name.
    /// Thanks to Tony Morris for the bug report.
    ///
    /// 04/02/2005: (V2005.04.02 - 1.0.11)
	/// 1. Supports one command line parameter to open the editing file.
	/// 
	///	03/27/2005: (V2005.03.27 - 1.0.10)
	///	1. Fixed the OID encoding leading zero(0x80) bug.
	///	Thanks for the bug report. Ref URL:
	///	http://www.codeproject.com/csharp/Asn1Editor.asp?msg=1068457#xx1068457xx
	///	
	///	03/16/2005:
	///	1. Extended the node content text editor content max length to unimited.
	///	2. Display GENERALIZED_TIME correctly.
	///	3. Support RELATIVE-OID.
	///	4. Support customized node text length.
	///	5. Resize the hex viewer together with the main window.
	///	6. Extended the OID table to include the BIO OIDs.
	///	
    ///	09/23/2004:
    ///	Bug Fix for general string decoding.
    ///	
    ///	11/05/2003:
    ///	Thanks to Xavier Monés for the bug report and suggestions.
    ///	Some changes are made to encod/decode UTF8 and BMP string correctly.
    ///	
    ///	10/10/2003:
    ///	Thanks to Joe Hartford for the bug report and suggestions.
    ///	1. Asn1Node.Data always return the data that not include it's tag 
    ///	and length.
    ///	2. Asn1Node.ParseEncapsulatedData property is added to control parsing 
    ///	encapsulated data.
    ///	3. Asn1Parser.ParseEncapsulatedData is added to control encapsulated
    ///	data parsing from the root.
    ///	4. ASN.1 Editor support "Parse encapsulated data" at node level.<br></br>
    ///	5. Asn1Node.GetRawData() is added to return the same data as SaveData() 
    ///	do, but it return byte[] instead stream.
    ///	
    ///	10/02/2003:
    ///	Thanks to Joe Hartford for the bug report and suggestions.
    ///	Bug fix for Asn1Util.DerLengthDecode function. It returns -2 
    ///	instead throwing exception when meet indefinite length. Actually,
    ///	this function should not throw exception because it will stop the
    ///	parser to do further decoding.
    ///	
    ///	09/27/2003:
    ///	Bug fix for Asn1Node.ListDecode function. The child node should 
    ///	be added after loading the child data.
    ///	
    /// 09/25/2003: 
    ///	Added functions:
    ///	public static long Asn1Node.GetDescendantNodeCount(Asn1Node node)
    /// void Asn1Parser.LoadPemData(string fileName).
    /// 
    ///	</code>	
	/// </summary>
	public class VersionInfo
	{
        private static string versionStr = "V2007.03.17 - 1.0.18";     
        private static string copyrightStr = "Copyright © 2003,2004,2005,2007 Liping Dai. All rights reserved.";
        private static string contactInfo = "LipingShare@yahoo.com";
        private static string updateUrl = "http://www.lipingshare.com/Asn1Editor";
        private static string author = "Liping Dai";
        private static string releaseDate = "March 17, 2007";

        /// <summary>
        /// Get version string.
        /// </summary>
        public static string VersionStr
        {
            get
            {
                return versionStr;
            }
        }

        /// <summary>
        /// Get copyright string.
        /// 
		/// <code>
		/// Copyright (c) 2003,2004,2005 Liping Dai. All rights reserved.
		/// Web: www.lipingshare.com
		/// Email: lipingshare@yahoo.com
		///                                                                               
		/// Copyright and Permission Details:                                             
		/// =================================                                             
		/// Permission is hereby granted, free of charge, to any person obtaining a copy  
		/// of this software and associated documentation files (the "Software"), to deal 
		/// in the Software without restriction, including without limitation the rights  
		/// to use, copy, modify, merge, publish, distribute, and/or sell copies of the   
		/// Software, subject to the following conditions:                                
		///                                                                               
		/// 1. Redistributions of source code must retain the above copyright notice, this
		/// list of conditions and the following disclaimer.                              
		///                                                                               
		/// 2. Redistributions in binary form must reproduce the above copyright notice,  
		/// this list of conditions and the following disclaimer in the documentation     
		/// and/or other materials provided with the distribution.                        
		///                                                                               
		/// THE SOFTWARE PRODUCT IS PROVIDED “AS IS” WITHOUT WARRANTY OF ANY KIND,        
		/// EITHER EXPRESS OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED         
		/// WARRANTIES OF TITLE, NON-INFRINGEMENT, MERCHANTABILITY AND FITNESS FOR        
		/// A PARTICULAR PURPOSE.                                                         
		/// </code>
		/// 
        /// </summary>
        public static string CopyrightStr
        {
            get
            {
                return copyrightStr;
            }
        }

        /// <summary>
        /// Get contact information.
        /// </summary>
        public static string ContactInfo
        {
            get
            {
                return contactInfo;
            }
        }

        /// <summary>
        /// Get update url.
        /// </summary>
        public static string UpdateUrl
        {
            get
            {
                return updateUrl;
            }
        }

        /// <summary>
        /// Get author.
        /// </summary>
        public static string Author
        {
            get
            {
                return author;
            }
        }

        /// <summary>
        /// Get release date.
        /// </summary>
        public static string ReleaseDate
        {
            get
            {
                return releaseDate;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public VersionInfo()
		{
		}
	}
}
