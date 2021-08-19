public class Solution {
    public string MinWindow(string S, string T) {
        if(S == T)
            return S;
        
        // optimization
        if(T.Length == 1){
            for (int i = 0; i < S.Length; i++)
		    {
                if(S[i] == T[0])
                    return T;
            }
            
            return "";
        }
        
        int c = 0;

		int start = -1;
		int len = -1;

		for (int i = 0; i < S.Length; i++)
		{
		    // go from left to right , to find the end index
			if (S[i] == T[c])
			{
				c++;
			}

            // found a match
			if (c == T.Length)
			{
			     //go from right to left , to find the  start index
				int d = i;
				while(c > 0)
				{
					if (T[c - 1] == S[d])
					{
						c--;
					}

					d--;
				}

				if (len == -1 || i - d < len)
				{
					len = i - d;
					start = d + 1;
				}
                
				//reset the new search index to the old start position
                i = d + 1;
			}
		}

		if (len == -1) return "";
		return S.Substring(start , len);
    }
}