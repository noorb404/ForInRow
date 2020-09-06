using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace _4InARowWCFService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
       ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class FourInRowService : IFourInRowService
    {
        private SortedDictionary<string, IFourInRowCallback> clients;
        private SortedDictionary<string, string> OnlineDous;
        static Four_In_Row_DBEntities dc = new Four_In_Row_DBEntities();

        public FourInRowService()
        {
            clients = new SortedDictionary<string, IFourInRowCallback>();
            OnlineDous = new SortedDictionary<string, string>();
        }

        public bool CheckUserName(string userName)
        {
            var s = (from u in dc.Customers
                     where u.UserName == userName
                     select u).FirstOrDefault();
            if (s == null) return false;
            return true;

        }
        public bool AddCustomer(string FName, string LName, string city, string username, string pssword)
        {
            if (CheckUserName(username))
                return false;

            Customer newCostumer = new Customer()
            {
                FirstName = FName,
                LastName = LName,
                City = city,
                UserName = username,
                Password = pssword,
                IsOnline = 0,
                IsPlaying = 0,
                NumOfgames = 0,
                NumOfWinning = 0,
                NumOfLose = 0
            };
            dc.Customers.Add(newCostumer);
            dc.SaveChanges();
            return true;
        }
        public bool LogIn(string username, string pssword)
        {
            var s = (from u in dc.Customers
                     where u.UserName == username &&
                            u.Password == pssword
                     select u).FirstOrDefault<Customer>();
            if (s == null)
                return false;
            IFourInRowCallback callback =
           OperationContext.Current.GetCallbackChannel<IFourInRowCallback>();
            clients.Add(s.FirstName, callback);
            s.IsOnline = 1;
            Thread update = new Thread(updateClients);
            update.Start();
            return true;

        }
        public void Search(string op,string usr)
        {
            if (op.Equals("USR"))
            {
                List<string> c = (from u in dc.Customers
                         orderby u.UserName
                         select u.UserName).ToList();
                clients[usr].SearchC(c);
            }
            else if(op.Equals("WIN"))
            {
                var c = (from u in dc.Customers
                         orderby u.NumOfWinning
                         select u.NumOfWinning + u.UserName).ToList();
                clients[usr].SearchC(c);

            }
            else if(op.Equals("LOSE"))
            {
                var c = (from u in dc.Customers
                         orderby u.NumOfLose
                         select u.NumOfLose + u.UserName).ToList();
                clients[usr].SearchC(c);

            }
            else if(op.Equals("GAME"))
            {
                var c = (from u in dc.Customers
                         orderby u.NumOfgames
                         select u.NumOfgames + u.UserName).ToList();
                clients[usr].SearchC(c);
            }
        }
        public void UpdateWin(string userName)
        {
            if (dc.Database.Connection.State == System.Data.ConnectionState.Closed)
                dc.Database.Connection.Open();
            var s = (from u in dc.Customers
                     where u.UserName == userName
                     select u).FirstOrDefault<Customer>();
            s.NumOfWinning++;
            s.NumOfgames++;
            dc.Entry(s).State = System.Data.Entity.EntityState.Modified;
            dc.SaveChanges();
        }
        public void UpdateLose(string userName)
        {

            var s = (from u in dc.Customers
                     where u.UserName == userName
                     select u).FirstOrDefault<Customer>();
            s.NumOfLose++;
            s.NumOfgames++;
            dc.Entry(s).State = System.Data.Entity.EntityState.Modified;
            dc.SaveChanges();
        }
        public bool AddStepToTheBoard(double loc, string fromClient)
        {
            Thread t2 = new Thread(() => clients[OnlineDous[fromClient]].NewStep(loc));
            t2.Start();
            return false;
        }
        public bool SendChallenge(string fromClient, string toClient)
        {
            bool answer = false;
            int flag = 0;
            if (clients.ContainsKey(toClient))
            {
                answer = clients[toClient].SendChallengeToClient(fromClient);
            }

            if (answer == true)
            {
                foreach (KeyValuePair<string, string> o in OnlineDous)
                {
                    if (o.Key.Equals(fromClient) && o.Value.Equals(toClient))
                        flag = 1;
                }
                if (flag == 0)
                {
                    OnlineDous.Add(fromClient, toClient);
                    OnlineDous.Add(toClient, fromClient);
                }
            }  
            return answer;
        }
        private void updateClients() {
            foreach (var c in clients.Values)
                c.UpdateClientsList(clients.Keys);
        }
        public void LogOut(string userName)
        {
            clients.Remove(userName);
            Thread updateThread = new Thread(updateClients);
            updateThread.Start();
        }
        public void ShowInfo(string fromclient,string toclient )
        {
            Customer cus = (from c in dc.Customers
                             where c.UserName == toclient
                             select c).FirstOrDefault<Customer>();

            double rate;
            if (cus.NumOfLose != 0)
            {
                rate = ((double)cus.NumOfWinning / (double)cus.NumOfLose);
                int temp = (int)(rate * 100);
                rate = (double)temp / 100.0;
            }
            else
                rate = cus.NumOfWinning;
            string s = "User name: " + cus.UserName + "\n" + "Games: " + cus.NumOfgames + "\n"
                       + "Wins: " + cus.NumOfWinning + "\n" + "Loses: " + cus.NumOfLose + "\n" + "Rate: " +
                       rate;
                Thread t2 = new Thread(() => clients[fromclient].UpdateProfileInfo(s));
                t2.Start();
       
          
            return;
        }
    }
}
