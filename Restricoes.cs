using System.Media;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace awtj {
    class Restricoes {
        public void RestrNome(string text, int length, KeyEventArgs e) {
            int carac = (int) e.Key;
            if (carac != 3 && carac != 2 && carac != 23 && carac != 25 && carac != 18 && carac < 44 || carac > 69) {
                e.Handled = true;
                SystemSounds.Beep.Play();
            } else if (text.Length >= length && e.Key != Key.Back && e.Key != Key.Tab && e.Key != Key.Left && e.Key != Key.Right) {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        public void RestrSemEspaco(string text, int length, KeyEventArgs e) {
            if (e.Key.Equals(Key.Space)) {
                e.Handled = true;
                SystemSounds.Beep.Play();
            } else if (text.Length >= length && e.Key != Key.Back && e.Key != Key.Tab && e.Key != Key.Left && e.Key != Key.Right) {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        public void RestrTamanho(string text, int length, KeyEventArgs e) {
            if (text.Length >= length && e.Key != Key.Back && e.Key != Key.Tab && e.Key != Key.Left && e.Key != Key.Right) {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        public bool RestrEmail(string text, int length, KeyEventArgs e) {
            bool valido = false;
            string emailRegex = string.Format("{0}{1}",
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))",
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
            if (text.Length <= 30) {
                try {
                    valido = Regex.IsMatch(text, emailRegex);
                } catch (RegexMatchTimeoutException) {
                    valido = false;
                }
            } else {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
            return valido;
        }
    }
}
