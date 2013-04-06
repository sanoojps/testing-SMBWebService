using System;
using System.Collections.Generic;

using System.Text;
using System.Threading;

namespace testing_SMBWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsumeWebService _conSu = new ConsumeWebService();
            
            //Check_Agent
            //string checkAgent = string.Empty;
            //checkAgent = _conSu.Check_Agent("saad","SADASDA");
            //if (checkAgent != "Yes")
            //    System.Diagnostics.Debug.WriteLine("Failed to authenticate");

            //Get_Client
            string getClient = string.Empty;
            string ID = string.Empty;
            string ProgramName = string.Empty;
            string RecordStatus = string.Empty;
            string ProgramImageURL = string.Empty;
            
            getClient = _conSu.Get_Client("Staples", 
                out ID, 
                out ProgramName,
                out RecordStatus,
                out ProgramImageURL
                );

            System.Diagnostics.Debug.WriteLine(getClient);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Done");

            //#region getClient

            ////XML PRocessing Of getClient

            //System.Xml.XmlDocument _xmlDoc =
            //    new System.Xml.XmlDocument();
            //_xmlDoc.PreserveWhitespace = true;

            //_xmlDoc.LoadXml(getClient);

            //System.Xml.XmlNodeList xnodeList =
            //    _xmlDoc.SelectNodes("/ClientTable/ClientList");

    
            //if (!xnodeList.Count.Equals(0))
            //{
            //    foreach (System.Xml.XmlNode xnode in xnodeList)
            //    {
            //        string _ID = string.Empty;
            //        string _ProgramName = string.Empty;
            //        string _RecordStatus = string.Empty;
            //        string _ProgramImageURL = string.Empty;


            //        _ID = xnode["ID"].InnerText;
            //        _ProgramName = xnode["ProgramName"].InnerText;
            //        _RecordStatus = xnode["RecordStatus"].InnerText;
            //        _ProgramImageURL = xnode["ProgramImageURL"].InnerText;

            //        if (!string.IsNullOrEmpty(_ID) 
            //            || !string.IsNullOrEmpty(_ProgramName) 
            //            || !string.IsNullOrEmpty(_RecordStatus)
            //            || !string.IsNullOrEmpty(_ProgramImageURL))
            //        {
            //            //Console.WriteLine(
            //            //    "ID: {0}\nProgramName: {1}\nRecordStatus: {2}\nProgramImageURL: {3}\n",
            //            //    _ID,
            //            //    _ProgramName,
            //            //    _RecordStatus,
            //            //    _ProgramImageURL
            //            //);
            //        }
            //        else
            //        {
            //            //Console.WriteLine(
            //            //    "ID: {0}\nProgramName: {1}\nRecordStatus: {2}\nProgramImageURL: {3}\n",
            //            //    _ID.Length,
            //            //    _ProgramName.Length,
            //            //    _RecordStatus.Length,
            //            //    _ProgramImageURL.Length
            //            //);
            //        }
            //    }
            //}
            //else
            //{
            //    //Console.WriteLine(xnodeList.Count);
            //}


            ////string _ID = xnodeList.Item(0).InnerText;
            //////string ProgramName = xnodeList.Item(1).InnerText;
            //////string RecordStatus = xnodeList.Item(2).InnerText;
            //////string ProgramImageURL = xnodeList.Item(3).InnerText;
            ////Console.WriteLine("ID: {0}\n"
            //////ProgramName: {1}\nRecordStatus: {2}\nProgramImageURL: {3}\n"
            ////,
            ////    _ID
            ////    //,
            ////    //ProgramName,
            ////    //RecordStatus,
            ////    //ProgramImageURL
            ////);


            //    //Console.WriteLine(
            ////    _xmlDoc.DocumentElement.OuterXml);

            //#endregion

            
                Console.WriteLine(
                    "ID: {0}\nProgramName: {1}\nRecordStatus: {2}\nProgramImageURL: {3}\n",
                    ID,
                    ProgramName,
                    RecordStatus,
                    ProgramImageURL
                );
                

            //verifyMacID

                Console.WriteLine(_conSu.Verify_MacID("00-50-56-C0-00-08"));


            Console.ReadLine();
        }
    }
}
