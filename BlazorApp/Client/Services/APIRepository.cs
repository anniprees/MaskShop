using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MaskShop.Domain.Common;
using Newtonsoft.Json;

namespace BlazorApp.Client.Services
{
    //TODO: Implement IRepository ja GetById
    public class APIRepository<TDomain> : ICrudMethods<TDomain> where TDomain : class
    {
        protected string ControllerName;
        protected string PrimaryKeyName;
        HttpClient HttpClient;

        public APIRepository(HttpClient http, string controllerName, string primaryKeyName)
        {
            HttpClient = http;
            ControllerName = controllerName;
            PrimaryKeyName = primaryKeyName;
        }


        public async Task<List<TDomain>> Get()
        {
            try
            {
                var result = await HttpClient.GetAsync(ControllerName);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<APIListOfEntityResponse<TDomain>>(responseBody);
                if (response.Success)
                    return response.Data;
                else
                    return new List<TDomain>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TDomain> Get(string id)
        {
            try
            {
                var arg = WebUtility.HtmlEncode(id.ToString());
                var url = ControllerName + "/" + arg;
                var result = await HttpClient.GetAsync(url);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<APIEntityResponse<TDomain>>(responseBody);
                if (response.Success)
                    return response.Data;
                else
                    return null;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

        public async Task Add(TDomain entity)
        {
            //try
            //{
            //    var result = await HttpClient.PostAsJsonAsync(ControllerName, entity);
            //    result.EnsureSuccessStatusCode();
            //    string responseBody = await result.Content.ReadAsStringAsync();
            //    var response = JsonConvert.DeserializeObject<APIEntityResponse<TDomain>>(responseBody);
            //    if (response.Success)
            //        return response.Data;
            //    else
            //        return;
            //}
            //catch (Exception ex)
            //{
            //    return ;
            //}
        }

        public async Task Update(TDomain entityToUpdate)
        {
            //try
            //{
            //    var result = await HttpClient.PutAsJsonAsync(ControllerName, entityToUpdate);
            //    result.EnsureSuccessStatusCode();
            //    string responseBody = await result.Content.ReadAsStringAsync();
            //    var response = JsonConvert.DeserializeObject<APIEntityResponse<TDomain>>(responseBody);
            //    if (response.Success)
            //        return response.Data;
            //    else
            //        return;
            //}
            //catch (Exception ex)
            //{
            //    return ;
            //}
        }

        public async Task<bool> Delete(TDomain entityToDelete)
        {
            try
            {
                var value = entityToDelete.GetType()
                    .GetProperty(PrimaryKeyName)
                    .GetValue(entityToDelete, null)
                    .ToString();

                var arg = WebUtility.HtmlEncode(value);
                var url = ControllerName + "/" + arg;
                var result = await HttpClient.DeleteAsync(url);
                result.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task Delete(string id)
        {
            //TODO: implement Try Catch
            var url = ControllerName + "/" + WebUtility.HtmlEncode(id.ToString());
            var result = await HttpClient.DeleteAsync(url);
            result.EnsureSuccessStatusCode();
        }
    }
}