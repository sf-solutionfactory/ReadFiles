﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// Este código fuente fue generado automáticamente por xsd, Versión=4.6.1055.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.sat.gob.mx/TimbreFiscalDigital")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.sat.gob.mx/TimbreFiscalDigital", IsNullable=false)]
public partial class TimbreFiscalDigital {
    
    private string versionField;
    
    private string uUIDField;
    
    private System.DateTime fechaTimbradoField;
    
    private string selloCFDField;
    
    private string noCertificadoSATField;
    
    private string selloSATField;
    
    public TimbreFiscalDigital() {
        this.versionField = "1.0";
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string version {
        get {
            return this.versionField;
        }
        set {
            this.versionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string UUID {
        get {
            return this.uUIDField;
        }
        set {
            this.uUIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public System.DateTime FechaTimbrado {
        get {
            return this.fechaTimbradoField;
        }
        set {
            this.fechaTimbradoField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string selloCFD {
        get {
            return this.selloCFDField;
        }
        set {
            this.selloCFDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string noCertificadoSAT {
        get {
            return this.noCertificadoSATField;
        }
        set {
            this.noCertificadoSATField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string selloSAT {
        get {
            return this.selloSATField;
        }
        set {
            this.selloSATField = value;
        }
    }
}
