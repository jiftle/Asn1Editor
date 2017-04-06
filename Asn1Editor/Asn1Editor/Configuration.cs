using System;
using Microsoft.Win32;

namespace LipingShare.Asn1Editor
{
	/// <summary>
	/// Summary description for Configuration.
	/// </summary>
	public class Configuration
	{
        /// <summary>
        /// Constructor.
        /// </summary>
		public Configuration()
		{
            InitRegPath();
		}

        protected Microsoft.Win32.RegistryKey regKey = null;

        /// <summary>
        /// Configuration settings registry path.
        /// </summary>
        public const string registryPath = "SOFTWARE\\LipingShare\\ASN.1 Editor";

        /// <summary>
        /// Initialize the registry path.
        /// </summary>
        private void InitRegPath()
        {
            try
            {
                regKey = Registry.LocalMachine.OpenSubKey(registryPath, true);
                if (regKey == null)
                {
                    regKey = Registry.LocalMachine.CreateSubKey(registryPath);
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message + ex.StackTrace;
            }
        }

        /// <summary>
        /// Read registry information.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public object ReadRegInfo(string name)
        {
            if (regKey == null) return null;
            object retval = null;
            try
            {
                retval = regKey.GetValue(name);
            }
            catch(Exception ex)
            {
                useRegSettings = false;
                string msg = ex.Message;
                retval = null;
            }
            if (retval == null)
            {
                useRegSettings = false;
            }
            return retval;
        }

        /// <summary>
        /// Write registry information.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public bool WriteRegInfo(string name, object data)
        {
            if (regKey == null) return false;
            try
            {
                regKey.SetValue(name, data);
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return false;
            }
            return true;
        }
    
        public bool useRegSettings = true;

        public int mainEditorLeft = 0;
        public int mainEditorTop = 0;
        public int mainEditorWidth = 640;
        public int mainEditorHeight = 480;

        public int isHexViewerVisible = 0;
        public int hexViewerLeft = 0;
        public int hexViewerTop = 0;
        public int hexViewerWidth = 200;
        public int hexViewerHeight = 480;

        public int textViewerLeft = 0;
        public int textViewerTop = 0;
        public int textViewerWidth = 640;
        public int textViewerHeight = 480;
        public int textLength = 90;

        public int currentScreenWidth = 0;
        public int currentScreenHeight = 0;

        public bool setTextViewSameAsTreeViewScreen = true; // Always use tree view location for now;

        public bool GetData()
        {
            currentScreenWidth         = Convert.ToInt32(ReadRegInfo("currentScreenWidth"));
            currentScreenHeight        = Convert.ToInt32(ReadRegInfo("currentScreenHeight"));
            
            mainEditorLeft          = Convert.ToInt32(ReadRegInfo("mainEditorLeft"));
            mainEditorTop           = Convert.ToInt32(ReadRegInfo("mainEditorTop"));
            mainEditorWidth         = Convert.ToInt32(ReadRegInfo("mainEditorWidth"));
            mainEditorHeight        = Convert.ToInt32(ReadRegInfo("mainEditorHeight"));
                                                                   
            isHexViewerVisible      = Convert.ToInt32(ReadRegInfo("isHexViewerVisible"));
            hexViewerLeft           = Convert.ToInt32(ReadRegInfo("hexViewerLeft"));
            hexViewerTop            = Convert.ToInt32(ReadRegInfo("hexViewerTop"));
            hexViewerWidth          = Convert.ToInt32(ReadRegInfo("hexViewerWidth"));
            hexViewerHeight         = Convert.ToInt32(ReadRegInfo("hexViewerHeight"));
                                                                   
            textViewerLeft          = Convert.ToInt32(ReadRegInfo("textViewerLeft"));
            textViewerTop           = Convert.ToInt32(ReadRegInfo("textViewerTop"));
            textViewerWidth         = Convert.ToInt32(ReadRegInfo("textViewerWidth"));
            textViewerHeight        = Convert.ToInt32(ReadRegInfo("textViewerHeight"));

            textLength        = Convert.ToInt32(ReadRegInfo("textLength"));

            return true;
        }

        public bool SaveData()
        {
            WriteRegInfo("currentScreenWidth"    ,currentScreenWidth   );
            WriteRegInfo("currentScreenHeight"   ,currentScreenHeight  );
            
            WriteRegInfo("mainEditorLeft"    ,mainEditorLeft     );
            WriteRegInfo("mainEditorTop"     ,mainEditorTop      );
            WriteRegInfo("mainEditorWidth"   ,mainEditorWidth    );
            WriteRegInfo("mainEditorHeight"  ,mainEditorHeight   );
                                                                       
            WriteRegInfo("isHexViewerVisible",isHexViewerVisible );
            WriteRegInfo("hexViewerLeft"     ,hexViewerLeft      );
            WriteRegInfo("hexViewerTop"      ,hexViewerTop       );
            WriteRegInfo("hexViewerWidth"    ,hexViewerWidth     );
            WriteRegInfo("hexViewerHeight"   ,hexViewerHeight    );
                                                                       
            WriteRegInfo("textViewerLeft"    ,textViewerLeft     );
            WriteRegInfo("textViewerTop"     ,textViewerTop      );
            WriteRegInfo("textViewerWidth"   ,textViewerWidth    );
            WriteRegInfo("textViewerHeight"  ,textViewerHeight   );
            WriteRegInfo("textLength"  ,textLength   );

            return true;
        }
        
	}
}

