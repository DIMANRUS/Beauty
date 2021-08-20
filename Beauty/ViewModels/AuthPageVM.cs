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
using System.Collections.Generic;
using System.IO;
using Beauty.Shared.Helpers;

namespace Beauty.ViewModels {
    public class AuthPageVM : BaseVM {
        private Page _page;
        //private string _email = "";
        //private string _password = "";
        //private string _userName = "";
        private string _userRole = "Пользователь";
        //private string _phone = "";
        private string _authButtonText = "Войти";
        private string _changeTypeAuthButtonText = "Зарегистрироваться";
        private LayoutState _layoutState = LayoutState.None;
        private byte[] Photo;
        //private bool
        public AuthPageVM() {
            OnAppearing = new Command(()
                => _page = Application.Current.MainPage);
            AuthRegClick = new Command(async () => {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                    if (Email?.Length >= 3 && Password?.Length >= 5) {
                        _layoutState = LayoutState.Loading;
                        NotifyPropertyChanged(nameof(CurrentState));
                        HttpResponseMessage result = null;
                        using (var httpClient = new HttpClient()) {
                            if (IsVisibleRegisterControls) {
                                if (UserName?.Length >= 2 && Phone?.Length >= 10)
                                    result = await Registration(httpClient);
                            } else
                                result = await Authorization(httpClient);
                            if (result?.StatusCode == HttpStatusCode.OK) {
                                await SaveUserData(await result.Content.ReadAsStringAsync());
                                Application.Current.MainPage = new BottomBarPage();
                            } else {
                                _layoutState = LayoutState.None;
                                NotifyPropertyChanged(nameof(CurrentState));
                                await _page.DisplayAlert($"Ошибка", $"Ошибка входа, обратитесь в поддержку или попробуйте позже. Также проверьте правильность введённых данных.", "OK");
                            }
                        }
                    } else
                        await _page.DisplayAlert("Ошибка", "Заполните все необходимые поля", "OK");
                else
                    await _page.DisplayAlert("Ошибка!", "Проверьте подключение к интернету", "Ок");
            });
            ChangeTypeAuthorization = new Command(() => {
                IsVisibleRegisterControls = !IsVisibleRegisterControls;
                if (IsVisibleRegisterControls) {
                    AuthButtonText = "Зарегистрироваться";
                    ChangeTypeAuthButtonText = "Вход";
                } else {
                    AuthButtonText = "Войти";
                    ChangeTypeAuthButtonText = "Зарегистрироваться";
                }
                NotifyPropertyChanged(nameof(IsVisibleRegisterControls));
            });
            ForgetPassword = new Command(async () => {
                if (Email?.Length > 3) {
                    _layoutState = LayoutState.Loading;
                    NotifyPropertyChanged(nameof(CurrentState));
                    using (var httpClient = new HttpClient()) {
                        var result = await httpClient.GetAsync($"https://api.beauty.dimanrus.ru/api/forget{Email}");
                        if (result.StatusCode is HttpStatusCode.OK)
                            await _page.DisplayAlert("Успешно", "Письмо с восстановлением пароля отправлено на вашу почту", "OK");
                        else
                            await _page.DisplayAlert("Ошибка", "Пользователь с такой почтой не найден", "OK");
                    }
                } else
                    await _page.DisplayAlert("Ошибка", "Заполните поле с почтой для сброса пароля", "OK");
            });
            //ChangeStateSelectionServicesView = new Command(() => {
            //    IsVisibleServicesView = !IsVisibleServicesView;
            //    IsVisibleBox = !IsVisibleBox;
            //    NotifyPropertyChanged(nameof(IsVisibleServicesView));
            //    NotifyPropertyChanged(nameof(IsVisibleBox));
            //});
            OpenFilePicker = new Command(async () => {
                var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "public.my.comic.extension" } },
                    { DevicePlatform.Android, new[] { "application/comics" } }
                });
                var options = new PickOptions {
                    PickerTitle = "Выберите фото",
                    FileTypes = customFileType,
                };
                var result = await FilePicker.PickAsync();
                if (result != null) {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase)) {
                        var stream = await result.OpenReadAsync();
                        Photo = ReadToEnd(stream);
                    }
                }
            });
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string UserRole { get => _userRole; set { _userRole = value; NotifyPropertyChanged(); } }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AuthButtonText { get => _authButtonText; set { _authButtonText = value; NotifyPropertyChanged(); } }
        public string ChangeTypeAuthButtonText { get => _changeTypeAuthButtonText; set { _changeTypeAuthButtonText = value; NotifyPropertyChanged(); } }

        public LayoutState CurrentState { get => _layoutState; private set => _layoutState = value; }

        public bool IsRunIndicator { get => (CurrentState == LayoutState.None) ? false : true; }
        public bool IsVisibleRegisterControls { get; private set; } = false;
        public bool IsSelfEmployed { get; set; }
        //public bool IsVisibleServicesView { get; private set; } = false;
        //public bool IsVisibleBox { get; private set; } = false;

        //public bool IsHairCut { get; set; } = false;
        //public bool IsManicur { get; set; } = false;

        public ICommand AuthRegClick { get; private set; }
        public ICommand RegisterClick { get; private set; }
        public ICommand ChangeTypeAuthorization { get; private set; }
        public ICommand ForgetPassword { get; private set; }
        public ICommand OnAppearing { get; set; }
        //public ICommand ChangeStateSelectionServicesView { get; set; }
        public ICommand OpenFilePicker { get; private set; }

        private async Task<HttpResponseMessage> Authorization(HttpClient httpClient) {
            LoginModelRequest loginModelRequest = new LoginModelRequest() {
                Email = Email,
                Password = Password
            };
            var content = new StringContent(JsonSerializer.Serialize(loginModelRequest), Encoding.UTF8, "application/json");
            return await httpClient.PostAsync("https://api.beauty.dimanrus.ru/auth/login", content);

        }
        private async Task<HttpResponseMessage> Registration(HttpClient httpClient) {
            RegistrationModelRequest registrationModelRequest = new RegistrationModelRequest() {
                Email = Email,
                Password = Password,
                Phone = Phone,
                UserName = UserName,
                Role = UserRole switch {
                    "Пользователь" => "User",
                    "Салон" => "Salon",
                    "Работник" => "Worker",
                    _ => "User"
                },
                Address = Address,
                IsSelfEmployed = IsSelfEmployed,
                Photo = Photo
            };
            var content = new StringContent(JsonSerializer.Serialize(registrationModelRequest), Encoding.UTF8, "application/json");
            return await httpClient.PostAsync("https://api.beauty.dimanrus.ru/auth/register", content);
        }
        static byte[] ReadToEnd(Stream stream) {
            long originalPosition = 0;

            if (stream.CanSeek) {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0) {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length) {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1) {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead) {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            } finally {
                if (stream.CanSeek) {
                    stream.Position = originalPosition;
                }
            }
        }
        async Task SaveUserData(string token) {
            TokenHelper tokenHelper = new TokenHelper( token);
            string role = tokenHelper.GetRole();
            await SecureStorage.SetAsync("UserName",tokenHelper.GetName());
            await SecureStorage.SetAsync("UserRole", (role != "Admin") ? role : "User");
            await SecureStorage.SetAsync("UserEmail", tokenHelper.GetEmail());
            await SecureStorage.SetAsync("UserId", tokenHelper.GetNameIdentifer());
            await SecureStorage.SetAsync("UserToken", token);
        }
    }
}