using System;
using System.Net;
using System.IO;

// Example of a custom assembly.
// Compile as follows:
// csc /target:library [/out:desiredDLLName.dll] L17_MichaelDLL.cs


namespace MichaelDLL
{
    public class Michael
    {
        public string Lookup(string url)
        {
            // create a request for the url
            WebRequest request = WebRequest.Create(url);
            // if required by the server, set the credentials
            request.Credentials = CredentialCache.DefaultCredentials;
            // get the response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // display the status
            Console.WriteLine("Status of the web request is {0}", response.StatusDescription);
            // get the stream containing content returned by the server
            Stream dataStream = response.GetResponseStream();
            // open the sream using StreamReader, for easy access
            StreamReader reader = new StreamReader(dataStream);
            // read the content
            string responseFromServer = reader.ReadToEnd();

            // clean up the streams and the response
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;

        }
    }
}
