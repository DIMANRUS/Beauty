using System;
using System.Net.Http;
using System.Windows.Input;
using Beauty.ViewModels.Shared;
using Xamarin.Forms;
using Beauty.Shared.Requests;
using System.Text.Json;
using System.Text;
using System.Net;
using Xamarin.Essentials;
using Xamarin.CommunityToolkit.UI.Views;
using System.Threading.Tasks;
using Beauty.Pages;

namespace Beauty.ViewModels
{
    public class AuthPageVM : BaseVM
    {
        public AuthPageVM(Page page)
        {
            _page = page;
            AuthRegClick = new Command(async () =>
            {
                if (_email?.Length >= 3 && _password?.Length >= 5)
                {
                    _layoutState = LayoutState.Loading;
                    NotifyPropertyChanged(nameof(CurrentState));
                    HttpResponseMessage result = null;
                    using (var httpClient = new HttpClient())
                    {
                        if (IsVisibleRegisterControls)
                        {
                            if (_userName?.Length >= 2 && _phone?.Length >= 10)
                                result = await Registration(httpClient);
                        }
                        else
                            result = await Authorization(httpClient);
                        if (result.StatusCode == HttpStatusCode.OK && result is not null)
                        {
                            await SecureStorage.SetAsync("user", await result.Content.ReadAsStringAsync());
                            await _page.Navigation.PushModalAsync(new BottomBarPage(), true);
                        }
                        else
                        {
                            _layoutState = LayoutState.None;
                            NotifyPropertyChanged(nameof(CurrentState));
                            await _page.DisplayAlert($"Ошибка", $"Ошибка входа, обратитесь в поддержку или попробуйте позже. Также проверьте правильность введённых данных.", "OK");
                        }
                    }
                }
                else
                    await _page.DisplayAlert("Ошибка", "Заполните все необходимые поля", "OK");
            });
            ChangeTypeAuthorization = new Command(() =>
            {
                IsVisibleRegisterControls = !IsVisibleRegisterControls;
                if (IsVisibleRegisterControls)
                {
                    AuthButtonText = "Зарегистрироваться";
                    ChangeTypeAuthButtonText = "Вход";
                }
                else
                {
                    AuthButtonText = "Войти";
                    ChangeTypeAuthButtonText = "Зарегистрироваться";
                }
                NotifyPropertyChanged(nameof(IsVisibleRegisterControls));
            });
            ForgetPassword = new Command(async () =>
            {
                if (_email?.Length > 3)
                {
                    _layoutState = LayoutState.Loading;
                    NotifyPropertyChanged(nameof(CurrentState));
                    using (var httpClient = new HttpClient())
                    {
                        var result = await httpClient.GetAsync($"https://api.beauty.dimanrus.ru/api/forget{_email}");
                        if (result.StatusCode is HttpStatusCode.OK)
                            await _page.DisplayAlert("Успешно", "Письмо с восстановлением пароля отправлено на вашу почту", "OK");
                        else
                            await _page.DisplayAlert("Ошибка", "Пользователь с такой почтой не найден", "OK");
                    }
                }
                else
                    await _page.DisplayAlert("Ошибка", "Заполните поле с почтой для сброса пароля", "OK");
            });
        }
        private Page _page;
        private string _email = "";
        private string _password = "";
        private string _userName = "";
        private string _userRole = "Пользователь";
        private string _phone = "";
        private string _authButtonText = "Войти";
        private string _changeTypeAuthButtonText = "Зарегистрироваться";
        private LayoutState _layoutState = LayoutState.None;

        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string UserRole { get => _userRole; set => _userRole = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string AuthButtonText { get => _authButtonText; set { _authButtonText = value; NotifyPropertyChanged(); } }
        public string ChangeTypeAuthButtonText { get => _changeTypeAuthButtonText; set { _changeTypeAuthButtonText = value; NotifyPropertyChanged(); } }

        public LayoutState CurrentState { get => _layoutState; private set => _layoutState = value; }

        public bool IsRunIndicator { get => (CurrentState == LayoutState.None) ? false : true; }
        public bool IsVisibleRegisterControls { get; private set; } = false;

        public ICommand AuthRegClick { get; private set; }
        public ICommand RegisterClick { get; private set; }
        public ICommand ChangeTypeAuthorization { get; private set; }
        public ICommand ForgetPassword { get; private set; }

        private async Task<HttpResponseMessage> Authorization(HttpClient httpClient)
        {
            LoginModelRequest loginModelRequest = new LoginModelRequest()
            {
                Email = _email,
                Password = _password
            };
            var content = new StringContent(JsonSerializer.Serialize(loginModelRequest), Encoding.UTF8, "application/json");
            return await httpClient.PostAsync("https://api.beauty.dimanrus.ru/api/auth/login", content);

        }
        private async Task<HttpResponseMessage> Registration(HttpClient httpClient)
        {
            RegistrationModelRequest loginModelRequest = new RegistrationModelRequest()
            {
                Email = _email,
                Password = _password,
                Phone = _phone,
                UserName = _userName,
                Role = UserRole switch
                {
                    "Пользователь" => "User",
                    "Салон" => "Salon",
                    "Работник"=> "Worker",
                    _ => "User"
                }
            };
            var content = new StringContent(JsonSerializer.Serialize(loginModelRequest), Encoding.UTF8, "application/json");
            return await httpClient.PostAsync("https://api.beauty.dimanrus.ru/api/auth/register", content);
        }
    }
}