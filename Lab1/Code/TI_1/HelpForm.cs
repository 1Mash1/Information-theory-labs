using System;
using System.Drawing;
using System.Windows.Forms;

namespace TI_1
{
    public partial class HelpForm : Form
    {
        public HelpForm(CipherType cipherType)
        {
            InitializeComponent();
            LoadHelpContent(cipherType);
        }

        private void LoadHelpContent(CipherType cipherType)
        {
            if (cipherType == CipherType.Columnar)
            {
                rtbHelp.Text = @"Столбцовый метод (улучшенный).
1. Исходный текст только для английского алфавита, остальные символы просто игнорируются
2. Принцип работы: ключ записывается как заголовки столбцов таблицы.
Определяется порядок каждой буквы ключа (если буквы повторяются, то
нумеруем слева направо). Исходный текст записывается по строкам, причем
в каждой строке до того столбца, у которого совпадает номер со строкой.
Шифротекст формируется записью букв по столбцам: сначала сверху вниз записываем
буквы 1 столбца, затем второго и так далее.
3. Если длины ключа не достаточно для шифрования всех символов, то ключ повторяется.

Пример :
Текст: HELLOWORLD
Ключ: KEY
K E Y K E Y
3 1 5 4 2 6
H E 
L L O W O
R
L D
Результат: ELDOH LRLWO";
            }
            else
            {
                rtbHelp.Text = @"Шифр Виженера
1. Исходный текст только для русского алфавита, остальные символы просто игнорируются.
2. Принцип работы: ключ повторяется до длины текста. Каждая буква для шифрования сдвигается
на позицию буквы ключа по таблице символов.

Пример:
Текст: ПРИВЕТМИР
Ключ: КЛЮЧ 
Результат: ЪЬЖЩФГХКХ";
            }

            rtbHelp.Select(0, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}