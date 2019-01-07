using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFilesConfig
{
    public class MySettings
    {
        public string rutaWinrar
        { get; set; }

        public string mail
        { get; set; }

        public string pass
        { get; set; }

        public string mail_type
        { get; set; }

        public bool ssl
        { get; set; }

        public string port
        { get; set; }

        public string server
        { get; set; }

        public string file_path
        { get; set; }

        public string sap_user
        { get; set; }

        public string sap_pass
        { get; set; }

        public string sap_host
        { get; set; }

        public string sap_sysnumber
        { get; set; }

        public string sap_name
        { get; set; }

        public string sap_client
        { get; set; }

        public bool save_mail
        { get; set; }

        public string carpeta_mail
        { get; set; }

        public string carpeta_xml
        { get; set; }

        public bool delete_files_at_attach
        { get; set; }

        public bool delete_mail_from_server
        { get; set; }

        public string company_code
        { get; set; }

        public string esCorreo
        { get; set; }

        public string esDirectorio
        { get; set; }

        public string prioridad
        { get; set; }

        public string directorioExtra
        { get; set; }

        public string directoriolog
        { get; set; }

        public string directorioCtes
        { get; set; }

        public bool esActivoDirProv
        { get; set; }

        public bool esActivoDirCtes
        { get; set; }

        public string SAPRouter
        { get; set; }

        public bool esNomina
        { get; set; }

        public string directorioNomina
        { get; set; }

        public bool esActPdfProv
        { get; set; }

        public bool esActPdfClie
        { get; set; }

        public bool esActPdfNomi
        { get; set; }

        public bool esActPdfcorreo
        { get; set; }

        public bool esCTodos
        { get; set; }

        public bool esNLeidos
        { get; set; }

        public bool activa_timer
        { get; set; }

        public string ruta_timer
        { get; set; }

        public string minutos_timer
        { get; set; }

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MySettings"/> class.
    /// </summary>
    public MySettings() : this(false)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MySettings"/> class.
    /// </summary>
    /// <param name="initializeValues">if set to <c>true</c> [initialize values].</param>
    public MySettings(bool initializeValues)
    {
        // Initialize  
        mail = "";
        mail_type = "";
        server = "";
        port = "";
        ssl = false;
        pass = "";

        sap_client = "";
        sap_host = "";
        sap_name = "";
        sap_pass = "";
        sap_sysnumber = "";
        sap_user = "";

        save_mail = false;
        carpeta_mail = "";
        carpeta_xml = "";

        delete_files_at_attach = true;
        delete_mail_from_server = false;

        company_code = "";

        esCorreo = "";
        esDirectorio = "";
        prioridad = "";
        directorioExtra = "";
        directoriolog = "";

        directorioCtes = "";
        esActivoDirCtes = false;
        esActivoDirProv = false;
        esActivoDirPagos = false;

        SAPRouter = "";

        esNomina = false;
        directorioNomina = "";

        esActPdfProv = false;
        esActPdfClie = false;
        esActPdfNomi = false;
        esActPdfPagos = false;
        esActPdfcorreo = false;

        esCTodos = false;
        esNLeidos = false;

    }

    public bool chkprov_ok
    { get; set; }

    public bool chkclient_ok
    { get; set; }

    public bool chknom_ok
    { get; set; }

    public bool chkpag_ok
    { get; set; }

    public string prov_ok
    { get; set; }

    public string client_ok
    { get; set; }

    public string nom_ok
    { get; set; }

    public string pag_ok
    { get; set; }

    public bool chkprov_notok
    { get; set; }

    public bool chkclient_notok
    { get; set; }

    public bool chknom_notok
    { get; set; }

    public bool chkpag_notok
    { get; set; }

    public string prov_Notok
    { get; set; }

    public string client_Notok
    { get; set; }

    public string nom_Notok
    { get; set; }

    public string pag_Notok
    { get; set; }
}
}

}
