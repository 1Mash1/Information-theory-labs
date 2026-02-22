using System;
using System.Text;
using System.Windows.Forms;

namespace TI_1;

public static class ImprovedColumnarCipher
{
    public static string GetOnlyLetters(string input)
    {
        string result = "";
        char upper;
        foreach (char symbol in input)
        {
            upper = char.ToUpper(symbol);
            if (upper >= 'A' && upper <= 'Z')
                result += upper;
        }
        return result;
    }

    private static string GetTextWithSpaces(string input)
    {
        string result = "";
        char upper;
        foreach (char symbol in input)
        {
            upper = char.ToUpper(symbol);
            if ((upper >= 'A' && upper <= 'Z') || upper == ' ' || upper == '\n' || upper == '\r')
                result += upper;
        }
        return result;
    }

    private static int[] GetColumnOrder(string key)
    {
        string upperKey;
        int keyLength;
        int counter = 1;
        int[] order;
        upperKey = GetOnlyLetters(key);
        keyLength = upperKey.Length;
        if (keyLength == 0)
            return Array.Empty<int>();
        order = new int[keyLength];
        for (char letter = 'A'; letter <= 'Z'; letter++)
            for (int i = 0; i < keyLength; i++)
                if (upperKey[i] == letter)
                    order[i] = counter++;
        return order;
    }

    private static void GetTableSize(string text, string key, out int rows, out int reps, out int[] order)
    {
        int capacity = 0, rowIndex = 0, stopCol;
        string currentKey;
        currentKey = key;
        reps = 1;
        order = GetColumnOrder(currentKey);
        while (capacity < text.Length)
        {
            stopCol = Array.IndexOf(order, (rowIndex % order.Length) + 1);
            capacity += (stopCol + 1);
            rowIndex++;
            if (rowIndex >= order.Length && capacity < text.Length)
            {
                reps++;
                currentKey += key;
                order = GetColumnOrder(currentKey);
            }
        }
        rows = rowIndex;
    }

    public static string Encipher(string text, string key, DataGridView grid = null)
    {
        int rows, reps, textIdx = 0, stop;
        int[] order;
        string baseText, clean, letters;
        char[,] matrix;
        baseText = GetTextWithSpaces(text);
        clean = GetOnlyLetters(baseText);
        if (clean.Length == 0)
            return baseText;
        GetTableSize(clean, key, out rows, out reps, out order);
        matrix = new char[rows, order.Length];
        for (int i = 0; i < rows; i++)
        {
            stop = Array.IndexOf(order, (i % order.Length) + 1);
            for (int j = 0; j <= stop && textIdx < clean.Length; j++)
                matrix[i, j] = clean[textIdx++];
        }
        if (grid != null)
            UpdateGrid(grid, key, reps, order, matrix);
        letters = ReadByColumns(matrix, order);
        return RestoreSpaces(baseText, letters);
    }

    private static string ReadByColumns(char[,] matrix, int[] order)
    {
        string res = "";
        int rows, cols, col;
        rows = matrix.GetLength(0);
        cols = matrix.GetLength(1);
        for (int priority = 1; priority <= cols; priority++)
        {
            col = Array.IndexOf(order, priority);
            for (int r = 0; r < rows; r++)
                if (matrix[r, col] != '\0')
                    res += matrix[r, col];
        }
        return res;
    }

    public static string Decipher(string text, string key, DataGridView grid = null)
    {
        int rows, reps, p = 0, stop, col, lettersCount = 0;
        int[] order;
        string baseText, clean, letters;
        char[,] matrix;
        bool[,] mask;
        baseText = GetTextWithSpaces(text);
        clean = GetOnlyLetters(baseText);
        if (clean.Length == 0)
            return baseText;
        GetTableSize(clean, key, out rows, out reps, out order);
        matrix = new char[rows, order.Length];
        mask = new bool[rows, order.Length];
        for (int i = 0; i < rows; i++)
        {
            stop = Array.IndexOf(order, (i % order.Length) + 1);
            for (int j = 0; j <= stop && lettersCount < clean.Length; j++)
            {
                mask[i, j] = true;
                lettersCount++;
            }
        }
        p = 0;
        for (int priority = 1; priority <= order.Length; priority++)
        {
            col = Array.IndexOf(order, priority);
            for (int i = 0; i < rows; i++)
                if (mask[i, col] && p < clean.Length)
                    matrix[i, col] = clean[p++];
        }
        if (grid != null)
            UpdateGrid(grid, key, reps, order, matrix);
        letters = ReadByRows(matrix, order);
        return RestoreSpaces(baseText, letters);
    }

    private static string ReadByRows(char[,] matrix, int[] order)
    {
        string res = "";
        int stop;
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            stop = Array.IndexOf(order, (r % order.Length) + 1);
            for (int c = 0; c <= stop; c++)
                if (matrix[r, c] != '\0')
                    res += matrix[r, c];
        }
        return res;
    }

    private static string RestoreSpaces(string baseStr, string letters)
    {
        char upper;
        int p = 0;
        var sb = new StringBuilder(baseStr.Length);
        foreach (char c in baseStr)
        {
            upper = char.ToUpper(c);
            if (upper >= 'A' && upper <= 'Z')
            {
                if (p < letters.Length)
                    sb.Append(letters[p++]);
            }
            else if (c == ' ' || c == '\n' || c == '\r')
                    sb.Append(c);
        }
        return sb.ToString();
    }

    public static void UpdateGrid(DataGridView grid, string key, int reps, int[] order, char[,] matrix)
    {
        string fullKey = "", cleanKey;
        string[] row;
        grid.Rows.Clear();
        grid.Columns.Clear();
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        for (int i = 0; i < reps; i++) fullKey += key.ToUpper();
        cleanKey = GetOnlyLetters(fullKey);
        for (int i = 0; i < order.Length; i++)
        {
            grid.Columns.Add("c" + i, cleanKey[i] + " (" + order[i] + ")");
            grid.Columns[i].Width = 50;
        }
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            row = new string[order.Length];
            for (int c = 0; c < order.Length; c++)
                row[c] = (matrix[r, c] == '\0') ? "" : matrix[r, c].ToString();
            grid.Rows.Add(row);
        }
    }
}