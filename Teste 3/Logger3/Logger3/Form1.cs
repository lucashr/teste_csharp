using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Logger3
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=SKAR1200799\DBSERVER;Database=TESTE_NET;User Id=sa;Password=qweasd;Trusted_Connection=True;";
        bool alterado;
        private string arquivo;
        private string mensagem;        

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogarTexto_Click_1(object sender, EventArgs e)
        {
            insereDadosDb();
        }

        private void btnTotRegistros_Click_1(object sender, EventArgs e)
        {
            lerArquivoTexto();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult mensagem = MessageBox.Show("Deseja terminar a aplicação?", "Encerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (mensagem == DialogResult.Yes)
            {
                Close();
            }
        }

        private void lerArquivoTexto()
        {
            string line;
            List<string> mensagemLinha = new List<string>();
            List<string> addQuebraLinha = new List<string>();


            // Read the file and display it line by line.  
            string file = @"C:\\Users\\lucas\\Desktop\\APAS_07062011.txt";

            using (StreamReader texto = new StreamReader(file))
            {
                while ((mensagem = texto.ReadLine()) != null)
                {
                    mensagemLinha.Add(mensagem);
                }

                string temp = "";

                //Adiciona o resultado da leitura do arquivo em uma string temporaria
                foreach (string item in mensagemLinha)
                {
                    temp += item;
                }                

                //Removendo espaços maior que 1
                while (temp.IndexOf("  ") >= 0)
                {
                    temp = temp.Replace("  ", " ");
                }
                
                string[] s = temp.Split(' '); //o arquivo possui 17 espaços em branco.uma linha tem 17 espaços em branco
                bool vrfPrimeiroApas = false;
                
                foreach (string item in s)
                {
                    bool schr = item.Contains("APAS");
                    
                    if (schr)
                    {                                              
                        if (vrfPrimeiroApas)
                        {
                            addQuebraLinha.Add(item);
                            vrfPrimeiroApas = false;
                        }
                        
                        int t = item.IndexOf("APAS");
                        string tmp = item.Insert(t,"\n");

                        addQuebraLinha.Add(tmp);
                    }
                    else
                    {
                        addQuebraLinha.Add(item);
                    }


                    }

                    foreach (string item in addQuebraLinha)
                    {
                        Console.WriteLine(item);
                    }

            }

        }

        private void insereDadosDb()
        {
            if (txtBox.Text.Trim() != "" && alterado)
            {

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("insereDados", con);

                cmd.Parameters.AddWithValue("@textoDigitado", txtBox.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Registro incluido com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }

            alterado = false;

        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            alterado = true;
        }

    }
}