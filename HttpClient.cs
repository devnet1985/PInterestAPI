using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PInterestClient
{
    class HttpClient
    {

        public string authorizationHeader = string.Empty;
        public JObject GetData(string url, string httpMethod, string accesstoken)
        {
            JObject result = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader streamReader = null;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                if (httpMethod.Equals("GET", StringComparison.CurrentCultureIgnoreCase))
                {
                    request.Method = "GET";
                    //string accesstoken1 = "AqHNYBbHeAFnaAOd97PShi831iD5FUujcfAxdodFKIHwX2A2ews8QDAAAZkdRSiCys1APkYAAAAA";
                    request.Headers.Add("Authorization", "Bearer "+accesstoken);
                }
                response = (HttpWebResponse)request.GetResponse();

                streamReader = new StreamReader(response.GetResponseStream());
                // string responseText = streamReader.ReadToEnd();

                result = JObject.Parse(streamReader.ReadToEnd());
                streamReader.Close();
                result.Add(new JProperty("StatusCode", (int)response.StatusCode));


            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;
                streamReader = new StreamReader(e.Response.GetResponseStream());

                result = JObject.Parse(streamReader.ReadToEnd());
                streamReader.Close();
                result.Add(new JProperty("StatusCode", (int)response.StatusCode));
            }
            finally
            {
                request = null;
                response = null;
            }
            return result;
        }
        public JObject PostData(string url, string httpMethod, string board, string accesstoken)
        {
            JObject result = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader streamReader = null;
            StreamWriter streamWriter = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                if (httpMethod.Equals("POST", StringComparison.CurrentCultureIgnoreCase))
                {

                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.Headers.Add("authorization", "Bearer "+accesstoken);
                    streamWriter = new StreamWriter(request.GetRequestStream());
                    streamWriter.Write(board);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                response = (HttpWebResponse)request.GetResponse();
                streamReader = new StreamReader(response.GetResponseStream());
                result = JObject.Parse(streamReader.ReadToEnd());

                streamReader.Close();
                result.Add(new JProperty("StatusCode", (int)response.StatusCode));
            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;
                streamReader = new StreamReader(e.Response.GetResponseStream());
                result = JObject.Parse(streamReader.ReadToEnd());
                streamReader.Close();
                
                result.Add(new JProperty("StatusCode", (int)response.StatusCode));
                result.Add(new JProperty("StatusDescription", response.StatusDescription));
               
            }
            finally
            {
                request = null;
                response = null;
            }
            return result;
        }
        public JObject DeleteData(string url, string httpMethod, string accesstoken)
        {
            JObject result = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader streamReader = null;
            StreamWriter streamWriter = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                if (httpMethod.Equals("DELETE", StringComparison.CurrentCultureIgnoreCase))
                {
                    request.Method = "DELETE";
                    request.Headers.Add("authorization", "Bearer "+accesstoken);
                  
                }
                response = (HttpWebResponse)request.GetResponse();
                streamReader = new StreamReader(response.GetResponseStream());
                result = JObject.Parse(streamReader.ReadToEnd());
                result.Add(new JProperty("StatusCode", response.StatusDescription.ToString()));
            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;
                //GenericResult onjResult = new GenericResult();
                //onjResult.StatusCode = ((int)response.StatusCode).ToString();
                //onjResult.Message = response.StatusDescription;
                streamReader = new StreamReader(response.GetResponseStream());
                result = JObject.Parse(streamReader.ReadToEnd());
                //string s = JsonConvert.SerializeObject(response);
                //result = JObject.Parse(s);
              result.Add(new JProperty("data", response.StatusDescription.ToString()));
                //  result.Add(new JProperty("StatusCode", response.StatusCode));
            }
            finally
            {
                request = null;
                response = null;
            }
            return result;


        }
        public JObject UpdateData(string url, string httpMethod, string payload, string accesstoken)
        {
            JObject result = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader streamReader = null;
            StreamWriter streamWriter = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                if (httpMethod.Equals("PATCH", StringComparison.CurrentCultureIgnoreCase))
                {
                    request.Method = "PATCH";
                    request.ContentType = "application/json";
                    request.Headers.Add("authorization", "Bearer "+ accesstoken);
                    streamWriter = new StreamWriter(request.GetRequestStream());
                    streamWriter.Write(payload);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                response = (HttpWebResponse)request.GetResponse();
                streamReader = new StreamReader(response.GetResponseStream());
                result = JObject.Parse(streamReader.ReadToEnd());
                streamReader.Close();
                result.Add(new JProperty("StatusCode", (int)response.StatusCode));
            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;

                //   streamReader = new StreamReader(e.Response.GetResponseStream());
              
                result = JObject.Parse(response.ToString());


            }
            finally
            {
                request = null;
                response = null;
            }
            return result;
        }
        public JObject PutData(string url, string httpMethod, string payload, string accesstoken)
        {
            JObject result = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader streamReader = null;
            StreamWriter streamWriter = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                if (httpMethod.Equals("PUT", StringComparison.CurrentCultureIgnoreCase))
                {
                    request.Method = "PUT";
                    request.ContentType = "application/json";
                    request.Headers.Add("authorization", "Bearer " + accesstoken);
                    streamWriter = new StreamWriter(request.GetRequestStream());
                    streamWriter.Write(payload);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                response = (HttpWebResponse)request.GetResponse();
                streamReader = new StreamReader(response.GetResponseStream());
                result = JObject.Parse(streamReader.ReadToEnd());
                streamReader.Close();
                result.Add(new JProperty("StatusCode", (int)response.StatusCode));
            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;

                //   streamReader = new StreamReader(e.Response.GetResponseStream());

                result = JObject.Parse(response.ToString());


            }
            finally
            {
                request = null;
                response = null;
            }
            return result;
        }

    }
}
