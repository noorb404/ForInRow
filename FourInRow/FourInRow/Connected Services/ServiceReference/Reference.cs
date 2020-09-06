﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FourInRow.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IFourInRowService", CallbackContract=typeof(FourInRow.ServiceReference.IFourInRowServiceCallback))]
    public interface IFourInRowService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/AddCustomer", ReplyAction="http://tempuri.org/IFourInRowService/AddCustomerResponse")]
        bool AddCustomer(string FName, string LName, string city, string username, string pssword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/AddCustomer", ReplyAction="http://tempuri.org/IFourInRowService/AddCustomerResponse")]
        System.Threading.Tasks.Task<bool> AddCustomerAsync(string FName, string LName, string city, string username, string pssword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/LogIn", ReplyAction="http://tempuri.org/IFourInRowService/LogInResponse")]
        bool LogIn(string username, string pssword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/LogIn", ReplyAction="http://tempuri.org/IFourInRowService/LogInResponse")]
        System.Threading.Tasks.Task<bool> LogInAsync(string username, string pssword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/LogOut", ReplyAction="http://tempuri.org/IFourInRowService/LogOutResponse")]
        void LogOut(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/LogOut", ReplyAction="http://tempuri.org/IFourInRowService/LogOutResponse")]
        System.Threading.Tasks.Task LogOutAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/ShowInfo", ReplyAction="http://tempuri.org/IFourInRowService/ShowInfoResponse")]
        void ShowInfo(string from, string to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/ShowInfo", ReplyAction="http://tempuri.org/IFourInRowService/ShowInfoResponse")]
        System.Threading.Tasks.Task ShowInfoAsync(string from, string to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/CheckUserName", ReplyAction="http://tempuri.org/IFourInRowService/CheckUserNameResponse")]
        bool CheckUserName(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/CheckUserName", ReplyAction="http://tempuri.org/IFourInRowService/CheckUserNameResponse")]
        System.Threading.Tasks.Task<bool> CheckUserNameAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/AddStepToTheBoard", ReplyAction="http://tempuri.org/IFourInRowService/AddStepToTheBoardResponse")]
        bool AddStepToTheBoard(double colNum, string fromClient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/AddStepToTheBoard", ReplyAction="http://tempuri.org/IFourInRowService/AddStepToTheBoardResponse")]
        System.Threading.Tasks.Task<bool> AddStepToTheBoardAsync(double colNum, string fromClient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/SendChallenge", ReplyAction="http://tempuri.org/IFourInRowService/SendChallengeResponse")]
        bool SendChallenge(string fromClient, string toClient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/SendChallenge", ReplyAction="http://tempuri.org/IFourInRowService/SendChallengeResponse")]
        System.Threading.Tasks.Task<bool> SendChallengeAsync(string fromClient, string toClient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/UpdateWin", ReplyAction="http://tempuri.org/IFourInRowService/UpdateWinResponse")]
        void UpdateWin(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/UpdateWin", ReplyAction="http://tempuri.org/IFourInRowService/UpdateWinResponse")]
        System.Threading.Tasks.Task UpdateWinAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/UpdateLose", ReplyAction="http://tempuri.org/IFourInRowService/UpdateLoseResponse")]
        void UpdateLose(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/UpdateLose", ReplyAction="http://tempuri.org/IFourInRowService/UpdateLoseResponse")]
        System.Threading.Tasks.Task UpdateLoseAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/Search", ReplyAction="http://tempuri.org/IFourInRowService/SearchResponse")]
        void Search(string op, string usr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/Search", ReplyAction="http://tempuri.org/IFourInRowService/SearchResponse")]
        System.Threading.Tasks.Task SearchAsync(string op, string usr);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFourInRowServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IFourInRowService/UpdateClientsList")]
        void UpdateClientsList(string[] users);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFourInRowService/SendChallengeToClient", ReplyAction="http://tempuri.org/IFourInRowService/SendChallengeToClientResponse")]
        bool SendChallengeToClient(string fromClient);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IFourInRowService/NewStep")]
        void NewStep(double colNum);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IFourInRowService/UpdateProfileInfo")]
        void UpdateProfileInfo(string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IFourInRowService/SearchC")]
        void SearchC(string[] op);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFourInRowServiceChannel : FourInRow.ServiceReference.IFourInRowService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FourInRowServiceClient : System.ServiceModel.DuplexClientBase<FourInRow.ServiceReference.IFourInRowService>, FourInRow.ServiceReference.IFourInRowService {
        
        public FourInRowServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public FourInRowServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public FourInRowServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public FourInRowServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public FourInRowServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public bool AddCustomer(string FName, string LName, string city, string username, string pssword) {
            return base.Channel.AddCustomer(FName, LName, city, username, pssword);
        }
        
        public System.Threading.Tasks.Task<bool> AddCustomerAsync(string FName, string LName, string city, string username, string pssword) {
            return base.Channel.AddCustomerAsync(FName, LName, city, username, pssword);
        }
        
        public bool LogIn(string username, string pssword) {
            return base.Channel.LogIn(username, pssword);
        }
        
        public System.Threading.Tasks.Task<bool> LogInAsync(string username, string pssword) {
            return base.Channel.LogInAsync(username, pssword);
        }
        
        public void LogOut(string userName) {
            base.Channel.LogOut(userName);
        }
        
        public System.Threading.Tasks.Task LogOutAsync(string userName) {
            return base.Channel.LogOutAsync(userName);
        }
        
        public void ShowInfo(string from, string to) {
            base.Channel.ShowInfo(from, to);
        }
        
        public System.Threading.Tasks.Task ShowInfoAsync(string from, string to) {
            return base.Channel.ShowInfoAsync(from, to);
        }
        
        public bool CheckUserName(string userName) {
            return base.Channel.CheckUserName(userName);
        }
        
        public System.Threading.Tasks.Task<bool> CheckUserNameAsync(string userName) {
            return base.Channel.CheckUserNameAsync(userName);
        }
        
        public bool AddStepToTheBoard(double colNum, string fromClient) {
            return base.Channel.AddStepToTheBoard(colNum, fromClient);
        }
        
        public System.Threading.Tasks.Task<bool> AddStepToTheBoardAsync(double colNum, string fromClient) {
            return base.Channel.AddStepToTheBoardAsync(colNum, fromClient);
        }
        
        public bool SendChallenge(string fromClient, string toClient) {
            return base.Channel.SendChallenge(fromClient, toClient);
        }
        
        public System.Threading.Tasks.Task<bool> SendChallengeAsync(string fromClient, string toClient) {
            return base.Channel.SendChallengeAsync(fromClient, toClient);
        }
        
        public void UpdateWin(string userName) {
            base.Channel.UpdateWin(userName);
        }
        
        public System.Threading.Tasks.Task UpdateWinAsync(string userName) {
            return base.Channel.UpdateWinAsync(userName);
        }
        
        public void UpdateLose(string userName) {
            base.Channel.UpdateLose(userName);
        }
        
        public System.Threading.Tasks.Task UpdateLoseAsync(string userName) {
            return base.Channel.UpdateLoseAsync(userName);
        }
        
        public void Search(string op, string usr) {
            base.Channel.Search(op, usr);
        }
        
        public System.Threading.Tasks.Task SearchAsync(string op, string usr) {
            return base.Channel.SearchAsync(op, usr);
        }
    }
}
