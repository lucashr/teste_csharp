using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Logger_2
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=SKAR1200799\DBSERVER;Database=TESTE_NET;User Id=sa;Password=qweasd;Trusted_Connection=True;";
        bool alterado;

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
            obterTotalRegistrosBanco();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult mensagem = MessageBox.Show("Deseja terminar a aplicação?", "Encerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (mensagem == DialogResult.Yes)
            {
                Close();
            }
        }

        //classe cliente e suas propriedades 
        public class Registros
        {
            public int totalRegistros { get; set; }
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

        private void obterTotalRegistrosBanco()
        {
            SqlConnection con = new SqlConnection(connectionString);            
            SqlDataReader dataReader;
            SqlCommand cmd = new SqlCommand("totRegistros", con);

            string output="";

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            dataReader = cmd.ExecuteReader();

            try
            {                

                while (dataReader.Read())
                {
                    output = output + dataReader.GetValue(0) + "\n";
                }

                DialogResult mensagem = MessageBox.Show("Total de registros no banco\n\n" + "                " + 
                Convert.ToString(output), "Registros", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter dados do banco: " + ex.ToString());
            }

            finally
            {
                dataReader.Close();
                cmd.Dispose();
                con.Close();                
            }
        }

    }
}