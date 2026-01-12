using System;
using System.Windows.Forms;


namespace frmPrincipal
{
    internal static class Program
    {
                [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Asegúrate de que esta línea no esté fallando

                Application.Run(new frmProductos());
            }
            catch (Exception ex)
            {
                // Esto te mostrará por qué se cierra si el error es al arrancar
                MessageBox.Show("Error fatal al iniciar: " + ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}
