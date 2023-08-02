﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp2BytesMusic.ServiceReferenceTracklist {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceTracklist.TracklistSoap")]
    public interface TracklistSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Save", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Save(int idAlbum, int idSong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Save", ReplyAction="*")]
        System.Threading.Tasks.Task<int> SaveAsync(int idAlbum, int idSong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CheckExist", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int CheckExist(int idAlbum, int idSong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CheckExist", ReplyAction="*")]
        System.Threading.Tasks.Task<int> CheckExistAsync(int idAlbum, int idSong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable Read(int idAlbum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> ReadAsync(int idAlbum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int idSong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        System.Threading.Tasks.Task<int> DeleteAsync(int idSong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteSongOnTracklist", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int DeleteSongOnTracklist(int idAlbum, int idSong);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteSongOnTracklist", ReplyAction="*")]
        System.Threading.Tasks.Task<int> DeleteSongOnTracklistAsync(int idAlbum, int idSong);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TracklistSoapChannel : WebApp2BytesMusic.ServiceReferenceTracklist.TracklistSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TracklistSoapClient : System.ServiceModel.ClientBase<WebApp2BytesMusic.ServiceReferenceTracklist.TracklistSoap>, WebApp2BytesMusic.ServiceReferenceTracklist.TracklistSoap {
        
        public TracklistSoapClient() {
        }
        
        public TracklistSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TracklistSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TracklistSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TracklistSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Save(int idAlbum, int idSong) {
            return base.Channel.Save(idAlbum, idSong);
        }
        
        public System.Threading.Tasks.Task<int> SaveAsync(int idAlbum, int idSong) {
            return base.Channel.SaveAsync(idAlbum, idSong);
        }
        
        public int CheckExist(int idAlbum, int idSong) {
            return base.Channel.CheckExist(idAlbum, idSong);
        }
        
        public System.Threading.Tasks.Task<int> CheckExistAsync(int idAlbum, int idSong) {
            return base.Channel.CheckExistAsync(idAlbum, idSong);
        }
        
        public System.Data.DataTable Read(int idAlbum) {
            return base.Channel.Read(idAlbum);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> ReadAsync(int idAlbum) {
            return base.Channel.ReadAsync(idAlbum);
        }
        
        public int Delete(int idSong) {
            return base.Channel.Delete(idSong);
        }
        
        public System.Threading.Tasks.Task<int> DeleteAsync(int idSong) {
            return base.Channel.DeleteAsync(idSong);
        }
        
        public int DeleteSongOnTracklist(int idAlbum, int idSong) {
            return base.Channel.DeleteSongOnTracklist(idAlbum, idSong);
        }
        
        public System.Threading.Tasks.Task<int> DeleteSongOnTracklistAsync(int idAlbum, int idSong) {
            return base.Channel.DeleteSongOnTracklistAsync(idAlbum, idSong);
        }
    }
}