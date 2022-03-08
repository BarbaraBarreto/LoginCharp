using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;

namespace LoginCharp
{
    public partial class Form1 : Form
    {
        //Referencia conexão
        SqlConnection Conexao = new SqlConnection(@"Data Source=X-PC\MSSQLSERVER01;Initial Catalog=LoginCharp;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            txtUsuario.Select();

            btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEntrar.FlatAppearance.BorderSize = 0;
            btnEntrar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnEntrar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnEntrar.BackColor = Color.Transparent;

            btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSair.FlatAppearance.BorderSize = 0;
            btnSair.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSair.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSair.BackColor = Color.Transparent;
        }

        void verificar()
        {
            if(txtUsuario.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("Preencha os campos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Select();
            }
        }

        /*protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath forma = new GraphicsPath();
            forma.AddEllipse(0, 5, btnEntrar.Width, btnEntrar.Height);
            btnEntrar.Region = new Region(forma);
        }*/

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Conexao.Open();
            verificar();
            string query = "SELECT * FROM Usuario WHERE Username = '" + txtUsuario.Text + "' AND Password = '" + txtPassword.Text + "'";
            SqlDataAdapter dp = new SqlDataAdapter(query, Conexao);
            DataTable dt = new DataTable();
            dp.Fill(dt);


            if (dt.Rows.Count == 1)
                {
                    FrmPrincipal principal = new FrmPrincipal();
                    this.Hide();
                    principal.Show();
                    Conexao.Close(); //Fechar a conexão
                }
            
            else
            {
                MessageBox.Show("Usuário ou Password incorreto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = ""; // Limpa as textBox depoisde serem verificadas
                txtPassword.Text = "";
                txtUsuario.Select(); // Cursor irá sinalizar a primeira textBox
            }
            Conexao.Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
