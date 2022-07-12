using Caesar_Cipher.Algorithm;
using Caesar_Cipher.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Caesar_Cipher.ViewModel
{
    class MainWindowModel : INotifyPropertyChanged
    {
        #region Поля
        Caesar caesar;
        private DelegateCommand _findEncryptedClick;
        public DelegateCommand FindEncryptedClick => _findEncryptedClick ?? (_findEncryptedClick = new DelegateCommand(FindEncrypted));
        private DelegateCommand _findDencryptedClick;
        public DelegateCommand FindDencryptedClick => _findDencryptedClick ?? (_findDencryptedClick = new DelegateCommand(FindDencrypted));
        #endregion
        #region Свойства
        public string EnterMessage { get; set; }
        public string Bias { get; set; }
        public string EncryptedMessage { get; set; }
        public string DencryptedMessage { get; set; }
        public string Alphabet { get; set; }
        #endregion
        public MainWindowModel()
        {
            Alphabet = new string(Enumerable.Range(0, 32).Select((x, i) => (char)('а' + i)).ToArray());
            OnPropertyChanged(nameof(Alphabet));
        }
        #region Методы
        private void FindEncrypted(object obj)
        {
            int bias = 0;
            caesar = new Caesar(Alphabet);
            if(EnterMessage == null || EnterMessage == "")
            {
                MessageBox.Show("Введите сообщение!");
                return;
            }
            try
            {
                bias = int.Parse(Bias);
            }
            catch (Exception)
            {
                MessageBox.Show("Введите корректно смещение!");
                return;
            }
            EncryptedMessage = caesar.GetEncryptedMessage(EnterMessage, int.Parse(Bias));
            OnPropertyChanged(nameof(EncryptedMessage));
            DencryptedMessage = caesar.GetDencryptedMessage(EncryptedMessage, int.Parse(Bias));
            OnPropertyChanged(nameof(DencryptedMessage));

        }
        private void FindDencrypted(object obj)
        {
            int bias = 0;
            caesar = new Caesar(Alphabet);
            if (EnterMessage == null || EnterMessage == "")
            {
                MessageBox.Show("Введите сообщение!");
                return;
            }
            try
            {
                bias = int.Parse(Bias);
            }
            catch (Exception)
            {
                MessageBox.Show("Введите корректно смещение!");
                return;
            }
            DencryptedMessage = caesar.GetDencryptedMessage(EnterMessage, int.Parse(Bias));
            OnPropertyChanged(nameof(DencryptedMessage));
            EncryptedMessage = caesar.GetEncryptedMessage(DencryptedMessage, int.Parse(Bias));
            OnPropertyChanged(nameof(EncryptedMessage));
        }
        #endregion
        #region INotify
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
