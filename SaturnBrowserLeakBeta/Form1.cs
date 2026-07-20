using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace SaturnBrowserLeakBeta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "SaturnBrowserLeakBeta"; // Título do Navegador
            InicializarNavegador();
        }

        private async void InicializarNavegador()
        {
            // Inicializa o motor Chromium do Edge
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.Navigate("https://www.google.com");

            // Atualiza a barra de endereço ao navegar
            webView.SourceChanged += (s, e) => {
                txtUrl.Text = webView.Source.ToString();
            };
        }

        // Função do Botão "Ir" (Conforme o erro btnIr_Click_1)
        private void btnIr_Click_1(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            if (!url.StartsWith("http")) url = "https://" + url;
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.Navigate(url);
            }
        }

        // Função do Botão "Voltar" (Conforme o erro btnVoltar_Click_1)
        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            if (webView != null && webView.CoreWebView2.CanGoBack)
            {
                webView.CoreWebView2.GoBack();
            }
        }

        // Função do Botão "Avançar" (Conforme o erro btnAvancar_Click_1)
        private void btnAvancar_Click_1(object sender, EventArgs e)
        {
            if (webView != null && webView.CoreWebView2.CanGoForward)
            {
                webView.CoreWebView2.GoForward();
            }
        }

        // Função do Botão "Atualizar" (Conforme o erro btnAtualizar_Click_1)
        private void btnAtualizar_Click_1(object sender, EventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.Reload();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Pode deixar vazio, roda ao iniciar o formulário
        }

        // NOVO: Botão Sobre
        private void btnAbout_Click(object sender, EventArgs e)
        {
            string infoProjeto = "SaturnBrowserLeakBeta\n" +
                                 "Versão: 6.7 (Leak)\n\n" +
                                 "Este navegador não tem nenhuma afiliação com o navegador original Saturn Browser, sendo apenas feito como piada (e com IA).";

            MessageBox.Show(infoProjeto, "Sobre o SaturnBrowserLeakBeta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // NOVO: Vamos usar o "button1" antigo para ser o botão do site oficial (Saturn App)
        private void button1_Click(object sender, EventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.Navigate("https://saturnbrowser.app");
            }
        }

        // NOVO: Botão Home (Leva para o Google)
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.Navigate("https://www.google.com");
            }
        }
    }
}