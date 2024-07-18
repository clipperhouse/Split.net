// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// https://github.com/dotnet/runtime/blob/main/LICENSE.TXT

using System.Buffers;
using System.Diagnostics;

namespace Split;

// Avoid paying the init cost of all the SearchValues unless they are actually used.
internal static class SearchValuesStorage
{
    /// <summary>A <see cref="SearchValues{Char}"/> for all of the Unicode whitespace characters</summary>
    public static readonly SearchValues<char> WhiteSpaceChars =
        SearchValues.Create("\t\n\v\f\r\u0020\u0085\u00a0\u1680\u2000\u2001\u2002\u2003\u2004\u2005\u2006\u2007\u2008\u2009\u200a\u2028\u2029\u202f\u205f\u3000");

#if DEBUG
    static SearchValuesStorage()
    {
        SearchValues<char> sv = WhiteSpaceChars;
        for (int i = 0; i <= char.MaxValue; i++)
        {
            Debug.Assert(char.IsWhiteSpace((char)i) == sv.Contains((char)i));
        }
    }
#endif
}
