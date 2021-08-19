	public class Solution
	{
		public bool BackspaceCompare(string S, string T)
		{
			var sCurrent = S.Length - 1;
			var tCurrent = T.Length - 1;

			while (sCurrent >= 0 && tCurrent >= 0)
			{
				PeekNextIndex(S, ref sCurrent);
				PeekNextIndex(T, ref tCurrent);
                
				if (sCurrent < 0 || tCurrent < 0)
					return sCurrent == tCurrent;

				if (S[sCurrent] != T[tCurrent])
					return false;

				sCurrent--;
				tCurrent--;
			}
            
            PeekNextIndex(S, ref sCurrent);
			PeekNextIndex(T, ref tCurrent);

			return sCurrent == tCurrent;
		}


		private static void PeekNextIndex(string str, ref int current)
		{
			var skip = 0;

			while (current >= 0)
			{
				if (str[current] == '#')
				{
					skip++;
				}
				else
				{
					if (skip > 0)
						skip--;
					else
						return;
				}

				current--;
			}
		}
	}