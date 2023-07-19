using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Iggy_SDK.Extensions;

internal static class Extensions
{
   internal static string ToSnakeCase(this string input)
   {
       Debug.Assert(!string.IsNullOrEmpty(input));
       if (CountUppercaseLetters(input) == 0)
	       return input.ToLower();
       
       var len = input.Length + CountUppercaseLetters(input) - 1;
       return string.Create(len, input, (span, value) =>
       {
	      value.AsSpan().CopyTo(span);
	      span[0] = char.ToLower(span[0]);
	      
	      for (int i = 0; i < len; ++i)
	      {
		      if (char.IsUpper(span[i]))
		      {
			      span[i] = char.ToLower(span[i]);
			      span[i..].ShiftSliceRight();
			      span[i] = '_';
		      }
	      }
       });
   }
   
   internal static UInt128 ToUInt128(this Guid g)
   {
	   var array = g.ToByteArray();
	   var hi = BitConverter.ToUInt64(array, 8);
	   var lo = BitConverter.ToUInt64(array, 0);
	   return new UInt128(hi, lo);
   }
   internal static byte[] GetBytesFromUInt128(this UInt128 value)
   {

	   Span<byte> result = stackalloc byte[16];
	   var span = MemoryMarshal.Cast<UInt128, byte>(MemoryMarshal.CreateReadOnlySpan(ref value, 1));
	   for (int i = 0; i < 16; i++)
	   {
		   result[i] = span[i];
	   }
	   return result.ToArray();
   }

   private static int CountUppercaseLetters(string input)
   {
	   return input.Count(char.IsUpper);
   }
   private static void ShiftSliceRight(this Span<char> slice)
   {
	   for (int i = slice.Length - 2; i >= 0; i--)
	   {
		   slice[i + 1] = slice[i];
	   }
   }
}