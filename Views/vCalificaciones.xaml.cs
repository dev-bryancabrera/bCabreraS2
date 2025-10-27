using static System.Runtime.InteropServices.JavaScript.JSType;

namespace bCabreraS2.Views;

public partial class vCalificaciones : ContentPage
{
    double notaParcial1, notaParcial2;
    double notaFinal;
    public vCalificaciones()
    {
        InitializeComponent();
    }

    private void btnCalcularNotas_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Variables para capturar nombre del estudiante parcial 1
            if (pkEstudianteP1.SelectedIndex == -1)
            {
                lblError.Text = "ERROR: Debe seleccionar un estudiante.";
                return;
            }

            string estudiante = pkEstudianteP1.Items[pkEstudianteP1.SelectedIndex].ToString();

            // Variables para capturar notas del estudiante parcial 1
            double notaSeguimiento1, notaExamen1;

            // Validar Nota de Seguimiento P1
            if (!double.TryParse(txtNotaSeguimiento.Text, out notaSeguimiento1))
            {
                lblError.Text = "ERROR: La nota de seguimiento (Parcial 1) debe ser un número válido.";
                return;
            }
            if (notaSeguimiento1 < 0 || notaSeguimiento1 > 10)
            {
                lblError.Text = "ERROR: La nota de seguimiento (Parcial 1) debe estar entre 0 y 10.";
                return;
            }

            // Validar Nota de Examen P1
            if (!double.TryParse(txtExamenP1.Text, out notaExamen1))
            {
                lblError.Text = "ERROR: La nota del examen (Parcial 1) debe ser un número válido.";
                return;
            }
            if (notaExamen1 < 0 || notaExamen1 > 10)
            {
                lblError.Text = "ERROR: La nota del examen (Parcial 1) debe estar entre 0 y 10.";
                return;
            }

            // Variables para capturar notas del estudiante parcial 2
            double notaSeguimiento2, notaExamen2;

            if (!double.TryParse(txtNotaSeguimientoP2.Text, out notaSeguimiento2))
            {
                lblError.Text = "ERROR: La nota de seguimiento (Parcial 2) debe ser un número válido.";
                return;
            }
            if (notaSeguimiento2 < 0 || notaSeguimiento2 > 10)
            {
                lblError.Text = "ERROR: La nota de seguimiento (Parcial 2) debe estar entre 0 y 10.";
                return;
            }

            // Validar Nota de Examen P2
            if (!double.TryParse(txtExamenP2.Text, out notaExamen2))
            {
                lblError.Text = "ERROR: La nota del examen (Parcial 2) debe ser un número válido.";
                return;
            }
            if (notaExamen2 < 0 || notaExamen2 > 10)
            {
                lblError.Text = "ERROR: La nota del examen (Parcial 2) debe estar entre 0 y 10.";
                return;
            }

            string fecha = dtpFecha.Date.ToString();

            // Estado del estudiante en base a las notas
            string estado;

            if (notaFinal >= 0.1 && notaFinal <= 4.9)
            {
                estado = "Reprobado";
            }
            else if (notaFinal >= 5 && notaFinal <= 6.9)
            {
                estado = "Complementario";
            }
            else if (notaFinal >= 7 && notaFinal <= 10)
            {
                estado = "Aprobado";
            }
            else
            {
                estado = "Nota inválida";
            }

            lblError.Text = "";

            DisplayAlert(
                "Resumen del Estudiante",
                "Nombre: " + estudiante + "\n" +
                "Fecha: " + fecha + "\n" +
                "Nota Parcial 1: " + notaParcial1.ToString("F2") + "\n" +
                "Nota Parcial 2: " + notaParcial2.ToString("F2") + "\n" +
                "Nota Final: " + notaFinal + "\n" +
                "Estado: " + estado,
                "OK"
            );

        }
        catch (Exception ex)
        {
            lblError.Text = "ERROR " + ex.Message;
        }
    }

    private void txtNotasFormato_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;

        if (string.IsNullOrEmpty(entry.Text))
        {
            entry.TextColor = Colors.White;
            return;
        }

        // Validar que el valor ingresado sea numérico decimal
        if (!decimal.TryParse(entry.Text, out decimal valor))
        {
            entry.TextColor = Colors.Red;
            return;
        }

        // Validar rango (0 a 10)
        if (valor < 0 || valor > 10)
        {
            entry.TextColor = Colors.Red;
        }
        else
        {
            entry.TextColor = Colors.White;
        }

        actualizarNotas();
    }

    public void actualizarNotas()
    {
        // Notas Parcial 1
        double notaSeguimiento1, notaExamen1;

        // Validar Nota de Seguimiento P1
        if (!double.TryParse(txtNotaSeguimiento.Text, out notaSeguimiento1))
        {
            return;
        }
        if (notaSeguimiento1 < 0 || notaSeguimiento1 > 10)
        {
            return;
        }

        // Validar Nota de Examen P1
        if (!double.TryParse(txtExamenP1.Text, out notaExamen1))
        {
            return;
        }
        if (notaExamen1 < 0 || notaExamen1 > 10)
        {
            return;
        }

        // Calculo de notas parciales
        notaParcial1 = (notaSeguimiento1 * 0.3) + (notaExamen1 * 0.2);
        lblNotaP1.Text = notaParcial1.ToString("0.00");

        // Notas Parcial 2
        double notaSeguimiento2, notaExamen2;

        if (!double.TryParse(txtNotaSeguimientoP2.Text, out notaSeguimiento2))
        {
            return;
        }
        if (notaSeguimiento2 < 0 || notaSeguimiento2 > 10)
        {
            return;
        }

        // Validar Nota de Examen P2
        if (!double.TryParse(txtExamenP2.Text, out notaExamen2))
        {
            return;
        }
        if (notaExamen2 < 0 || notaExamen2 > 10)
        {
            return;
        }

        // Calculo de notas parciales
        notaParcial2 = (notaSeguimiento2 * 0.3) + (notaExamen2 * 0.2);
        lblNotaP2.Text = notaParcial2.ToString("0.00");

        notaFinal = notaParcial1 + notaParcial2;
        lblNotaFinal.Text = notaFinal.ToString("0.00");
    }
}