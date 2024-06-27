using System;
using System.Windows.Forms;
using System.Threading;
using Entidades;

namespace Patentes
{
    public delegate void FinExposicionPatente(VistaPatente vistaPatente);

    public delegate void MostrarPatente(object patente);

    public partial class VistaPatente : UserControl
    {
        public event FinExposicionPatente finExposicion;

        public VistaPatente()
        {
            InitializeComponent();
            picPatente.Image = fondosPatente.Images[(int)Tipo.Mercosur];
        }
        /// <summary>
        /// Metodo para mostrar patente durante un tiempo de 1.5 segundos y dispara el evento de que finalizó la exposición de la patente.
        /// </summary>
        /// <param name="patente"></param>
        public void MostrarPatente(object patente)
        {
            if (lblPatenteNro.InvokeRequired)
            {
                try
                {
                    // Llama al hilo principal para actualizar la interfaz de usuario.
                    Invoke((MethodInvoker)delegate
                    {
                        picPatente.Image = fondosPatente.Images[(int)((Patente)patente).TipoCodigo];
                        lblPatenteNro.Text = patente.ToString();
                    });

                    Thread.Sleep(1500);

                    // Dispara el evento de que finalizó la exposición de la patente.
                    finExposicion?.Invoke(this); // Invoca el evento finExposicion si no es nulo


                }
                catch (Exception) { }
            }
            else
            {

                picPatente.Image = fondosPatente.Images[(int)((Patente)patente).TipoCodigo];
                lblPatenteNro.Text = patente.ToString();
            }
        }
    }
}
