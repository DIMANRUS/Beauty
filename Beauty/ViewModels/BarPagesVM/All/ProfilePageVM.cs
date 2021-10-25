using Beauty.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using Beauty.Pages;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using Beauty.Shared.Responses;
using System.Text.Json;
using System.Net.Http.Headers;
using Beauty.Shared.Requests;
using System.Net;
using Xamarin.CommunityToolkit.UI.Views;
using Beauty.Helpers;

namespace Beauty.ViewModels.BarPagesVM.All {
    class ProfilePageVM : BaseVM {
        public ProfilePageVM() {
            Task.Run(async () =>
            {
                CurrentState = LayoutState.Loading;
                UserResponse userResponse = await HttpHelper.GetRequest<UserResponse>("User/GetUser");
                UserName = userResponse.UserName;
                Phone = userResponse.PhoneNumber;
                Email = userResponse.Email;
                Photo = userResponse.Photo;
                CurrentState = LayoutState.None;
            });
            ExitCommand = new Command(() =>
            {
                SecureStorage.RemoveAll();
                Application.Current.MainPage = new AuthPage();
            });
            PageLoadingCommand = new Command(() =>
                _page = Application.Current.MainPage);
            OpenFilePicker = new Command(async () =>
            {
                var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "public.my.comic.extension" } },
                    { DevicePlatform.Android, new[] { "application/comics" } }
                });
                var options = new PickOptions
                {
                    PickerTitle = "Выберите фото",
                    FileTypes = customFileType,
                };
                var result = await FilePicker.PickAsync();
                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        var stream = await result.OpenReadAsync();
                        Photo = ReadToEnd(stream);
                    }
                }
            });
            SaveNewUserData = new Command(async () =>
            {
                CurrentState = LayoutState.Loading;
                if (CurrentPassword != "")
                {
                    HttpClient httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("UserToken"));
                    var userRequest = new UserRequest()
                    {
                        CurrentPassword = CurrentPassword,
                        NewPassword = NewPassword,
                        Email = _email,
                        PhoneNumber = _phone,
                        Photo = _photo
                    };
                    string json = JsonSerializer.Serialize(userRequest);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = await httpClient.PostAsync("https://api.beauty.dimanrus.ru/User/UpdateUser", content);
                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        await SecureStorage.SetAsync("UserEmail", _email);
                        await _page.DisplayAlert("Успешно", "Данные изменены", "Ок");
                    } else
                    {
                        await _page.DisplayAlert("Ошибка", "Данные не изменены. Ошибка пароля.", "Ок");
                    }
                } else
                {
                    await _page.DisplayAlert("Ошибка", "Введите пароль", "Ок");
                }
                CurrentState = LayoutState.None;
            });
        }

        private Page _page;
        public string UserName { get => _userName; private set { _userName = value; NotifyPropertyChanged(); } }
        public string Phone { get => _phone; set { _phone = value; NotifyPropertyChanged(); } }
        public string Email { get => _email; set { _email = value; NotifyPropertyChanged(); } }
        public byte[] Photo { get => _photo; set { _photo = value; NotifyPropertyChanged(); } }
        public string NewPassword { get; set; }
        public string CurrentPassword { get; set; }

        private string _userName;
        private string _phone;
        private string _email;
        private byte[] _photo;

        public ICommand ExitCommand { get; private set; }
        public ICommand OpenFilePicker { get; private set; }
        public ICommand SaveNewUserData { get; private set; }

        static byte[] ReadToEnd(Stream stream) {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            } finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
    }
}