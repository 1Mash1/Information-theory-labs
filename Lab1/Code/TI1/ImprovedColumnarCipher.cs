using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TI_1;
public static class ImprovedColumnarCipher
{
    public static string GetPlainText(string str)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char symbol in str)
        {
            char upperSymbol = char.ToUpper(symbol);
            if (upperSymbol >= 'A' && upperSymbol <= 'Z')
                sb.Append(upperSymbol);
        }
        return sb.ToString();
    }

    private static string FilterKey(string key)
    {
        char upperSymbol;
        StringBuilder filteredKey = new StringBuilder();
        foreach (char symbol in key)
        {
            upperSymbol = char.ToUpper(symbol);
            if (upperSymbol >= 'A' && upperSymbol <= 'Z')
                filteredKey.Append(upperSymbol);
        }
        return filteredKey.ToString();
    }

    private static int[] CalculateColumnOrder(string upperKey)
    {
        int[] order;
        List<KeyValuePair<char, int>> pairs;
        pairs = new List<KeyValuePair<char, int>>();
        for (int i = 0; i < upperKey.Length; i++)
            pairs.Add(new KeyValuePair<char, int>(upperKey[i], i));
        var sortedPairs = pairs.OrderBy(p => p.Key).ThenBy(p => p.Value).ToList();
        order = new int[upperKey.Length];
        for (int i = 0; i < sortedPairs.Count; i++)
            order[sortedPairs[i].Value] = i + 1;
        return order;
    }

    private static int[] GetColumnOrder(string key)
    {
        string upperKey;
        upperKey = FilterKey(key);
        if (upperKey.Length == 0)
        {
            MessageBox.Show("Ключ должен содержать хотя бы одну латинскую букву!", "Внимание");
            return [];
        }
        return CalculateColumnOrder(upperKey);
    }

    public static void ShowTableInGrid(DataGridView dataGrid, string key, int[] order, List<List<char>> table)
    {
        char upperSymbol;
        string upperKey, cellValue;
        int columnCount;
        string[] rowData;
        bool hasLetters;
        dataGrid.AllowUserToAddRows = false;
        dataGrid.Rows.Clear();
        dataGrid.Columns.Clear();
        dataGrid.Visible = true;
        StringBuilder filteredKey = new StringBuilder();
        foreach (char symbol in key)
        {
            upperSymbol = char.ToUpper(symbol);
            if (upperSymbol >= 'A' && upperSymbol <= 'Z')
                filteredKey.Append(upperSymbol);
        }
        upperKey = filteredKey.ToString();
        columnCount = order.Length;
        for (int i = 0; i < columnCount; i++)
        {
            dataGrid.Columns.Add($"col{i}", $"{upperKey[i]} ({order[i]})");
            dataGrid.Columns[i].Width = 50;
        }
        for (int row = 0; row < table.Count; row++)
        {
            rowData = new string[columnCount];
            for (int col = 0; col < columnCount; col++)
            {
                if (table[row][col] != '\0' && table[row][col] != ' ')
                    rowData[col] = table[row][col].ToString();
                else
                    rowData[col] = "";
            }
            dataGrid.Rows.Add(rowData);
        }
        if (dataGrid.Rows.Count > 0)
        {
            DataGridViewRow lastRow = dataGrid.Rows[dataGrid.Rows.Count - 1];
            hasLetters = false;
            for (int i = 0; i < columnCount; i++)
            {
                cellValue = lastRow.Cells[i].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(cellValue) && char.IsLetter(cellValue[0]))
                {
                    hasLetters = true;
                    break;
                }
            }
            if (!hasLetters)
                dataGrid.Rows.Remove(lastRow);
        }
    }

    public static string Encipher(string plainText, string key, DataGridView dataGrid = null)
    {
        string cleanText, repeatedKey, displayKey;
        int repeats = 1, columnCount, totalCapacity = 0, row = 0;
        int stopValue, stopIndex, textIndex = 0, currentRow = 0, colIndex;
        int[] columnOrder;
        List<List<char>> table;
        bool foundStopColumn;
        cleanText = GetPlainText(plainText);
        if (cleanText.Length == 0)
        {
            MessageBox.Show("Длина вашего текста должна быть отличная от нуля!", "Внимание");
            return plainText;
        }
        if (key.Length == 0)
        {
            MessageBox.Show("Ключ не должен быть пустым!", "Внимание");
            return plainText;
        }
        columnOrder = GetColumnOrder(key);
        columnCount = columnOrder.Length;
        while (totalCapacity < cleanText.Length)
        {
            stopValue = (row % columnCount) + 1;
            stopIndex = Array.IndexOf(columnOrder, stopValue);
            totalCapacity += stopIndex + 1;
            row++;
            if (row >= columnCount && totalCapacity < cleanText.Length)
            {
                repeats++;
                repeatedKey = "";
                for (int i = 0; i < repeats; i++)
                    repeatedKey += key;
                columnOrder = GetColumnOrder(repeatedKey);
                columnCount = columnOrder.Length;
            }
        }
        for (int i = 1; i < repeats; i++)
        {
            repeatedKey = "";
            for (int j = 0; j <= i; j++)
                repeatedKey += key;
            columnOrder = GetColumnOrder(repeatedKey);
            columnCount = columnOrder.Length;
        }
        table = new List<List<char>>();
        textIndex = 0;
        currentRow = 0;
        while (textIndex < cleanText.Length)
        {
            table.Add(new List<char>());
            foundStopColumn = false;
            stopValue = (currentRow % columnCount) + 1;
            stopIndex = Array.IndexOf(columnOrder, stopValue);
            for (int col = 0; col < columnCount; col++)
            {
                if (!foundStopColumn)
                {
                    if (textIndex < cleanText.Length)
                    {
                        table[currentRow].Add(cleanText[textIndex]);
                        textIndex++;
                    }
                    else
                        table[currentRow].Add('\0');
                    if (col == stopIndex)
                        foundStopColumn = true;
                }
                else
                    table[currentRow].Add('\0');
            }
            currentRow++;
        }
        if (dataGrid != null)
        {
            displayKey = "";
            for (int i = 0; i < repeats; i++)
                displayKey += key;
            ShowTableInGrid(dataGrid, displayKey, columnOrder, table);
        }
        StringBuilder cipher = new StringBuilder();
        for (int i = 1; i <= columnCount; i++)
        {
            colIndex = Array.IndexOf(columnOrder, i);
            for (int r = 0; r < table.Count; r++)
                if (colIndex < table[r].Count && table[r][colIndex] != '\0' && table[r][colIndex] != ' ')
                    cipher.Append(table[r][colIndex]);
        }
        return cipher.ToString();
    }

    public static string Decipher(string cipherText, string key, DataGridView dataGrid = null)
    {
        string cleanText, repeatedKey, displayKey;
        int[] columnOrder;
        int repeats = 1, columnCount, totalCapacity = 0, row = 0, stopValue, stopIndex, stopCol;
        int cols, total, filled = 0, rowNum = 0, rows, textIndex = 0, colIndex;
        List<List<int>> rowStructure;
        List<int> row_;
        List<List<char>> table;
        cleanText = GetPlainText(cipherText);
        if (cleanText.Length == 0 || key.Length == 0)
            return cipherText;
        columnOrder = GetColumnOrder(key);
        columnCount = columnOrder.Length;
        while (totalCapacity < cleanText.Length)
        {
            stopValue = (row % columnCount) + 1;
            stopIndex = Array.IndexOf(columnOrder, stopValue);
            totalCapacity += stopIndex + 1;
            row++;
            if (row >= columnCount && totalCapacity < cleanText.Length)
            {
                repeats++;
                repeatedKey = "";
                for (int i = 0; i < repeats; i++)
                    repeatedKey += key;
                columnOrder = GetColumnOrder(repeatedKey);
                columnCount = columnOrder.Length;
            }
        }
        for (int i = 1; i < repeats; i++)
        {
            repeatedKey = "";
            for (int j = 0; j <= i; j++)
                repeatedKey += key;
            columnOrder = GetColumnOrder(repeatedKey);
            columnCount = columnOrder.Length;
        }
        cols = columnOrder.Length;
        total = cleanText.Length;
        rowStructure = new List<List<int>>();
        while (filled < total)
        {
            row_ = new List<int>();
            stopValue = (rowNum % cols) + 1;
            stopCol = Array.IndexOf(columnOrder, stopValue);
            for (int c = 0; c <= stopCol && filled < total; c++)
            {
                row_.Add(c);
                filled++;
            }
            rowStructure.Add(row_);
            rowNum++;
        }
        rows = rowStructure.Count;
        table = new List<List<char>>();
        for (int i = 0; i < rows; i++)
        {
            table.Add(new List<char>());
            for (int j = 0; j < cols; j++)
            {
                table[i].Add('\0');
            }
        }
        for (int order = 1; order <= cols; order++)
        {
            colIndex = Array.IndexOf(columnOrder, order);
            for (int r = 0; r < rows; r++)
            {
                if (rowStructure[r].Contains(colIndex))
                {
                    if (textIndex < cleanText.Length)
                    {
                        table[r][colIndex] = cleanText[textIndex];
                        textIndex++;
                    }
                }
            }
        }
        if (dataGrid != null)
        {
            displayKey = "";
            for (int i = 0; i < repeats; i++)
                displayKey += key;
            ShowTableInGrid(dataGrid, displayKey, columnOrder, table);
        }
        StringBuilder plain = new StringBuilder();
        for (int r = 0; r < rows; r++)
        {
            foreach (int col in rowStructure[r])
            {
                if (table[r][col] != '\0' && table[r][col] != ' ')
                    plain.Append(table[r][col]);
            }
        }
        return plain.ToString();
    }

}


