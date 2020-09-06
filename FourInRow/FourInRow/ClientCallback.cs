using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourInRow.ServiceReference;
using System.ServiceModel;

namespace FourInRow
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ClientCallback  : IFourInRowServiceCallback
    {
     
        public delegate void NewStepInTheGameDelegate(double loc);
        public event NewStepInTheGameDelegate newStep;
        public void NewStep(double loc)
        {
            newStep(loc);
        }

        public delegate bool DisplayGameRequestDelegate(string fromClient);
        public event DisplayGameRequestDelegate displayChallenge;
        public bool SendChallengeToClient(string fromClient)
        {
            return displayChallenge(fromClient);
        }

        public delegate void UpdateInfoListDelegate(string info);
        public event UpdateInfoListDelegate updateInfo;
        public void UpdateProfileInfo(string info)
        {
            updateInfo(info);
        }

        public delegate void UpdateListDelegate(string[] users);
        public event UpdateListDelegate updateUsers;
        public void UpdateClientsList(string[] users)
        {
            updateUsers?.Invoke(users);
        }

        public delegate void SearchDelegate(string[] users);
        public event SearchDelegate srch;
        public void SearchC(string[] users)
        {
            srch(users);
        }

    }
}
