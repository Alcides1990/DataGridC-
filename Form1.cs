using System;
using System.Linq;
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
            //EJEMPLO PARA ASIGNAR DATOS A LA TABLA
            tablaProducto.Rows[n].Cells[0].Value = txtCodigo.Text;
            tablaProducto.Rows[n].Cells[1].Value = txtNombre.Text;
            tablaProducto.Rows[n].Cells[2].Value = txtPrecio.Text;
            sumarTotal();
        }

        private void tablaProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
            if (n!=-1)
            {
                //EJEMPLO PARA OBTENER LOS VALORES DE LA TABLA Y MOSTRARLOS EN LAS CAJAS DE TEXTO
                txtCodigo.Text = tablaProducto.Rows[n].Cells[0].Value.ToString();
                txtNombre.Text = tablaProducto.Rows[n].Cells[1].Value.ToString();
                txtPrecio.Text = tablaProducto.Rows[n].Cells[2].Value.ToString();
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (n!=-1)
            {
                //EJEMPLO PARA ELIMINAR UNA FILA DE LA TABLA
                tablaProducto.Rows.RemoveAt(n);
                txtNombre.Focus();
                sumarTotal();
            }
        }

        public void sumarTotal()
        {
            //EJEMPLO PARA SUMAR UNA COLUMNA DE LA TABLA
            int total = tablaProducto.Rows.OfType<DataGridViewRow>().Sum(x => (int?)Convert.ToInt32(x.Cells[2].Value) ?? 0);//
            lblTotal.Text = total.ToString();
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


    }
}
