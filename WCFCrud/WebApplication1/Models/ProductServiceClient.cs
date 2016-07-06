using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.ModelBinding;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace WebApplication1.Models
{
    public class ProductServiceClient
    {
        private string BASE_URL = "http://localhost:50930/ServiceProduct.svc/";
        public List<Product> findAll()
        {
            try
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString(BASE_URL + "findAll");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Product>>(json);

            }
            catch (Exception)
            {

                return null;
            }
        }
        public Product find(string id)
        {
            try
            {
                var webClient = new WebClient();
                string url = string.Format(BASE_URL + "find/{0}", id);
                var json = webClient.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<Product>(json);

            }
            catch (Exception)
            {

                return null;
            }
        }
        public bool create(Product product)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof
                    (Product));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, product);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(BASE_URL + "create", "POST", data);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Test(Product product)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof
                    (Product));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, product);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(BASE_URL + "create", "POST", data);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool edit(Product product)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof
                    (Product));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, product);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(BASE_URL + "edit", "PUT", data);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool delete(Product product)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof
                    (Product));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, product);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(BASE_URL + "delete", "DELETE", data);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}