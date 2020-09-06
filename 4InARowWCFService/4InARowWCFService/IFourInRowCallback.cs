using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;

namespace _4InARowWCFService
{
    
    public interface IFourInRowCallback
    {
        

        [OperationContract(IsOneWay = true)]
        void UpdateClientsList(IEnumerable<string> users);

        [OperationContract(IsOneWay = false)]
        bool SendChallengeToClient(string fromClient);

        [OperationContract(IsOneWay = true)]
        void NewStep(double colNum);

        [OperationContract(IsOneWay = true)]
        void UpdateProfileInfo(string username);

        [OperationContract(IsOneWay = true)]
        void SearchC(IEnumerable<string> op);

    }
}
