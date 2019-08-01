using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadMail.IEntities
{
    [Serializable]
    public class PARAMETROS_BE
    {

        private int _id;
        private string _prgnm = string.Empty;
        private string _const = string.Empty;
        private string _lid = string.Empty;
        private string _sign = string.Empty;
        private string _optn = string.Empty;
        private string _low = string.Empty;
        private string _high = string.Empty;
        private int _fk;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string prgnm
        {
            get { return _prgnm; }
            set { _prgnm = value; }
        }
        public string constante
        {
            get { return _const; }
            set { _const = value; }
        }
        public string lid
        {
            get { return _lid; }
            set { _lid = value; }
        }
        public string sign
        {
            get { return _sign; }
            set { _sign = value; }
        }
        public string optn
        {
            get { return _optn; }
            set { _optn = value; }
        }
        public string low
        {
            get { return _low; }
            set { _low = value; }
        }
        public string high
        {
            get { return _high; }
            set { _high = value; }
        }
        public int fk
        {
            get { return _fk; }
            set { _fk = value; }
        }



    }

    public class SAP_CNX
    {
        private string _sap_cnx = string.Empty;
        private string _sap_ip = string.Empty;
        private string _sap_synumber = string.Empty;
        private string _sap_user = string.Empty;
        private string _sap_pass = string.Empty;
        private string _sap_client = string.Empty;

        public string sap_cnx
        {
            get { return _sap_cnx; }
            set { _sap_cnx = value; }
        }
        public string sap_ip
        {
            get { return _sap_ip; }
            set { _sap_ip = value; }
        }
        public string sap_synumber
        {
            get { return _sap_synumber; }
            set { _sap_synumber = value; }
        }
        public string sap_user
        {
            get { return _sap_user; }
            set { _sap_user = value; }
        }
        public string sap_pass
        {
            get { return _sap_pass; }
            set { _sap_pass = value; }
        }
        public string sap_client
        {
            get { return _sap_client; }
            set { _sap_client = value; }
        }
    }
}
