using Prueba16Nov.Algoritmos;

namespace Prueba16Nov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Paso 0: Condic�on de vac�o
            if (textBox5.Text.Equals(""))
            {
                MessageBox.Show("Los números tienen que ser MAYOR que cero, NO VAC�OS");
                return;
            }

            // Paso 1: Inicializaci�n de par�metros
            int n = Convert.ToInt32(textBox5.Text);

            // Paso 1.2: Validación algoritmo
            if (n < 0)
            {
                MessageBox.Show("El número tiene que ser MAYOR QUE CERO");
                return;
            }


            // Paso 2: Declarar clase algoritmo gen�tico
            AlgoritmoSimulacion algoritmo = new AlgoritmoSimulacion();

            // Paso 3: Llamar m�todo principal
            var(a,b,c,d,f,g) = algoritmo.GenerarValoresPseudoaleatoriosNoCongruencial(n);

            // Paso 4: Llenar el grid
            llenarGrid(a,b,c,d,f,g);
        }
        public void llenarGrid(List<int> lista1, List<int> lista2, List<int> lista3, List<int> lista4, List<int> lista5, List<int> lista6)
        {
            // Paso 0: Indicas el n�mero de columnas
            string numeroColumna1 = "1";
            string numeroColumna2 = "2";
            string numeroColumna3 = "3";
            string numeroColumna4 = "4";
            string numeroColumna5 = "5";
            string numeroColumna6 = "6";
            string numeroColumna7 = "7";

            // Paso 1: Determinas la cantidad de columnas
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(numeroColumna1, "Id");
            dataGridView1.Columns.Add(numeroColumna2, "R(n)");
            dataGridView1.Columns.Add(numeroColumna3, "R(n+1)");
            dataGridView1.Columns.Add(numeroColumna4, "R(n)*R(n+1)");
            dataGridView1.Columns.Add(numeroColumna5, "M.(R(n)*R(n+1))");
            dataGridView1.Columns.Add(numeroColumna6, "Valor 1");
            dataGridView1.Columns.Add(numeroColumna7, "Valor 2");

            //Paso 2: Recorres el grid para cada fila llenas los valores aleatorios
            for (int i = 0; i < lista1.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna1) - 1].Value = (i + 1).ToString();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna2) - 1].Value = lista1[i].ToString();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna3) - 1].Value = lista2[i].ToString();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna4) - 1].Value = lista3[i].ToString();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna5) - 1].Value = lista4[i].ToString();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna6) - 1].Value = lista5[i].ToString();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna7) - 1].Value = lista6[i].ToString();
            }

        }

        public void DescargaExcel(DataGridView data)
        {
            // Paso 0: Instalar complemente de exel
            Microsoft.Office.Interop.Excel.Application exportarExcel = new Microsoft.Office.Interop.Excel.Application();
            exportarExcel.Application.Workbooks.Add(true);
            int indiceColumna = 0;
            // Paso 1: Construyes columnas y los nombres de las "cabeceras"
            foreach (DataGridViewColumn columna in data.Columns)
            {
                indiceColumna++;
                exportarExcel.Cells[1, indiceColumna] = columna.HeaderText;
            }
            // Paso 2: Construyes filas y llenas valores
            int indiceFilas = 0;

            foreach (DataGridViewRow fila in data.Rows)
            {
                indiceFilas++;
                indiceColumna = 0;
                foreach (DataGridViewColumn columna in data.Columns)
                {
                    indiceColumna++;
                    exportarExcel.Cells[indiceFilas + 1, indiceColumna] = fila.Cells[columna.Name].Value;
                }
            }
            // Paso 3: visibilidad
            exportarExcel.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DescargaExcel(dataGridView1);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
