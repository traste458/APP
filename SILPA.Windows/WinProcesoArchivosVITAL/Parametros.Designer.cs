﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinProcesoArchivosVITAL {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Parametros : global::System.Configuration.ApplicationSettingsBase {
        
        private static Parametros defaultInstance = ((Parametros)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Parametros())));
        
        public static Parametros Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2016")]
        public int AnioInicio {
            get {
                return ((int)(this["AnioInicio"]));
            }
            set {
                this["AnioInicio"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2024")]
        public int AnioFinal {
            get {
                return ((int)(this["AnioFinal"]));
            }
            set {
                this["AnioFinal"] = value;
            }
        }
    }
}