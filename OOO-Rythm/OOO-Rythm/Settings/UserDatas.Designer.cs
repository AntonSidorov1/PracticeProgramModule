﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OOO_Rythm.Settings {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    public sealed partial class UserDatas : global::System.Configuration.ApplicationSettingsBase {
        
        private static UserDatas defaultInstance = ((UserDatas)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new UserDatas())));
        
        public static UserDatas Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Login {
            get {
                return ((string)(this["Login"]));
            }
            set {
                if (SaveDatas)
                    this["Login"] = value;
                else
                    this["Login"] = "";
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Password {
            get {
                return ((string)(this["Password"]));
            }
            set {
                if (SaveDatas)
                    this["Password"] = value;
                else
                    this["Password"] = "";
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SaveDatas {
            get {
                return ((bool)(this["SaveDatas"]));
            }
            set {
                bool save = value;
                this["SaveDatas"] = save;
                if(!save)
                {
                    Login = "";
                    Password = "";
                }
                Save();
            }
        }
    }
}
