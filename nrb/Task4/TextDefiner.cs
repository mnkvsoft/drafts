using System;

namespace Task4;

static class TextDefiner
{
    private const int MaxLength = 65_536; // 2^16

    public static int GetCountOfOccurrences(string text) => GetCountOfOccurrences(text, 
        main: 'A', 
        padLeft: 4, 
        left: 'B',
        padRight: 1, 
        right: 'C');
    
    private static int GetCountOfOccurrences(string text, char main, int padLeft, char left, int padRight, char right)
    {
        if (text.Length > MaxLength)
            throw new ArgumentException($"Argument '{text}' length must be less than {MaxLength}. Current length: {text.Length}");

        // в тексте меньшей длины вхождений гарантированно не будет
        if (text.Length < padLeft + padRight + 1)
            return 0;

        int counter = 0;
        for (int i = padLeft; i < text.Length - padRight; i++)
        {
            if (text[i] == main &&
                text[i - padLeft] == left &&
                text[i + padRight] == right)
            {
                counter++;
            }
        }

        return counter;
    }
}