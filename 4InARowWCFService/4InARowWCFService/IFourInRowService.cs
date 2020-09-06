using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _4InARowWCFService
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IFourInRowCallback))]
    public interface IFourInRowService
    {
        [OperationContract]
        bool AddCustomer(string FName, string LName, string city, string username, string pssword);
        [OperationContract]
        bool LogIn(string username, string pssword);
        [OperationContract]
        void LogOut(string userName);
        [OperationContract]
        void ShowInfo(string from,string to);
        [OperationContract]
        bool CheckUserName(string userName);
        [OperationContract]
        bool AddStepToTheBoard(double colNum, string fromClient);
        [OperationContract]
        bool SendChallenge(string fromClient, string toClient);
        [OperationContract]
        void UpdateWin(string userName);
        [OperationContract]
        void UpdateLose(string userName);
        [OperationContract]
        void Search(string op,string usr);
        // TODO: Add your service operations here
    }

   
}
