namespace bCabreraS2.Views;

public partial class vPrincipal : ContentPage
{
    public vPrincipal()
    {
        InitializeComponent();
    }

    public vPrincipal(string usuario, string contrasena)
    {
        InitializeComponent();

        lblUsuario.Text = usuario;
        lblPassword.Text = contrasena;
    }

    private void btnCalificaciones_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vCalificaciones());
    }
}