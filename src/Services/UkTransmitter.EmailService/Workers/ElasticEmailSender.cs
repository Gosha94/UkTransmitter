using UkTransmitter.Core.Contracts;
using UkTransmitter.EmailModule.Models;
using UkTransmitter.EmailModule.Contracts;
using System;
using System.IO;
using System.Collections.Specialized;
using System.Net.Http;
using System.Collections.Generic;

namespace UkTransmitter.EmailModule.Workers
{

    /// <summary>
    /// Класс описывает Отправлятор Писем при помощи Elastic Email API
    /// </summary>
    internal sealed class ElasticEmailSender : IEmailSender
    {
        #region Private Fields
        
        private string _attachmentPath;
        private CommonEmailSettings _emailSettings;
        private ElasticApiSettings _apiSettings;

        private Stream[] _attachmentStreams;
        private string[] _attachmentNamesArray;

        #endregion

        #region Public Properties

        #endregion

        #region Constructor

        public ElasticEmailSender(string attachmentPath, CommonEmailSettings emailSettings, ElasticApiSettings apiSettings)
        {
            this._attachmentPath = attachmentPath;
            this._emailSettings = emailSettings;
            this._apiSettings = apiSettings;
        }

        #endregion

        #region Public API

        public bool SendEmailMessage()
        {

            List<NameValueCollection> httpBodiesList = new List<NameValueCollection>()
            {
                PrepareHttpBodyForSend(false),
                PrepareHttpBodyForSend(true)
            };

            httpBodiesList.ForEach(httpBody =>
            {
                PrepareNewAttachmentForSend("Attachment.doc");
                SendWithAttach(httpBody, this._attachmentStreams, this._attachmentNamesArray);
            });

            return true;
        }

        #endregion

        #region Private Methods
        
        /// <summary>
        /// Метод создает файловый поток с данными файла-вложения на отправку
        /// </summary>
        private void PrepareNewAttachmentForSend(string fileName)
        {
            var attachPath = this._attachmentPath;
            var fileStream = File.OpenRead(attachPath);

            this._attachmentStreams = new Stream[] { fileStream };
            this._attachmentNamesArray = new string[] { fileName };
        }

        private NameValueCollection PrepareHttpBodyForSend(bool isSendingToCarbonCopy)
        {
            NameValueCollection emailDataList = new NameValueCollection();
   
            var apiKey = this._apiSettings.ApiKey;

            emailDataList.Add("apikey", apiKey);
            emailDataList.Add("from", this._emailSettings.From);
            emailDataList.Add("fromName", "Георгий");

            if (isSendingToCarbonCopy)
            {
                emailDataList.Add("to", this._emailSettings.CopyTo);
            }
            else
            {
                emailDataList.Add("to", this._emailSettings.MainTo);
            }

            emailDataList.Add("subject", this._emailSettings.Subject);
            emailDataList.Add("bodyText", this._emailSettings.Body);
            //emailDataList.Add("bodyHtml", "<h1>Html Body</h1>");
            emailDataList.Add("isTransactional", "true");
            
            return emailDataList;
        }

        private bool SendWithAttach
        (
            NameValueCollection httpBodyDict, 
            Stream[] paramFileStream = null,
            string[] filenames = null
        )
        {
            using (var client = new HttpClient())
            {
                using (var formData = new MultipartFormDataContent())
                {
                    foreach (string key in httpBodyDict)
                    {
                        HttpContent stringContent = new StringContent(httpBodyDict[key]);
                        formData.Add(stringContent, key);
                    }

                    for (int i = 0; i < paramFileStream.Length; i++)
                    {
                        HttpContent fileStreamContent = new StreamContent(paramFileStream[i]);
                        formData.Add(fileStreamContent, "file" + i, filenames[i]);
                    }

                    var response = client.PostAsync(this._apiSettings.ApiUri, formData).Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.Content.ReadAsStringAsync().Result);
                    }

                    //return response.Content.ReadAsStringAsync().Result;
                    return response.IsSuccessStatusCode;
                }
            }
                
            }

        #endregion

    }
}