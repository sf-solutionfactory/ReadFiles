using ReadFilesConfig;
using ReadMail.IEntities;
using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP_CNX = ReadFilesConfig.SAP_CNX;

namespace ReadFiles.IPersistence
{
    class DataLayer
    {

        public int SAVE_MAIL_DATA(List<MAIL_DATA_BE> mail_data, SharedSettings.Settings settings)
        {
            try
            {
                //Establecemos conexion con SAP
                RfcConfigParameters rfc = SAP_Connection.GetParameters(settings);

                RfcDestination rfcDest = null;
                rfcDest = RfcDestinationManager.GetDestination(rfc);

                //Creamos repositorio para la función
                RfcRepository repo = rfcDest.Repository;
                IRfcFunction save_mail = repo.CreateFunction("Z_MAIL_SAVE");

                IRfcTable p_maildata = save_mail.GetTable("P_MAILDATA");
                get_maildata_saptab(mail_data, ref p_maildata);

                save_mail.Invoke(rfcDest);

                IRfcStructure bapiret = save_mail.GetStructure("BAPIRET");

                //Ejecutamos la consulta
                //save_mail.Invoke(rfcDest);

                //Revisamos que la consulta haya sido exitosa
                if (bapiret.GetString("TYPE") == "E")
                {
                    return 4; //Hubo un error
                }
                else
                {
                    return 0; //Guardado exitoso
                }
            }
            catch (RfcCommunicationException e)
            {
                throw e;
            }
            catch (RfcLogonException e)
            {
                // user could not logon...
                throw e;
            }
            catch (RfcAbapRuntimeException e)
            {
                // serious problem on ABAP system side...
                throw e;
            }
            catch (RfcAbapBaseException e)
            {
                // The function module returned an ABAP exception, an ABAP message
                // or an ABAP class-based exception...
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public string SAVE_MAIL_DATA(MAIL_DATA_BE mail_data, List<Attachment_BE> attachs, List<Relacionados> relacionados, SharedSettings.Settings settings)
        {
            byte[] pdf;
            try
            {
                //Establecemos conexion con SAP
                RfcConfigParameters rfc = SAP_Connection.GetParameters(settings);

                RfcDestination rfcDest = null;
                rfcDest = RfcDestinationManager.GetDestination(rfc);

                //Creamos repositorio para la función
                RfcRepository repo = rfcDest.Repository;
                IRfcFunction save_mail = repo.CreateFunction("Z_MAIL_SAVE");


                IRfcStructure p_maildata = save_mail.GetStructure("P_MAILDATA");
                IRfcTable p_attachments = save_mail.GetTable("P_ATTACHMENTS");
                get_maildata_sapstr(mail_data, ref p_maildata);
                get_mailattach_saptab(attachs, ref p_attachments, settings.sap_name);

                if (!settings.sap_name.Contains("POLY"))    //ADD SF RSG 14.07.2022
                {
                    IRfcTable p_relacionados = save_mail.GetTable("P_RELACIONADOS");
                    get_relacionados_saptab(relacionados, ref p_relacionados);
                }

                //Ejecutamos la consulta
                save_mail.Invoke(rfcDest);

                if (!settings.sap_name.Contains("POLY"))   //ADD SF RSG 14.07.2022
                {
                    pdf = save_mail.GetByteArray("FILEPDFGEN");
                }
                else   //ADD SF RSG 14.07.2022
                {
                    pdf = new byte[0];
                }
                IRfcStructure bapiret = save_mail.GetStructure("BAPIRET");
                //string res = save_mail.GetString("MSG");

                //Revisamos que la consulta haya sido exitosa
                if (pdf.Length > 0 && String.IsNullOrEmpty(attachs[0].PATHFILEPDF) == false)
                {
                    if (System.IO.File.Exists(attachs[0].PATHFILEPDF) == false)
                        System.IO.File.WriteAllBytes(attachs[0].PATHFILEPDF, pdf);
                }
                if (bapiret.GetString("TYPE") == "E")
                {
                    string mensajeError = bapiret.GetString("MESSAGE");
                    return mensajeError; //Hubo un error
                }
                else
                {
                    return ""; //Guardado exitoso
                }
            }
            catch (RfcCommunicationException e)
            {
                throw e;
            }
            catch (RfcLogonException e)
            {
                // user could not logon...
                throw e;
            }
            catch (RfcAbapRuntimeException e)
            {
                // serious problem on ABAP system side...
                throw e;
            }
            catch (RfcAbapBaseException e)
            {
                // The function module returned an ABAP exception, an ABAP message
                // or an ABAP class-based exception...
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Attachment_BE VALIDATE_XML(ref Attachment_BE attach, string metodoPago, SharedSettings.Settings settings)
        {
            try
            {
                //Establecemos conexion con SAP
                RfcConfigParameters rfc = SAP_Connection.GetParameters(settings);

                RfcDestination rfcDest = null;
                rfcDest = RfcDestinationManager.GetDestination(rfc);

                //Creamos repositorio para la función
                RfcRepository repo = rfcDest.Repository;
                IRfcFunction validate_mail = repo.CreateFunction("Z_MAIL_VALIDATE_DATA");

                validate_mail.SetValue("P_RFC_VENDOR", attach.RFC_VEND);
                validate_mail.SetValue("P_RFC_COMPANY", attach.RFC_COMP);
                validate_mail.SetValue("P_MET_PAGO", metodoPago);
                //Ejecutamos la consulta
                validate_mail.Invoke(rfcDest);

                attach.RFC_COMPANY = validate_mail.GetString("ERFC_COMPANY");
                attach.RFC_VENDOR = validate_mail.GetString("ERFC_VENDOR");
                attach.LIFNR = validate_mail.GetString("ELIFNR");
                attach.BUKRS = validate_mail.GetString("EBUKRS");

                //attach.ECALLECOMP = validate_mail.GetString("ECALLECOMP");
                //attach.E_N_EXTCOMP = validate_mail.GetString("E_N_EXTCOMP");
                //attach.ECOLCOMP = validate_mail.GetString("ECOLCOMP");
                //attach.EMUNI_COMP = validate_mail.GetString("EMUNI_COMP");
                //attach.ECPCOMP = validate_mail.GetString("ECPCOMP");
                //attach.EPAISCOMP = validate_mail.GetString("EPAISCOMP");
                //attach.ECALLEVEND = validate_mail.GetString("ECALLEVEND");
                //attach.E_N_EXTVEND = validate_mail.GetString("E_N_EXTVEND");
                //attach.ECOLVEND = validate_mail.GetString("ECOLVEND");
                //attach.EMUNI_VEND = validate_mail.GetString("EMUNI_VEND");
                //attach.ECPVEND = validate_mail.GetString("ECPVEND");
                //attach.EPAISVEND = validate_mail.GetString("EPAISVEND");
                //attach.EEDO_COMP = validate_mail.GetString("EEDO_COMP");
                //attach.EEDO_VEND = validate_mail.GetString("EEDO_VEND");
                attach.Desc_Error = attach.Desc_Error + validate_mail.GetString("E_MET_PAGO");


                return attach;
            }
            catch (RfcCommunicationException e)
            {
                throw e;
            }
            catch (RfcLogonException e)
            {
                // user could not logon...
                throw e;
            }
            catch (RfcAbapRuntimeException e)
            {
                // serious problem on ABAP system side...
                throw e;
            }
            catch (RfcAbapBaseException e)
            {
                // The function module returned an ABAP exception, an ABAP message
                // or an ABAP class-based exception...
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int VALIDATE_MAIL(string UIDL, SharedSettings.Settings settings)
        {
            string value = string.Empty;
            try
            {
                //Establecemos conexion con SAP
                RfcConfigParameters rfc = SAP_Connection.GetParameters(settings);

                RfcDestination rfcDest = null;
                rfcDest = RfcDestinationManager.GetDestination(rfc);

                //Creamos repositorio para la función
                RfcRepository repo = rfcDest.Repository;
                IRfcFunction validate_mail = repo.CreateFunction("Z_MAIL_VALIDATE");


                validate_mail.SetValue("UIDL", UIDL);

                //Ejecutamos la consulta
                validate_mail.Invoke(rfcDest);

                IRfcStructure ret = validate_mail.GetStructure("RETURN");
                value = ret.GetValue("NUMBER").ToString();
                if (value == "004")
                {
                    //Encontró correo previamente guardado
                    return 0;
                }
                else
                {
                    //No encontró correo return
                    return 4;
                }

            }
            catch (RfcCommunicationException e)
            {
                throw e;
            }
            catch (RfcLogonException e)
            {
                // user could not logon...
                throw e;
            }
            catch (RfcAbapRuntimeException e)
            {
                // serious problem on ABAP system side...
                throw e;
            }
            catch (RfcAbapBaseException e)
            {
                // The function module returned an ABAP exception, an ABAP message
                // or an ABAP class-based exception...
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #region NET->SAP
        public static IRfcTable get_maildata_saptab(List<MAIL_DATA_BE> mail_data, ref IRfcTable p_maildata)
        {

            foreach (MAIL_DATA_BE mail in mail_data)
            {
                //Create new row
                p_maildata.Append();

                //Append values
                p_maildata.SetValue("MAIL", mail.MAIL);
                p_maildata.SetValue("DATUM", mail.DATUM);
                p_maildata.SetValue("TIME", mail.TIME);
                p_maildata.SetValue("FILES", mail.FILES);
                p_maildata.SetValue("SUBJECT", mail.SUBJECT);
                p_maildata.SetValue("CONTA", mail.CONTA);

            }

            return p_maildata;

        }
        public void get_maildata_sapstr(MAIL_DATA_BE mail, ref IRfcStructure p_maildata)
        {
            p_maildata.SetValue("UIDL", mail.UIDL);
            p_maildata.SetValue("MAIL", mail.MAIL);
            p_maildata.SetValue("DATUM", mail.DATUM);
            p_maildata.SetValue("ZTIME", mail.TIME);
            p_maildata.SetValue("FILES", mail.FILES);
            p_maildata.SetValue("SUBJECT", mail.SUBJECT);
            p_maildata.SetValue("CONTA", mail.CONTA);
        }
        public static void get_mailattach_saptab(List<Attachment_BE> attachs, ref IRfcTable p_attach, string sap_name)
        {
            if (attachs.Count > 0)
            {
                foreach (Attachment_BE a in attachs)
                {
                    //New row
                    p_attach.Append();

                    p_attach.SetValue("UIDL", a.UIDL);
                    p_attach.SetValue("MAIL", a.MAIL);
                    p_attach.SetValue("DATUM", a.DATUM);
                    p_attach.SetValue("TIME", a.TIME);
                    p_attach.SetValue("FILENAME", a.FILE);
                    p_attach.SetValue("EXT", a.EXT);
                    p_attach.SetValue("ATTACH", a.ATTCH);
                    p_attach.SetValue("LIFNR", a.LIFNR);
                    p_attach.SetValue("XBLNR", a.XBLNR);
                    p_attach.SetValue("WRBTR", a.WRBTR);
                    p_attach.SetValue("WAERS", a.WAERS);
                    p_attach.SetValue("SAT", a.SAT);
                    p_attach.SetValue("RFC_VENDOR", a.RFC_VENDOR);
                    p_attach.SetValue("RFC_COMPANY", a.RFC_COMPANY);
                    p_attach.SetValue("BLDAT", a.BLDAT);
                    p_attach.SetValue("FOLIO", a.SerFolio);
                    p_attach.SetValue("BUKRS", a.BUKRS);
                    p_attach.SetValue("RFC_VEND", a.RFC_VEND);
                    p_attach.SetValue("RFC_COMP", a.RFC_COMP);
                    p_attach.SetValue("UUID_XML", a.UUID_XML);
                    p_attach.SetValue("XML", a.XML);
                    p_attach.SetValue("Desc_Error", a.Desc_Error);
                    p_attach.SetValue("RETENCION", a.RETENCION);
                    p_attach.SetValue("RESSAT", a.RESSAT);
                    p_attach.SetValue("RES_PDF", a.RES_PDF);
                    if (!sap_name.Contains("POLY"))    //ADD SF RSG 14.07.2022
                    {
                        p_attach.SetValue("GENPDF", a.GENPDF);
                    }
                }
            }
        }
        public static void get_relacionados_saptab(List<Relacionados> relacionados, ref IRfcTable p_relacionados)
        {
            if (relacionados.Count > 0)
            {
                for (int i = 0; i < relacionados.Count; i++)
                {
                    p_relacionados.Append();
                    p_relacionados.SetValue("BUKRS", relacionados[i].BUKRS);
                    p_relacionados.SetValue("RIDDOCUMENTO", relacionados[i].RIDDOCUMENTO);
                    p_relacionados.SetValue("UUID", relacionados[i].UUID);
                    p_relacionados.SetValue("FILENAME", relacionados[i].FILENAME);
                    p_relacionados.SetValue("RIMPPAGADO", relacionados[i].RIMPPAGADO);
                    p_relacionados.SetValue("RFOLIO", relacionados[i].RFOLIO);
                    p_relacionados.SetValue("RSERIEDR", relacionados[i].RSERIEDR);
                    p_relacionados.SetValue("RMONEDADR", relacionados[i].RMONEDADR);
                    p_relacionados.SetValue("RMETODODEPAGODR", relacionados[i].RMETODODEPAGODR);
                    p_relacionados.SetValue("GJAHR", relacionados[i].GJAHR);
                }
            }
        }
        #endregion
    }
}
