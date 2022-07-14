﻿
using System.Xml.Serialization;

// NOTA: El código generado puede requerir, como mínimo, .NET Framework 4.5 o .NET Core/Standard 2.0.
/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/4", IsNullable = false)]
public partial class Comprobante4
{

    private ComprobanteInformacionGlobal4 informacionGlobalField;

    private ComprobanteCfdiRelacionados4[] cfdiRelacionadosField;

    private ComprobanteEmisor4 emisorField;

    private ComprobanteReceptor4 receptorField;

    private ComprobanteConcepto4[] conceptosField;

    private ComprobanteImpuestos4 impuestosField;

    private ComprobanteComplemento4[] complementoField;

    private ComprobanteAddenda4 addendaField;

    private string versionField;

    private string serieField;

    private string folioField;

    private System.DateTime fechaField;

    private string selloField;

    private string formaPagoField;

    private string noCertificadoField;

    private string certificadoField;

    private string condicionesDePagoField;

    private decimal subTotalField;

    private decimal descuentoField;

    private string monedaField;

    private decimal tipoCambioField;

    private decimal totalField;

    private string tipoDeComprobanteField;

    private string exportacionField;

    private string metodoPagoField;

    private string lugarExpedicionField;

    private string confirmacionField;

    public Comprobante4()
    {
        this.versionField = "4.0";
    }
    /// <remarks/>
    public ComprobanteInformacionGlobal4 InformacionGlobal
    {
        get
        {
            return this.informacionGlobalField;
        }
        set
        {
            this.informacionGlobalField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CfdiRelacionados")]
    public ComprobanteCfdiRelacionados4[] CfdiRelacionados
    {
        get
        {
            return this.cfdiRelacionadosField;
        }
        set
        {
            this.cfdiRelacionadosField = value;
        }
    }

    /// <remarks/>
    public ComprobanteEmisor4 Emisor
    {
        get
        {
            return this.emisorField;
        }
        set
        {
            this.emisorField = value;
        }
    }

    /// <remarks/>
    public ComprobanteReceptor4 Receptor
    {
        get
        {
            return this.receptorField;
        }
        set
        {
            this.receptorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Concepto", IsNullable = false)]
    public ComprobanteConcepto4[] Conceptos
    {
        get
        {
            return this.conceptosField;
        }
        set
        {
            this.conceptosField = value;
        }
    }

    /// <remarks/>
    public ComprobanteImpuestos4 Impuestos
    {
        get
        {
            return this.impuestosField;
        }
        set
        {
            this.impuestosField = value;
        }
    }

    ///// <remarks/>
    //public object Complemento
    //{
    //    get
    //    {
    //        return this.complementoField;
    //    }
    //    set
    //    {
    //        this.complementoField = value;
    //    }
    //}

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Complemento")]
    public ComprobanteComplemento4[] Complemento
    {
        get
        {
            return this.complementoField;
        }
        set
        {
            this.complementoField = value;
        }
    }

    /// <remarks/>
    public ComprobanteAddenda4 Addenda
    {
        get
        {
            return this.addendaField;
        }
        set
        {
            this.addendaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Version
    {
        get
        {
            return this.versionField;
        }
        set
        {
            this.versionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Serie
    {
        get
        {
            return this.serieField;
        }
        set
        {
            this.serieField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Folio
    {
        get
        {
            return this.folioField;
        }
        set
        {
            this.folioField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public System.DateTime Fecha
    {
        get
        {
            return this.fechaField;
        }
        set
        {
            this.fechaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Sello
    {
        get
        {
            return this.selloField;
        }
        set
        {
            this.selloField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string FormaPago
    {
        get
        {
            return this.formaPagoField;
        }
        set
        {
            this.formaPagoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NoCertificado
    {
        get
        {
            return this.noCertificadoField;
        }
        set
        {
            this.noCertificadoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Certificado
    {
        get
        {
            return this.certificadoField;
        }
        set
        {
            this.certificadoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CondicionesDePago
    {
        get
        {
            return this.condicionesDePagoField;
        }
        set
        {
            this.condicionesDePagoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal SubTotal
    {
        get
        {
            return this.subTotalField;
        }
        set
        {
            this.subTotalField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Descuento
    {
        get
        {
            return this.descuentoField;
        }
        set
        {
            this.descuentoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Moneda
    {
        get
        {
            return this.monedaField;
        }
        set
        {
            this.monedaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TipoCambio
    {
        get
        {
            return this.tipoCambioField;
        }
        set
        {
            this.tipoCambioField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Total
    {
        get
        {
            return this.totalField;
        }
        set
        {
            this.totalField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TipoDeComprobante
    {
        get
        {
            return this.tipoDeComprobanteField;
        }
        set
        {
            this.tipoDeComprobanteField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Exportacion
    {
        get
        {
            return this.exportacionField;
        }
        set
        {
            this.exportacionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string MetodoPago
    {
        get
        {
            return this.metodoPagoField;
        }
        set
        {
            this.metodoPagoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string LugarExpedicion
    {
        get
        {
            return this.lugarExpedicionField;
        }
        set
        {
            this.lugarExpedicionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Confirmacion
    {
        get
        {
            return this.confirmacionField;
        }
        set
        {
            this.confirmacionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteInformacionGlobal4
{

    private string periodicidadField;

    private string mesesField;

    private ushort añoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Periodicidad
    {
        get
        {
            return this.periodicidadField;
        }
        set
        {
            this.periodicidadField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Meses
    {
        get
        {
            return this.mesesField;
        }
        set
        {
            this.mesesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort Año
    {
        get
        {
            return this.añoField;
        }
        set
        {
            this.añoField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteCfdiRelacionados4
{

    private ComprobanteCfdiRelacionadosCfdiRelacionado[] cfdiRelacionadoField;

    private string tipoRelacionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CfdiRelacionado")]
    public ComprobanteCfdiRelacionadosCfdiRelacionado[] CfdiRelacionado
    {
        get
        {
            return this.cfdiRelacionadoField;
        }
        set
        {
            this.cfdiRelacionadoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TipoRelacion
    {
        get
        {
            return this.tipoRelacionField;
        }
        set
        {
            this.tipoRelacionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteCfdiRelacionadosCfdiRelacionado4
{

    private string uUIDField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string UUID
    {
        get
        {
            return this.uUIDField;
        }
        set
        {
            this.uUIDField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteEmisor4
{

    private string rfcField;

    private string nombreField;

    private ushort regimenFiscalField;

    private string facAtrAdquirenteField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Rfc
    {
        get
        {
            return this.rfcField;
        }
        set
        {
            this.rfcField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Nombre
    {
        get
        {
            return this.nombreField;
        }
        set
        {
            this.nombreField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort RegimenFiscal
    {
        get
        {
            return this.regimenFiscalField;
        }
        set
        {
            this.regimenFiscalField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string FacAtrAdquirente
    {
        get
        {
            return this.facAtrAdquirenteField;
        }
        set
        {
            this.facAtrAdquirenteField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteReceptor4
{

    private string rfcField;

    private string nombreField;

    private string domicilioFiscalReceptorField;

    private string residenciaFiscalField;

    private string numRegIdTribField;

    private ushort regimenFiscalReceptorField;

    private string usoCFDIField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Rfc
    {
        get
        {
            return this.rfcField;
        }
        set
        {
            this.rfcField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Nombre
    {
        get
        {
            return this.nombreField;
        }
        set
        {
            this.nombreField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string DomicilioFiscalReceptor
    {
        get
        {
            return this.domicilioFiscalReceptorField;
        }
        set
        {
            this.domicilioFiscalReceptorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ResidenciaFiscal
    {
        get
        {
            return this.residenciaFiscalField;
        }
        set
        {
            this.residenciaFiscalField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NumRegIdTrib
    {
        get
        {
            return this.numRegIdTribField;
        }
        set
        {
            this.numRegIdTribField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort RegimenFiscalReceptor
    {
        get
        {
            return this.regimenFiscalReceptorField;
        }
        set
        {
            this.regimenFiscalReceptorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string UsoCFDI
    {
        get
        {
            return this.usoCFDIField;
        }
        set
        {
            this.usoCFDIField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteConcepto4
{

    private ComprobanteConceptoImpuestos impuestosField;

    private ComprobanteConceptoACuentaTerceros aCuentaTercerosField;

    private ComprobanteConceptoInformacionAduanera[] informacionAduaneraField;

    private ComprobanteConceptoCuentaPredial[] cuentaPredialField;

    private object complementoConceptoField;

    private ComprobanteConceptoParte[] parteField;

    private uint claveProdServField;

    private string noIdentificacionField;

    private decimal cantidadField;

    private string claveUnidadField;

    private string unidadField;

    private string descripcionField;

    private decimal valorUnitarioField;

    private decimal importeField;

    private decimal descuentoField;

    private string objetoImpField;

    /// <remarks/>
    public ComprobanteConceptoImpuestos Impuestos
    {
        get
        {
            return this.impuestosField;
        }
        set
        {
            this.impuestosField = value;
        }
    }

    /// <remarks/>
    public ComprobanteConceptoACuentaTerceros ACuentaTerceros
    {
        get
        {
            return this.aCuentaTercerosField;
        }
        set
        {
            this.aCuentaTercerosField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("InformacionAduanera")]
    public ComprobanteConceptoInformacionAduanera[] InformacionAduanera
    {
        get
        {
            return this.informacionAduaneraField;
        }
        set
        {
            this.informacionAduaneraField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CuentaPredial")]
    public ComprobanteConceptoCuentaPredial[] CuentaPredial
    {
        get
        {
            return this.cuentaPredialField;
        }
        set
        {
            this.cuentaPredialField = value;
        }
    }

    /// <remarks/>
    public object ComplementoConcepto
    {
        get
        {
            return this.complementoConceptoField;
        }
        set
        {
            this.complementoConceptoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Parte")]
    public ComprobanteConceptoParte[] Parte
    {
        get
        {
            return this.parteField;
        }
        set
        {
            this.parteField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint ClaveProdServ
    {
        get
        {
            return this.claveProdServField;
        }
        set
        {
            this.claveProdServField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NoIdentificacion
    {
        get
        {
            return this.noIdentificacionField;
        }
        set
        {
            this.noIdentificacionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Cantidad
    {
        get
        {
            return this.cantidadField;
        }
        set
        {
            this.cantidadField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ClaveUnidad
    {
        get
        {
            return this.claveUnidadField;
        }
        set
        {
            this.claveUnidadField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Unidad
    {
        get
        {
            return this.unidadField;
        }
        set
        {
            this.unidadField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Descripcion
    {
        get
        {
            return this.descripcionField;
        }
        set
        {
            this.descripcionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal ValorUnitario
    {
        get
        {
            return this.valorUnitarioField;
        }
        set
        {
            this.valorUnitarioField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe
    {
        get
        {
            return this.importeField;
        }
        set
        {
            this.importeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Descuento
    {
        get
        {
            return this.descuentoField;
        }
        set
        {
            this.descuentoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ObjetoImp
    {
        get
        {
            return this.objetoImpField;
        }
        set
        {
            this.objetoImpField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteConceptoImpuestos4
{

    private ComprobanteConceptoImpuestosTraslado[] trasladosField;

    private ComprobanteConceptoImpuestosRetencion[] retencionesField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Traslado", IsNullable = false)]
    public ComprobanteConceptoImpuestosTraslado[] Traslados
    {
        get
        {
            return this.trasladosField;
        }
        set
        {
            this.trasladosField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Retencion", IsNullable = false)]
    public ComprobanteConceptoImpuestosRetencion[] Retenciones
    {
        get
        {
            return this.retencionesField;
        }
        set
        {
            this.retencionesField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteConceptoImpuestosTraslado4
{

    private decimal baseField;

    private string impuestoField;

    private string tipoFactorField;

    private decimal tasaOCuotaField;

    private decimal importeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Base
    {
        get
        {
            return this.baseField;
        }
        set
        {
            this.baseField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Impuesto
    {
        get
        {
            return this.impuestoField;
        }
        set
        {
            this.impuestoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TipoFactor
    {
        get
        {
            return this.tipoFactorField;
        }
        set
        {
            this.tipoFactorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TasaOCuota
    {
        get
        {
            return this.tasaOCuotaField;
        }
        set
        {
            this.tasaOCuotaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe
    {
        get
        {
            return this.importeField;
        }
        set
        {
            this.importeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteConceptoImpuestosRetencion4
{

    private decimal baseField;

    private string impuestoField;

    private string tipoFactorField;

    private decimal tasaOCuotaField;

    private decimal importeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Base
    {
        get
        {
            return this.baseField;
        }
        set
        {
            this.baseField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Impuesto
    {
        get
        {
            return this.impuestoField;
        }
        set
        {
            this.impuestoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TipoFactor
    {
        get
        {
            return this.tipoFactorField;
        }
        set
        {
            this.tipoFactorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TasaOCuota
    {
        get
        {
            return this.tasaOCuotaField;
        }
        set
        {
            this.tasaOCuotaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe
    {
        get
        {
            return this.importeField;
        }
        set
        {
            this.importeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteConceptoACuentaTerceros4
{

    private string rfcACuentaTercerosField;

    private string nombreACuentaTercerosField;

    private ushort regimenFiscalACuentaTercerosField;

    private string domicilioFiscalACuentaTercerosField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string RfcACuentaTerceros
    {
        get
        {
            return this.rfcACuentaTercerosField;
        }
        set
        {
            this.rfcACuentaTercerosField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NombreACuentaTerceros
    {
        get
        {
            return this.nombreACuentaTercerosField;
        }
        set
        {
            this.nombreACuentaTercerosField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort RegimenFiscalACuentaTerceros
    {
        get
        {
            return this.regimenFiscalACuentaTercerosField;
        }
        set
        {
            this.regimenFiscalACuentaTercerosField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string DomicilioFiscalACuentaTerceros
    {
        get
        {
            return this.domicilioFiscalACuentaTercerosField;
        }
        set
        {
            this.domicilioFiscalACuentaTercerosField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteConceptoInformacionAduanera4
{

    private string numeroPedimentoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NumeroPedimento
    {
        get
        {
            return this.numeroPedimentoField;
        }
        set
        {
            this.numeroPedimentoField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteConceptoCuentaPredial4
{

    private string numeroField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Numero
    {
        get
        {
            return this.numeroField;
        }
        set
        {
            this.numeroField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteConceptoParte4
{

    private ComprobanteConceptoParteInformacionAduanera[] informacionAduaneraField;

    private uint claveProdServField;

    private string noIdentificacionField;

    private decimal cantidadField;

    private string unidadField;

    private string descripcionField;

    private decimal valorUnitarioField;

    private decimal importeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("InformacionAduanera")]
    public ComprobanteConceptoParteInformacionAduanera[] InformacionAduanera
    {
        get
        {
            return this.informacionAduaneraField;
        }
        set
        {
            this.informacionAduaneraField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint ClaveProdServ
    {
        get
        {
            return this.claveProdServField;
        }
        set
        {
            this.claveProdServField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NoIdentificacion
    {
        get
        {
            return this.noIdentificacionField;
        }
        set
        {
            this.noIdentificacionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Cantidad
    {
        get
        {
            return this.cantidadField;
        }
        set
        {
            this.cantidadField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Unidad
    {
        get
        {
            return this.unidadField;
        }
        set
        {
            this.unidadField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Descripcion
    {
        get
        {
            return this.descripcionField;
        }
        set
        {
            this.descripcionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal ValorUnitario
    {
        get
        {
            return this.valorUnitarioField;
        }
        set
        {
            this.valorUnitarioField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe
    {
        get
        {
            return this.importeField;
        }
        set
        {
            this.importeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteConceptoParteInformacionAduanera4
{

    private string numeroPedimentoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string NumeroPedimento
    {
        get
        {
            return this.numeroPedimentoField;
        }
        set
        {
            this.numeroPedimentoField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteImpuestos4
{

    private ComprobanteImpuestosRetencion[] retencionesField;

    private ComprobanteImpuestosTraslado[] trasladosField;

    private decimal totalImpuestosRetenidosField;

    private decimal totalImpuestosTrasladadosField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Retencion", IsNullable = false)]
    public ComprobanteImpuestosRetencion[] Retenciones
    {
        get
        {
            return this.retencionesField;
        }
        set
        {
            this.retencionesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Traslado", IsNullable = false)]
    public ComprobanteImpuestosTraslado[] Traslados
    {
        get
        {
            return this.trasladosField;
        }
        set
        {
            this.trasladosField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TotalImpuestosRetenidos
    {
        get
        {
            return this.totalImpuestosRetenidosField;
        }
        set
        {
            this.totalImpuestosRetenidosField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TotalImpuestosTrasladados
    {
        get
        {
            return this.totalImpuestosTrasladadosField;
        }
        set
        {
            this.totalImpuestosTrasladadosField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteImpuestosRetencion4
{

    private string impuestoField;

    private decimal importeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Impuesto
    {
        get
        {
            return this.impuestoField;
        }
        set
        {
            this.impuestoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe
    {
        get
        {
            return this.importeField;
        }
        set
        {
            this.importeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4")]
public partial class ComprobanteImpuestosTraslado4
{

    private decimal baseField;

    private string impuestoField;

    private string tipoFactorField;

    private decimal tasaOCuotaField;

    private decimal importeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Base
    {
        get
        {
            return this.baseField;
        }
        set
        {
            this.baseField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Impuesto
    {
        get
        {
            return this.impuestoField;
        }
        set
        {
            this.impuestoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TipoFactor
    {
        get
        {
            return this.tipoFactorField;
        }
        set
        {
            this.tipoFactorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TasaOCuota
    {
        get
        {
            return this.tasaOCuotaField;
        }
        set
        {
            this.tasaOCuotaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Importe
    {
        get
        {
            return this.importeField;
        }
        set
        {
            this.importeField = value;
        }
    }
}


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteComplemento4
{

    private System.Xml.XmlElement[] anyField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAnyElementAttribute()]
    public System.Xml.XmlElement[] Any
    {
        get
        {
            return this.anyField;
        }
        set
        {
            this.anyField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
public partial class ComprobanteAddenda4
{

    private System.Xml.XmlElement[] anyField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAnyElementAttribute()]
    public System.Xml.XmlElement[] Any
    {
        get
        {
            return this.anyField;
        }
        set
        {
            this.anyField = value;
        }
    }
}