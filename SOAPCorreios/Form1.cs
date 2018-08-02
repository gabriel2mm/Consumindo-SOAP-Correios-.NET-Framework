using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Services;
using System.Xml;
using SOAPCorreios.Correio;
using System.ServiceModel.Description;
using System.Xml.Serialization;
using Correio;

namespace SOAPCorreios
{
    using br.com.correios.webservice;
    using System.IO;
    using System.Threading;
    using System.Xml.Serialization;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void limparCampos()
        {
            txtCat.Text = "";
            txtQtd.Text = "";
            txtCidade.Text = "";
            txtData.Text = "";
            txtUf.Text = "";
            txtHora.Text = "";
            txtLocal.Text = "";
            rcDesc.Text = "";
            txtSigla.Text = "";
            txtNumero.Text = "";
            txtBairroDest.Text = "";
            txtCidadeDest.Text = "";
            txtLocalDest.Text = "";
            txtUfDest.Text = "";
        }

        public void recentes(String pesquisa)
        {
            if (!listRecentes.Items.Contains(pesquisa))
            {
                listRecentes.Items.Add(pesquisa);
            }
        }

        public void Pesquisar()
        {
            progress.Value = 0;
            limparCampos();
            progress.Value = 10;
            if (txtCodigo.Text != null && txtCodigo.Text.Trim().Length > 0)
            {
                try
                {
                    progress.Value = 30;
                    Correio.ServiceClient wsCorreio = new ServiceClient();
                    progress.Value = 40;
                    var requestInterceptor = new Correio.Interceptor();
                    progress.Value = 50;
                    wsCorreio.Endpoint.EndpointBehaviors.Add(requestInterceptor);
                    progress.Value = 60;
                    wsCorreio.buscaEventos(Usuario.getInstance().User, Usuario.getInstance().Pass, Usuario.getInstance().Tipo, Usuario.getInstance().Result, Usuario.getInstance().Language, txtCodigo.Text);
                    string requestXML = requestInterceptor.LastRequestXML;
                    XmlSerializer ser = new XmlSerializer(typeof(Envelope));
                    Envelope envelope = new Envelope();
                    using (TextReader reader = new StringReader(requestInterceptor.LastResponseXML))
                    {
                        envelope = (Envelope)ser.Deserialize(reader);
                    }
                    progress.Value = 70;
                    returnObjeto objetoRastreado = envelope.Body.buscaEventosResponse.@return.objeto;
                   
                    txtSigla.Text = objetoRastreado.sigla;
                    txtNumero.Text = objetoRastreado.numero;
                    txtCat.Text = objetoRastreado.categoria;
                    if (objetoRastreado.erro == null || objetoRastreado.erro.Trim().Length == 0)
                    {
                        progress.Value = 80;
                        returnObjetoEvento[] objetoRastreadoEvento = envelope.Body.buscaEventosResponse.@return.objeto.evento;



                        foreach (returnObjetoEvento s in objetoRastreadoEvento)
                        {
                            txtQtd.Text = envelope.Body.buscaEventosResponse.@return.qtd.ToString();
                            txtCidade.Text = s.cidade;
                            txtData.Text = s.data;
                            txtUf.Text = s.uf;
                            txtHora.Text = s.hora;
                            txtLocal.Text = s.local;
                            rcDesc.Text = s.descricao;
                            recentes(objetoRastreado.numero);

                            if (s.destino != null && s.destino.cidade.Trim().Length > 0)
                            {
                                returnObjetoEventoDestino dest = s.destino;
                                txtCidadeDest.Text = dest.cidade;
                                txtBairroDest.Text = dest.bairro;
                                txtLocalDest.Text = dest.local;
                                txtUfDest.Text = dest.uf;
                            }else
                            {
                                txtLocalDest.Text = "Objeto entregue ao destino!";
                            }
                        }
                        progress.Value = 100;
                    }
                    else
                    {
                        progress.Value = 100;
                        MessageBox.Show(objetoRastreado.erro , "Erro" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                    }
                    Thread.Sleep(500);
                    progress.Value = 0;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ocorreu um erro desconhecido :  " + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor informe o código do objeto que deseja rastrear!", "Preencha todos os campos!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Pesquisar();
            }
        }

        private void listRecentes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (listRecentes.Items.Count > 0)
                {
                    int selectedIndex = listRecentes.SelectedIndex;
                    if (selectedIndex != -1)
                    {
                        string selecionado = listRecentes.SelectedItem.ToString();
                        txtCodigo.Text = selecionado;
                        Pesquisar();
                    }
                    else
                    {
                        MessageBox.Show("Selecione um item para realizar a pesquisa!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }                
            }
            catch (Exception r)
            {
                MessageBox.Show("Um erro desconhecido aconteceu : " + r.Message , "ERRO" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listRecentes.Items.Count > 0)
                {
                    int selectedIndex = listRecentes.SelectedIndex;
                    if (selectedIndex != -1)
                    {
                        listRecentes.Items.RemoveAt(selectedIndex);
                        listRecentes.ClearSelected();
                    }
                    else
                    {
                        MessageBox.Show("Selecione um item para remover!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception r)
            {
                MessageBox.Show("Um erro desconhecido aconteceu : " + r.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var m = MessageBox.Show("Deseja salvar ?" , "salvar ?" , MessageBoxButtons.YesNo , MessageBoxIcon.Question);
            if (m == DialogResult.Yes)
            {
                StreamWriter sw = new StreamWriter(@"banco.ini");
                foreach (string s in listRecentes.Items)
                {
                    sw.WriteLine(s);
                }
                sw.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("banco.ini"))
            {
                StreamReader sr = new StreamReader("banco.ini");
                string linha = null;
                while ((linha = sr.ReadLine()) != null)
                {
                    recentes(linha);
                }
                sr.Close();
            }
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_MouseHover(object sender, EventArgs e)
        {
            
        }
    }
}
