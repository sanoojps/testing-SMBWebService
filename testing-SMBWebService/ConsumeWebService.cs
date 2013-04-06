using System;
using System.Collections.Generic;
using System.Text;

using testing_SMBWebService.smb_WebService_Reference;

namespace testing_SMBWebService
{
    class ConsumeWebService
    {
        ///Instantiate the Webservice
        smb_WebService_Reference.SMBService _SMBService
            = new smb_WebService_Reference.SMBService();
        
        public ConsumeWebService()
        {}

        #region Check_Agent

        /// <summary>
        /// Check_Agent
        /// CheckIfAgentIsPresentInTheDB
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strPassWord"></param>
        /// <returns>
        /// "Yes" - if present
        /// "No"  - if not
        /// "eXception" - if exception occurs
        /// </returns>
        /// <example>
        /// string checkAgent = string.Empty;
        /// ConsumeWebService _conSu = new ConsumeWebService();
        /// checkAgent = _conSu.Check_Agent("saad","SADASDA");
        /// if (checkAgent != "Yes")
        /// System.Diagnostics.Debug.WriteLine("Failed to authenticate");
        /// </example>
        public string Check_Agent(
            string strUserName = "thangappa", 
            string strPassWord = "solve123#")
        {
            string strReturnValue = string.Empty;
            try
            {
                ///Check Agent
                strReturnValue = _SMBService.CheckAgent(strUserName, strPassWord);
            }
            catch (Exception eXception)
            {
                System.Diagnostics.Debug.WriteLine("Check_Agent"
                    + Environment.NewLine
                    + eXception.Message
                        + Environment.NewLine
                        + eXception.StackTrace
                        );

                strReturnValue = "eXception";
            }
            return strReturnValue;
        }

        #endregion


        #region Create_User
        
        /// <summary>
        /// Create_User
        /// </summary>
        /// <param name="strSmbID"></param>
        /// <param name="strBusinessName"></param>
        /// <param name="strEMail"></param>
        /// <param name="strClientId"></param>
        /// <returns>
        /// "Yes" - if successful
        /// "No"  - if not
        /// "eXception" - if exception occurs
        /// </returns>
        /// <example>
        /// </example>
        public string Create_User(
            string strSmbID,
           string strBusinessName,
           string strEMail,
            string strClientId)
        {
            string strReturnValue = string.Empty;
            try
            {
                //create User
               strReturnValue = 
                   _SMBService.CreateUser(strSmbID, 
                   strBusinessName, 
                   strEMail, 
                   strClientId);
            }
            catch (Exception eXception)
            {
                System.Diagnostics.Debug.WriteLine("Create_User"
                    +Environment.NewLine
                    +eXception.Message
                        + Environment.NewLine
                        + eXception.StackTrace
                        );

                strReturnValue = "eXception";
            }
            return strReturnValue;
        }
        
        #endregion


        #region Get_Client
       
