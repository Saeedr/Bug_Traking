﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bug_Traking.LiveClassifi {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ReqOrganization", Namespace="http://schemas.datacontract.org/2004/07/DataContracts.Behdasht.Request")]
    [System.SerializableAttribute()]
    public partial class ReqOrganization : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ActivationDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ActivationStatusCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AreaNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BuildingOwnershipTypeCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountryCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountryDivisionsCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DisplayNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool DraftField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InternetBandwidthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IntranetBandwidthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LatitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LocalNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LongNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LongitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MunicipalityRegionCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrganizationIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OrganizationID8DigitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrganizationNationalCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrganizationTypeCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OwnerOrganizationIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OwnerTypeCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PostalCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProvinceCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime RecordCreationDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ShortNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StablishmentDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SupervisorUniversityIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TownshipCodeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ActivationDate {
            get {
                return this.ActivationDateField;
            }
            set {
                if ((object.ReferenceEquals(this.ActivationDateField, value) != true)) {
                    this.ActivationDateField = value;
                    this.RaisePropertyChanged("ActivationDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ActivationStatusCode {
            get {
                return this.ActivationStatusCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.ActivationStatusCodeField, value) != true)) {
                    this.ActivationStatusCodeField = value;
                    this.RaisePropertyChanged("ActivationStatusCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AreaNumber {
            get {
                return this.AreaNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.AreaNumberField, value) != true)) {
                    this.AreaNumberField = value;
                    this.RaisePropertyChanged("AreaNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BuildingOwnershipTypeCode {
            get {
                return this.BuildingOwnershipTypeCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.BuildingOwnershipTypeCodeField, value) != true)) {
                    this.BuildingOwnershipTypeCodeField = value;
                    this.RaisePropertyChanged("BuildingOwnershipTypeCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CountryCode {
            get {
                return this.CountryCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CountryCodeField, value) != true)) {
                    this.CountryCodeField = value;
                    this.RaisePropertyChanged("CountryCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CountryDivisionsCode {
            get {
                return this.CountryDivisionsCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CountryDivisionsCodeField, value) != true)) {
                    this.CountryDivisionsCodeField = value;
                    this.RaisePropertyChanged("CountryDivisionsCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DisplayName {
            get {
                return this.DisplayNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DisplayNameField, value) != true)) {
                    this.DisplayNameField = value;
                    this.RaisePropertyChanged("DisplayName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Draft {
            get {
                return this.DraftField;
            }
            set {
                if ((this.DraftField.Equals(value) != true)) {
                    this.DraftField = value;
                    this.RaisePropertyChanged("Draft");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string InternetBandwidth {
            get {
                return this.InternetBandwidthField;
            }
            set {
                if ((object.ReferenceEquals(this.InternetBandwidthField, value) != true)) {
                    this.InternetBandwidthField = value;
                    this.RaisePropertyChanged("InternetBandwidth");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IntranetBandwidth {
            get {
                return this.IntranetBandwidthField;
            }
            set {
                if ((object.ReferenceEquals(this.IntranetBandwidthField, value) != true)) {
                    this.IntranetBandwidthField = value;
                    this.RaisePropertyChanged("IntranetBandwidth");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Latitude {
            get {
                return this.LatitudeField;
            }
            set {
                if ((object.ReferenceEquals(this.LatitudeField, value) != true)) {
                    this.LatitudeField = value;
                    this.RaisePropertyChanged("Latitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LocalNumber {
            get {
                return this.LocalNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.LocalNumberField, value) != true)) {
                    this.LocalNumberField = value;
                    this.RaisePropertyChanged("LocalNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LongName {
            get {
                return this.LongNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LongNameField, value) != true)) {
                    this.LongNameField = value;
                    this.RaisePropertyChanged("LongName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Longitude {
            get {
                return this.LongitudeField;
            }
            set {
                if ((object.ReferenceEquals(this.LongitudeField, value) != true)) {
                    this.LongitudeField = value;
                    this.RaisePropertyChanged("Longitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MunicipalityRegionCode {
            get {
                return this.MunicipalityRegionCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.MunicipalityRegionCodeField, value) != true)) {
                    this.MunicipalityRegionCodeField = value;
                    this.RaisePropertyChanged("MunicipalityRegionCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrganizationID {
            get {
                return this.OrganizationIDField;
            }
            set {
                if ((object.ReferenceEquals(this.OrganizationIDField, value) != true)) {
                    this.OrganizationIDField = value;
                    this.RaisePropertyChanged("OrganizationID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OrganizationID8Digit {
            get {
                return this.OrganizationID8DigitField;
            }
            set {
                if ((this.OrganizationID8DigitField.Equals(value) != true)) {
                    this.OrganizationID8DigitField = value;
                    this.RaisePropertyChanged("OrganizationID8Digit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrganizationNationalCode {
            get {
                return this.OrganizationNationalCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.OrganizationNationalCodeField, value) != true)) {
                    this.OrganizationNationalCodeField = value;
                    this.RaisePropertyChanged("OrganizationNationalCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrganizationTypeCode {
            get {
                return this.OrganizationTypeCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.OrganizationTypeCodeField, value) != true)) {
                    this.OrganizationTypeCodeField = value;
                    this.RaisePropertyChanged("OrganizationTypeCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OwnerOrganizationID {
            get {
                return this.OwnerOrganizationIDField;
            }
            set {
                if ((object.ReferenceEquals(this.OwnerOrganizationIDField, value) != true)) {
                    this.OwnerOrganizationIDField = value;
                    this.RaisePropertyChanged("OwnerOrganizationID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OwnerTypeCode {
            get {
                return this.OwnerTypeCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.OwnerTypeCodeField, value) != true)) {
                    this.OwnerTypeCodeField = value;
                    this.RaisePropertyChanged("OwnerTypeCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PostalCode {
            get {
                return this.PostalCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.PostalCodeField, value) != true)) {
                    this.PostalCodeField = value;
                    this.RaisePropertyChanged("PostalCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProvinceCode {
            get {
                return this.ProvinceCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.ProvinceCodeField, value) != true)) {
                    this.ProvinceCodeField = value;
                    this.RaisePropertyChanged("ProvinceCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime RecordCreationDate {
            get {
                return this.RecordCreationDateField;
            }
            set {
                if ((this.RecordCreationDateField.Equals(value) != true)) {
                    this.RecordCreationDateField = value;
                    this.RaisePropertyChanged("RecordCreationDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ShortName {
            get {
                return this.ShortNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ShortNameField, value) != true)) {
                    this.ShortNameField = value;
                    this.RaisePropertyChanged("ShortName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StablishmentDate {
            get {
                return this.StablishmentDateField;
            }
            set {
                if ((object.ReferenceEquals(this.StablishmentDateField, value) != true)) {
                    this.StablishmentDateField = value;
                    this.RaisePropertyChanged("StablishmentDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SupervisorUniversityID {
            get {
                return this.SupervisorUniversityIDField;
            }
            set {
                if ((object.ReferenceEquals(this.SupervisorUniversityIDField, value) != true)) {
                    this.SupervisorUniversityIDField = value;
                    this.RaisePropertyChanged("SupervisorUniversityID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TownshipCode {
            get {
                return this.TownshipCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.TownshipCodeField, value) != true)) {
                    this.TownshipCodeField = value;
                    this.RaisePropertyChanged("TownshipCode");
                }
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ReqCountry", Namespace="http://schemas.datacontract.org/2004/07/DataContracts.Country.Request")]
    [System.SerializableAttribute()]
    public partial class ReqCountry : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AreaTypeCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CenterNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CityCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountryCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountyCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreationDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool DeletedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ModificationDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ParentAreaCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ParentAreaTypeCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProvinceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProvinceCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RuralDistinctField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RuralDistinctCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatisticsOrgCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TownshipField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TownshipCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float VersionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AreaTypeCode {
            get {
                return this.AreaTypeCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.AreaTypeCodeField, value) != true)) {
                    this.AreaTypeCodeField = value;
                    this.RaisePropertyChanged("AreaTypeCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CenterName {
            get {
                return this.CenterNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CenterNameField, value) != true)) {
                    this.CenterNameField = value;
                    this.RaisePropertyChanged("CenterName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string City {
            get {
                return this.CityField;
            }
            set {
                if ((object.ReferenceEquals(this.CityField, value) != true)) {
                    this.CityField = value;
                    this.RaisePropertyChanged("City");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CityCode {
            get {
                return this.CityCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CityCodeField, value) != true)) {
                    this.CityCodeField = value;
                    this.RaisePropertyChanged("CityCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CountryCode {
            get {
                return this.CountryCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CountryCodeField, value) != true)) {
                    this.CountryCodeField = value;
                    this.RaisePropertyChanged("CountryCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string County {
            get {
                return this.CountyField;
            }
            set {
                if ((object.ReferenceEquals(this.CountyField, value) != true)) {
                    this.CountyField = value;
                    this.RaisePropertyChanged("County");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CountyCode {
            get {
                return this.CountyCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CountyCodeField, value) != true)) {
                    this.CountyCodeField = value;
                    this.RaisePropertyChanged("CountyCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CreationDate {
            get {
                return this.CreationDateField;
            }
            set {
                if ((this.CreationDateField.Equals(value) != true)) {
                    this.CreationDateField = value;
                    this.RaisePropertyChanged("CreationDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Date {
            get {
                return this.DateField;
            }
            set {
                if ((object.ReferenceEquals(this.DateField, value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Deleted {
            get {
                return this.DeletedField;
            }
            set {
                if ((this.DeletedField.Equals(value) != true)) {
                    this.DeletedField = value;
                    this.RaisePropertyChanged("Deleted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ModificationDate {
            get {
                return this.ModificationDateField;
            }
            set {
                if ((this.ModificationDateField.Equals(value) != true)) {
                    this.ModificationDateField = value;
                    this.RaisePropertyChanged("ModificationDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ParentAreaCode {
            get {
                return this.ParentAreaCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.ParentAreaCodeField, value) != true)) {
                    this.ParentAreaCodeField = value;
                    this.RaisePropertyChanged("ParentAreaCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ParentAreaTypeCode {
            get {
                return this.ParentAreaTypeCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.ParentAreaTypeCodeField, value) != true)) {
                    this.ParentAreaTypeCodeField = value;
                    this.RaisePropertyChanged("ParentAreaTypeCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Province {
            get {
                return this.ProvinceField;
            }
            set {
                if ((object.ReferenceEquals(this.ProvinceField, value) != true)) {
                    this.ProvinceField = value;
                    this.RaisePropertyChanged("Province");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProvinceCode {
            get {
                return this.ProvinceCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.ProvinceCodeField, value) != true)) {
                    this.ProvinceCodeField = value;
                    this.RaisePropertyChanged("ProvinceCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RuralDistinct {
            get {
                return this.RuralDistinctField;
            }
            set {
                if ((object.ReferenceEquals(this.RuralDistinctField, value) != true)) {
                    this.RuralDistinctField = value;
                    this.RaisePropertyChanged("RuralDistinct");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RuralDistinctCode {
            get {
                return this.RuralDistinctCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.RuralDistinctCodeField, value) != true)) {
                    this.RuralDistinctCodeField = value;
                    this.RaisePropertyChanged("RuralDistinctCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StatisticsOrgCode {
            get {
                return this.StatisticsOrgCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.StatisticsOrgCodeField, value) != true)) {
                    this.StatisticsOrgCodeField = value;
                    this.RaisePropertyChanged("StatisticsOrgCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Township {
            get {
                return this.TownshipField;
            }
            set {
                if ((object.ReferenceEquals(this.TownshipField, value) != true)) {
                    this.TownshipField = value;
                    this.RaisePropertyChanged("Township");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TownshipCode {
            get {
                return this.TownshipCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.TownshipCodeField, value) != true)) {
                    this.TownshipCodeField = value;
                    this.RaisePropertyChanged("TownshipCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Version {
            get {
                return this.VersionField;
            }
            set {
                if ((this.VersionField.Equals(value) != true)) {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
                }
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LiveClassifi.ILiveClassification")]
    public interface ILiveClassification {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILiveClassification/GetBehdashtClassificationByParam", ReplyAction="http://tempuri.org/ILiveClassification/GetBehdashtClassificationByParamResponse")]
        Bug_Traking.LiveClassifi.ReqOrganization[] GetBehdashtClassificationByParam(int fromDay, string orgKind, string parentID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILiveClassification/GetBehdashtClassificationByParam", ReplyAction="http://tempuri.org/ILiveClassification/GetBehdashtClassificationByParamResponse")]
        System.Threading.Tasks.Task<Bug_Traking.LiveClassifi.ReqOrganization[]> GetBehdashtClassificationByParamAsync(int fromDay, string orgKind, string parentID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILiveClassification/GetCountryClassificationByParam", ReplyAction="http://tempuri.org/ILiveClassification/GetCountryClassificationByParamResponse")]
        Bug_Traking.LiveClassifi.ReqCountry[] GetCountryClassificationByParam(string AreaTypeCode, string ParentAreaCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILiveClassification/GetCountryClassificationByParam", ReplyAction="http://tempuri.org/ILiveClassification/GetCountryClassificationByParamResponse")]
        System.Threading.Tasks.Task<Bug_Traking.LiveClassifi.ReqCountry[]> GetCountryClassificationByParamAsync(string AreaTypeCode, string ParentAreaCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILiveClassification/GetCountryClassificationByCountryCode", ReplyAction="http://tempuri.org/ILiveClassification/GetCountryClassificationByCountryCodeRespo" +
            "nse")]
        Bug_Traking.LiveClassifi.ReqCountry[] GetCountryClassificationByCountryCode(string AreaTypeCode, string ParentAreaCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILiveClassification/GetCountryClassificationByCountryCode", ReplyAction="http://tempuri.org/ILiveClassification/GetCountryClassificationByCountryCodeRespo" +
            "nse")]
        System.Threading.Tasks.Task<Bug_Traking.LiveClassifi.ReqCountry[]> GetCountryClassificationByCountryCodeAsync(string AreaTypeCode, string ParentAreaCode);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILiveClassificationChannel : Bug_Traking.LiveClassifi.ILiveClassification, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LiveClassificationClient : System.ServiceModel.ClientBase<Bug_Traking.LiveClassifi.ILiveClassification>, Bug_Traking.LiveClassifi.ILiveClassification {
        
        public LiveClassificationClient() {
        }
        
        public LiveClassificationClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LiveClassificationClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LiveClassificationClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LiveClassificationClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Bug_Traking.LiveClassifi.ReqOrganization[] GetBehdashtClassificationByParam(int fromDay, string orgKind, string parentID) {
            return base.Channel.GetBehdashtClassificationByParam(fromDay, orgKind, parentID);
        }
        
        public System.Threading.Tasks.Task<Bug_Traking.LiveClassifi.ReqOrganization[]> GetBehdashtClassificationByParamAsync(int fromDay, string orgKind, string parentID) {
            return base.Channel.GetBehdashtClassificationByParamAsync(fromDay, orgKind, parentID);
        }
        
        public Bug_Traking.LiveClassifi.ReqCountry[] GetCountryClassificationByParam(string AreaTypeCode, string ParentAreaCode) {
            return base.Channel.GetCountryClassificationByParam(AreaTypeCode, ParentAreaCode);
        }
        
        public System.Threading.Tasks.Task<Bug_Traking.LiveClassifi.ReqCountry[]> GetCountryClassificationByParamAsync(string AreaTypeCode, string ParentAreaCode) {
            return base.Channel.GetCountryClassificationByParamAsync(AreaTypeCode, ParentAreaCode);
        }
        
        public Bug_Traking.LiveClassifi.ReqCountry[] GetCountryClassificationByCountryCode(string AreaTypeCode, string ParentAreaCode) {
            return base.Channel.GetCountryClassificationByCountryCode(AreaTypeCode, ParentAreaCode);
        }
        
        public System.Threading.Tasks.Task<Bug_Traking.LiveClassifi.ReqCountry[]> GetCountryClassificationByCountryCodeAsync(string AreaTypeCode, string ParentAreaCode) {
            return base.Channel.GetCountryClassificationByCountryCodeAsync(AreaTypeCode, ParentAreaCode);
        }
    }
}
