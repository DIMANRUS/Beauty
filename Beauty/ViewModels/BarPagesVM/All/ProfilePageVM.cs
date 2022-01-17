using Beauty.ViewModels.Shared;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using Beauty.Pages;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Xamarin.CommunityToolkit.UI.Views;
using Beauty.Helpers;
using Beauty.Requests;
using Beauty.Responses;

namespace Beauty.ViewModels.BarPagesVM.All {
    class ProfilePageVm : BaseVm {
        public ProfilePageVm() {
            Task.Run(async () => {
                CurrentState = LayoutState.Loading;
                using HttpHelper httpHelper = new ();
                var userResponse = await httpHelper.GetRequest<UserResponse>("User/GetUser");
                UserName = userResponse.UserName;
                Phone = userResponse.PhoneNumber;
                Email = userResponse.Email;
                Photo = userResponse.Photo;
                CurrentState = LayoutState.None;
                NotifyPropertyChanged(nameof(Photo));
            });
            ExitCommand = new Command(() => {
                SecureStorage.RemoveAll();
                Application.Current.MainPage = new AuthPage();
            });
            PageLoadingCommand = new Command(() =>
                _page = Application.Current.MainPage);
            OpenFilePicker = new Command(async () => {
            //var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            //{
            //        { DevicePlatform.iOS, new[] { "public.my.comic.extension" } },
            //        { DevicePlatform.Android, new[] { "application/comics" } }
            //    });
            //PickOptions options = new() {
            //    PickerTitle = "Выберите фото",
            //    FileTypes = customFileType,
            //};
            var result = await FilePicker.PickAsync();
            if (result == null ||
                !result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) &&
                !result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                return;
            var stream = await result.OpenReadAsync();
            await using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            Photo = ms.ToArray();
        });
            SaveNewUserData = new Command(async() => {
            CurrentState = LayoutState.Loading;
            if (CurrentPassword != "") {
                UserRequest userRequest = new() {
                    CurrentPassword = CurrentPassword,
                    NewPassword = NewPassword,
                    Email = _email,
                    PhoneNumber = _phone,
                    Photo = _photo
                };
                HttpResponseMessage result;
                using (HttpHelper httpHelper = new ()) {
                    result = await httpHelper.PostRequest("User/UpdateUser", userRequest);
                }
                if (result.StatusCode == HttpStatusCode.OK) {
                    await SecureStorage.SetAsync("UserEmail", _email);
                    await _page.DisplayAlert("Успешно", "Данные изменены", "Ок");
                } else {
                    await _page.DisplayAlert("Ошибка", "Данные не изменены. Ошибка пароля.", "Ок");
                }
            } else {
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

    public ICommand ExitCommand { get; }
    public ICommand OpenFilePicker { get; }
    public ICommand SaveNewUserData { get; }
}
}