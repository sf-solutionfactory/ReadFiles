using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadMail.IEntities
{
    [Serializable]
    public class MAIL_DATA_BE
    {
        private string _UIDL = string.Empty;
        private string _MAIL = string.Empty;
        private string _DATUM = string.Empty;
        private string _TIME = string.Empty;
        private int _FILES = 0;        
        private string _SUBJECT = string.Empty;
        private string _CONTA = string.Empty;

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
        public int FILES
        {
            get { return _FILES; }
            set { _FILES = value; }
        }
        public string SUBJECT
        {
            get { return _SUBJECT; }
            set { _SUBJECT = value; }
        }
        public string CONTA
        {
            get { return _CONTA; }
            set { _CONTA = value; }
        }
    }
}
