using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_c__tutorial.Delegates.Delegate_Asynchronous_method_calls
{
    public class DelegateExample7
    {
        public static int requestCounter;
        public static ArrayList hostData = new ArrayList();
        public static StringCollection hostNames = new StringCollection();
        //string collecttion kiynneth arrayList ekkmai namuth meke store krnna puluwan strings withri

        public static void UpdateUserInterface()
        {
            //mekn wenne application ek thaama working on request kiyna ek pennanai
            Console.WriteLine($"{requestCounter} request remaining");
        }

        // The following method is called when each asynchronous operation completes.
        public static void ProcessDnsInformation(IAsyncResult result)
        {
            string hostName = (string)result.AsyncState;
            hostNames.Add(hostName);
            try
            {
                //get result
                IPHostEntry host = Dns.EndGetHostEntry(result);
                hostData.Add(host);
            }
            catch (SocketException e)
            {
                hostData.Add(e.Message);
            }
            finally 
            {
                Interlocked.Decrement(ref requestCounter);
            }
        }
    }
}
