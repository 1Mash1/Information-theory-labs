using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TI_1;

public static class Vigener
{
    public const int LetterCount = 33;
    public static string GetPlainTextOrKey(string str)
    {
        StringBuilder sb = new();
        foreach (char symbol in str)
        {
            var upperSymbol = char.ToUpper(symbol);
            if (upperSymbol is <= 'Я' and >= 'А' or 'Ё')
                sb.Append(symbol);
        }
        return sb.ToString();
    }

    private static string GetPlainTextWithSpaces(string str)
    {
        StringBuilder sb = new();
        foreach (char symbol in str)
        {
            var upperSymbol = char.ToUpper(symbol);
            if (upperSymbol is <= 'Я' and >= 'А' or 'Ё' or ' ' or '\n' or '\r')
                sb.Append(upperSymbol);
        }
        return sb.ToString();
    }

    public static void ShowVigenereTable(DataGridView dataGrid)
    {
        char[] alphabet;
        int index = 0, resultIndex;
        string[] rowData;
        dataGrid.Rows.Clear();
        dataGrid.Columns.Clear();
        dataGrid.Visible = true;
        dataGrid.AllowUserToAddRows = false;
        alphabet = new char[LetterCount];
        for (char i = 'А'; i <= 'Я'; i++)
        {
            if (i == 'Е' + 1)
                alphabet[index++] = 'Ё';
            alphabet[index++] = i;
        }
        dataGrid.DefaultCellStyle.Font = new Font("Arial", 9);
        dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
        dataGrid.RowTemplate.Height = 20;
        dataGrid.ColumnHeadersHeight = 22;
        dataGrid.Columns.Add("col0", "");
        dataGrid.Columns[0].Width = 30;
        for (int i = 0; i < LetterCount; i++)
        {
            dataGrid.Columns.Add($"col{i + 1}", alphabet[i].ToString());
            dataGrid.Columns[i + 1].Width = 22;
        }
        for (int row = 0; row < LetterCount; row++)
        {
            rowData = new string[LetterCount + 1];
            rowData[0] = alphabet[row].ToString();
            for (int col = 0; col < LetterCount; col++)
            {
                resultIndex = (row + col) % LetterCount;
                rowData[col + 1] = alphabet[resultIndex].ToString();
            }
            dataGrid.Rows.Add(rowData);
        }
        dataGrid.Rows[0].DefaultCellStyle.BackColor = Color.LightYellow;
        dataGrid.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
        dataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
        foreach (DataGridViewColumn column in dataGrid.Columns)
        {
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
    
    public static string Encipher(string plainText, string key)
    {
        char[] letterArray;
        char keyLetter;
        int letter = 0, index = 0, changedLetter, changedKeyLetter, alphabetIndex = 0; ;
        plainText = GetPlainTextWithSpaces(plainText);
        var resultText = GetPlainTextOrKey(plainText);
        if (resultText is "")
            return "";
        letterArray = new char[LetterCount];
        for (char i = 'А'; i <= 'Я'; i++)
        {
            if (letter == 6)
                letterArray[letter++] = 'Ё';
            letterArray[letter++] = i;
        }
        StringBuilder sbCipherText = new StringBuilder();
        StringBuilder generatedKey = new StringBuilder(key);
        for (int i = 0; i < resultText.Length; i++)
        {
            if (i < key.Length)
                keyLetter = generatedKey[i];
            else
            {
                keyLetter = resultText[i - key.Length];
                generatedKey.Append(keyLetter);
            }
            if (resultText[i] == 'Ё')
                changedLetter = 6;
            else
                changedLetter = resultText[i] <= 'Е' ? resultText[i] - 'А' : resultText[i] - 'А' + 1;
            switch (keyLetter)
            {
                case 'Ё':
                    sbCipherText.Append(letterArray[(changedLetter + 6) % LetterCount]);
                    break;
                case <= 'Е':
                    {
                        changedKeyLetter = keyLetter - 'А';
                        sbCipherText.Append(letterArray[(changedLetter + changedKeyLetter) % LetterCount]);
                        break;
                    }
                default:
                    {
                        changedKeyLetter = keyLetter - 'А' + 1;
                        sbCipherText.Append(letterArray[(changedLetter + changedKeyLetter) % LetterCount]);
                        break;
                    }
            }
        }
        StringBuilder finalResult = new StringBuilder();
        foreach (char symbol in plainText)
        {
            var upper = char.ToUpper(symbol);
            if (upper is <= 'Я' and >= 'А' or 'Ё')
                finalResult.Append(sbCipherText[alphabetIndex++]);
            else if (symbol == ' ' || symbol == '\n' || symbol == '\r')
                finalResult.Append(symbol);
        }
        return finalResult.ToString();
    }
    public static string Decipher(string cipher, string key)
    {
        char[] letterArray;
        int letter = 0, index = 0, changedLetter, changedKeyLetter, plainTextIdx = 0;
        char keyLetter;
        cipher = GetPlainTextWithSpaces(cipher);
        var resultText = GetPlainTextOrKey(cipher);
        if (resultText is "")
            return "";
        letterArray = new char[LetterCount];
        for (char i = 'А'; i <= 'Я'; i++)
        {
            if (letter == 6)
                letterArray[letter++] = 'Ё';
            letterArray[letter++] = i;
        }
        StringBuilder sbPlainText = new StringBuilder();
        StringBuilder generatedKey = new StringBuilder(key);
        for (int i = 0; i < resultText.Length; i++)
        {
            if (i < key.Length)
                keyLetter = generatedKey[i];
            else
            {
                keyLetter = sbPlainText[i - key.Length];
                generatedKey.Append(keyLetter);
            }
            if (resultText[i] == 'Ё')
                changedLetter = 6;
            else
                changedLetter = resultText[i] <= 'Е' ? resultText[i] - 'А' : resultText[i] - 'А' + 1;
            switch (keyLetter)
            {
                case 'Ё':
                    sbPlainText.Append(letterArray[(changedLetter + (LetterCount - 6)) % LetterCount]);
                    break;
                case <= 'Е':
                    {
                        changedKeyLetter = keyLetter - 'А';
                        sbPlainText.Append(letterArray[(changedLetter + (LetterCount - changedKeyLetter)) % LetterCount]);
                        break;
                    }
                default:
                    {
                        changedKeyLetter = keyLetter - 'А' + 1;
                        sbPlainText.Append(letterArray[(changedLetter + (LetterCount - changedKeyLetter)) % LetterCount]);
                        break;
                    }
            }
        }
        StringBuilder finalResult = new StringBuilder();
        foreach (char symbol in cipher)
        {
            var upper = char.ToUpper(symbol);
            if (upper is <= 'Я' and >= 'А' or 'Ё')
                if (plainTextIdx < sbPlainText.Length)
                    finalResult.Append(sbPlainText[plainTextIdx++]);
            else if (symbol == ' ' || symbol == '\n' || symbol == '\r')
                finalResult.Append(symbol);
        }
        return finalResult.ToString();
    }
}