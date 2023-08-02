﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp2BytesMusic.ServiceReferenceSong {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceSong.SongSoap")]
    public interface SongSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Save", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Save(WebApp2BytesMusic.ServiceReferenceSong.ESong song);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Save", ReplyAction="*")]
        System.Threading.Tasks.Task<int> SaveAsync(WebApp2BytesMusic.ServiceReferenceSong.ESong song);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable Read();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> ReadAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(WebApp2BytesMusic.ServiceReferenceSong.ESong song);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        System.Threading.Tasks.Task<int> UpdateAsync(WebApp2BytesMusic.ServiceReferenceSong.ESong song);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int songId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        System.Threading.Tasks.Task<int> DeleteAsync(int songId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CheckExist", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int CheckExist(string songName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CheckExist", ReplyAction="*")]
        System.Threading.Tasks.Task<int> CheckExistAsync(string songName);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4161.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ESong : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idField;
        
        private string songNameField;
        
        private string songPathField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("ID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string SongName {
            get {
                return this.songNameField;
            }
            set {
                this.songNameField = value;
                this.RaisePropertyChanged("SongName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string SongPath {
            get {
                return this.songPathField;
            }
            set {
                this.songPathField = value;
                this.RaisePropertyChanged("SongPath");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SongSoapChannel : WebApp2BytesMusic.ServiceReferenceSong.SongSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SongSoapClient : System.ServiceModel.ClientBase<WebApp2BytesMusic.ServiceReferenceSong.SongSoap>, WebApp2BytesMusic.ServiceReferenceSong.SongSoap {
        
        public SongSoapClient() {
        }
        
        public SongSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SongSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SongSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SongSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Save(WebApp2BytesMusic.ServiceReferenceSong.ESong song) {
            return base.Channel.Save(song);
        }
        
        public System.Threading.Tasks.Task<int> SaveAsync(WebApp2BytesMusic.ServiceReferenceSong.ESong song) {
            return base.Channel.SaveAsync(song);
        }
        
        public System.Data.DataTable Read() {
            return base.Channel.Read();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> ReadAsync() {
            return base.Channel.ReadAsync();
        }
        
        public int Update(WebApp2BytesMusic.ServiceReferenceSong.ESong song) {
            return base.Channel.Update(song);
        }
        
        public System.Threading.Tasks.Task<int> UpdateAsync(WebApp2BytesMusic.ServiceReferenceSong.ESong song) {
            return base.Channel.UpdateAsync(song);
        }
        
        public int Delete(int songId) {
            return base.Channel.Delete(songId);
        }
        
        public System.Threading.Tasks.Task<int> DeleteAsync(int songId) {
            return base.Channel.DeleteAsync(songId);
        }
        
        public int CheckExist(string songName) {
            return base.Channel.CheckExist(songName);
        }
        
        public System.Threading.Tasks.Task<int> CheckExistAsync(string songName) {
            return base.Channel.CheckExistAsync(songName);
        }
    }
}