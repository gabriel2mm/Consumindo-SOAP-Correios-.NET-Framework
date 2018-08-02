using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correio
{


    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
    public partial class Envelope
    {

        private EnvelopeHeader headerField;

        private EnvelopeBody bodyField;

        public EnvelopeHeader Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        public EnvelopeBody Body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeHeader
    {

        private string xOPNETTransactionTraceField;

        [System.Xml.Serialization.XmlElementAttribute("X-OPNET-Transaction-Trace", Namespace = "http://opnet.com")]
        public string XOPNETTransactionTrace
        {
            get
            {
                return this.xOPNETTransactionTraceField;
            }
            set
            {
                this.xOPNETTransactionTraceField = value;
            }
        }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeBody
    {

        private buscaEventosResponse buscaEventosResponseField;

        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://resource.webservice.correios.com.br/")]
        public buscaEventosResponse buscaEventosResponse
        {
            get
            {
                return this.buscaEventosResponseField;
            }
            set
            {
                this.buscaEventosResponseField = value;
            }
        }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://resource.webservice.correios.com.br/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://resource.webservice.correios.com.br/", IsNullable = false)]
    public partial class buscaEventosResponse
    {

        private @return returnField;

        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public @return @return
        {
            get
            {
                return this.returnField;
            }
            set
            {
                this.returnField = value;
            }
        }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class @return
    {

        private decimal versaoField;

        private byte qtdField;

        private returnObjeto objetoField;

        public decimal versao
        {
            get
            {
                return this.versaoField;
            }
            set
            {
                this.versaoField = value;
            }
        }

        public byte qtd
        {
            get
            {
                return this.qtdField;
            }
            set
            {
                this.qtdField = value;
            }
        }

        public returnObjeto objeto
        {
            get
            {
                return this.objetoField;
            }
            set
            {
                this.objetoField = value;
            }
        }

    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class returnObjeto
    {

        private string numeroField;

        private string siglaField;

        private string nomeField;

        private string categoriaField;

        private string erroField;

        private returnObjetoEvento[] eventoField;

        public string numero
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

        public string sigla
        {
            get
            {
                return this.siglaField;
            }
            set
            {
                this.siglaField = value;
            }
        }

        public string nome
        {
            get
            {
                return this.nomeField;
            }
            set
            {
                this.nomeField = value;
            }
        }

        public string erro
        {
            get
            {
                return this.erroField;
            }
            set
            {
                this.erroField = value;
            }
        }

        public string categoria
        {
            get
            {
                return this.categoriaField;
            }
            set
            {
                this.categoriaField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("evento")]
        public returnObjetoEvento[] evento
        {
            get
            {
                return this.eventoField;
            }
            set
            {
                this.eventoField = value;
            }
        }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class returnObjetoEvento
    {

        private string tipoField;

        private byte statusField;

        private string dataField;

        private string horaField;

        private string descricaoField;

        private string detalheField;

        private string localField;

        private uint codigoField;

        private string cidadeField;

        private string ufField;

        private returnObjetoEventoDestino destinoField;

        public string tipo
        {
            get
            {
                return this.tipoField;
            }
            set
            {
                this.tipoField = value;
            }
        }


        public byte status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        public string data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }

        public string hora
        {
            get
            {
                return this.horaField;
            }
            set
            {
                this.horaField = value;
            }
        }

        public string descricao
        {
            get
            {
                return this.descricaoField;
            }
            set
            {
                this.descricaoField = value;
            }
        }

        public string detalhe
        {
            get
            {
                return this.detalheField;
            }
            set
            {
                this.detalheField = value;
            }
        }

        public string local
        {
            get
            {
                return this.localField;
            }
            set
            {
                this.localField = value;
            }
        }

        public uint codigo
        {
            get
            {
                return this.codigoField;
            }
            set
            {
                this.codigoField = value;
            }
        }

        public string cidade
        {
            get
            {
                return this.cidadeField;
            }
            set
            {
                this.cidadeField = value;
            }
        }

        public string uf
        {
            get
            {
                return this.ufField;
            }
            set
            {
                this.ufField = value;
            }
        }

        public returnObjetoEventoDestino destino
        {
            get
            {
                return this.destinoField;
            }
            set
            {
                this.destinoField = value;
            }
        }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class returnObjetoEventoDestino
    {

        private string localField;

        private uint codigoField;

        private string cidadeField;

        private string bairroField;

        private string ufField;

        public string local
        {
            get
            {
                return this.localField;
            }
            set
            {
                this.localField = value;
            }
        }

        public uint codigo
        {
            get
            {
                return this.codigoField;
            }
            set
            {
                this.codigoField = value;
            }
        }

        public string cidade
        {
            get
            {
                return this.cidadeField;
            }
            set
            {
                this.cidadeField = value;
            }
        }

        public string bairro
        {
            get
            {
                return this.bairroField;
            }
            set
            {
                this.bairroField = value;
            }
        }

        public string uf
        {
            get
            {
                return this.ufField;
            }
            set
            {
                this.ufField = value;
            }
        }
    }


}