        /// <summary>
        /// Get_Client
        /// </summary>
        /// <param name="strClientName"></param>
        /// <param name="strID"></param>
        /// <param name="strProgramName"></param>
        /// <param name="strRecordStatus"></param>
        /// <param name="strProgramImageURL"></param>
        /// <returns>
        /// XML Fragment as string
        /// -Sample XML Fragment
        /// <ClientTable>
        /// <ClientList>
        /// <ID>1</ID> 1-Mcafee 3-Staples
        /// <ProgramName>McAfee</ProgramName>
        /// <RecordStatus>ACTIVE</RecordStatus>
        /// <ProgramImageURL>http://mypremiumsupport.com/smb/mcafee/images/Mcafee_LOGO.png</ProgramImageURL>
        /// </ClientList>
        /// </ClientTable>
        /// </returns>
        /// <example>
        ///  string getClient = string.Empty;
        ///  string ID = string.Empty;
        ///  string ProgramName = string.Empty;
        ///  string RecordStatus = string.Empty;
        ///  string ProgramImageURL = string.Empty;
        ///  getClient = _conSu.Get_Client("Staples", 
        ///  out ID, 
        ///  out ProgramName,
        ///  out RecordStatus,
        ///  out ProgramImageURL
        ///  );
        ///  System.Diagnostics.Debug.WriteLine(getClient);
        ///  System.Diagnostics.Debug.WriteLine(
        ///  "ID: "+  ID + "\n"
        ///  + "ProgramName: " + ProgramName + "\n"
        ///  + "RecordStatus: " + RecordStatus + "\n"
        ///  + "ProgramImageURL: " + ProgramImageURL + "\n"
        ///  );
        /// </example>
        public string Get_Client(string strClientName,
            out string strID,
            out string strProgramName,
            out string strRecordStatus,
            out string strProgramImageURL
            )
        {
            {
                string strReturnValue = string.Empty;
                strID = string.Empty;
                strProgramName = string.Empty;
                strRecordStatus = string.Empty;
                strProgramImageURL = string.Empty;
                
                try
                {
                    strReturnValue = _SMBService.GetClient(strClientName);

                    ///XML Processing of the returnValue

                    ///Create The XmlDocument
                    System.Xml.XmlDocument _xmlDoc =
               new System.Xml.XmlDocument();
                    ///Set to preserve White Space
                    _xmlDoc.PreserveWhitespace = true;

                    ///load THe string in XML Format
                    _xmlDoc.LoadXml(strReturnValue);

                    ///create a list 
                    System.Xml.XmlNodeList xnodeList =
                        _xmlDoc.SelectNodes("/ClientTable/ClientList");

                    ///Check if the list is empty
                    ///List will be empty if the result of getClient is 
                    ///<ClientTable />
                    if (!xnodeList.Count.Equals(0))
                    {
                        ///iterate through the list and get the text in XML
                        foreach (System.Xml.XmlNode xnode in xnodeList)
                        {
                            strID = xnode["ID"].InnerText;
                            strProgramName = xnode["ProgramName"].InnerText;
                            strRecordStatus = xnode["RecordStatus"].InnerText;
                            strProgramImageURL = xnode["ProgramImageURL"].InnerText;

                            #region unNecessary
                            if (!string.IsNullOrEmpty(strID)
                                || !string.IsNullOrEmpty(strProgramName)
                                || !string.IsNullOrEmpty(strRecordStatus)
                                || !string.IsNullOrEmpty(strProgramImageURL))
                            {
                                System.Diagnostics.Debug.WriteLine(
                                    "ID: "+  strID + "\n"
                                    + "ProgramName: " + strProgramName + "\n"
                                    + "RecordStatus: " + strRecordStatus + "\n"
                                    + "ProgramImageURL: " + strProgramImageURL + "\n"
                                );
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine(
                                     "ID: " + strID.Length + "\n"
                                     + "ProgramName: " + strProgramName.Length + "\n"
                                     + "RecordStatus: " + strRecordStatus.Length + "\n"
                                     + "ProgramImageURL: " + strProgramImageURL.Length + "\n"
                                 );
                            }
                            #endregion
                        
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(xnodeList.Count);
                    }
                           
                }
                catch (Exception eXception)
                {
                    System.Diagnostics.Debug.WriteLine("Get_Client" 
                        + Environment.NewLine 
                        + eXception.Message
                            + Environment.NewLine
                            + eXception.StackTrace
                            );

                    strReturnValue = "eXception";
                }
                
                return strReturnValue;
            }
        }
        #endregion


        #region Get_System_Info

        /// <summary>
        /// Get_System_Info
        /// </summary>
        /// <param name="strMacID"></param>
        /// <param name="strMode"></param>
        /// <returns></returns>
        public string Get_System_Info(string strMacID,string strMode)
        {
            string strReturnValue = string.Empty;
            try
            {
                ///GetSystemInfo
                strReturnValue = _SMBService.GetSystemInfo(strMacID, strMode);
            }
            catch (Exception eXception)
            {
                System.Diagnostics.Debug.WriteLine("Get_System_Info"
                    + Environment.NewLine
                    + eXception.Message
                        + Environment.NewLine
                        + eXception.StackTrace
                        );

                strReturnValue = "eXception";
            }
            return strReturnValue;
        }


        #endregion

       
        #region Insert_SMBStatus_Log

        /// <summary>
        /// Insert_SMBStatus_Log
        /// </summary>
        /// <param name="strIssueDate"></param>
        /// <param name="strIssueTime"></param>
        /// <param name="strPCName"></param>
        /// <param name="strUserName"></param>
        /// <param name="strMacID"></param>
        /// <param name="strIPAddress"></param>
        /// <param name="strEventName"></param>
        /// <param name="strFunctionRunStatus"></param>
        /// <param name="strIssueStatus"></param>
        /// <returns></returns>
        public string Insert_SMBStatus_Log(
            string strIssueDate,
            string strIssueTime,
            string strPCName,
            string strUserName,
            string strMacID,
            string strIPAddress,
            string strEventName,
            string strFunctionRunStatus,
            string strIssueStatus
            )
        {
            string strReturnValue = string.Empty;
            try
            {
                ///Insert_SMBStatus_Log
                strReturnValue =
                    _SMBService.InsertSMBStatusLog(
                    strIssueDate,
                    strIssueTime,
                    strPCName,
                    strUserName,
                    strMacID,
                    strIPAddress,
                    strEventName,
                    strFunctionRunStatus,
                    strIssueStatus);
            }
            catch (Exception eXception)
            {
                System.Diagnostics.Debug.WriteLine("Insert_SMBStatus_Log"
                    + Environment.NewLine
                    + eXception.Message
                        + Environment.NewLine
                        + eXception.StackTrace
                        );

                strReturnValue = "eXception";
            }
            return strReturnValue;
        }

        #endregion


        #region Insert_System_Info

        public string Insert_System_Info(
           string strUserName,
string strUserAccessRights,
string strMacID,
string strIPAddress,
string strProcessorAndClockSpeed,
string strRAM,
string strDefaultBrowser,
string strSystemBootupTime,
string strDefaultPrinter,
string strOSArchitecture,
string strVideoCard,
string strSoundCard,
string strDXVersion,
string strSystemPartition,
string strNumberOfPartitions,
string strSystemManufacturer,
string strAgentID,
string strPCName,
string strOS,
string strAppVersion
            )
        {
            string strReturnValue = string.Empty;
            try
            {
                ///Insert_System_Info
                strReturnValue =
                    _SMBService.InsertSystemInfo(
                    strUserName,
strUserAccessRights,
strMacID,
strIPAddress,
strProcessorAndClockSpeed,
strRAM,
strDefaultBrowser,
strSystemBootupTime,
strDefaultPrinter,
strOSArchitecture,
strVideoCard,
strSoundCard,
strDXVersion,
strSystemPartition,
strNumberOfPartitions,
strSystemManufacturer,
strAgentID,
strPCName,
strOS,
strAppVersion
                    );
            }
            catch (Exception eXception)
            {
                System.Diagnostics.Debug.WriteLine("Insert_System_Info"
                    + Environment.NewLine
                    + eXception.Message
                        + Environment.NewLine
                        + eXception.StackTrace
                        );

                strReturnValue = "eXception";
            }
            return strReturnValue;
        }


        #endregion


        #region Verify_MacID

        /// <summary>
        /// Verify_MacID
        /// </summary>
        /// <param name="strMacID"></param>
        /// <returns>
        /// 0 - if absent
        /// 1 - if present
        /// </returns>
        public string Verify_MacID(
            string strMacID)
        {
            string strReturnValue = string.Empty;
            try
            {
                ///Verify_MacID
                strReturnValue =
                    _SMBService.VerifyMacID(strMacID);
            }
            catch (Exception eXception)
            {
                System.Diagnostics.Debug.WriteLine("Verify_MacID"
                    + Environment.NewLine
                    + eXception.Message
                        + Environment.NewLine
                        + eXception.StackTrace
                        );

                strReturnValue = "eXception";
            }
            return strReturnValue;
        }


        #endregion



    }
}
