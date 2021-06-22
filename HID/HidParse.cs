using System;
using System.Collections.Generic;
using System.Linq;

namespace HID
{
    public class HidParse
    {
        public String DeviceName { get; set; }
        private String Idle { get; set;}
        private String[] IdleArray { get; set; } // This should get computed when Idle gets set, but for now we'll do it later.
        private IDictionary<String, String>[] MessageTable { get; set; }
        public char Delimiter { get; set; }

        // Accept a string.
        // Compare it to idle
        // Return null if equal.
        // Split the string
        // Compare arrays, collect location(s) of difference(s)
        // Compare the change at the location with the thing to see what the change meant.
        // I think we'll have an array of Dictionary objects. Dictionary<String, String>, key = USB message, value = action
        // Supply the message that's different and the index of the difference.  
        // Use the index to find the dictionary and then the different value to find the message.

        public HidParse()
        {
            Delimiter = '-';
        }

        public HidParse(String Delimiter)
        {
            this.Delimiter = Delimiter[0];
        }

        public void SetIdleMessage(String Message)
        {
            this.Idle = Message;
            this.IdleArray = Message.Split(Delimiter);
        }

        public void LoadMessageTable()
        {
            this.MessageTable = new IDictionary<string, string>[IdleArray.Length];
            for(int i = 0; i < MessageTable.Length; i++)
            {
                MessageTable[i] = new Dictionary<String, String>();
            }
            var Messages = ReadMessagesFromConfigFile();
            foreach (var Message in Messages)
            {
                var MessageElements = Message.Split(':');  //MessageElements[0] = Hid text, MessageElements[1] = what the action is.
                var MessageDifferences = ComputeDifferences(MessageElements[0]); // Returns an array of the inde(x/ces) of the element(s) that are different.
                var MessageAtoms = MessageElements[0].Split(Delimiter); // MessageAtoms[] is each piece of the Hid message.
                foreach (var Difference in MessageDifferences)
                {
                    MessageTable[Difference].Add(MessageAtoms[Difference], MessageElements[1]);
                }
            }
            // Read the config file
        }

        public IEnumerable<String> Parse(String Message)
        {
            IList<String> rc = new List<String>();
            var MessageDifferences = ComputeDifferences(Message);
            if (MessageDifferences.Count() > 0)
            {
                foreach (var Difference in MessageDifferences)
                {
                    var MessageAtoms = Message.Split(Delimiter);
                    rc.Add(MessageTable[Difference].TryGetValue(MessageAtoms[Difference], out String EventMessage) ? EventMessage : "");
                }
            }
            return rc.Distinct();  // There may be a single message that involves multiple atoms changing.
        }

        private IList<String> ReadMessagesFromConfigFile()
        {
            // This will be replaced by a read from the config file.
            List<String> Messages = new List<String> { "00-02-00:next", "00-04-00:prev" };
            return (Messages);
        }

        public IEnumerable<int> ComputeDifferences(String Message)
        {
            IList<int> Differences = new List<int>();
            var MessageArray = Message.Split(Delimiter);
            for (int i = 0; i < IdleArray.Length; i++)
            {
                if (MessageArray[i] != IdleArray[i])
                {
                    Differences.Add(i);
                }
            }
            return Differences.ToList();
        }

    }
}
