﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.ISyncDBService")]
    public interface ISyncDBService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISyncDBService/GetData", ReplyAction="http://tempuri.org/ISyncDBService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISyncDBService/GetData", ReplyAction="http://tempuri.org/ISyncDBService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISyncDBService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ISyncDBService/GetDataUsingDataContractResponse")]
        SyncDataBasesWCF.CompositeType GetDataUsingDataContract(SyncDataBasesWCF.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISyncDBService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ISyncDBService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<SyncDataBasesWCF.CompositeType> GetDataUsingDataContractAsync(SyncDataBasesWCF.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISyncDBService/Sync", ReplyAction="http://tempuri.org/ISyncDBService/SyncResponse")]
        bool Sync(string clientConnection);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISyncDBService/Sync", ReplyAction="http://tempuri.org/ISyncDBService/SyncResponse")]
        System.Threading.Tasks.Task<bool> SyncAsync(string clientConnection);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISyncDBServiceChannel : ConsoleApplication1.ServiceReference2.ISyncDBService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SyncDBServiceClient : System.ServiceModel.ClientBase<ConsoleApplication1.ServiceReference2.ISyncDBService>, ConsoleApplication1.ServiceReference2.ISyncDBService {
        
        public SyncDBServiceClient() {
        }
        
        public SyncDBServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SyncDBServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SyncDBServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SyncDBServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public SyncDataBasesWCF.CompositeType GetDataUsingDataContract(SyncDataBasesWCF.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<SyncDataBasesWCF.CompositeType> GetDataUsingDataContractAsync(SyncDataBasesWCF.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public bool Sync(string clientConnection) {
            return base.Channel.Sync(clientConnection);
        }
        
        public System.Threading.Tasks.Task<bool> SyncAsync(string clientConnection) {
            return base.Channel.SyncAsync(clientConnection);
        }
    }
}
