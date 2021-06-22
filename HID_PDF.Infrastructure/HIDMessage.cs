using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HID_PDF.Infrastructure
{
    public class HIDMessage 
    {
        private String LastMessage;
        private List<String> ReadMessages;
        private static String InvalidOperationExceptionMessage = "Cannot compare binary and non-binary messages";
        public bool IsBinary { get; set; }
        public int MessageDelta { get; set; }
        public int MessageIndex { get; set; }
        public String IdleMessage { get; set; }
        public String RawMessage { get; set; }

        public HIDMessage()
        {
            ReadMessages = new List<String>();
            IsBinary = false;
            RawMessage = "";
        }

        public bool Equals(HIDMessage Compare)
        {
            if (IsBinary != Compare.IsBinary)
            {
                throw (new InvalidOperationException(InvalidOperationExceptionMessage));
            }
            if (IsBinary)
            {
                return (RawMessage.Equals(Compare.RawMessage));
            }
            else
            {
                return (MessageDelta == Compare.MessageDelta && MessageIndex == Compare.MessageIndex);
            }
        }

        public static bool Equals(HIDMessage Msg1, HIDMessage Msg2)
        {
            if (Msg1.IsBinary != Msg2.IsBinary)
            {
                throw (new InvalidOperationException(InvalidOperationExceptionMessage));
            }
            if (Msg1.IsBinary && Msg2.IsBinary)
            {
                return (Msg1.RawMessage.Equals(Msg2.RawMessage));
            }
            else
            {
                return (Msg1.MessageDelta == Msg2.MessageDelta && Msg1.MessageIndex == Msg2.MessageIndex);
            }
        }

        public bool IsChanged(String Message)
        {
            return (Message.Equals(LastMessage));
        }

        public void AddMessage(String Message)
        {
            if (!ReadMessages.Contains(Message))
            {
                ReadMessages.Add(Message);
            }
        }

        public HIDMessage ComputeMessage()
        {
            // Now go through the list of stuff we've read, figure out what's changed and how and somehow create an 
            // object that encapsulates that information so that we can put it in a configuration file.  Hah!
            // Let's try this idea.  
            /* Start with the Idle message, then
             * -For each string read:
             * -Split each string
             * -For each element in the resulting array (which will be 2 character hex):
             * -  Convert.toInt32(foo, 16);
             * -  Subtract the corresponding "Idle" value;
             * -  Add it to the respective "bucket"
             * -  Next
             * - When we're done, we'll have some possible states:
             * - The result = # of strings * value (at idle)
             *      this means that this value did not change.
             * - The result <> # of strings * value (at idle)
             *      - All the values are in one of two states
             *        means this is a binary value.  An "on" value is exact match
             *      - Values in more than 3 states
             *        means this is an analog.  An "on" value is one that is more than or less than idle.
             */
            var Message = new HIDMessage();
            var IdleArray = IdleMessage.Split('-');
            var IdleAccum = new int[IdleArray.Count()];
            var MsgAccum = new int[IdleArray.Count()];
            // If there's only one message, then there's no need to parse through it, just send it back.
            if (ReadMessages.Count == 1)
            {
                Message.IsBinary = true;
                Message.RawMessage = ReadMessages.First();
            }
            else
            {
                for (int i = 0; i < IdleArray.Count(); i++)
                {
                    IdleAccum[i] = Convert.ToInt32(IdleArray[i], 16);
                }
                foreach (var msg in ReadMessages)
                {
                    var MsgArray = msg.Split('-');
                    for (int i = 0; i < IdleArray.Count(); i++)
                    {
                        MsgAccum[i] += Convert.ToInt32(MsgArray[i], 16) - IdleAccum[i];
                    }
                }
                Message.IsBinary = false;
                for (int i = 0; i < IdleArray.Count(); i++)
                {
                    if (MsgAccum[i] > IdleAccum[i])
                    {
                        // Check to see if > is a multiple.
                        if (MsgAccum[i] == IdleAccum[i] * IdleAccum.Count())
                        {
                            // The ith element has changed but only when up
                            Message.IsBinary = true;
                            Message.RawMessage = i.ToString() + "th Element turned on";
                        }
                        else
                        {
                            Message.IsBinary = false;
                            Message.RawMessage = i.ToString() + "th Element went up";
                        }
                    }
                    else // MsgAccum < Idle
                    {
                        if (MsgAccum[i] == -1 * IdleAccum[i] * IdleAccum.Count())
                        {
                            // The ith element has changed but only when up
                            Message.IsBinary = true;
                            Message.RawMessage = i.ToString() + "th Element turned on";
                        }
                        else
                        {
                            Message.IsBinary = false;
                            Message.RawMessage = i.ToString() + "th Element went down";
                        }
                    }
                }
            }
            return (Message);
        }
    }
}
