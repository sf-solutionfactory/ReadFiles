﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedSettings;

namespace ReadFilesConfig
{
    public partial class Form1 : Form
    {
        Settings settings = new Settings();
        public Form1()
        {
            InitializeComponent();
            CargarConf();
        }
        private void Guardar()
        {
            btnGuardar.Enabled = false;
            settings.sap_name = txtDescripcion.Text;
            settings.sap_host = txtServidor.Text;
            settings.sap_sysnumber = txtInstancia.Text;
            settings.sap_client = txtMandante.Text;
            settings.sap_user = txtUsuario.Text;
            settings.sap_pass = txtCveA.Text;
            settings.SAPRouter = txtRouter.Text;

            settings.esActivoDirCtes = chkCliente.Checked;
            settings.esActivoDirProv = chkProveedor.Checked;
            settings.esActivoNomina = chkNomina.Checked;
            settings.directorioCtes = txtCliente.Text;
            settings.directorioProv = txtProveedor.Text;
            settings.directorioNomina = txtNomina.Text;
            settings.directorioLog = txtLog.Text;

            settings.directorioCtesC = txtClienteC.Text;
            settings.directorioProvC = txtProveedorC.Text;
            settings.directorioNomC = txtNominaC.Text;
            settings.directorioCtesI = txtClienteI.Text;
            settings.directorioProvI = txtProveedorI.Text;
            settings.directorioNomI = txtNominaI.Text;
            settings.esActivoCteC = chkClienteC.Checked;
            settings.esActivoProvC = chkProveedorC.Checked;
            settings.esActivoNomC = chkNominaC.Checked;
            settings.esActivoCteI = chkClienteI.Checked;
            settings.esActivoProvI = chkProveedorI.Checked;
            settings.esActivoNomI = chkNominaI.Checked;

            settings.prox_act = chkProxy.Checked;
            settings.prox_host = txtIPProxy.Text;
            settings.prox_puert = Convert.ToInt32(txtPuerProxy.Text);
            settings.prox_user = txtUsuProxy.Text;
            settings.prox_pass = txtPassProxy.Text;
            if (String.IsNullOrEmpty(settings.directorioLog))
            {
                MessageBox.Show("Agrege un directorio en el Log", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGuardar.Enabled = true;
                return;
            }
            if (String.IsNullOrEmpty(settings.prox_host) && chkProxy.Checked )
            {
                MessageBox.Show("Agrege la direccion del proxy", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGuardar.Enabled = true;
                return;
            }
            AppSettings.SettConfig(settings);//guarda la configuracion
            string mensajeconn = "";
            if (chkProxy.Checked)
            {
                mensajeconn = funcionProxy();
                if (mensajeconn != "")
                {
                    MessageBox.Show(mensajeconn, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnGuardar.Enabled = true;
                    return;
                }
            }
            mensajeconn = SAP_Connection.Save_sap_settings(settings);//valida la conexion en sap
            btnGuardar.Enabled = true;
            if (mensajeconn == "")
            {
                MessageBox.Show("¡¡Guardado Correctamente!!", "¡Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensajeconn, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarConf()
        {
            settings = AppSettings.getConfig(settings);
            txtDescripcion.Text = settings.sap_name;
            txtServidor.Text = settings.sap_host;
            txtInstancia.Text = settings.sap_sysnumber;
            txtMandante.Text = settings.sap_client;
            txtUsuario.Text = settings.sap_user;
            txtCveA.Text = settings.sap_pass;
            txtRouter.Text = settings.SAPRouter;

            chkCliente.Checked = settings.esActivoDirCtes;
            chkProveedor.Checked = settings.esActivoDirProv;
            chkNomina.Checked = settings.esActivoNomina;
            txtCliente.Text = settings.directorioCtes;
            txtProveedor.Text = settings.directorioProv;
            txtNomina.Text = settings.directorioNomina;
            txtLog.Text = settings.directorioLog;

            txtClienteC.Text = settings.directorioCtesC;
            txtProveedorC.Text = settings.directorioProvC;
            txtNominaC.Text = settings.directorioNomC;
            txtClienteI.Text = settings.directorioCtesI;
            txtProveedorI.Text = settings.directorioProvI;
            txtNominaI.Text = settings.directorioNomI;
            chkClienteC.Checked = settings.esActivoCteC;
            chkProveedorC.Checked = settings.esActivoProvC;
            chkNominaC.Checked = settings.esActivoNomC;
            chkClienteI.Checked = settings.esActivoCteI;
            chkProveedorI.Checked = settings.esActivoProvI;
            chkNominaI.Checked = settings.esActivoNomI;

            chkProxy.Checked = settings.prox_act;
            txtIPProxy.Text = settings.prox_host;
            txtPuerProxy.Text = settings.prox_puert.ToString();
            txtUsuProxy.Text = settings.prox_user;
            txtPassProxy.Text = settings.prox_pass;
        }
        private string examinarRuta(string dir)
        {
            string res = dir;
            folderBrowserDialog1.SelectedPath = dir;
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                res = folderBrowserDialog1.SelectedPath;
            }

            return res;
        }
        private string funcionProxy()
        {
            WebClient request = new WebClient();
            string msm = "";
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
                byte[] vs = request.UploadData("https://consultaqr.facturaelectronica.sat.gob.mx/ConsultaCFDIService.svc", new byte[] { });
                //request.DownloadString("https://consultaqr.facturaelectronica.sat.gob.mx/ConsultaCFDIService.svc");
            }
            catch (Exception)
            {
                msm = "Error de proxy: No pudo conectar a internet \r Verifique su configuracion.";
            }
            return msm;
        }
        private void SoloNum(ref KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                }
            }
        }
        private void txtPuerProxy_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNum(ref e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void txtMandante_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNum(ref e);
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            this.txtProveedor.Text = examinarRuta(txtProveedor.Text);
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            this.txtCliente.Text = examinarRuta(txtCliente.Text);
        }

        private void btnNomina_Click(object sender, EventArgs e)
        {
            this.txtNomina.Text = examinarRuta(txtNomina.Text);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            this.txtLog.Text = examinarRuta(txtLog.Text);
        }

        private void btnProveedorC_Click(object sender, EventArgs e)
        {
            this.txtProveedorC.Text = examinarRuta(txtProveedorC.Text);
        }

        private void btnClienteC_Click(object sender, EventArgs e)
        {
            this.txtClienteC.Text = examinarRuta(txtClienteC.Text);
        }

        private void btnNominaC_Click(object sender, EventArgs e)
        {
            this.txtNominaC.Text = examinarRuta(txtNominaC.Text);
        }

        private void btnProveedorI_Click(object sender, EventArgs e)
        {
            this.txtProveedorI.Text = examinarRuta(txtProveedorI.Text);
        }

        private void btnClienteI_Click(object sender, EventArgs e)
        {
            this.txtClienteI.Text = examinarRuta(txtClienteI.Text);
        }

        private void btnNominaI_Click(object sender, EventArgs e)
        {
            this.txtNominaI.Text = examinarRuta(txtNominaI.Text);
        }

        private void txtInstancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNum(ref e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
