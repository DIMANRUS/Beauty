using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Input;
using Beauty.ViewModels.Shared;
using Xamarin.Forms;
using Beauty.Shared.Requests;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using Xamarin.Essentials;
using Xamarin.CommunityToolkit.UI.Views;
using System.Threading.Tasks;
using Beauty.Pages;
using System.IO;
using Beauty.Shared.Helpers;
using Beauty.Helpers;
using Beauty.Stores;
using Xamarin.CommunityToolkit.ObjectModel;
using NetworkAccess = Xamarin.Essentials.NetworkAccess;

namespace Beauty.ViewModels {
    public class AuthPageVm : BaseVm {
        #region Private fields
        private Page _page;
        private string _authButtonText = "Войти";
        private string _changeTypeAuthButtonText = "Зарегистрироваться";
        private byte[] _photo;
        private bool _isSelfEmployyed = true;
        #endregion
        public AuthPageVm() {
            OnAppearing = new Command(()
                => _page = Application.Current.MainPage);
            AuthRegClick = new AsyncCommand(async () => {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                    if (Email?.Length >= 5 && Email.Contains('@') && Password?.Length >= 5) {
                        CurrentState = LayoutState.Loading;
                        HttpResponseMessage result = null;
                        using var httpHelper = new HttpHelper();
                        if (IsVisibleRegisterControls) {
                            if (UserName?.Length >= 5 && Phone?.Length >= 10)
                                result = await Registration(httpHelper);
                        } else
                            result = await Authorization(httpHelper);
                        if (result?.StatusCode == HttpStatusCode.OK) {
                            await SaveUserData(await result.Content.ReadAsStringAsync());
                            Application.Current.MainPage = new BottomBarPage();
                        } else {
                            CurrentState = LayoutState.None;
                            await _page.DisplayAlert($"Ошибка", $"Ошибка входа, обратитесь в поддержку или попробуйте позже. Также проверьте правильность введённых данных.", "OK");
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
            ForgetPassword = new AsyncCommand(async () => {
                if (Email?.Length > 3) {
                    CurrentState = LayoutState.Loading;
                    using var httpClient = new HttpClient();
                    var result = await httpClient.GetAsync($"https://api.beauty.dimanrus.ru/api/forget{Email}");
                    if (result.StatusCode is HttpStatusCode.OK)
                        await _page.DisplayAlert("Успешно", "Письмо с восстановлением пароля отправлено на вашу почту", "OK");
                    else
                        await _page.DisplayAlert("Ошибка", "Пользователь с такой почтой не найден", "OK");
                } else
                    await _page.DisplayAlert("Ошибка", "Заполните поле с почтой для сброса пароля", "OK");
            });
            OpenFilePicker = new AsyncCommand(async () => {
                //var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                //{
                //    { DevicePlatform.iOS, new[] { "public.my.comic.extension" } },
                //    { DevicePlatform.Android, new[] { "application/comics" } }
                //});
                //var options = new PickOptions {
                //    PickerTitle = "Выберите фото",
                //    FileTypes = customFileType,
                //};
                var result = await FilePicker.PickAsync();
                if (result == null)
                    return;
                if (!result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) &&
                    !result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    return;
                var stream = await result.OpenReadAsync();
                _photo = ReadToEnd(stream);
            });
            OpenDialogAboutPassword = new AsyncCommand(async () =>
                await _page.DisplayAlert("Требования к паролю:", "- От 8 до 30 символов\n-Должен содеражть хотябы одну заглавную букву и цифру\n- Должен содержать хотябы один специальный символ: !@~.", "Ок"));
        }
        #region Properties
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        //public string UserRoleInput { get; set; } = "Пользователь";

        public string Phone { get; set; }
        public string Address { get; set; }
        public string AuthButtonText { get => _authButtonText; set { _authButtonText = value; NotifyPropertyChanged(); } }
        public string ChangeTypeAuthButtonText { get => _changeTypeAuthButtonText; set { _changeTypeAuthButtonText = value; NotifyPropertyChanged(); } }

        public bool IsVisibleRegisterControls { get; private set; }
        public bool IsSelfEmployed {
            get => _isSelfEmployyed;
            set => Set(ref _isSelfEmployyed, value);
        }

        public IEnumerable<string> Salons => new string[] {"Привет","Пока","Покатушки" };
        #endregion
        #region Commands
        public ICommand AuthRegClick { get; }
        public ICommand RegisterClick { get; private set; }
        public ICommand ChangeTypeAuthorization { get; }
        public ICommand ForgetPassword { get; }
        public ICommand OnAppearing { get; set; }
        public ICommand OpenFilePicker { get; }
        public ICommand OpenDialogAboutPassword { get; }
        #endregion
        #region Private methods
        async Task<HttpResponseMessage> Authorization(HttpHelper httpHelper) {
            LoginModelRequest loginModelRequest = new() {
                Email = Email,
                Password = Password
            };
            return await httpHelper.PostRequest("auth/login", loginModelRequest);
        }
        async Task<HttpResponseMessage> Registration(HttpHelper httpHelper) {
            RegistrationModelRequest registrationModelRequest = new() {
                Email = Email,
                Password = Password,
                Phone = Phone,
                UserName = UserName,
                Role = UserRole,
                //Role = UserRoleInput switch {
                //    "Пользователь" => "USER",
                //    "Салон" => "SALON",
                //    _ => IsSelfEmployed ? "WORKER" : "WORKERSALON"
                //},
                Address = Address,
                IsSelfEmployed = IsSelfEmployed,
                Photo = _photo
            };
            var content = new StringContent(JsonConvert.SerializeObject(registrationModelRequest), Encoding.UTF8, "application/json");
            return await httpHelper.PostRequest("https://api.beauty.dimanrus.ru/auth/register", content);
        }

        private static byte[] ReadToEnd(Stream stream) {
            long originalPosition = 0;

            if (stream.CanSeek) {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try {
                var readBuffer = new byte[4096];

                var totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0) {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead != readBuffer.Length)
                        continue;
                    var nextByte = stream.ReadByte();
                    if (nextByte == -1)
                        continue;
                    var temp = new byte[readBuffer.Length * 2];
                    Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                    Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                    readBuffer = temp;
                    totalBytesRead++;
                }

                var buffer = readBuffer;
                if (readBuffer.Length == totalBytesRead)
                    return buffer;
                buffer = new byte[totalBytesRead];
                Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                return buffer;
            } finally {
                if (stream.CanSeek)
                    stream.Position = originalPosition;
            }
        }

        private static async Task SaveUserData(string token) {
            TokenHelper tokenHelper = new(token);
            var role = tokenHelper.GetRole();
            await SecureStorage.SetAsync("UserName", tokenHelper.GetName());
            await SecureStorage.SetAsync("UserRole", role);
            await SecureStorage.SetAsync("UserEmail", tokenHelper.GetEmail());
            await SecureStorage.SetAsync("UserId", tokenHelper.GetNameIdentifer());
            await SecureStorage.SetAsync("UserToken", token);
            await UserDataStore.Initializate();
        }
        #endregion
    }
}