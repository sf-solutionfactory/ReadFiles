using System;
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

            settings.prox_host = txtIPProxy.Text;
            settings.prox_puert = Convert.ToInt32(txtPuerProxy.Text);
            settings.prox_user = txtUsuProxy.Text;
            settings.prox_pass = txtPassProxy.Text;
            AppSettings.SettConfig(settings);//guarda la configuracion
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

            txtIPProxy.Text = settings.prox_host;
            txtPuerProxy.Text = settings.prox_puert.ToString();
            txtUsuProxy.Text = settings.prox_user;
            txtPassProxy.Text = settings.prox_pass;
        }
        private string examinarRuta(string dir)
        {
            string res = "";
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
        private void txtPuerProxy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void txtMandante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
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
            this.txtNomina.Text = examinarRuta(txtLog.Text);
        }

        private void btnProveedorC_Click(object sender, EventArgs e)
        {
            this.txtProveedor.Text = examinarRuta(txtProveedorC.Text);
        }

        private void btnClienteC_Click(object sender, EventArgs e)
        {
            this.txtNomina.Text = examinarRuta(txtClienteC.Text);
        }

        private void btnNominaC_Click(object sender, EventArgs e)
        {
            this.txtNomina.Text = examinarRuta(txtNominaC.Text);
        }

        private void btnProveedorI_Click(object sender, EventArgs e)
        {
            this.txtProveedor.Text = examinarRuta(txtProveedorI.Text);
        }

        private void btnClienteI_Click(object sender, EventArgs e)
        {
            this.txtNomina.Text = examinarRuta(txtClienteI.Text);
        }

        private void btnNominaI_Click(object sender, EventArgs e)
        {
            this.txtNomina.Text = examinarRuta(txtNominaI.Text);
        }
    }
}
