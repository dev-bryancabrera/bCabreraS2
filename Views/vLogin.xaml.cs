namespace bCabreraS2.Views;

public partial class vLogin : ContentPage
{
    // Credenciales de usuario predefinidas
    string[] usuarios = { "Carlos", "Ana", "Jose" };
    string[] contrasenas = { "carlos123", "ana123", "jose123" };

    public vLogin()
    {
        InitializeComponent();
    }

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        try
        {
            string user = txtUsuario.Text;
            string passwd = txtPassword.Text;

            bool usuarioValido = false;

            for (int i = 0; i < usuarios.Length; i++)
            {
                if (user == usuarios[i] && passwd == contrasenas[i])
                {
                    // Credenciales correctas
                    usuarioValido = true;
                    break;
                }
            }

            if (!usuarioValido)
            {
                DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
                return;
            }

            Navigation.PushAsync(new vPrincipal(user, passwd));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al iniciar sesión: {ex.Message}");

        }
    }
}