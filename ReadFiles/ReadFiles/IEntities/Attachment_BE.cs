using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadMail.IEntities
{
    [Serializable]
    public class Attachment_BE
    {
        private string _UIDL = string.Empty;
        private string _MAIL = string.Empty;
        private string _DATUM = string.Empty;
        private string _TIME = string.Empty;
        private string _FILE = string.Empty;
        private string _EXT = string.Empty;
        private string _ATTCH = string.Empty;
        private string _LIFNR = string.Empty;
        private string _XBLNR = string.Empty;
        private decimal _WRBTR = 0;
        private string _WAERS = string.Empty;
        private string _SAT = string.Empty;
        private string _RFC_VENDOR = string.Empty;
        private string _RFC_COMPANY = string.Empty;
        private string _BLDAT = string.Empty;
        private DateTime _FechaDocumento = new DateTime();
        private string _SerFolio = string.Empty;

        private string _BUKRS = string.Empty;
        private byte[] _RES_PDF;

        private string _RFC_VEND = string.Empty;
        private string _RFC_COMP = string.Empty;
        private string _UUID_XML = string.Empty;

        private string _XML = string.Empty;
        private string _PATHFILEPDF = string.Empty;
        private string _GENPDF = string.Empty;

        public string Desc_Error { set; get; }
        public string ECALLECOMP { set; get; }
        public string E_N_EXTCOMP { set; get; }
        public string ECOLCOMP { set; get; }
        public string EMUNI_COMP { set; get; }
        public string ECPCOMP { set; get; }
        public string EPAISCOMP { set; get; }
        public string ECALLEVEND { set; get; }
        public string E_N_EXTVEND { set; get; }
        public string ECOLVEND { set; get; }
        public string EMUNI_VEND { set; get; }
        public string ECPVEND { set; get; }
        public string EPAISVEND { set; get; }
        public string EEDO_COMP { set; get; }
        public string EEDO_VEND { set; get; }
        public string RETENCION { set; get; }
        public string RESSAT { set; get; }

        public string XML
        {
            get { return _XML; }
            set { _XML = value; }
        }

        public string RFC_VEND
        {
            get { return _RFC_VEND; }
            set { _RFC_VEND = value; }
        }

        public string RFC_COMP
        {
            get { return _RFC_COMP; }
            set { _RFC_COMP = value; }
        }

        public string UUID_XML
        {
            get { return _UUID_XML; }
            set { _UUID_XML = value; }
        }

        public string BUKRS
        {
            get { return _BUKRS; }
            set { _BUKRS = value; }
        }

        public string UIDL
        {
            get { return _UIDL; }
            set { _UIDL = value; }
        }
        public string MAIL
        {
            get { return _MAIL; }
            set { _MAIL = value; }
        }
        public string DATUM
        {
            get { return _DATUM; }
            set { _DATUM = value; }
        }
        public string TIME
        {
            get { return _TIME; }
            set { _TIME = value; }
        }
        public string FILE
        {
            get { return _FILE; }
            set { _FILE = value; }
        }
        public string EXT
        {
            get { return _EXT; }
            set { _EXT = value; }
        }
        public string ATTCH
        {
            get { return _ATTCH; }
            set { _ATTCH = value; }
        }
        public string LIFNR
        {
            get { return _LIFNR; }
            set { _LIFNR = value; }
        }
        public string XBLNR
        {
            get { return _XBLNR; }
            set { _XBLNR = value; }
        }
        public decimal WRBTR
        {
            get { return _WRBTR; }
            set { _WRBTR = value; }
        }
        public string WAERS
        {
            get { return _WAERS; }
            set { _WAERS = value; }
        }
        public string SAT
        {
            get { return _SAT; }
            set { _SAT = value; }
        }
        public string RFC_VENDOR
        {
            get { return _RFC_VENDOR; }
            set { _RFC_VENDOR = value; }
        }
        public string RFC_COMPANY
        {
            get { return _RFC_COMPANY; }
            set { _RFC_COMPANY = value; }
        }
        public string BLDAT
        {
            get { return _BLDAT; }
            set { _BLDAT = value; }
        }
        public DateTime FechaDocumento
        {
            get { return _FechaDocumento; }
            set { _FechaDocumento = value; }
        }
        public string SerFolio
        {
            get { return _SerFolio; }
            set { _SerFolio = value; }
        }
        public byte[] RES_PDF
        {
            get { return _RES_PDF; }
            set { _RES_PDF = value; }
        }
        public string SERIE { set; get; }
        public string PATHFILEPDF
        {
            get { return _PATHFILEPDF; }
            set { _PATHFILEPDF = value; }
        }
        public string GENPDF
        {
            get { return _GENPDF; }
            set { _GENPDF = value; }
        }
    }
    public class Relacionados
    {
        private string bUKRS;
        private string rIDDOCUMENTO;
        private string uUID;
        private string fILENAME;
        private decimal rIMPPAGADO;
        private string rFOLIO;
        private string rSERIEDR;
        private string rMONEDADR;
        private string rMETODODEPAGODR;
        private string gJAHR;

        //public string BUKRS = "";
        //public string RIDDOCUMENTO = "";
        //public string UUID = "";
        //public string FILENAME = "";
        //public decimal RIMPPAGADO = 0;
        //public string RFOLIO = "";
        //public string RSERIEDR = "";
        //public string RMONEDADR = "";
        //public string RMETODODEPAGODR = "";
        //public string GJAHR = "";
        public string BUKRS
        {
            get
            {
                return bUKRS;
            }

            set
            {
                bUKRS = value;
            }
        }

        public string RIDDOCUMENTO
        {
            get
            {
                return rIDDOCUMENTO;
            }

            set
            {
                rIDDOCUMENTO = value;
            }
        }

        public string UUID
        {
            get
            {
                return uUID;
            }

            set
            {
                uUID = value;
            }
        }

        public string FILENAME
        {
            get
            {
                return fILENAME;
            }

            set
            {
                fILENAME = value;
            }
        }

        public decimal RIMPPAGADO
        {
            get
            {
                return rIMPPAGADO;
            }

            set
            {
                rIMPPAGADO = value;
            }
        }

        public string RFOLIO
        {
            get
            {
                return rFOLIO;
            }

            set
            {
                rFOLIO = value;
            }
        }

        public string RSERIEDR
        {
            get
            {
                return rSERIEDR;
            }

            set
            {
                rSERIEDR = value;
            }
        }

        public string RMONEDADR
        {
            get
            {
                return rMONEDADR;
            }

            set
            {
                rMONEDADR = value;
            }
        }

        public string RMETODODEPAGODR
        {
            get
            {
                return rMETODODEPAGODR;
            }

            set
            {
                rMETODODEPAGODR = value;
            }
        }

        public string GJAHR
        {
            get
            {
                return gJAHR;
            }

            set
            {
                gJAHR = value;
            }
        }

        public Relacionados(string bUKRS, string rIDDOCUMENTO, string uUID, string fILENAME, decimal rIMPPAGADO, string rFOLIO, string rSERIEDR, string rMONEDADR, string rMETODODEPAGODR, string gJAHR)
        {
            BUKRS = bUKRS;
            RIDDOCUMENTO = rIDDOCUMENTO;
            UUID = uUID;
            FILENAME = fILENAME;
            RIMPPAGADO = rIMPPAGADO;
            RFOLIO = rFOLIO;
            RSERIEDR = rSERIEDR;
            RMONEDADR = rMONEDADR;
            RMETODODEPAGODR = rMETODODEPAGODR;
            GJAHR = gJAHR;
        }
    }
}
