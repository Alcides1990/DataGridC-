using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int n = 0; //variable para utilizar cuando necesitemos seleccionar un registro del datagriw
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = tablaProducto.Rows.Add();
            if (txtCodigo.Text.Equals("") || txtNombre.Text.Equals("") || txtPrecio.Text.Equals(""))
            {
                MessageBox.Show("No ingreso ningun codigo","ATENCION");
            }
            else
            {
                if (txtPrecio.Text.Equals("0") || txtPrecio.Text.Equals("1") || txtPrecio.Text.Equals("2") || txtPrecio.Text.Equals("3")
                    || txtPrecio.Text.Equals("4") || txtPrecio.Text.Equals("5") || txtPrecio.Text.Equals("6") || txtPrecio.Text.Equals("7")
                    || txtPrecio.Text.Equals("8") || txtPrecio.Text.Equals("9"))
                {

                }
            }


            tablaProducto.Rows[n].Cells[0].Value = txtCodigo.Text;
            tablaProducto.Rows[n].Cells[1].Value = txtNombre.Text;
            tablaProducto.Rows[n].Cells[2].Value = txtPrecio.Text;
            sumarTotal();
        }

        private void c(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tablaProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
            if (n!=-1)
            {
                txtCodigo.Text = tablaProducto.Rows[n].Cells[0].Value.ToString();
                txtNombre.Text = tablaProducto.Rows[n].Cells[1].Value.ToString();
                txtPrecio.Text = tablaProducto.Rows[n].Cells[2].Value.ToString();
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (n!=-1)
            {
                tablaProducto.Rows.RemoveAt(n);
                txtNombre.Focus();
                sumarTotal();
            }
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
           
        }
        public void sumarTotal()
        {
            int total = tablaProducto.Rows.OfType<DataGridViewRow>().Sum(x => (int?)Convert.ToInt32(x.Cells[2].Value) ?? 0);//
            lblTotal.Text = total.ToString();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtCodigo.Text, "^ [0-9]"))
            {
                txtCodigo.Text = "";
            }
        }

        //EJEMPLO COMO VALIDAR UN TEXTBOX PARA QUE SOLO ACEPTE NUMEROS
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            

        }
    }
}
