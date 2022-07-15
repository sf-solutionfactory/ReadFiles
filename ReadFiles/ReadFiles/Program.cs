using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using ReadFiles.IPersistence;
using ReadMail.IEntities;
using SharedSettings;
//using SW.Services.Status;
//using SAT.Services.ConsultaCFDIService;
using ReadFiles.mx.gob.sat.facturaelectronica.consultaqr;

namespace ReadFiles
{
    class Program
    {
        static Settings settings = new Settings();
        static string direlog;
        //static Status status = new Status("https://consultaqr.facturaelectronica.sat.gob.mx/ConsultaCFDIService.svc");
        static Acuse response = new Acuse();
        static void Main(string[] args)
        {
            settings = AppSettings.getConfig(settings);
            CrearLog();
            MostrarMensajeConsola("Inicio");
            MostrarMensajeConsola("Configuracion Cargada");
            if (settings.prox_act)
            {
                Proxy();
            }
            if (settings.esActivoDirProv || settings.esActivoDirCtes || settings.esActivoNomina)
            {
                CargarArchivos();
            }
            MostrarMensajeConsola("Fin.");
        }
        private static void CargarArchivos()
        {
            FileInfo[] listfilesxml;
            FileInfo[] listfilespdf;
            DirectoryInfo directory;
            MostrarMensajeConsola("Cargando archivos");
            if (String.IsNullOrEmpty(settings.directorioProv) == false && settings.esActivoDirProv)
            {
                MostrarMensajeConsola("Cargando Proveedores");
                directory = new DirectoryInfo(settings.directorioProv);
                listfilesxml = directory.GetFiles("*.*", SearchOption.AllDirectories).Where(x => x.Extension == ".XML" || x.Extension == ".xml").ToArray();
                listfilespdf = directory.GetFiles("*.*", SearchOption.AllDirectories).Where(x => x.Extension == ".PDF" || x.Extension == ".pdf").ToArray();
                Procesar(listfilesxml, listfilespdf, "P");
            }
            else
            {
                MostrarMensajeConsola("No se agrego directorio de facturas de Proveedor o Carga Proveedor desactivado");
            }
            if (String.IsNullOrEmpty(settings.directorioCtes) == false && settings.esActivoDirCtes)
            {
                MostrarMensajeConsola("Cargando Clientes");
                directory = new DirectoryInfo(settings.directorioCtes);
                listfilesxml = directory.GetFiles("*.*", SearchOption.AllDirectories).Where(x => x.Extension == ".XML" || x.Extension == ".xml").ToArray();
                listfilespdf = directory.GetFiles("*.*", SearchOption.AllDirectories).Where(x => x.Extension == ".PDF" || x.Extension == ".pdf").ToArray();
                Procesar(listfilesxml, listfilespdf, "C");
            }
            else
            {
                MostrarMensajeConsola("No se agrego directorio de facturas de Clientes o Carga Clientes desactivado");
            }
            if (String.IsNullOrEmpty(settings.directorioNomina) == false && settings.esActivoNomina)
            {
                MostrarMensajeConsola("Cargando Nomina");
                directory = new DirectoryInfo(settings.directorioNomina);
                listfilesxml = directory.GetFiles("*.*", SearchOption.AllDirectories).Where(x => x.Extension == ".XML" || x.Extension == ".xml").ToArray();
                listfilespdf = directory.GetFiles("*.*", SearchOption.AllDirectories).Where(x => x.Extension == ".PDF" || x.Extension == ".pdf").ToArray();
                Procesar(listfilesxml, listfilespdf, "C");
            }
            else
            {
                MostrarMensajeConsola("No se agrego directorio de facturas de Nomina Carga Nomina desactivado");
            }
        }
        private static void Procesar(FileInfo[] fileInfosxml, FileInfo[] fileInfospdf, string clase)
        {
            XmlDocument xmlobj = new XmlDocument();
            TimbreFiscalDigital timbre = new TimbreFiscalDigital();
            Comprobante comprobante = new Comprobante();
            Comprobante2 comprobante2 = new Comprobante2();
            //Comprobante40 comprobante40 = new Comprobante40();
            Comprobante4 comprobante4 = new Comprobante4();
            Nomina nomina = new Nomina();
            XmlSerializer serializer;
            Pagos pagos = new Pagos();
            DataLayer dataLayer = new DataLayer();
            Attachment_BE attach = new Attachment_BE();
            List<Attachment_BE> attachments = new List<Attachment_BE>();
            List<Relacionados> relacionados = new List<Relacionados>();
            string xml = "";
            bool errorxml = false;
            MostrarMensajeConsola("Se encontraron " + fileInfosxml.Length + "XML y " + fileInfospdf.Length + " PDFs");
            for (int i = 0; i < fileInfosxml.Length; i++)
            {
                MostrarLinea("*");
                MostrarMensajeConsola((i + 1) + " de " + fileInfosxml.Length);
                MostrarMensajeConsola(fileInfosxml[i].Name);
                xmlobj.Load(new MemoryStream(cargaArch(fileInfosxml[i].Name, fileInfosxml, false)));
                attach.XML = xml = xmlobj.InnerXml;
                if (xml.Contains("Version=\"4.0\""))
                {
                    //serializer = new XmlSerializer(typeof(Comprobante40));
                    //comprobante40 = (Comprobante40)serializer.Deserialize(new StringReader(xml));
                    xml = xml.Replace("Comprobante", "Comprobante4");
                    serializer = new XmlSerializer(typeof(Comprobante4));
                    comprobante4 = (Comprobante4)serializer.Deserialize(new StringReader(xml));
                    serializer = new XmlSerializer(typeof(TimbreFiscalDigital));
                    timbre = (TimbreFiscalDigital)serializer.Deserialize(
                        new StringReader(comprobante4.Complemento[0].Any.Where(x => x.LocalName == "TimbreFiscalDigital").Select(x => x.OuterXml).ToArray()[0]));
                    attach.Desc_Error = EstatusCFDI(comprobante4.Emisor.Rfc, comprobante4.Receptor.Rfc, comprobante4.Total.ToString(), timbre.UUID
                                                    , comprobante4.Sello.Substring(comprobante4.Sello.Length-8,8));
                    attach.WRBTR = decimal.Round(comprobante4.Total, 2);

                    if (clase == "P")
                    {
                        attach.EXT = "XML";
                        if (xml.Contains("pago10:Pagos"))
                        {
                            serializer = new XmlSerializer(typeof(Pagos));
                            pagos = (Pagos)serializer.Deserialize(
                                new StringReader(comprobante4.Complemento[0].Any.Where(x => x.LocalName == "Pagos").Select(x => x.OuterXml).ToArray()[0]));
                            attach.WRBTR = decimal.Round(pagos.Pago.Sum(x => x.Monto), 2);
                        }
                    }
                    else if (clase == "C")
                    {
                        attach.EXT = "CTE";
                        if (xml.Contains("nomina12:Nomina"))
                        {
                            serializer = new XmlSerializer(typeof(Nomina));
                            nomina = (Nomina)serializer.Deserialize(
                                new StringReader(comprobante4.Complemento[0].Any.Where(x => x.LocalName == "Nomina").Select(x => x.OuterXml).ToArray()[0]));
                            attach.EXT = "NOM";
                        }
                    }
                    if (comprobante4.Impuestos != null)
                    {
                        if (comprobante4.Impuestos.TotalImpuestosRetenidos != 0)
                        {
                            attach.RETENCION = "X";
                        }
                    }
                    attach.RFC_VENDOR = "X";
                    attach.RFC_COMPANY = "X";
                    attach.WAERS = comprobante4.Moneda;
                    attach.FechaDocumento = comprobante4.Fecha;
                    attach.SerFolio = comprobante4.Serie + " " + comprobante4.Folio;
                    attach.BLDAT = FechaFormatoSAP(comprobante4.Fecha);
                    attach.FILE = fileInfosxml[i].Name;
                    attach.RFC_VEND = comprobante4.Emisor.Rfc;
                    attach.RFC_COMP = comprobante4.Receptor.Rfc;
                    attach.XBLNR = comprobante4.Serie + comprobante4.Folio;
                    attach.UUID_XML = timbre.UUID.ToUpper();
                    if (clase == "P")
                    {
                        try
                        {
                            dataLayer.VALIDATE_XML(ref attach, comprobante4.MetodoPago, settings);
                        }
                        catch (Exception e)
                        {
                            errorxml = true;
                            //MostrarMensajeConsola(e.Message, false);
                        }
                    }
                    relacionados.Clear();

                    if (pagos.Pago != null)
                    {
                        for (int j = 0; j < pagos.Pago.Length; j++)
                        {
                            if (pagos.Pago[j].DoctoRelacionado != null)
                            {
                                foreach (var relacionado in pagos.Pago[j].DoctoRelacionado)
                                {
                                    if (relacionados.Exists(x => x.UUID == relacionado.IdDocumento.ToUpper()) == false)
                                    {
                                        relacionados.Add(new Relacionados(
                                        attach.BUKRS,
                                        timbre.UUID.ToUpper(),
                                        relacionado.IdDocumento.ToUpper(),
                                        fileInfosxml[i].Name,
                                        relacionado.ImpPagado,
                                        relacionado.Folio,
                                        relacionado.Serie,
                                        relacionado.MonedaDR.ToString(),
                                        relacionado.MetodoDePagoDR.ToString(),
                                        ""
                                        ));
                                    }
                                }

                            }
                            else
                            {
                                errorxml = true;
                                MostrarMensajeConsola("Coprobante de pago tiene estructura incorrecta");
                                break;
                            }
                        }
                    }
                    pagos = new Pagos();
                }
                else if (xml.Contains("Version=\"3.3\""))
                {
                    serializer = new XmlSerializer(typeof(Comprobante));
                    comprobante = (Comprobante)serializer.Deserialize(new StringReader(xml));
                    serializer = new XmlSerializer(typeof(TimbreFiscalDigital));
                    timbre = (TimbreFiscalDigital)serializer.Deserialize(
                        new StringReader(comprobante.Complemento[0].Any.Where(x => x.LocalName == "TimbreFiscalDigital").Select(x => x.OuterXml).ToArray()[0]));
                    attach.Desc_Error = EstatusCFDI(comprobante.Emisor.Rfc, comprobante.Receptor.Rfc, comprobante.Total.ToString(), timbre.UUID
                                                    , comprobante.Sello.Substring(comprobante.Sello.Length - 8, 8));
                    attach.WRBTR = decimal.Round(comprobante.Total, 2);
                    if (clase == "P")
                    {
                        attach.EXT = "XML";
                        if (xml.Contains("pago10:Pagos"))
                        {
                            serializer = new XmlSerializer(typeof(Pagos));
                            pagos = (Pagos)serializer.Deserialize(
                                new StringReader(comprobante.Complemento[0].Any.Where(x => x.LocalName == "Pagos").Select(x => x.OuterXml).ToArray()[0]));
                            attach.WRBTR = decimal.Round(pagos.Pago.Sum(x => x.Monto), 2);
                        }
                    }
                    else if (clase == "C")
                    {
                        attach.EXT = "CTE";
                        if (xml.Contains("nomina12:Nomina"))
                        {
                            serializer = new XmlSerializer(typeof(Nomina));
                            nomina = (Nomina)serializer.Deserialize(
                                new StringReader(comprobante.Complemento[0].Any.Where(x => x.LocalName == "Nomina").Select(x => x.OuterXml).ToArray()[0]));
                            attach.EXT = "NOM";
                        }
                    }
                    if (comprobante.Impuestos != null)
                    {
                        if (comprobante.Impuestos.TotalImpuestosRetenidos != 0)
                        {
                            attach.RETENCION = "X";
                        }
                    }
                    attach.RFC_VENDOR = "X";
                    attach.RFC_COMPANY = "X";
                    attach.WAERS = comprobante.Moneda;
                    attach.FechaDocumento = comprobante.Fecha;
                    attach.SerFolio = comprobante.Serie + " " + comprobante.Folio;
                    attach.BLDAT = FechaFormatoSAP(comprobante.Fecha);
                    attach.FILE = fileInfosxml[i].Name;
                    attach.RFC_VEND = comprobante.Emisor.Rfc;
                    attach.RFC_COMP = comprobante.Receptor.Rfc;
                    attach.XBLNR = comprobante.Serie + comprobante.Folio;
                    attach.UUID_XML = timbre.UUID.ToUpper();
                    if (clase == "P")
                    {
                        try
                        {
                            dataLayer.VALIDATE_XML(ref attach, comprobante.MetodoPago, settings);
                        }
                        catch (Exception e)
                        {
                            errorxml = true;
                            //MostrarMensajeConsola(e.Message, false);
                        }
                    }
                    relacionados.Clear();
                    if (pagos.Pago != null)
                    {
                        for (int j = 0; j < pagos.Pago.Length; j++)
                        {
                            if (pagos.Pago[j].DoctoRelacionado != null)
                            {
                                foreach (var relacionado in pagos.Pago[j].DoctoRelacionado)
                                {
                                    if (relacionados.Exists(x => x.UUID == relacionado.IdDocumento.ToUpper()) == false)
                                    {
                                        relacionados.Add(new Relacionados(
                                        attach.BUKRS,
                                        timbre.UUID.ToUpper(),
                                        relacionado.IdDocumento.ToUpper(),
                                        fileInfosxml[i].Name,
                                        relacionado.ImpPagado,
                                        relacionado.Folio,
                                        relacionado.Serie,
                                        relacionado.MonedaDR.ToString(),
                                        relacionado.MetodoDePagoDR.ToString(),
                                        ""
                                        ));
                                    }
                                }

                            }
                            else
                            {
                                errorxml = true;
                                MostrarMensajeConsola("Coprobante de pago tiene estructura incorrecta");
                                break;
                            }
                        }
                    }
                    pagos = new Pagos();
                }
                else if (xml.Contains("Version=\"3.2\""))
                {
                    serializer = new XmlSerializer(typeof(Comprobante2));
                    comprobante2 = (Comprobante2)serializer.Deserialize(new StringReader(xml));
                    serializer = new XmlSerializer(typeof(TimbreFiscalDigital));
                    timbre = (TimbreFiscalDigital)serializer.Deserialize(new StringReader(comprobante.Complemento[0].ToString()));
                    //attach.Desc_Error = EstatusCFDI(comprobante2.Emisor.rfc, comprobante2.Receptor.rfc, comprobante2.total.ToString(), timbre.UUID
                    //                                , comprobante2.Sello.Substring(comprobante2.Sello.Length - 8, 8));
                    if (comprobante2.Impuestos.totalImpuestosRetenidos != 0)
                    {
                        attach.RETENCION = "X";
                    }
                    attach.EXT = "XML";
                    attach.RFC_VENDOR = comprobante2.Emisor.rfc;
                    attach.RFC_COMPANY = comprobante2.Receptor.rfc;
                    attach.WRBTR = decimal.Round(comprobante2.total, 2);
                    attach.WAERS = comprobante2.Moneda;
                    attach.FechaDocumento = comprobante2.fecha;
                    attach.SerFolio = comprobante2.serie + " " + comprobante2.folio;
                    attach.BLDAT = FechaFormatoSAP(comprobante2.fecha);
                    attach.FILE = fileInfosxml[i].Name;
                    attach.RFC_VEND = comprobante2.Emisor.rfc;
                    attach.RFC_COMP = comprobante2.Receptor.rfc;
                    attach.XBLNR = comprobante2.serie + comprobante2.folio;
                    attach.UUID_XML = timbre.UUID.ToUpper();
                    if (clase == "P")
                    {
                        try
                        {
                            dataLayer.VALIDATE_XML(ref attach, comprobante2.metodoDePago, settings);
                        }
                        catch (Exception e)
                        {
                            errorxml = true;
                            //MostrarMensajeConsola(e.Message, false);
                        }
                    }
                }
                if (attach.Desc_Error.Contains("Vigente"))
                {
                    attach.SAT = "X";
                    attach.RES_PDF = cargaArch(fileInfosxml[i].Name, fileInfospdf, true);
                }
                else
                {
                    attach.XML = "";
                }

                if (attach.RFC_COMPANY == "" && attach.RFC_VENDOR == "")
                {
                    attach.Desc_Error = attach.Desc_Error + "<@>" + "El RFC de la empresa y proveedor son incorrectos";
                    MostrarMensajeConsola("El RFC de la empresa y proveedor son incorrectos");
                }
                else
                {
                    if (attach.RFC_COMPANY == "")
                    {
                        attach.Desc_Error = attach.Desc_Error + "<@>" + "El RFC de la empresa es incorrecto";
                        MostrarMensajeConsola("El RFC de la empresa es incorrecto");
                    }
                    if (attach.RFC_VENDOR == "")
                    {
                        attach.Desc_Error = attach.Desc_Error + "<@>" + "El RFC del proveedor es incorrecto";
                    }
                }
                if (attach.XML != "")
                {
                    MAIL_DATA_BE mail_data = new MAIL_DATA_BE();
                    attachments.Add(attach);
                    string r = "";
                    if (errorxml == false)
                    {
                        try
                        {
                            r = dataLayer.SAVE_MAIL_DATA(mail_data, attachments, relacionados, settings);
                        }
                        catch (Exception e)
                        {
                            errorxml = true;
                            //MostrarMensajeConsola(e.Message, false);
                        }
                    }
                    if (errorxml == false)
                    {
                        MostrarMensajeConsola("Información guardada en SAP");
                        Mover(fileInfosxml[i], attach.EXT, true);
                        if (fileInfospdf.Length > 0)
                        {
                            FileInfo info = fileInfospdf.Where(x => x.Name.Substring(0, x.Name.Length - 4) == (fileInfosxml[i].Name.Substring(0, (fileInfosxml[i].Name.Length - 4)))).SingleOrDefault();
                            if (info != null)
                            {
                                Mover(info, attach.EXT, true);
                            }
                        }
                    }
                    else
                    {
                        MostrarMensajeConsola(r);
                        Mover(fileInfosxml[i], attach.EXT, false);
                        if (fileInfospdf.Length > 0)
                        {
                            FileInfo info = fileInfospdf.Where(x => x.Name.Substring(0, x.Name.Length - 4) == (fileInfosxml[i].Name.Substring(0, (fileInfosxml[i].Name.Length - 4)))).SingleOrDefault();
                            if (info != null)
                            {
                                Mover(info, attach.EXT, false);
                            }
                        }
                    }
                    attachments.Clear();
                }
                else
                {
                    Mover(fileInfosxml[i], attach.EXT, false);
                    if (fileInfospdf.Length > 0)
                    {
                        FileInfo info = fileInfospdf.Where(x => x.Name.Substring(0, x.Name.Length - 4) == (fileInfosxml[i].Name.Substring(0, (fileInfosxml[i].Name.Length - 4)))).SingleOrDefault();
                        if (info != null)
                        {
                            Mover(info, attach.EXT, false);
                        }
                    }
                }
                attach = new Attachment_BE();
                MostrarLinea("*");
                errorxml = false;
            }
        }
        private static string EstatusCFDI(string rfcemisor, string rfcreceptor, string total, string uuid, string sello)
        {
            try
            {
                //response = new Acuse();
                //response = status.GetStatusCFDI(rfcemisor, rfcreceptor, total, uuid);
                ////response.Estado = "Vigente";
                //MostrarMensajeConsola("El XML es " + response.Estado + " según el SAT");
                //return "El XML es " + response.Estado + " según el SAT";
                response = new Acuse();
                ConsultaCFDIService status = new ConsultaCFDIService();
                response = status.Consulta("?re=" + rfcemisor + "&rr=" + rfcreceptor + "&tt=" + total + "&id=" + uuid + "&fe="+ sello);
                //response.Estado = "Vigente";
                MostrarMensajeConsola("El XML es " + response.Estado + " según el SAT");
                return "El XML es " + response.Estado + " según el SAT";
            }
            catch (Exception)
            {
                return "";
            }
        }
        private static void Mover(FileInfo fileInfo, string extencion, bool correcto)
        {
            string pathfolder = "";

            if (correcto)
            {
                switch (extencion)
                {
                    case "XML":
                        if (settings.esActivoProvC && !String.IsNullOrEmpty(settings.directorioProvC))
                        {
                            pathfolder = settings.directorioProvC;
                        }
                        break;
                    case "CTE":
                        if (settings.esActivoCteC && !String.IsNullOrEmpty(settings.directorioCtesC))
                        {
                            pathfolder = settings.directorioCtesC;
                        }
                        break;
                    case "NOM":
                        if (settings.esActivoNomC && !String.IsNullOrEmpty(settings.directorioNomC))
                        {
                            pathfolder = settings.directorioNomC;
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (extencion)
                {
                    case "XML":
                        if (settings.esActivoProvI && !String.IsNullOrEmpty(settings.directorioProvI))
                        {
                            pathfolder = settings.directorioProvI;
                        }
                        break;
                    case "CTE":
                        if (settings.esActivoCteI && !String.IsNullOrEmpty(settings.directorioCtesI))
                        {
                            pathfolder = settings.directorioCtesI;
                        }
                        break;
                    case "NOM":
                        if (settings.esActivoNomI && !String.IsNullOrEmpty(settings.directorioNomI))
                        {
                            pathfolder = settings.directorioNomI;
                        }
                        break;
                    default:
                        break;
                }
            }
            try
            {
                if (!String.IsNullOrEmpty(pathfolder))
                {
                    if (!Directory.Exists(pathfolder))
                    {
                        Directory.CreateDirectory(pathfolder);
                    }
                    File.Move(fileInfo.FullName, pathfolder + "\\" + fileInfo.Name);
                }
            }
            catch (Exception)
            {
                MostrarMensajeConsola("Error al mover a ruta " + pathfolder);
            }
        }
        private static void CrearLog()
        {
            string nombre = "";
            string dirFile = settings.directorioLog;
            DateTime thisDay = DateTime.Now;
            nombre = "Recuperador" + thisDay.ToString();
            nombre = nombre.Replace(':', '-');
            nombre = nombre.Replace('\\', '-');
            nombre = nombre.Replace('/', '-');
            dirFile = dirFile + "\\" + nombre + ".txt";
            try
            {
                System.IO.File.WriteAllText(@dirFile, "RESPUESTAS:");
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@dirFile, true))
                {
                    file.WriteLine(" ");
                    file.Close();
                }

                direlog = @dirFile;
            }
            catch (Exception)
            {
                MostrarMensajeConsola("No fue posible crear el archivo de LOG de la carga de archivos");
                MostrarMensajeConsola("Debe indicar un directorio donde pueda ser creado");
                MostrarMensajeConsola("Pulse enter para salir");
                Console.ReadLine();
                Environment.Exit(0);
            }
            //nombre = "Directorio" + thisDay.ToString();
            //nombre = nombre.Replace(':', '-');
            //nombre = nombre.Replace('\\', '-');
            //nombre = nombre.Replace('/', '-');
            //dirFile = settings.directorioLog;
            //dirFile = dirFile + "\\" + nombre + ".txt";
            //try
            //{
            //    System.IO.File.WriteAllText(@dirFile, "DIRECTORIOS:");
            //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@dirFile, true))
            //    {
            //        file.WriteLine(" ");
            //        file.Close();
            //    }

            //    direlogdir = @dirFile;
            //}
            //catch (Exception)
            //{
            //    MostrarMensajeConsola("No fue posible crear el archivo de LOG de la carga de archivos");
            //    MostrarMensajeConsola("Debe indicar un directorio donde pueda ser creado");
            //    MostrarMensajeConsola("Pulse enter para salir");
            //    Console.ReadLine();
            //    Environment.Exit(0);
            //}
        }
        private static void Proxy()
        {
            WebClient request = new WebClient();
            MostrarMensajeConsola("Conectando...");
            try
            {
                WebProxy myProxy = new WebProxy();
                string url = "http://" + settings.prox_host + ":" + settings.prox_puert;

                Uri newUri = new Uri(url);
                // Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
                myProxy.Address = newUri;
                // Create a NetworkCredential object and associate it with the 
                // Proxy property of request object.
                myProxy.Credentials = new NetworkCredential(settings.prox_user, settings.prox_pass);
                request.Proxy = myProxy;
                //request.DownloadString("https://consultaqr.facturaelectronica.sat.gob.mx/ConsultaCFDIService.svc");
                //request.DownloadString("https://consultaqr.facturaelectronica.sat.gob.mx");
                byte[] vs = request.UploadData("https://consultaqr.facturaelectronica.sat.gob.mx/ConsultaCFDIService.svc", new byte[] { });
                MostrarMensajeConsola("Conectado");
            }
            catch (Exception e)
            {
                MostrarMensajeConsola("Error de proxy: No pudo conectar a internet.");
                Console.WriteLine("Precione Enter para salir");
                Console.ReadLine();
                Environment.Exit(0);

            }
        }
        public static void MostrarMensajeConsola(string mensaje, bool tipo = true)
        {
            try
            {
                int ancho = 0;
                ancho = Console.BufferWidth;
                string inicioMensaje = "[] ", complementoMensaje = " []";
                if (!tipo)
                { inicioMensaje = "<< "; complementoMensaje = " >>"; }
                if (mensaje.Length >= ancho - (inicioMensaje.Length + complementoMensaje.Length))
                {
                    DividirMensaje(mensaje, ancho, complementoMensaje, inicioMensaje);
                }
                else
                {
                    MostrarMensajeFinal(inicioMensaje, mensaje, complementoMensaje, ancho);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(mensaje);
            }
        }
        private static string[] DividirMensaje(string mensaje, int ancho, string complementoMensaje, string inicioMensaje)
        {
            string[] array = new string[2];
            int recortar = ancho - complementoMensaje.Length;
            if (mensaje.Contains('\n'))
            {
                string[] comp = mensaje.Split('\n');
                foreach (string mess in comp)
                {
                    MostrarMensajeFinal(inicioMensaje, mess, complementoMensaje, ancho);
                }
            }
            else
            {
                if (recortar > 0 && mensaje.Length > recortar)
                {
                    array[0] = mensaje.Substring(0, recortar);
                    array[1] = mensaje.Substring(recortar, (mensaje.Length - recortar));
                    MostrarMensajeFinal(inicioMensaje, array[0], complementoMensaje, ancho);
                    //Console.WriteLine(inicioMensaje + array[0] + complementoMensaje);
                    if (array[1].Length >= ancho - (inicioMensaje.Length + complementoMensaje.Length))
                    {
                        DividirMensaje(array[1], ancho, complementoMensaje, inicioMensaje);
                    }
                    else
                    {
                        MostrarMensajeFinal(inicioMensaje, array[1], complementoMensaje, ancho);
                    }
                }
                else
                {
                    array[0] = mensaje;
                    MostrarMensajeFinal(inicioMensaje, array[0], complementoMensaje, ancho);
                }
            }
            return array;
        }
        private static void MostrarMensajeFinal(string inicioMensaje, string mensaje, string complementoMensaje, int ancho)
        {
            string mensajeFinal = inicioMensaje + mensaje;
            string relleno = "";
            int tam = mensajeFinal.Length;
            int rellenar = 0;
            rellenar = ancho - (tam + complementoMensaje.Length);
            for (int i = 0; i < rellenar; i++)
            {
                relleno = relleno + " ";
            }
            string msgShow = inicioMensaje + mensaje + relleno + complementoMensaje;
            Console.WriteLine(msgShow);
            //logs.Add(msgShow);
            string[] text = { msgShow };
            File.AppendAllLines(direlog, text);
        }
        private static string FechaFormatoSAP(DateTime pFecha)
        {
            string Fec_Formateada = "";
            //Fec_Formateada = pFecha.Year + "-" + string.Format("{0:D2}", pFecha.Month) + "-" + string.Format("{0:D2}", pFecha.Day);
            Fec_Formateada = pFecha.Year + string.Format("{0:D2}", pFecha.Month) + string.Format("{0:D2}", pFecha.Day);
            return Fec_Formateada;
        }
        private static byte[] cargaArch(string dirpdf, FileInfo[] fileInfos, bool pdf)
        {
            string direccion = "";
            string nomxml = "";
            if (pdf)
            {
                nomxml = dirpdf.Replace("XML", "PDF").Replace("xml", "pdf");
            }
            else
            {
                nomxml = dirpdf;
            }
            byte[] rawByte = new byte[0];
            if (fileInfos.Length > 0)
            {
                try
                {
                    direccion = fileInfos.Where(x => x.Name == nomxml).Select(x => x.FullName).ToArray()[0];
                }
                catch (Exception) { }

                if (!String.IsNullOrEmpty(direccion))
                {
                    DateTime start;
                    int intentos = 0;
                    while (true)
                    {
                        start = DateTime.Now;
                        while ((DateTime.Now - start).TotalMilliseconds < 2000)
                            System.Windows.Forms.Application.DoEvents();

                        rawByte = GetFile(direccion);
                        if (rawByte.Length > 2 || intentos == 15)
                        {
                            break;
                        }
                        else
                        {
                            intentos++;
                        }
                    }
                    if (rawByte.Length == 0)
                    {
                        MostrarMensajeConsola("No se encontro el archivo pdf en la ruta: " + direccion);
                    }
                }
                else
                {
                    MostrarMensajeConsola("No se encontro archivo PDF");
                }
            }
            else
            {
                MostrarMensajeConsola("No existen archivos PDF");
            }
            return rawByte;
        }
        private static byte[] GetFile(string direccion)
        {
            byte[] response = new byte[0];
            try
            {
                response = File.ReadAllBytes(direccion);
            }
            catch (Exception)
            {

            }
            return response;
        }
        private static void MostrarLinea(string caracter)
        {
            int ancho = 0;
            ancho = Console.BufferWidth;
            string mensaje = "";
            for (int i = 0; i < ancho; i++)
            {
                mensaje = mensaje + caracter;
            }
            Console.WriteLine(mensaje);
            //logs.Add(mensaje);
            string[] text = { mensaje };
            File.AppendAllLines(direlog, text);
        }
    }
}
