﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp2BytesMusic.ServiceReferenceUser {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceUser.UserSoap")]
    public interface UserSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Save", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Save(WebApp2BytesMusic.ServiceReferenceUser.EUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Save", ReplyAction="*")]
        System.Threading.Tasks.Task<int> SaveAsync(WebApp2BytesMusic.ServiceReferenceUser.EUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable Read();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Read", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> ReadAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Update(WebApp2BytesMusic.ServiceReferenceUser.EUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Update", ReplyAction="*")]
        System.Threading.Tasks.Task<int> UpdateAsync(WebApp2BytesMusic.ServiceReferenceUser.EUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Delete(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Delete", ReplyAction="*")]
        System.Threading.Tasks.Task<int> DeleteAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ValidationsDuplicated", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ValidationsDuplicated(WebApp2BytesMusic.ServiceReferenceUser.EUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ValidationsDuplicated", ReplyAction="*")]
        System.Threading.Tasks.Task<string> ValidationsDuplicatedAsync(WebApp2BytesMusic.ServiceReferenceUser.EUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AuthenticateUser", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable AuthenticateUser(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AuthenticateUser", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> AuthenticateUserAsync(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CheckExistUser", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int CheckExistUser(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CheckExistUser", ReplyAction="*")]
        System.Threading.Tasks.Task<int> CheckExistUserAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CheckExistEmail", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int CheckExistEmail(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CheckExistEmail", ReplyAction="*")]
        System.Threading.Tasks.Task<int> CheckExistEmailAsync(string email);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4161.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class EUser : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idField;
        
        private string userNameField;
        
        private string passwordField;
        
        private string emailField;
        
        private string birthdayField;
        
        private int userTypeField;
        
        private string photoField;
        
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
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
                this.RaisePropertyChanged("UserName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("Password");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
                this.RaisePropertyChanged("Email");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Birthday {
            get {
                return this.birthdayField;
            }
            set {
                this.birthdayField = value;
                this.RaisePropertyChanged("Birthday");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int UserType {
            get {
                return this.userTypeField;
            }
            set {
                this.userTypeField = value;
                this.RaisePropertyChanged("UserType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Photo {
            get {
                return this.photoField;
            }
            set {
                this.photoField = value;
                this.RaisePropertyChanged("Photo");
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
    public interface UserSoapChannel : WebApp2BytesMusic.ServiceReferenceUser.UserSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserSoapClient : System.ServiceModel.ClientBase<WebApp2BytesMusic.ServiceReferenceUser.UserSoap>, WebApp2BytesMusic.ServiceReferenceUser.UserSoap {
        
        public UserSoapClient() {
        }
        
        public UserSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Save(WebApp2BytesMusic.ServiceReferenceUser.EUser user) {
            return base.Channel.Save(user);
        }
        
        public System.Threading.Tasks.Task<int> SaveAsync(WebApp2BytesMusic.ServiceReferenceUser.EUser user) {
            return base.Channel.SaveAsync(user);
        }
        
        public System.Data.DataTable Read() {
            return base.Channel.Read();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> ReadAsync() {
            return base.Channel.ReadAsync();
        }
        
        public int Update(WebApp2BytesMusic.ServiceReferenceUser.EUser user) {
            return base.Channel.Update(user);
        }
        
        public System.Threading.Tasks.Task<int> UpdateAsync(WebApp2BytesMusic.ServiceReferenceUser.EUser user) {
            return base.Channel.UpdateAsync(user);
        }
        
        public int Delete(int id) {
            return base.Channel.Delete(id);
        }
        
        public System.Threading.Tasks.Task<int> DeleteAsync(int id) {
            return base.Channel.DeleteAsync(id);
        }
        
        public string ValidationsDuplicated(WebApp2BytesMusic.ServiceReferenceUser.EUser user) {
            return base.Channel.ValidationsDuplicated(user);
        }
        
        public System.Threading.Tasks.Task<string> ValidationsDuplicatedAsync(WebApp2BytesMusic.ServiceReferenceUser.EUser user) {
            return base.Channel.ValidationsDuplicatedAsync(user);
        }
        
        public System.Data.DataTable AuthenticateUser(string login, string password) {
            return base.Channel.AuthenticateUser(login, password);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> AuthenticateUserAsync(string login, string password) {
            return base.Channel.AuthenticateUserAsync(login, password);
        }
        
        public int CheckExistUser(string userName) {
            return base.Channel.CheckExistUser(userName);
        }
        
        public System.Threading.Tasks.Task<int> CheckExistUserAsync(string userName) {
            return base.Channel.CheckExistUserAsync(userName);
        }
        
        public int CheckExistEmail(string email) {
            return base.Channel.CheckExistEmail(email);
        }
        
        public System.Threading.Tasks.Task<int> CheckExistEmailAsync(string email) {
            return base.Channel.CheckExistEmailAsync(email);
        }
    }
}
