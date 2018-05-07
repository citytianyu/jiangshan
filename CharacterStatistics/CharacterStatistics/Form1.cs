using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterStatistics
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.FileName == "")
                MessageBox.Show("No file has been selected.");
            else
            {
                if (currFilename.CompareTo(openFileDialog.FileName) != 0)
                {
                    // read all the content from the file
                    string fileContent = System.IO.File.ReadAllText(openFileDialog.FileName, Encoding.UTF8);
                    // split the text into volume
                    volumeContents = splitVolume(openFileDialog.FileName, fileContent);

                    currFilename = openFileDialog.FileName;
                }

                int fileNum = 1;
                foreach (string content in volumeContents)
                {
                    countChar(currFilename, content, fileNum.ToString());
                }

                MessageBox.Show("Done!");
            }
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            //MessageBox.Show(openFileDialog.FileName);
        }

        private List<string> splitVolume(string filename, string fileContent)
        {
            string keyWord = "第一章";

            List<string> subStrings = new List<string>();

            int index = fileContent.IndexOf(keyWord);

            int nextIndex = index + 3;
            do
            {
                nextIndex = fileContent.IndexOf(keyWord, index + 3);

                if (nextIndex == -1)
                    nextIndex = fileContent.Length;

                string subString = fileContent.Substring(index, nextIndex - index);

                subStrings.Add(subString);

                index = nextIndex;

            } while (nextIndex != -1 && nextIndex < fileContent.Length);

            return subStrings;
        }

        private void countChar(string filename, string fileContent, string fileIndex)
        {
            Dictionary<char, uint> table = new Dictionary<char, uint>();
            table.Clear();

            for (int i = 0; i < fileContent.Length; i++)
            {
                char curr = fileContent[i];
                uint num = 0;
                if (table.TryGetValue(curr, out num))
                {
                    num++;
                    table[curr] = num;
                }
                else
                {
                    table.Add(curr, 1);
                }
            }

            uint sum = 0;
            foreach (KeyValuePair<char, uint> pair in table)
            {
                sum += pair.Value;
            }

            var items = from pair in table
                        orderby pair.Value descending
                        select pair;

            string result = "";
            foreach (KeyValuePair<char, uint> pair in items)
            {
                if (pair.Key != ' ')
                {
                    float ratio = (float)pair.Value / (float)sum * 100.0f;
                    result += pair.Key + "  " + pair.Value.ToString() + " " + ratio.ToString() + "%\n";
                }
            }

            saveToFile(filename, result, "Result", fileIndex);
        }

        private void saveToFile(string filename, string result, string name, string num)
        {
            string resultFilename = filename;
            int lastSlashIdx = resultFilename.LastIndexOf('\\');
            resultFilename = resultFilename.Substring(0, lastSlashIdx + 1);
            //MessageBox.Show(resultFilename);
            resultFilename += name + num + ".txt";

            System.IO.File.WriteAllText(resultFilename, result);
        }

        List<string> volumeContents = null;
        string currFilename = "";

        Dictionary<string, int>[] MegaTable = new Dictionary<string, int>[1];
        Dictionary<string, int>[] AccTable = new Dictionary<string, int>[1];
        int[] Sums = new int[1];

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog.FileName == "")
                MessageBox.Show("No file has been selected.");
            else
            {
                if (currFilename.CompareTo(openFileDialog.FileName) != 0)
                {
                    // read all the content from the file
                    string fileContent = System.IO.File.ReadAllText(openFileDialog.FileName, Encoding.UTF8);
                    // split the text into volume
                    volumeContents = splitVolume(openFileDialog.FileName, fileContent);

                    currFilename = openFileDialog.FileName;
                }

                string result = "";
                for (int i = 0; i < volumeContents.Count; ++i)
                {
                    result += (i + 1).ToString() + " " + countDialogs(volumeContents[i]) + "\n";
                }

                saveToFile(currFilename, result, "dialogStats", "1");

                MessageBox.Show("Done!");
            }
        }

        private int countDialogs(string content)
        {
            int left = 0;
            int right = left;

            int sum = 0;
            left = content.IndexOf('“');

            do
            {
                int alterLeft = content.IndexOf('“', left + 1);
                right = content.IndexOf('”', left + 1);

                if (right == -1)
                    break;

                if (alterLeft < right)
                {
                    left = alterLeft;
                    continue;
                }

                sum += right - left - 1;
                left = content.IndexOf('“', right + 1);
            }
            while (left != -1 && left < content.Length);

            return sum;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog.FileName == "")
                MessageBox.Show("No file has been selected.");
            else
            {
                if (currFilename.CompareTo(openFileDialog.FileName) != 0)
                {
                    // read all the content from the file
                    string fileContent = System.IO.File.ReadAllText(openFileDialog.FileName, Encoding.UTF8);
                    // split the text into volume
                    volumeContents = splitVolume(openFileDialog.FileName, fileContent);

                    currFilename = openFileDialog.FileName;
                }

                string toReplace = "\r\n";

                for (int i = 0; i < volumeContents.Count; ++i)
                {
                    string temp = volumeContents[i].Replace(toReplace, " ");
                    saveToFile(currFilename, temp, "split\\volume", (i + 1).ToString());
                }

                MessageBox.Show("Done!");
            }
        }

        private void btnSelectPhraseFiles_Click(object sender, EventArgs e)
        {
            openFileDialogPhrase.ShowDialog();
        }

        private void btnAnalyzePhrase_Click(object sender, EventArgs e)
        {
            if (openFileDialogPhrase.FileNames.Length == 0)
            {
                MessageBox.Show("No Phrase file has been selected.");
                return;
            }

            string[] filenames = openFileDialogPhrase.FileNames;

            Dictionary<int, int> table = new Dictionary<int, int>();

            for (int i = 0; i < filenames.Length; i++)
            {
                int number = -1;
                int startIndex = filenames[i].LastIndexOf('\\') + 1;
                string substr = filenames[i].Substring(startIndex, filenames[i].LastIndexOf('.') - startIndex);
                if (int.TryParse(substr, out number))
                {
                    table.Add(number, i);
                }
            }

            var items = from pair in table
                        orderby pair.Key ascending
                        select pair;

  
            MegaTable = new Dictionary<string, int>[table.Count];
            AccTable = new Dictionary<string, int>[table.Count];
            Sums = new int[table.Count];

            int volumeIndex = 0;
            foreach (KeyValuePair<int, int> pair in items)
            {
                string fileContent = System.IO.File.ReadAllText(filenames[pair.Value], Encoding.UTF8);

                MegaTable[volumeIndex] = countPhrase(filenames[pair.Value], fileContent, pair.Key.ToString(), out Sums[volumeIndex]);

                accumulatePhrases(filenames[pair.Value], pair.Key.ToString(), volumeIndex - 1, volumeIndex);

                volumeIndex++;
            }

            MessageBox.Show("Done!");
        }

        private Dictionary<string, int> countPhrase(string filename, string content, string fileIndex, out int totalPhraseCount)
        {
            Dictionary<string, int> table = new Dictionary<string, int>();

            for (int p = 0; p < content.Length;)
            {
                if (content[p] == '\t')
                {
                    p++;
                    continue;
                }

                int q = p + 1;
                while (q < content.Length && content[q] != '\t')
                    q++;

                if (q >= content.Length)
                    break;

                string phrase = content.Substring(p, q - p);
                if (table.ContainsKey(phrase))
                    table[phrase]++;
                else
                    table.Add(phrase, 1);

                p = q + 1;
            }

            string result = "";

            var items = from pair in table
                        orderby pair.Value descending
                        select pair;

            int sum = 0;
            foreach (KeyValuePair<string, int> pair in items)
            {
                sum += pair.Value;
            }

            foreach (KeyValuePair<string, int> pair in items)
            {
                float ratio = (float)pair.Value / (float)sum * 100.0f;
                result += pair.Key + "\t" + pair.Value.ToString() + "\t" + ratio.ToString() + "%\n";
            }

            saveToFile(filename, result, "phraseStats", fileIndex);

            totalPhraseCount = sum;

            return table;
        }

        private void accumulatePhrases(string filename, string fileIndex, int prevAccTableIndex, int currTableIndex)
        {
            if (AccTable[currTableIndex] == null)
                AccTable[currTableIndex] = new Dictionary<string, int>();

            int sum = 0;
            if (currTableIndex == 0)
            {
                MegaTable[0].ToList().ForEach(x => AccTable[0].Add(x.Key, x.Value));
                sum = Sums[currTableIndex];
            }
            else
            {
                // copy prev to currAcc
                foreach (KeyValuePair<string, int> pair in AccTable[prevAccTableIndex])
                {
                    AccTable[currTableIndex].Add(pair.Key, pair.Value);
                }

                // accumulate
                foreach (KeyValuePair<string, int> pair in MegaTable[currTableIndex])
                {
                    if (AccTable[currTableIndex].ContainsKey(pair.Key))
                        AccTable[currTableIndex][pair.Key] += pair.Value;
                    else
                        AccTable[currTableIndex].Add(pair.Key, pair.Value);
                }

                for (int j = 0; j <= prevAccTableIndex; j++)
                    sum += Sums[j];
                sum += Sums[currTableIndex];
            }

            var items = from pair in AccTable[currTableIndex]
                        orderby pair.Value descending
                        select pair;

            string result = "";
            foreach (KeyValuePair<string, int> pair in items)
            {
                float ratio = (float)pair.Value / (float)sum * 100.0f;
                result += pair.Key + "\t" + pair.Value.ToString() + "\t" + ratio.ToString() + "%\n";
            }

            saveToFile(filename, result, "AccPhraseStats", fileIndex);
        }
    }
}
