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

namespace Beauty.ViewModels.BarPagesVM.All {
    class ProfilePageVM : BaseVM {
        public ProfilePageVM() {
            ExitCommand = new Command(() => {
                SecureStorage.RemoveAll();
                Application.Current.MainPage = new AuthPage();
            });
            PageLoadingCommand = new Command(() =>
                _page = Application.Current.MainPage);
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

        private Page _page;
        public string UserName { get; private set; } = "Сорокин Алексей Владимирович"; //
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }

        public ICommand ExitCommand { get; private set; }
        public ICommand PageLoadingCommand { get; private set; }
        public ICommand OpenFilePicker { get; private set; }
        public ICommand SaveNewUserData { get; private set; }

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
        async Task UpdateUserData(string token) {
            await SecureStorage.SetAsync("UserEmail", Email);
            await SecureStorage.SetAsync("UserToken", token);
        }
    }
}