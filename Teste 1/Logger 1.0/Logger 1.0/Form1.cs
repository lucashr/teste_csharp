using System;
using System.IO;
using System.Windows.Forms;

namespace Logger_1._0
{
    public partial class Form1 : Form
    {
        static string dirLog; //Caminho absoluto do diretorio de Log
        string arqLog;        //Caminho absoluto do arquivo de Log
        bool arquivoCriado;   //Seta valor verdadeiro caso o arquivo ja tenha sido criado

        public Form1()
        {
            InitializeComponent();
            diretorioRaiz(); //Verifica o diretorio atual de execução ao iniciar o programa
        }

        private void btnLogarTexto_Click_1(object sender, EventArgs e)
        {
            criaArquivoLogTxt();      //Chama a função para criar o arquivo de log
            gravarTxtBoxParaArqLog(); //Chama a função de gravação do conteudo do input para o arquivo txt
        }

        private void btnAbrirArqLog_Click_1(object sender, EventArgs e)
        {
            abrirArquivoDia();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult mensagem = MessageBox.Show("Deseja terminar a aplicação?", "Encerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (mensagem == DialogResult.Yes)
            {
                Close();
            }
        }

        private void diretorioRaiz()
        {
            string diretorio = Environment.CurrentDirectory; //Obtem o diretório atual
            criaDiretorioLog(diretorio);                     // Chama a função para criação do diretorio Log          
        }

        private void criaDiretorioLog(string dirAtual)
        {
            dirLog = dirAtual + "\\" + "Log";

            if (!File.Exists(dirLog)) //Se o diretorio de log não existir, então ele é criado
            {
                Directory.CreateDirectory(dirLog);
            }

        }

        private void criaArquivoLogTxt()
        {
            DateTime data = DateTime.Now; //Obtem o dia e a hora atual
            arqLog = dirLog + "\\" + "Log_" + data.ToString("yyyyMMdd") + ".txt";

            if (!File.Exists(arqLog) && !arquivoCriado) //Se o arquivo de log não existir no diretorio informado, então ele é criado
            {
                File.Create(arqLog).Close();
                arquivoCriado = true;
            }

        }

        private void gravarTxtBoxParaArqLog()
        {
            DateTime data = DateTime.Now; //Obtem o dia e a hora atual
            string linha;
            linha = txtBox.Text;
            File.AppendAllText(arqLog, data.ToString("HH:mm:ss - ") + linha.ToString() + "\r\n");
        }

        private void abrirArquivoDia()
        {
            DirectoryInfo dir = new DirectoryInfo(dirLog);
            FileInfo[] arq = dir.GetFiles("*", SearchOption.AllDirectories);

            DateTime data = DateTime.Now; //Obtem o dia e a hora atual

            string arquivoAtual = "Log_" + data.ToString("yyyyMMdd") + ".txt";            
            string localArquivo = "";

            bool arqEncontrado = false;

            foreach (var item in arq)
            {
                string arqAtual = item.ToString();
                bool exiteArqAtual = arqAtual.Contains(arquivoAtual);
                

                if (exiteArqAtual)
                {
                    localArquivo = dirLog + "\\" + arquivoAtual;
                    arqEncontrado = true;
                    break;
                }

            }

            if (!arqEncontrado)
            {
                DialogResult mensagem = MessageBox.Show("Arquivo do dia corrente não encontrado", "Arquivo do dia", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            else
            {
                System.Diagnostics.Process.Start("notepad.exe", localArquivo);
            }

        }
        
    }
}