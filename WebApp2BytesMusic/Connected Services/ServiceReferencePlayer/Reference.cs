﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp2BytesMusic.ServiceReferencePlayer {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferencePlayer.PlayerSoap")]
    public interface PlayerSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Save", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Save(int idArtist, int idSong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Save", ReplyAction="*")]
        System.Threading.Tasks.Task<int> SaveAsync(int idArtist, int idSong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CheckExist", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int CheckExist(int idArtist, int idSong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CheckExist", ReplyAction="*")]
        System.Threading.Tasks.Task<int> CheckExistAsync(int idArtist, int idSong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable Read(int idArtist);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> ReadAsync(int idArtist);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteByIdSong", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int DeleteByIdSong(int idSong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteByIdSong", ReplyAction="*")]
        System.Threading.Tasks.Task<int> DeleteByIdSongAsync(int idSong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int idArtist, int idSong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        System.Threading.Tasks.Task<int> DeleteAsync(int idArtist, int idSong);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PlayerSoapChannel : WebApp2BytesMusic.ServiceReferencePlayer.PlayerSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PlayerSoapClient : System.ServiceModel.ClientBase<WebApp2BytesMusic.ServiceReferencePlayer.PlayerSoap>, WebApp2BytesMusic.ServiceReferencePlayer.PlayerSoap {
        
        public PlayerSoapClient() {
        }
        
        public PlayerSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PlayerSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PlayerSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PlayerSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Save(int idArtist, int idSong) {
            return base.Channel.Save(idArtist, idSong);
        }
        
        public System.Threading.Tasks.Task<int> SaveAsync(int idArtist, int idSong) {
            return base.Channel.SaveAsync(idArtist, idSong);
        }
        
        public int CheckExist(int idArtist, int idSong) {
            return base.Channel.CheckExist(idArtist, idSong);
        }
        
        public System.Threading.Tasks.Task<int> CheckExistAsync(int idArtist, int idSong) {
            return base.Channel.CheckExistAsync(idArtist, idSong);
        }
        
        public System.Data.DataTable Read(int idArtist) {
            return base.Channel.Read(idArtist);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> ReadAsync(int idArtist) {
            return base.Channel.ReadAsync(idArtist);
        }
        
        public int DeleteByIdSong(int idSong) {
            return base.Channel.DeleteByIdSong(idSong);
        }
        
        public System.Threading.Tasks.Task<int> DeleteByIdSongAsync(int idSong) {
            return base.Channel.DeleteByIdSongAsync(idSong);
        }
        
        public int Delete(int idArtist, int idSong) {
            return base.Channel.Delete(idArtist, idSong);
        }
        
        public System.Threading.Tasks.Task<int> DeleteAsync(int idArtist, int idSong) {
            return base.Channel.DeleteAsync(idArtist, idSong);
        }
    }
}