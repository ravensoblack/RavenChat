﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RazorChat.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.4.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string BbsHostOrIp {
            get {
                return ((string)(this["BbsHostOrIp"]));
            }
            set {
                this["BbsHostOrIp"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10006")]
        public string ChatPort {
            get {
                return ((string)(this["ChatPort"]));
            }
            set {
                this["ChatPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SysopUsername {
            get {
                return ((string)(this["SysopUsername"]));
            }
            set {
                this["SysopUsername"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SysopPassword {
            get {
                return ((string)(this["SysopPassword"]));
            }
            set {
                this["SysopPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SystemPassword {
            get {
                return ((string)(this["SystemPassword"]));
            }
            set {
                this["SystemPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UsernameSavedOnMain {
            get {
                return ((bool)(this["UsernameSavedOnMain"]));
            }
            set {
                this["UsernameSavedOnMain"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool PasswordsSavedOnMain {
            get {
                return ((bool)(this["PasswordsSavedOnMain"]));
            }
            set {
                this["PasswordsSavedOnMain"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool VisualPagingEnabled {
            get {
                return ((bool)(this["VisualPagingEnabled"]));
            }
            set {
                this["VisualPagingEnabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool AudioPagingEnabled {
            get {
                return ((bool)(this["AudioPagingEnabled"]));
            }
            set {
                this["AudioPagingEnabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ExternalPagingEnabled {
            get {
                return ((bool)(this["ExternalPagingEnabled"]));
            }
            set {
                this["ExternalPagingEnabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("disconnected")]
        public string ConnectToBbs {
            get {
                return ((string)(this["ConnectToBbs"]));
            }
            set {
                this["ConnectToBbs"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool PagerEnabled {
            get {
                return ((bool)(this["PagerEnabled"]));
            }
            set {
                this["PagerEnabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4")]
        public int NumberOfNodes {
            get {
                return ((int)(this["NumberOfNodes"]));
            }
            set {
                this["NumberOfNodes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Default_SBBS_syspage")]
        public string AudioPageFile {
            get {
                return ((string)(this["AudioPageFile"]));
            }
            set {
                this["AudioPageFile"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ExternalPageCommand {
            get {
                return ((string)(this["ExternalPageCommand"]));
            }
            set {
                this["ExternalPageCommand"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ExternalPageOptions {
            get {
                return ((string)(this["ExternalPageOptions"]));
            }
            set {
                this["ExternalPageOptions"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("v0.6a")]
        public string AboutVersion {
            get {
                return ((string)(this["AboutVersion"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10005")]
        public string PagerPort {
            get {
                return ((string)(this["PagerPort"]));
            }
            set {
                this["PagerPort"] = value;
            }
        }
    }
}
