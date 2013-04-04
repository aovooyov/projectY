using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using Yandex.Direct;
using Yandex.Direct.Authentication;
using Yandex.Direct.Configuration;

namespace YDirect.Model
{
    public partial class Facade
    {
        private static readonly Lazy<Facade> _instance = new Lazy<Facade>(() => new Facade());
        public static Facade Instance
        {
            get { return _instance.Value; }
        }

        private Facade() { }

        private string _login;
        private IEnumerable<ShortClientInfo> _clients;

        public YandexDirectService YandexDirect { get; private set; }

        public IEnumerable<ShortClientInfo> ClientList
        {
            get { return _clients ?? (_clients = YandexDirect.GetClientsList()); }
        }

        //public string Login
        //{
        //    get { return _login ?? (_login = ((YandexDirectAuthProviderBase)YandexDirect.Configuration.AuthProvider).Login); }
        //}

        public string[] Logins
        {
            get { return ClientList.Select(c => c.Login).ToArray(); }
        }

        //public void LoginYandexDirect(string certificatePath, string password)
        //{
        //    var config = new YandexDirectConfiguration(certificatePath, password, YandexApiLanguage.Russian);
        //    YandexDirect = new YandexDirectService(config);
        //    YandexDirect.TestApiConnection();
        //}

        //public void LoginSandbox()
        //{
        //    YandexDirect = new YandexDirectService();
        //    YandexDirect.TestApiConnection();
        //}

        public bool CreatePfx(string name, string path)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(path))
                return false;

            if (!Directory.Exists(path))
                return false;

            var files = Directory.GetFiles(path);
            string
                cert = files.FirstOrDefault(file => file.Contains("cert.crt")),
                privatekey = files.FirstOrDefault(file => file.Contains("private.key")),
                cacert = files.FirstOrDefault(file => file.Contains("cacert.pem")),
                req = files.FirstOrDefault(file => file.Contains("req.csr")),
                location = string.Format("{0}\\{1}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "pfx");

            if (string.IsNullOrEmpty(cert) || string.IsNullOrEmpty(privatekey) || string.IsNullOrEmpty(cacert) || string.IsNullOrEmpty(req))
                return false;

            if (!Directory.Exists(location))
                Directory.CreateDirectory(location);

            string
                pfx = string.Format("{0}\\{1}.pfx", location, name),
                arguments = string.Format("/env /user:Administrator cmd /K \"C:\\OpenSSL-Win64\\bin\\openssl pkcs12 -in \"{0}\" -inkey \"{1}\" -export -out \"{2}\"\"", cert, privatekey, pfx);

            if (File.Exists(pfx))
                return false;

            var process = Process.Start(new ProcessStartInfo
                          {
                              FileName = "cmd.exe",
                              UseShellExecute = true,
                              Verb = "runas",
                              Arguments = arguments,
                          });

            process.WaitForExit();
            return true;
        }

        public string[] GetProfiles()
        {
            var location = string.Format("{0}\\{1}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "pfx");
            return Directory
                .GetFiles(location, "*.pfx")
                .Select(f => f.Substring(f.LastIndexOf("\\", StringComparison.Ordinal) + 1).Replace(".pfx", ""))
                .ToArray();
        }

        public string GetPathCertificate(string profile)
        {
            var location = string.Format("{0}\\{1}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "pfx");
            return Directory
                .GetFiles(location, "*.pfx")
                .FirstOrDefault(f => f.Substring(f.LastIndexOf("\\", StringComparison.Ordinal) + 1).Replace(".pfx", "") == profile);
        }

        public bool Login(string profile, string password)
        {
            var certificatePath = GetPathCertificate(profile);
            
            if (string.IsNullOrEmpty(certificatePath))
                return false;

            if (!File.Exists(certificatePath))
                return false;

            var config = new YandexDirectConfiguration(profile, certificatePath, password, YandexApiLanguage.Russian);
            YandexDirect = new YandexDirectService(config);
            YandexDirect.TestApiConnection();
            return true;
        }

        public bool RemoveProfile(string profile)
        {
            var certificatePath = GetPathCertificate(profile);

            if (string.IsNullOrEmpty(certificatePath))
                return false;

            if (!File.Exists(certificatePath))
                return false;
            
            File.Delete(certificatePath);
            return true;
        }

        public void Sandbox()
        {
            YandexDirect = new YandexDirectService();
            YandexDirect.TestApiConnection();
        }
    }
}
