using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextJustification
{
    // from LeetCode
    // Runtime 107 ms - Beats 58.51% of users with C#

    public class Solution
    {
        int max = 0;
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            // algorithm
            // walk the array adding letter count and space for each word until
            // maxWidth is reached or exceeded.
            // Reached - repeat for next words in array
            // exceeded - back off and pad. Then repeat.

            // Pad algorithm - starting at first word, add space and check length.
            // If not maxWidth not reached on after space adde between last 2 words
            // repeat from first word.
            // when maxWidth reached padding is done
            List<string> textOut = new System.Collections.Generic.List<string>();

            string line = new string("");
            max = maxWidth;

            foreach (string word in words)
            {
                if (line.Length + word.Length == maxWidth)
                {
                    // we have a complete line, nothing more to do
                    textOut.Add(line + word);
                    line = "";
                }
                else if (line.Length + word.Length < maxWidth)
                {
                    // add this word and then see if the next word fits
                    line = line + word + " ";
                }
                else
                {
                    // if space was appended, strip and insert spaces between words
                    if (line[line.Length - 1] == ' ')
                    {
                        line = line.Remove(line.Length - 1);
                    }
                    textOut.Add(AddPadding(line));
                    
                    if (word.Length < maxWidth)
                    {
                        line = word + " ";
                    }
                    else
                    {
                        //last word might fit a line completely, so no space
                        line = word;
                    }
                    
                }
            }
            if (line.Length > 0)
            {
                line = line.PadRight(maxWidth);
                textOut.Add(line);
            }
            return textOut;
        }

        private string AddPadding(string line)
        {
            int start = 0;
            int index = 0;
            bool done = false;
            while (!done)
            {
                if (line.Length == max)
                {
                    done = true;
                }
                else
                {
                    index = line.IndexOf(' ', start);
                    if (index < 0)
                    {
                        if(start == 0)
                        {
                            // one word on this line, pad and done
                            line = line.PadRight(max);
                            break;
                        }
                        start = 0;
                        continue;
                    }
                    else
                    {
                        line = line.Insert(index, " ");
                        while((index <= line.Length) && (line.ElementAtOrDefault<char>(index) == ' '))
                        {
                            // walk past inserted spaces to next word break to insert a space
                            index++;
                        }
                        start = index;
                        if (start == line.Length)
                        {
                            // have inserted spaces between all words, might be done might need to repeat
                            start = 0;
                        }
                    }
                }
            }
            return line;
        }
    }
}
